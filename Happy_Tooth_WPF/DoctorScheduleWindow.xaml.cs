using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Happy_Tooth_WPF
{
    /// <summary>
    /// Логика взаимодействия для DoctorScheduleWindow.xaml
    /// </summary>
    public partial class DoctorScheduleWindow : Window
    {
        private HappyToothEntities db = new HappyToothEntities();
        private doctors _doctor;

        public DoctorScheduleWindow(doctors doctor)
        {
            InitializeComponent();
            _doctor = doctor;
            lblDoctorName.Content = doctor.full_name;
            LoadSchedule();
        }

        private void LoadSchedule()
        {
            scheduleGrid.ItemsSource = db.doctor_schedule
                .Where(s => s.doctor_id == _doctor.doctor_id)
                .OrderBy(s => s.day_of_week)
                .ToList();
        }

        private void AddSchedule_Click(object sender, RoutedEventArgs e)
        {
            if (cmbDayOfWeek.SelectedItem == null)
            {
                MessageBox.Show("Выберите день недели", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!TimeSpan.TryParse(txtStartTime.Text, out TimeSpan startTime))
            {
                MessageBox.Show("Некорректное время начала", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!TimeSpan.TryParse(txtEndTime.Text, out TimeSpan endTime))
            {
                MessageBox.Show("Некорректное время окончания", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (startTime >= endTime)
            {
                MessageBox.Show("Время начала должно быть раньше времени окончания", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string dayOfWeek = (cmbDayOfWeek.SelectedItem as ComboBoxItem).Content.ToString();

            // Проверяем, есть ли уже расписание на этот день
            var existingSchedule = db.doctor_schedule
                .FirstOrDefault(s => s.doctor_id == _doctor.doctor_id && s.day_of_week == dayOfWeek);

            if (existingSchedule != null)
            {
                MessageBox.Show("Расписание на этот день уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var newSchedule = new doctor_schedule
            {
                doctor_id = _doctor.doctor_id,
                day_of_week = dayOfWeek,
                start_time = startTime,
                end_time = endTime
            };

            db.doctor_schedule.Add(newSchedule);
            db.SaveChanges();
            LoadSchedule();
        }

        private void DeleteSchedule_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Tag is int scheduleId)
            {
                var scheduleToDelete = db.doctor_schedule.Find(scheduleId);
                if (scheduleToDelete != null)
                {
                    db.doctor_schedule.Remove(scheduleToDelete);
                    db.SaveChanges();
                    LoadSchedule();
                }
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
