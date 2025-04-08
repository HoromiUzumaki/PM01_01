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
    /// Логика взаимодействия для DoctorEditDialog.xaml
    /// </summary>
    public partial class DoctorEditDialog : Window
    {
        public DoctorEditDialog()
        {
            InitializeComponent();
        }

        public string FullName
        {
            get => txtFullName.Text;
            set => txtFullName.Text = value;
        }

        public string Specialization
        {
            get => txtSpecialization.Text;
            set => txtSpecialization.Text = value;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FullName))
            {
                MessageBox.Show("ФИО врача обязательно для заполнения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(Specialization))
            {
                MessageBox.Show("Специализация врача обязательна для заполнения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
