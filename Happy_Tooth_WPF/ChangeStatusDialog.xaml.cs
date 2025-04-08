using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Happy_Tooth_WPF
{
    /// <summary>
    /// Логика взаимодействия для ChangeStatusDialog.xaml
    /// </summary>
    public partial class ChangeStatusDialog : Window
    {
        public string SelectedStatus { get; private set; }
        private readonly string[] _availableStatuses = {
        "Запланирован", "Отменен", "Завершен"
    };

        public ChangeStatusDialog(string currentStatus)
        {
            InitializeComponent();
            cmbStatus.ItemsSource = _availableStatuses;
            cmbStatus.SelectedItem = _availableStatuses.FirstOrDefault(
                s => s.ToLower() == currentStatus.ToLower()) ?? _availableStatuses[0];
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SelectedStatus = cmbStatus.SelectedItem.ToString();
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
