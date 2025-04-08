using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Happy_tooth_Mobile
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseContext _dbContext;

        public MainPage()
        {
            InitializeComponent();
            _dbContext = App.Database;
        }
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameEntry.Text) ||
                string.IsNullOrWhiteSpace(passwordEntry.Text))
            {
                await DisplayAlert("Ошибка", "Заполните все поля", "OK");
                return;
            }

            var user = _dbContext.GetUser(usernameEntry.Text, passwordEntry.Text);

            if (user == null)
            {
                await DisplayAlert("Ошибка", "Неверный логин или пароль", "OK");
                return;
            }

            if (user.Role == "patient")
            {
                var patient = _dbContext.GetPatientByUserId(user.UserId);
                await Navigation.PushAsync(new TabbedPage1(patient));
            }
            else
            {
                await DisplayAlert("Ошибка", "Доступ только для пациентов", "OK");
            }
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
    }
}
