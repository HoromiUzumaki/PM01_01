using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System.Linq;
namespace Happy_tooth_Mobile
{


    public class DatabaseContext
    {
        private readonly SQLiteConnection _connection;

        public DatabaseContext(string dbPath)
        {
            _connection = new SQLiteConnection(dbPath);
            CreateTables();
            SeedData();
        }

        private void CreateTables()
        {
            _connection.CreateTable<User>();
            _connection.CreateTable<Patient>();
            _connection.CreateTable<Doctor>();
            _connection.CreateTable<Appointment>();
            _connection.CreateTable<Visit>();
            _connection.CreateTable<Service>();
            _connection.CreateTable<VisitService>();
            _connection.CreateTable<DoctorSchedule>();
        }

        private void SeedData()
        {
            if (_connection.Table<User>().Any()) return;

            
            var users = new List<User>
    {
        new User { Username = "admin", PasswordHash = "admin123", Role = "admin" },
        new User { Username = "ivanov", PasswordHash = "ivanov123", Role = "patient" },
        new User { Username = "smirnova", PasswordHash = "smirnova123", Role = "patient" },
        new User { Username = "kozlova", PasswordHash = "kozlova123", Role = "doctor" }
    };
            _connection.InsertAll(users);

           
            var patients = new List<Patient>
    {
        new Patient { FullName = "Иванов Петр Сидорович", Phone = "+79161234567", Email = "ivanov@mail.ru", BirthDate = new DateTime(1985, 3, 15), UserId = 2 },
        new Patient { FullName = "Смирнова Анна Владимировна", Phone = "+79035678901", Email = "smirnova@gmail.com", BirthDate = new DateTime(1990, 7, 22), UserId = 3 },
        new Patient { FullName = "Кузнецов Дмитрий Игоревич", Phone = "+79219876543", Email = "kuznetsov@yandex.ru", BirthDate = new DateTime(1978, 11, 30) },
        new Patient { FullName = "Петрова Ольга Сергеевна", Phone = "+79105551234", Email = "petrova@mail.com", BirthDate = new DateTime(1982, 5, 17) },
        new Patient { FullName = "Сидоров Алексей Викторович", Phone = "+79031112233", Email = "sidorov@inbox.ru", BirthDate = new DateTime(1995, 9, 21) }
    };
            _connection.InsertAll(patients);

            
            var doctors = new List<Doctor>
    {
        new Doctor { FullName = "Козлова Елена Дмитриевна", Specialization = "Терапевт", UserId = 4 },
        new Doctor { FullName = "Петров Сергей Иванович", Specialization = "Хирург" },
        new Doctor { FullName = "Соколова Анна Михайловна", Specialization = "Ортодонт" },
        new Doctor { FullName = "Лебедев Денис Владимирович", Specialization = "Имплантолог" },
        new Doctor { FullName = "Громова Наталья Петровна", Specialization = "Пародонтолог" }
    };
            _connection.InsertAll(doctors);

            
            var services = new List<Service>
    {
        new Service { Name = "Консультация", Price = 1500.00m },
        new Service { Name = "Лечение кариеса", Price = 5000.00m },
        new Service { Name = "Удаление зуба", Price = 7000.00m },
        new Service { Name = "Профессиональная чистка", Price = 3500.00m },
        new Service { Name = "Рентгенография", Price = 1200.00m },
        new Service { Name = "Пломбирование", Price = 4500.00m },
        new Service { Name = "Лечение пульпита", Price = 8000.00m },
        new Service { Name = "Отбеливание", Price = 10000.00m },
        new Service { Name = "Установка винира", Price = 20000.00m },
        new Service { Name = "Имплантация", Price = 35000.00m }
    };
            _connection.InsertAll(services);

            
            var schedules = new List<DoctorSchedule>
    {
        new DoctorSchedule { DoctorId = 1, DayOfWeek = "пн", StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(18, 0, 0) },
        new DoctorSchedule { DoctorId = 1, DayOfWeek = "вт", StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(18, 0, 0) },
        new DoctorSchedule { DoctorId = 1, DayOfWeek = "ср", StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(19, 0, 0) },
        new DoctorSchedule { DoctorId = 2, DayOfWeek = "пн", StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(19, 0, 0) },
        new DoctorSchedule { DoctorId = 2, DayOfWeek = "ср", StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(17, 0, 0) }
    };
            _connection.InsertAll(schedules);

           
            var appointments = new List<Appointment>
    {
        // Записи для Иванова (PatientId = 1)
        new Appointment { PatientId = 1, DoctorId = 1, AppointmentTime = DateTime.Now.AddDays(1), Status = "запланирован" },
        new Appointment { PatientId = 1, DoctorId = 2, AppointmentTime = DateTime.Now.AddDays(3), Status = "запланирован" },
        new Appointment { PatientId = 1, DoctorId = 3, AppointmentTime = DateTime.Now.AddDays(-5), Status = "завершен" },
        new Appointment { PatientId = 1, DoctorId = 4, AppointmentTime = DateTime.Now.AddDays(-10), Status = "завершен" },
        
        // Записи для Смирновой (PatientId = 2)
        new Appointment { PatientId = 2, DoctorId = 3, AppointmentTime = DateTime.Now.AddDays(2), Status = "запланирован" },
        new Appointment { PatientId = 2, DoctorId = 1, AppointmentTime = DateTime.Now.AddDays(-2), Status = "завершен" },
        new Appointment { PatientId = 2, DoctorId = 5, AppointmentTime = DateTime.Now.AddDays(-7), Status = "отменен" },
        
        // Записи для Кузнецова (PatientId = 3)
        new Appointment { PatientId = 3, DoctorId = 2, AppointmentTime = DateTime.Now.AddDays(-1), Status = "завершен" },
        new Appointment { PatientId = 3, DoctorId = 4, AppointmentTime = DateTime.Now.AddDays(4), Status = "запланирован" },
        
        // Записи для Петровой (PatientId = 4)
        new Appointment { PatientId = 4, DoctorId = 5, AppointmentTime = DateTime.Now.AddDays(-3), Status = "завершен" },
        new Appointment { PatientId = 4, DoctorId = 1, AppointmentTime = DateTime.Now.AddDays(5), Status = "запланирован" },
        
        // Записи для Сидорова (PatientId = 5)
        new Appointment { PatientId = 5, DoctorId = 3, AppointmentTime = DateTime.Now.AddDays(-4), Status = "завершен" },
        new Appointment { PatientId = 5, DoctorId = 2, AppointmentTime = DateTime.Now.AddDays(6), Status = "запланирован" }
    };
            _connection.InsertAll(appointments);

            
            var visits = new List<Visit>
    {
        // Визиты для завершенных записей Иванова
        new Visit { AppointmentId = 3, Diagnosis = "Кариес", Treatment = "Пломбирование зуба", TotalPrice = 4500.00m },
        new Visit { AppointmentId = 4, Diagnosis = "Пульпит", Treatment = "Лечение каналов", TotalPrice = 8000.00m },
        
        // Визиты для Смирновой
        new Visit { AppointmentId = 6, Diagnosis = "Профилактический осмотр", Treatment = "Чистка зубов", TotalPrice = 3500.00m },
        
        // Визиты для Кузнецова
        new Visit { AppointmentId = 8, Diagnosis = "Перелом зуба", Treatment = "Удаление зуба", TotalPrice = 7000.00m },
        
        // Визиты для Петровой
        new Visit { AppointmentId = 10, Diagnosis = "Гингивит", Treatment = "Лечение десен", TotalPrice = 5000.00m },
        
        // Визиты для Сидорова
        new Visit { AppointmentId = 12, Diagnosis = "Неправильный прикус", Treatment = "Консультация ортодонта", TotalPrice = 1500.00m }
    };
            _connection.InsertAll(visits);

            
            var visitServices = new List<VisitService>
    {
        // Услуги для визита 1 (Иванов)
        new VisitService { VisitId = 1, ServiceId = 2, Quantity = 1 }, // Лечение кариеса
        new VisitService { VisitId = 1, ServiceId = 6, Quantity = 1 }, // Пломбирование
        
        // Услуги для визита 2 (Иванов)
        new VisitService { VisitId = 2, ServiceId = 7, Quantity = 1 }, // Лечение пульпита
        new VisitService { VisitId = 2, ServiceId = 5, Quantity = 2 }, // Рентгенография (2 снимка)
        
        // Услуги для визита 3 (Смирнова)
        new VisitService { VisitId = 3, ServiceId = 4, Quantity = 1 }, // Проф. чистка
        new VisitService { VisitId = 3, ServiceId = 1, Quantity = 1 }, // Консультация
        
        // Услуги для визита 4 (Кузнецов)
        new VisitService { VisitId = 4, ServiceId = 3, Quantity = 1 }, // Удаление зуба
        new VisitService { VisitId = 4, ServiceId = 5, Quantity = 1 }, // Рентгенография
        
        // Услуги для визита 5 (Петрова)
        new VisitService { VisitId = 5, ServiceId = 9, Quantity = 1 }, // Лечение десен
        new VisitService { VisitId = 5, ServiceId = 4, Quantity = 1 }, // Проф. чистка
        
        // Услуги для визита 6 (Сидоров)
        new VisitService { VisitId = 6, ServiceId = 1, Quantity = 1 }  // Консультация
    };
            _connection.InsertAll(visitServices);
        }

