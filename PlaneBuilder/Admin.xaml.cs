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

namespace PlaneBuilder
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
       
        public Admin()
        {
            InitializeComponent();
        }
    

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            HistoryManufacturing historyManufacturing = new HistoryManufacturing();
            historyManufacturing.Show();
            this.Close();
        }

        private void btnHistoryUser_Click(object sender, RoutedEventArgs e)
        {
            HistoryEmployee historyEmployee = new HistoryEmployee();
            historyEmployee.Show();
            this.Close();
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            AdminEmployee adminEmployee = new AdminEmployee();
            adminEmployee.Show();
            this.Close();
        }

        private void btnCex_Click(object sender, RoutedEventArgs e)
        {
            Cex cex = new Cex();
            cex.Show();
            this.Close();
        }

        private void btnPlace_Click(object sender, RoutedEventArgs e)
        {
            Plot plot = new Plot();
            plot.Show();
            this.Close();
        }

        private void btnFactory_Click(object sender, RoutedEventArgs e)
        {

            ManufacturingProcess manufacturingProcess = new ManufacturingProcess();
            manufacturingProcess.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
