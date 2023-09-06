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

namespace PlaneBuilderEDM
{
    /// <summary>
    /// Логика взаимодействия для ResearchLab.xaml
    /// </summary>
    public partial class ResearchLab : Window
    {
        public ResearchLab()
        {
            InitializeComponent();
        }

        //Метод перехода на окно авторизации
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Close();
        }

        //Метод перехода на окно истории производства
        private void btnHistoryReserch_Click(object sender, RoutedEventArgs e)
        {
            HistoryManufacturing historyManufacturing = new HistoryManufacturing();
            historyManufacturing.Show();
            this.Close();
        }

        //Метод перехода на окно лаборатории
        private void btnResearch_Click(object sender, RoutedEventArgs e)
        {
            ResearchLabLaboratory research = new ResearchLabLaboratory();
            research.Show();
            this.Close();
        }
    }
}
