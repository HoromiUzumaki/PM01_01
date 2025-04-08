using HappyToothDLL;
using System;

namespace HappyToothDLL_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ClinicManager clinicManager = new ClinicManager();

            // Пример 1: Получить все записи для конкретного пациента
            Console.WriteLine("Введите ID пациента для получения записей:");
            int patientId = int.Parse(Console.ReadLine());
            var patientAppointments = clinicManager.GetAppointmentsForPatient(patientId);
            Console.WriteLine($"Записи для пациента с ID {patientId}:");
            foreach (var appointment in patientAppointments)
            {
                Console.WriteLine($"- {appointment.appointment_time}: {appointment.status}");
            }

            // Пример 2: Получить все записи для конкретного врача
            Console.WriteLine("Введите ID врача для получения записей:");
            int doctorId = int.Parse(Console.ReadLine());
            var doctorAppointments = clinicManager.GetAppointmentsForDoctor(doctorId);
            Console.WriteLine($"Записи для врача с ID {doctorId}:");
            foreach (var appointment in doctorAppointments)
            {
                Console.WriteLine($"- {appointment.appointment_time}: {appointment.status}");
            }

            // Пример 3: Получить предстоящие записи
            var upcomingAppointments = clinicManager.GetUpcomingAppointments();
            Console.WriteLine("Предстоящие записи:");
            foreach (var appointment in upcomingAppointments)
            {
                Console.WriteLine($"- {appointment.appointment_time}: {appointment.status}");
            }

            // Пример 4: Получить завершенные визиты пациента
            Console.WriteLine("Введите ID пациента для получения завершенных визитов:");
            patientId = int.Parse(Console.ReadLine());
            var completedVisits = clinicManager.GetCompletedVisitsForPatient(patientId);
            Console.WriteLine($"Завершенные визиты для пациента с ID {patientId}:");
            foreach (var visit in completedVisits)
            {
                Console.WriteLine($"- Диагноз: {visit.diagnosis}, Лечение: {visit.treatment}, Общая стоимость: {visit.total_price}");
            }

            // Пример 5: Расчет общего дохода от завершенных визитов
            decimal totalRevenue = clinicManager.CalculateTotalRevenue();
            Console.WriteLine($"Общий доход от завершенных визитов: {totalRevenue}");

            // Пример 6: Расчет дохода по типам услуг
            var revenueByService = clinicManager.CalculateRevenueByService();
            Console.WriteLine("Доход по типам услуг:");
            foreach (var service in revenueByService)
            {
                Console.WriteLine($"- {service.Key}: {service.Value}");
            }

            // Пример 7: Получить расписание врача
            Console.WriteLine("Введите ID врача для получения расписания:");
            doctorId = int.Parse(Console.ReadLine());
            var doctorSchedule = clinicManager.GetDoctorSchedule(doctorId);
            Console.WriteLine($"Расписание врача с ID {doctorId}:");
            foreach (var schedule in doctorSchedule)
            {
                Console.WriteLine($"- {schedule.day_of_week}: {schedule.start_time} - {schedule.end_time}");
            }

            // Пример 8: Получить доступные временные слоты для врача в конкретный день
            Console.WriteLine("Введите ID врача и дату (в формате ГГГГ-ММ-ДД) для получения доступных временных слотов:");
            doctorId = int.Parse(Console.ReadLine());
            DateTime date = DateTime.Parse(Console.ReadLine());
            var availableSlots = clinicManager.GetAvailableTimeSlots(doctorId, date);
            Console.WriteLine($"Доступные временные слоты для врача с ID {doctorId} на {date.ToShortDateString()}:");
            foreach (var slot in availableSlots)
            {
                Console.WriteLine($"- {slot}");
            }

            // Пример 9: Получить пациентов по году рождения
            Console.WriteLine("Введите год рождения для получения пациентов:");
            int year = int.Parse(Console.ReadLine());
            var patientsByYear = clinicManager.GetPatientsByBirthYear(year);
            Console.WriteLine($"Пациенты, родившиеся в {year} году:");
            foreach (var patient in patientsByYear)
            {
                Console.WriteLine($"- {patient.full_name}, Дата рождения: {patient.birth_date}");
            }

            // Пример 10: Получить самые популярные услуги
            Console.WriteLine("Введите количество популярных услуг для получения:");
            int topCount = int.Parse(Console.ReadLine());
            var popularServices = clinicManager.GetPopularServices(topCount);
            Console.WriteLine($"Самые популярные услуги (топ {topCount}):");
            foreach (var service in popularServices)
            {
                Console.WriteLine($"- {service.Key}: {service.Value} раз");
            }

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
