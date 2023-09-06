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
    /// Логика взаимодействия для Research.xaml
    /// </summary>
    public partial class ResearchW : Window
    {
        public ResearchW()
        {
            InitializeComponent();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
           MainWindow mainWindow = new MainWindow();
           mainWindow.Show();
           this.Close();
        }

        private void btnHistoryReserch_Click(object sender, RoutedEventArgs e)
        {
            HistoryManufacturing historyManufacturing = new HistoryManufacturing();
            historyManufacturing.Show();
            this.Close();
        }

        private void btnResearch_Click(object sender, RoutedEventArgs e)
        {
            ResearchR research = new ResearchR();
            research.Show();
            this.Close();
        }
    }
}
