using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Happy_Tooth_WPF
{
    public partial class AppointmentsPage : Page
    {
        private HappyToothEntities _context = new HappyToothEntities();

        public AppointmentsPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            _context.appointments
                .Include(a => a.patients)
                .Include(a => a.doctors)
                .Load();

            appointmentsGrid.ItemsSource = _context.appointments.Local;

            // Заполняем фильтры
            _context.doctors.Load();
            cmbDoctorFilter.ItemsSource = _context.doctors.Local;

            _context.patients.Load();
            cmbPatientFilter.ItemsSource = _context.patients.Local;

            cmbStatusFilter.SelectedIndex = 0;
        }

        private void FilterAppointments_Click(object sender, RoutedEventArgs e)
        {
            var query = _context.appointments
                .Include(a => a.patients)
                .Include(a => a.doctors)
                .AsQueryable();

            if (cmbDoctorFilter.SelectedItem is doctors selectedDoctor)
            {
                query = query.Where(a => a.doctor_id == selectedDoctor.doctor_id);
            }

            if (cmbPatientFilter.SelectedItem is patients selectedPatient)
            {
                query = query.Where(a => a.patient_id == selectedPatient.patient_id);
            }

            if (dpDateFilter.SelectedDate.HasValue)
            {
                var selectedDate = dpDateFilter.SelectedDate.Value;
                query = query.Where(a => DbFunctions.TruncateTime(a.appointment_time) == selectedDate.Date);
            }

            if (cmbStatusFilter.SelectedItem is ComboBoxItem selectedStatus && selectedStatus.Content.ToString() != "Все статусы")
            {
                query = query.Where(a => a.status == selectedStatus.Content.ToString().ToLower());
            }

            appointmentsGrid.ItemsSource = query.ToList();
        }

        private void ResetFilters_Click(object sender, RoutedEventArgs e)
        {
            cmbDoctorFilter.SelectedItem = null;
            cmbPatientFilter.SelectedItem = null;
            dpDateFilter.SelectedDate = null;
            cmbStatusFilter.SelectedIndex = 0;
            LoadData();
        }

        private void EditAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (appointmentsGrid.SelectedItem is appointments selectedAppointment)
            {
                // Создаем диалоговое окно для изменения статуса
                var dialog = new ChangeStatusDialog(selectedAppointment.status);

                if (dialog.ShowDialog() == true)
                {
                    try
                    {
                        // Получаем выбранный статус из диалога
                        string newStatus = dialog.SelectedStatus.ToLower();

                        // Проверяем, изменился ли статус
                        if (selectedAppointment.status != newStatus)
                        {
                            // Обновляем статус и сохраняем изменения
                            selectedAppointment.status = newStatus;
                            _context.SaveChanges();

                            // Обновляем отображение
                            appointmentsGrid.Items.Refresh();

                            MessageBox.Show("Статус записи успешно изменен", "Успех",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при изменении статуса: {ex.Message}", "Ошибка",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                        _context.Entry(selectedAppointment).Reload();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для изменения статуса", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (appointmentsGrid.SelectedItem is appointments selectedAppointment)
            {
                var result = MessageBox.Show(
                    $"Удалить запись пациента {selectedAppointment.patients?.full_name} на {selectedAppointment.appointment_time:dd.MM.yyyy HH:mm}?",
                    "Подтверждение удаления",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _context.appointments.Remove(selectedAppointment);
                    _context.SaveChanges();
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void appointmentsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Можно добавить логику при выборе записи
        }
    }
}