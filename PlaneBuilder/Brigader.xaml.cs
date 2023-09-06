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
    /// Логика взаимодействия для Brigade.xaml
    /// </summary>
    public partial class Brigader : Window
    {
        public Brigader()
        {
            InitializeComponent();
        }

        private void btnFactor_Click(object sender, RoutedEventArgs e)
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

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            BrigadeEmployee showEmployee = new BrigadeEmployee();
            showEmployee.Show();
            this.Close();
        }
    }
}
