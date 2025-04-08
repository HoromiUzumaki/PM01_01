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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        private HappyToothEntities db = new HappyToothEntities();
        private users _currentUser;

        public ProfilePage()
        {
            InitializeComponent();
            LoadCurrentUser();
        }

        private void LoadCurrentUser()
        {
            
            _currentUser = db.users.FirstOrDefault(u => u.username == "admin");

            if (_currentUser != null)
            {
                lblUsername.Content = _currentUser.username;
            }
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewUsername.Text) &&
                string.IsNullOrEmpty(txtNewPassword.Password) &&
                string.IsNullOrEmpty(txtConfirmPassword.Password))
            {
                MessageBox.Show("Нет изменений для сохранения", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtNewUsername.Text))
            {
                // Проверяем, не занят ли новый логин
                if (db.users.Any(u => u.username == txtNewUsername.Text && u.user_id != _currentUser.user_id))
                {
                    MessageBox.Show("Этот логин уже занят", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _currentUser.username = txtNewUsername.Text;
            }

            if (!string.IsNullOrEmpty(txtNewPassword.Password))
            {
                if (txtNewPassword.Password != txtConfirmPassword.Password)
                {
                    MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (txtNewPassword.Password.Length < 6)
                {
                    MessageBox.Show("Пароль должен содержать не менее 6 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _currentUser.password_hash = txtNewPassword.Password;
            }

            db.SaveChanges();
            MessageBox.Show("Изменения сохранены", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            LoadCurrentUser();
        }
    }
}
