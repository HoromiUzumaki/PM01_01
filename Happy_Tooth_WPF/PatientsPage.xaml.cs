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
    /// Логика взаимодействия для PatientsPage.xaml
    /// </summary>
    public partial class PatientsPage : Page
    {
        private HappyToothEntities db = new HappyToothEntities();
        public PatientsPage()
        {
            InitializeComponent();
            LoadPatients();
        }
        private void LoadPatients()
        {
            patientsGrid.ItemsSource = db.patients.ToList();
        }

        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new PatientEditDialog();
            if (dialog.ShowDialog() == true)
            {
                var newPatient = new patients
                {
                    full_name = dialog.FullName,
                    phone = dialog.Phone,
                    email = dialog.Email,
                    birth_date = dialog.BirthDate
                };

                db.patients.Add(newPatient);
                db.SaveChanges();
                LoadPatients();
            }
        }

        private void EditPatient_Click(object sender, RoutedEventArgs e)
        {
            if (patientsGrid.SelectedItem is patients selectedPatient)
            {
                var dialog = new PatientEditDialog
                {
                    FullName = selectedPatient.full_name,
                    Phone = selectedPatient.phone,
                    Email = selectedPatient.email,
                    BirthDate = selectedPatient.birth_date
                };

                if (dialog.ShowDialog() == true)
                {
                    selectedPatient.full_name = dialog.FullName;
                    selectedPatient.phone = dialog.Phone;
                    selectedPatient.email = dialog.Email;
                    selectedPatient.birth_date = dialog.BirthDate;

                    db.SaveChanges();
                    LoadPatients();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите пациента для редактирования.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeletePatient_Click(object sender, RoutedEventArgs e)
        {
            if (patientsGrid.SelectedItem is patients selectedPatient)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите удалить пациента {selectedPatient.full_name}?",
                    "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    db.patients.Remove(selectedPatient);
                    db.SaveChanges();
                    LoadPatients();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите пациента для удаления.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void patientsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Можно добавить дополнительную логику при выборе пациента
        }
    }
}

