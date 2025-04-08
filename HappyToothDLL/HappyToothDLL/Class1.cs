using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyToothDLL
{
    public class ClinicManager
    {
        private readonly HappyToothEntities _context;

        public ClinicManager()
        {
            _context = new HappyToothEntities(); // Инициализация контекста базы данных
        }

        // Метод 1: Получить все записи для конкретного пациента
        public List<appointments> GetAppointmentsForPatient(int patientId)
        {
            return _context.appointments
                .Where(a => a.patient_id == patientId) // Фильтр по ID пациента
                .OrderBy(a => a.appointment_time) // Сортировка по времени записи
                .ToList();
        }

        // Метод 2: Получить все записи для конкретного врача
        public List<appointments> GetAppointmentsForDoctor(int doctorId)
        {
            return _context.appointments
                .Where(a => a.doctor_id == doctorId) // Фильтр по ID врача
                .OrderBy(a => a.appointment_time) // Сортировка по времени
                .ToList();
        }

        // Метод 3: Получить предстоящие записи (будущие записи)
        public List<appointments> GetUpcomingAppointments()
        {
            return _context.appointments
                .Where(a => a.appointment_time > DateTime.Now && a.status == "запланирован") // Только будущие и запланированные
                .OrderBy(a => a.appointment_time) // Сортировка по дате
                .ToList();
        }

        // Метод 4: Получить завершенные визиты пациента
        public List<visits> GetCompletedVisitsForPatient(int patientId)
        {
            return _context.visits
                .Join(_context.appointments, // Соединение таблиц визитов и записей
                    visit => visit.appointment_id,
                    appointment => appointment.appointment_id,
                    (visit, appointment) => new { Visit = visit, Appointment = appointment })
                .Where(x => x.Appointment.patient_id == patientId) // Фильтр по пациенту
                .Select(x => x.Visit) // Выбираем только данные визитов
                .ToList();
        }

        // Метод 5: Расчет общего дохода от завершенных визитов
        public decimal CalculateTotalRevenue()
        {
            return _context.visits
                .Sum(v => v.total_price ?? 0); // Суммируем все суммы визитов
        }

        // Метод 6: Расчет дохода по типам услуг
        public Dictionary<string, decimal> CalculateRevenueByService()
        {
            return _context.visit_services
                .Join(_context.services, // Соединяем услуги визитов с каталогом услуг
                    vs => vs.service_id,
                    s => s.service_id,
                    (vs, s) => new { ServiceName = s.name, Revenue = s.price * (vs.quantity ?? 1) })
                .GroupBy(x => x.ServiceName) // Группируем по названию услуги
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Revenue)); // Суммируем выручку по каждой услуге
        }

        // Метод 7: Получить расписание врача
        public List<doctor_schedule> GetDoctorSchedule(int doctorId)
        {
            return _context.doctor_schedule
                .Where(ds => ds.doctor_id == doctorId) // Фильтр по врачу
                .OrderBy(ds => ds.day_of_week) // Сортировка по дням недели
                .ToList();
        }

        // Метод 8: Получить доступные временные слоты для врача в конкретный день
        public List<TimeSpan> GetAvailableTimeSlots(int doctorId, DateTime date)
        {
            // Получаем русское обозначение дня недели
            var dayOfWeek = GetRussianDayOfWeek(date.DayOfWeek);

            // Находим расписание врача на этот день
            var schedule = _context.doctor_schedule
                .FirstOrDefault(ds => ds.doctor_id == doctorId && ds.day_of_week == dayOfWeek);

            if (schedule == null)
                return new List<TimeSpan>(); // Если нет расписания - возвращаем пустой список

            // Получаем все записи врача на эту дату
            var appointments = _context.appointments
                .Where(a => a.doctor_id == doctorId &&
                           DbFunctions.TruncateTime(a.appointment_time) == date.Date && // Изменено здесь
                           a.status != "отменен") // Исключаем отмененные записи
                .Select(a => a.appointment_time.TimeOfDay)
                .ToList();

            var availableSlots = new List<TimeSpan>();
            var currentTime = schedule.start_time;
            var endTime = schedule.end_time;

            // Формируем список доступных слотов (каждые 30 минут)
            while (currentTime < endTime)
            {
                if (!appointments.Contains(currentTime))
                {
                    availableSlots.Add(currentTime);
                }
                currentTime = currentTime.Add(TimeSpan.FromMinutes(30));
            }

            return availableSlots;
        }

        // Метод 9: Получить пациентов по году рождения
        public List<patients> GetPatientsByBirthYear(int year)
        {
            return _context.patients
                .Where(p => p.birth_date.HasValue && p.birth_date.Value.Year == year)
                .OrderBy(p => p.birth_date)
                .ToList();
        }

        // Метод 10: Получить самые популярные услуги
        public Dictionary<string, int> GetPopularServices(int topCount)
        {
            return _context.visit_services
                .Join(_context.services,
                    vs => vs.service_id,
                    s => s.service_id,
                    (vs, s) => new { ServiceName = s.name, Quantity = vs.quantity ?? 1 })
                .GroupBy(x => x.ServiceName) // Группируем по названию услуги
                .OrderByDescending(g => g.Sum(x => x.Quantity)) // Сортируем по количеству
                .Take(topCount) // Берем топ N
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Quantity)); // Преобразуем в словарь
        }

        // Вспомогательный метод для преобразования DayOfWeek в русское сокращение
        private string GetRussianDayOfWeek(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday: return "пн";
                case DayOfWeek.Tuesday: return "вт";
                case DayOfWeek.Wednesday: return "ср";
                case DayOfWeek.Thursday: return "чт";
                case DayOfWeek.Friday: return "пт";
                case DayOfWeek.Saturday: return "сб";
                case DayOfWeek.Sunday: return "вс";
                default: return "";
            }
        }
    }
}
