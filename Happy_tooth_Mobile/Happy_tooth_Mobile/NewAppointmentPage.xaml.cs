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
    public partial class NewAppointmentPage : ContentPage
    {
        private readonly DatabaseContext _dbContext;
        private int _patientId;
        private List<DateTime> _availableSlots = new List<DateTime>();

        public NewAppointmentPage(Patient patient)
        {
            InitializeComponent();
            _dbContext = App.Database;
            _patientId = patient.PatientId;
            LoadDoctors();
            datePicker.Date = DateTime.Today;
        }

        private void LoadDoctors()
        {
            var doctors = _dbContext.GetAllDoctors();
            doctorPicker.ItemsSource = doctors;
        }

        private async void OnFindTimeClicked(object sender, EventArgs e)
        {
            if (doctorPicker.SelectedItem == null)
            {
                await DisplayAlert("Ошибка", "Выберите врача", "OK");
                return;
            }

            var doctor = (Doctor)doctorPicker.SelectedItem;
            _availableSlots = _dbContext.GetAvailableSlots(doctor.DoctorId, datePicker.Date);

            timeSlotPicker.ItemsSource = _availableSlots
                .Select(s => s.ToString("HH:mm"))
                .ToList();
        }

        private async void OnBookAppointmentClicked(object sender, EventArgs e)
        {
            if (doctorPicker.SelectedItem == null || timeSlotPicker.SelectedIndex == -1)
            {
                await DisplayAlert("Ошибка", "Заполните все поля", "OK");
                return;
            }

            var doctor = (Doctor)doctorPicker.SelectedItem;
            var appointmentTime = _availableSlots[timeSlotPicker.SelectedIndex];

            var appointment = new Appointment
            {
                PatientId = _patientId,
                DoctorId = doctor.DoctorId,
                AppointmentTime = appointmentTime,
                Status = "запланирован"
            };

            _dbContext.AddAppointment(appointment);
            await DisplayAlert("Успех", "Вы успешно записаны", "OK");
            await Navigation.PopAsync();
        }
    }
}