using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Happy_tooth_Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage1 : TabbedPage
    {
        private Patient _patient;
        private readonly DatabaseContext _dbContext;

        public TabbedPage1(Patient patient)
        {
            InitializeComponent();
            _patient = patient;
            _dbContext = App.Database;

            // Добавляем дочерние страницы с передачей пациента
            this.Children.Add(new ProfilePage(_patient) { Title = "Профиль", IconImageSource = "profile_icon.png" });
            this.Children.Add(new HistoryPage(_patient) { Title = "История", IconImageSource = "history_icon.png" });
            this.Children.Add(new AppointmentsPage(_patient) { Title = "Записи", IconImageSource = "appointment_icon.png" });
            this.Children.Add(new NewAppointmentPage(_patient) { Title = "Записаться", IconImageSource = "galochka.png" });
        }
    }
}