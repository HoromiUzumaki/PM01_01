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
    public partial class AppointmentsPage : ContentPage
    {
        private readonly DatabaseContext _dbContext;
        private int _patientId;

        public AppointmentsPage(Patient patient)
        {
            InitializeComponent();
            _dbContext = App.Database;
            _patientId = patient.PatientId;
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            var appointments = _dbContext.GetUpcomingAppointments(_patientId);
            appointmentsCollection.ItemsSource = appointments;
        }

        private async void OnCancelAppointment(int appointmentId)
        {
            bool result = await DisplayAlert("Подтверждение",
                "Вы действительно хотите отменить запись?", "Да", "Нет");

            if (result)
            {
                _dbContext.CancelAppointment(appointmentId);
                LoadAppointments();
            }
        }
    }
}