        // User methods
        public User GetUser(string username, string password)
        {
            return _connection.Table<User>()
                .FirstOrDefault(u => u.Username == username && u.PasswordHash == password);
        }

        public int AddUser(User user)
        {
            return _connection.Insert(user);
        }

        // Patient methods
        public Patient GetPatientByUserId(int userId)
        {
            return _connection.Table<Patient>().FirstOrDefault(p => p.UserId == userId);
        }
        public TableQuery<T> Table<T>() where T : new()
        {
            return _connection.Table<T>();
        }

        public int Insert(object obj)
        {
            return _connection.Insert(obj);
        }
        public bool UserExists(string username)
        {
            return _connection.Table<User>().Any(u => u.Username == username);
        }

        public int CreatePatient(Patient patient)
        {
            return _connection.Insert(patient);
        }
        public List<Patient> GetAllPatients()
        {
            return _connection.Table<Patient>().ToList();
        }

        public int UpdatePatient(Patient patient)
        {
            return _connection.Update(patient);
        }

        // Doctor methods
        public List<Doctor> GetAllDoctors()
        {
            return _connection.Table<Doctor>().ToList();
        }

        public Doctor GetDoctorById(int doctorId)
        {
            return _connection.Table<Doctor>().FirstOrDefault(d => d.DoctorId == doctorId);
        }

