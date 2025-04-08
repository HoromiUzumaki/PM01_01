using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Happy_tooth_Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        private readonly DatabaseContext _dbContext;

        public RegistrationPage()
        {
            InitializeComponent();
            _dbContext = App.Database;
            birthDatePicker.Date = DateTime.Now.AddYears(-18);
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameEntry.Text) ||
                string.IsNullOrWhiteSpace(passwordEntry.Text) ||
                string.IsNullOrWhiteSpace(fullNameEntry.Text) ||
                string.IsNullOrWhiteSpace(phoneEntry.Text))
            {
                await DisplayAlert("Ошибка", "Заполните обязательные поля", "OK");
                return;
            }

            if (_dbContext.Table<User>().Any(u => u.Username == usernameEntry.Text))
            {
                await DisplayAlert("Ошибка", "Пользователь с таким логином уже существует", "OK");
                return;
            }

            var user = new User
            {
                Username = usernameEntry.Text,
                PasswordHash = passwordEntry.Text,
                Role = "patient"
            };

            _dbContext.AddUser(user);

            var patient = new Patient
            {
                FullName = fullNameEntry.Text,
                Phone = phoneEntry.Text,
                Email = emailEntry.Text,
                BirthDate = birthDatePicker.Date,
                UserId = user.UserId
            };

            _dbContext.Insert(patient);

            await DisplayAlert("Успех", "Регистрация завершена", "OK");
            await Navigation.PopAsync();
        }
    }
}