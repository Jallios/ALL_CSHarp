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
    /// Логика взаимодействия для RoutePage.xaml
    /// </summary>
    public partial class RoutePage : Window
    {
        private Route _currentRoute = new Route();
        public RoutePage(Route route)
        {
            if (route != null)
                _currentRoute = route;

            InitializeComponent();

            DataContext = _currentRoute;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentRoute.NumberRoute.ToString()))
                stringBuilder.AppendLine("Укажите номер маршрута");
            if (string.IsNullOrWhiteSpace(_currentRoute.FirstStation))
                stringBuilder.AppendLine("Укажите первую остановку маршрута");
            if (string.IsNullOrWhiteSpace(_currentRoute.LastStation))
                stringBuilder.AppendLine("Укажите последнюю остановку маршрута");
            if (string.IsNullOrWhiteSpace(_currentRoute.Mileage.ToString()))
                stringBuilder.AppendLine("Укажите километраж");

            if (stringBuilder.Length > 0)
            {
                MessageBox.Show(stringBuilder.ToString());
                return;
            }

            if (_currentRoute.ID_Route == 0)
            {
                BusStationEntities2.GetContext().Route.Add(_currentRoute);
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

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BusStationEntities2.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
