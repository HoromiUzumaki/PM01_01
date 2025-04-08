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
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new PatientsPage());
        }
        private void btnPatients_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PatientsPage());
        }

        private void btnDoctors_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new DoctorsPage());
        }

        private void btnReports_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ReportsPage());
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProfilePage());
        }
        private void btnAppointments_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AppointmentsPage());
        }

        private void btnVisits_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new VisitsPage());
        }
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new MainWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}