        // Appointment methods
        public List<Appointment> GetPatientAppointments(int patientId)
        {
            return _connection.Table<Appointment>()
                .Where(a => a.PatientId == patientId)
                .OrderBy(a => a.AppointmentTime)
                .ToList();
        }

        public List<Appointment> GetUpcomingAppointments(int patientId)
        {
            return _connection.Table<Appointment>()
                .Where(a => a.PatientId == patientId &&
                            a.AppointmentTime >= DateTime.Now &&
                            a.Status == "запланирован")
                .OrderBy(a => a.AppointmentTime)
                .ToList();
        }

        public int AddAppointment(Appointment appointment)
        {
            return _connection.Insert(appointment);
        }

        public int CancelAppointment(int appointmentId)
        {
            var appointment = _connection.Table<Appointment>()
                .FirstOrDefault(a => a.AppointmentId == appointmentId);

            if (appointment != null)
            {
                appointment.Status = "отменен";
                return _connection.Update(appointment);
            }
            return 0;
        }

        // Visit methods
        public List<Visit> GetPatientVisits(int patientId)
        {
            // Получаем все визиты с деталями
            var allVisits = _connection.GetAllWithChildren<Visit>();

            // Получаем все записи для пациента
            var patientAppointments = _connection.Table<Appointment>()
                .Where(a => a.PatientId == patientId)
                .ToList();

            // Фильтруем визиты по записям пациента
            return allVisits
                .Where(v => patientAppointments.Any(a => a.AppointmentId == v.AppointmentId))
                .OrderByDescending(v => v.Appointment?.AppointmentTime ?? DateTime.MinValue)
                .ToList();
        }

        // Service methods
        public List<Service> GetAllServices()
        {
            return _connection.Table<Service>().ToList();
        }

        // Doctor Schedule methods
        public List<DoctorSchedule> GetDoctorSchedule(int doctorId)
        {
            return _connection.Table<DoctorSchedule>()
                .Where(s => s.DoctorId == doctorId)
                .OrderBy(s => s.DayOfWeek)
                .ToList();
        }

        public List<DateTime> GetAvailableSlots(int doctorId, DateTime date)
        {
            var dayOfWeek = date.DayOfWeek.ToString().ToLower();
            var schedule = _connection.Table<DoctorSchedule>()
                .FirstOrDefault(s => s.DoctorId == doctorId && s.DayOfWeek == dayOfWeek);

            if (schedule == null) return new List<DateTime>();

            var existingAppointments = _connection.Table<Appointment>()
                .Where(a => a.DoctorId == doctorId &&
                            a.AppointmentTime.Date == date.Date &&
                            a.Status != "отменен")
                .Select(a => a.AppointmentTime)
                .ToList();

            var availableSlots = new List<DateTime>();
            var currentTime = date.Date.Add(schedule.StartTime);
            var endTime = date.Date.Add(schedule.EndTime);

            while (currentTime.AddMinutes(30) <= endTime)
            {
                if (!existingAppointments.Any(a => a == currentTime))
                {
                    availableSlots.Add(currentTime);
                }
                currentTime = currentTime.AddMinutes(30);
            }

            return availableSlots;
        }
    }
}