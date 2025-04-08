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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Happy_Tooth_WPF
{
    /// <summary>
    /// Логика взаимодействия для DoctorsPage.xaml
    /// </summary>
    public partial class DoctorsPage : Page
    {
        private HappyToothEntities db = new HappyToothEntities();

        public DoctorsPage()
        {
            InitializeComponent();
            LoadDoctors();
        }

        private void LoadDoctors()
        {
            doctorsGrid.ItemsSource = db.doctors.ToList();
        }

        private void AddDoctor_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new DoctorEditDialog();
            if (dialog.ShowDialog() == true)
            {
                var newDoctor = new doctors
                {
                    full_name = dialog.FullName,
                    specialization = dialog.Specialization
                };

                db.doctors.Add(newDoctor);
                db.SaveChanges();
                LoadDoctors();
            }
        }

        private void EditDoctor_Click(object sender, RoutedEventArgs e)
        {
            if (doctorsGrid.SelectedItem is doctors selectedDoctor)
            {
                var dialog = new DoctorEditDialog
                {
                    FullName = selectedDoctor.full_name,
                    Specialization = selectedDoctor.specialization
                };

                if (dialog.ShowDialog() == true)
                {
                    selectedDoctor.full_name = dialog.FullName;
                    selectedDoctor.specialization = dialog.Specialization;

                    db.SaveChanges();
                    LoadDoctors();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите врача для редактирования.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteDoctor_Click(object sender, RoutedEventArgs e)
        {
            if (doctorsGrid.SelectedItem is doctors selectedDoctor)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите удалить врача {selectedDoctor.full_name}?",
                    "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    db.doctors.Remove(selectedDoctor);
                    db.SaveChanges();
                    LoadDoctors();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите врача для удаления.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ManageSchedule_Click(object sender, RoutedEventArgs e)
        {
            if (doctorsGrid.SelectedItem is doctors selectedDoctor)
            {
                var scheduleWindow = new DoctorScheduleWindow(selectedDoctor);
                scheduleWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите врача для управления расписанием.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void doctorsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Дополнительная логика при выборе врача
        }
    }
}
