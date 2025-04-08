using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Happy_Tooth_WPF
{
    /// <summary>
    /// Логика взаимодействия для ReportsPage.xaml
    /// </summary>
    public partial class ReportsPage : Page
    {
        private HappyToothEntities db = new HappyToothEntities();

        public ReportsPage()
        {
            InitializeComponent();
            dpStartDate.SelectedDate = DateTime.Today.AddMonths(-1);
            dpEndDate.SelectedDate = DateTime.Today;
        }

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            if (cmbReportType.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип отчета", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (dpStartDate.SelectedDate == null || dpEndDate.SelectedDate == null)
            {
                MessageBox.Show("Выберите период", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DateTime startDate = dpStartDate.SelectedDate.Value;
            DateTime endDate = dpEndDate.SelectedDate.Value;

            if (startDate > endDate)
            {
                MessageBox.Show("Дата начала не может быть позже даты окончания", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string reportType = (cmbReportType.SelectedItem as ComboBoxItem).Content.ToString();

            switch (reportType)
            {
                case "Приемы по врачам":
                    ShowAppointmentsByDoctorReport(startDate, endDate);
                    break;
                case "Финансовый отчет":
                    ShowFinancialReport(startDate, endDate);
                    break;
                case "Статистика услуг":
                    ShowServicesStatisticsReport(startDate, endDate);
                    break;
            }
        }

        private void ShowAppointmentsByDoctorReport(DateTime startDate, DateTime endDate)
        {
            var reportData = db.appointments
                .Where(a => a.appointment_time >= startDate && a.appointment_time <= endDate)
                .GroupBy(a => a.doctors.full_name)
                .Select(g => new
                {
                    Doctor = g.Key,
                    AppointmentsCount = g.Count(),
                    CompletedCount = g.Count(a => a.status == "завершен"),
                    PlannedCount = g.Count(a => a.status == "запланирован"),
                    CanceledCount = g.Count(a => a.status == "отменен")
                })
                .ToList();

            reportGrid.ItemsSource = reportData;
            reportGrid.AutoGenerateColumns = true;
        }

        private void ShowFinancialReport(DateTime startDate, DateTime endDate)
        {
            var reportData = db.visits
                .Where(v => v.appointments.appointment_time >= startDate && v.appointments.appointment_time <= endDate)
                .GroupBy(v => v.appointments.doctors.full_name)
                .Select(g => new
                {
                    Doctor = g.Key,
                    TotalVisits = g.Count(),
                    TotalIncome = g.Sum(v => v.total_price)
                })
                .ToList();

            reportGrid.ItemsSource = reportData;
            reportGrid.AutoGenerateColumns = true;
        }

        private void ShowServicesStatisticsReport(DateTime startDate, DateTime endDate)
        {
            var reportData = db.visit_services
                .Where(vs => vs.visits.appointments.appointment_time >= startDate &&
                            vs.visits.appointments.appointment_time <= endDate)
                .GroupBy(vs => vs.services.name)
                .Select(g => new
                {
                    Service = g.Key,
                    Count = g.Sum(vs => vs.quantity ?? 1),
                    TotalIncome = g.Sum(vs => (vs.quantity ?? 1) * vs.services.price)
                })
                .ToList();

            reportGrid.ItemsSource = reportData;
            reportGrid.AutoGenerateColumns = true;
        }

        private void ExportToExcel_Click(object sender, RoutedEventArgs e)
        {
            if (reportGrid.ItemsSource == null)
            {
                MessageBox.Show("Нет данных для экспорта", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel файл (*.xlsx)|*.xlsx",
                Title = "Сохранить отчет как",
                DefaultExt = "xlsx"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Получаем тип отчета для названия листа
                    string reportType = cmbReportType.SelectedItem != null
                        ? (cmbReportType.SelectedItem as ComboBoxItem).Content.ToString()
                        : "Отчет";

                    // Создаем Excel пакет
                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        // Добавляем лист в книгу
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(reportType);

                        // Получаем данные из DataGrid
                        var itemsSource = reportGrid.ItemsSource;
                        if (itemsSource == null)
                        {
                            MessageBox.Show("Нет данных для экспорта", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        // Записываем заголовки столбцов
                        for (int i = 0; i < reportGrid.Columns.Count; i++)
                        {
                            worksheet.Cells[1, i + 1].Value = reportGrid.Columns[i].Header;
                            worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        }

                        // Записываем данные
                        int row = 2;
                        foreach (var item in itemsSource)
                        {
                            for (int col = 0; col < reportGrid.Columns.Count; col++)
                            {
                                var column = reportGrid.Columns[col];
                                var property = item.GetType().GetProperty(column.SortMemberPath);
                                if (property != null)
                                {
                                    var value = property.GetValue(item, null);
                                    worksheet.Cells[row, col + 1].Value = value?.ToString();
                                }
                            }
                            row++;
                        }

                        // Автонастройка ширины столбцов
                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                        // Добавляем информацию о периоде отчета
                        worksheet.Cells[row + 2, 1].Value = $"Период отчета: с {dpStartDate.SelectedDate?.ToString("dd.MM.yyyy")} по {dpEndDate.SelectedDate?.ToString("dd.MM.yyyy")}";
                        worksheet.Cells[row + 2, 1].Style.Font.Bold = true;

                        // Сохраняем файл
                        FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                        excelPackage.SaveAs(excelFile);

                        MessageBox.Show($"Отчет успешно сохранен в файл:\n{saveFileDialog.FileName}",
                            "Экспорт завершен", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при экспорте в Excel:\n{ex.Message}",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
    

