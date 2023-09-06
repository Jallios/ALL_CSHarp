using BusStationWPF;
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

namespace BusStationClass
{
    /// <summary>
    /// Логика взаимодействия для DriverPage.xaml
    /// </summary>
    public partial class DriverPage : Window
    {
        private Driver _currentDriver = new Driver();
        public DriverPage(Driver driver)
        {
            if (driver != null)
                _currentDriver = driver;

            InitializeComponent();

            DataContext = _currentDriver;

            NumberRouteCmb.ItemsSource = BusStationEntities2.GetContext().Route.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentDriver.Name))
                stringBuilder.AppendLine("Укажите имя");
            if (string.IsNullOrWhiteSpace(_currentDriver.Surname))
                stringBuilder.AppendLine("Укажите фамилию");
            if (string.IsNullOrWhiteSpace(_currentDriver.Patronymic))
                stringBuilder.AppendLine("Укажите отчество");
            if (_currentDriver.Route == null)
                stringBuilder.AppendLine("Укажите номер маршрута");

            if (stringBuilder.Length > 0)
            {
                MessageBox.Show(stringBuilder.ToString());
                return;
            }

            if (_currentDriver.ID_Driver == 0)
            {
                BusStationEntities2.GetContext().Driver.Add(_currentDriver);
            }

            try
            {
                BusStationEntities2.GetContext().SaveChanges();
                MessageBox.Show("Успешно!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            SecondWindow secondWindow = new SecondWindow();
            secondWindow.Show();
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow secondWindow = new SecondWindow();
            secondWindow.Show();
            this.Close();
        }

        private void NumberRouteCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
