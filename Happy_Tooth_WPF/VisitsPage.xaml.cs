using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Happy_Tooth_WPF
{
    public partial class VisitsPage : Page
    {
        private HappyToothEntities _context = new HappyToothEntities();

        public VisitsPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            _context.visits
                .Include(v => v.appointments)
                .Include(v => v.appointments.patients)
                .Include(v => v.appointments.doctors)
                .Load();

            visitsGrid.ItemsSource = _context.visits.Local;

            // Заполняем фильтры
            _context.patients.Load();
            cmbPatientFilter.ItemsSource = _context.patients.Local;

            _context.doctors.Load();
            cmbDoctorFilter.ItemsSource = _context.doctors.Local;
        }

        private void FilterVisits_Click(object sender, RoutedEventArgs e)
        {
            var query = _context.visits
                .Include(v => v.appointments)
                .Include(v => v.appointments.patients)
                .Include(v => v.appointments.doctors)
                .AsQueryable();

            if (cmbPatientFilter.SelectedItem is patients selectedPatient)
            {
                query = query.Where(v => v.appointments.patient_id == selectedPatient.patient_id);
            }

            if (cmbDoctorFilter.SelectedItem is doctors selectedDoctor)
            {
                query = query.Where(v => v.appointments.doctor_id == selectedDoctor.doctor_id);
            }

            if (dpFromDate.SelectedDate.HasValue)
            {
                query = query.Where(v => v.appointments.appointment_time >= dpFromDate.SelectedDate.Value);
            }

            if (dpToDate.SelectedDate.HasValue)
            {
                var toDate = dpToDate.SelectedDate.Value.AddDays(1);
                query = query.Where(v => v.appointments.appointment_time < toDate);
            }

            visitsGrid.ItemsSource = query.ToList();
        }

        private void ResetFilters_Click(object sender, RoutedEventArgs e)
        {
            cmbPatientFilter.SelectedItem = null;
            cmbDoctorFilter.SelectedItem = null;
            dpFromDate.SelectedDate = null;
            dpToDate.SelectedDate = null;
            LoadData();
        }

        private void visitsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (visitsGrid.SelectedItem is visits selectedVisit)
            {
                visitDetailsPanel.Visibility = Visibility.Visible;
                txtDiagnosis.Text = selectedVisit.diagnosis;
                txtTreatment.Text = selectedVisit.treatment;

                _context.Entry(selectedVisit)
                    .Collection(v => v.visit_services)
                    .Query()
                    .Include(vs => vs.services)
                    .Load();

                servicesGrid.ItemsSource = selectedVisit.visit_services.ToList();
            }
            else
            {
                visitDetailsPanel.Visibility = Visibility.Collapsed;
            }
        }
    }
}