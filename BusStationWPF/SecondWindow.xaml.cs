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
    /// Логика взаимодействия для SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BusStationEntities2.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DriverDataGrid.ItemsSource = BusStationEntities2.GetContext().Driver.ToList();
                MessageBox.Show("Данные загружены успешно");
            }
        }

        private void toRoute_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DriverPage driverPage = new DriverPage((sender as Button).DataContext as Driver);
            driverPage.Show();
            this.Close();
        }

        private void DeleteDriverButton_Click(object sender, RoutedEventArgs e)
        {
            var driverIsRemoving = DriverDataGrid.SelectedItems.Cast<Route>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {driverIsRemoving.Count} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    BusStationEntities2.GetContext().Route.RemoveRange(driverIsRemoving);
                    BusStationEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!!!");

                    DriverDataGrid.ItemsSource = BusStationEntities2.GetContext().Route.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void AddDriverButton_Click(object sender, RoutedEventArgs e)
        {
            DriverPage driverPage = new DriverPage(null);
            driverPage.Show();
            this.Close();
        }
    }
}
