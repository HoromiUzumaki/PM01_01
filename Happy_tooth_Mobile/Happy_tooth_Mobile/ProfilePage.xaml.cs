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
    public partial class ProfilePage : ContentPage
    {
        private Patient _patient;
        private readonly DatabaseContext _dbContext;

        public ProfilePage(Patient patient)
        {
            InitializeComponent();
            _patient = patient;
            _dbContext = App.Database;
            BindingContext = _patient;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            _patient.FullName = fullNameEntry.Text;
            _patient.Phone = phoneEntry.Text;
            _patient.Email = emailEntry.Text;
            _patient.BirthDate = birthDatePicker.Date;

            var result = _dbContext.UpdatePatient(_patient);

            if (result > 0)
            {
                await DisplayAlert("Успех", "Данные сохранены", "OK");
            }
            else
            {
                await DisplayAlert("Ошибка", "Не удалось сохранить данные", "OK");
            }
        }
    }
}