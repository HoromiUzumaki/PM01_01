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
    public partial class HistoryPage : ContentPage
    {
        private readonly DatabaseContext _dbContext;
        private int _patientId;

        public HistoryPage(Patient patient)
        {
            InitializeComponent();
            _dbContext = App.Database;
            _patientId = patient.PatientId;
            LoadVisits();
        }

        private void LoadVisits()
        {
            var visits = _dbContext.GetPatientVisits(_patientId);
            visitsCollection.ItemsSource = visits;
        }
    }
}