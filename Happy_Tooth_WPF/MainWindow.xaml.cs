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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HappyToothEntities db = new HappyToothEntities();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            var user = db.users.FirstOrDefault(u => u.username == username && u.password_hash == password);

            if (user != null && user.role == "admin")
            {
                MenuWindow mainWindow = new MenuWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                lblErrorMessage.Content = "Неверный логин или пароль";
                lblErrorMessage.Visibility = Visibility.Visible;
            }
        }
    }
}

