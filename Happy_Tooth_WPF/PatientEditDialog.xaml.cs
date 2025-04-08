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
    /// Логика взаимодействия для PatientEditDialog.xaml
    /// </summary>
    public partial class PatientEditDialog : Window
    {
        public PatientEditDialog()
        {
            InitializeComponent();
        }
        public string FullName
        {
            get => txtFullName.Text;
            set => txtFullName.Text = value;
        }

        public string Phone
        {
            get => txtPhone.Text;
            set => txtPhone.Text = value;
        }

        public string Email
        {
            get => txtEmail.Text;
            set => txtEmail.Text = value;
        }

        public DateTime? BirthDate
        {
            get => dpBirthDate.SelectedDate;
            set => dpBirthDate.SelectedDate = value;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FullName))
            {
                MessageBox.Show("ФИО пациента обязательно для заполнения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

