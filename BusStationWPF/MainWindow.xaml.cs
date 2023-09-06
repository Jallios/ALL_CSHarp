using BusStationWPF;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BusStationClass
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Route _currentRoute = new Route();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddRouteButton_Click(object sender, RoutedEventArgs e)
        {
            RoutePage routePage = new RoutePage(null);
            routePage.Show();
            this.Close();
        }

        private void DeleteRouteButton_Click(object sender, RoutedEventArgs e)
        {
            var routeIsRemoving = RouteDataGrid.SelectedItems.Cast<Route>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {routeIsRemoving.Count} элементов?","Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    BusStationEntities2.GetContext().Route.AddRange(routeIsRemoving);

                    // BusStationEntities2.GetContext().Route.RemoveRange(routeIsRemoving);
                    // BusStationEntities2.GetContext().Route.
                    BusStationEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!!!");

                    RouteDataGrid.ItemsSource = BusStationEntities2.GetContext().Route.ToList();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    
                }
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            RoutePage routePage = new RoutePage((sender as Button).DataContext as Route);
            routePage.Show();
            this.Close();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                BusStationEntities2.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                RouteDataGrid.ItemsSource = BusStationEntities2.GetContext().Route.ToList();
                MessageBox.Show("Данные загружены успешно");
            }
        }

        private void toDriver_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow second = new SecondWindow();
            second.Show();
            this.Close();
        }
    }
}
