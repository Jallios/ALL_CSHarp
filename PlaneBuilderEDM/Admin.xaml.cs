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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }
        //Переход на окно истории производства
        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            HistoryManufacturing historyManufacturing = new HistoryManufacturing();
            historyManufacturing.Show();
            this.Close();
        }

        //Переход на окно просмотра истории сотрудников
        private void btnHistoryUser_Click(object sender, RoutedEventArgs e)
        {
            AdminHistoryEmployee historyEmployee = new AdminHistoryEmployee();
            historyEmployee.Show();
            this.Close();
        }

        //Переход на окно сотрудника
        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            AdminEmployee adminEmployee = new AdminEmployee();
            adminEmployee.Show();
            this.Close();
        }

        //Переход на окно цеха
        private void btnCex_Click(object sender, RoutedEventArgs e)
        {
            AdminWorksop adminWorksop = new AdminWorksop();
            adminWorksop.Show();
            this.Close();
        }

        //Переход на окно участка
        private void btnPlace_Click(object sender, RoutedEventArgs e)
        {
            AdminArea adminArea = new AdminArea();
            adminArea.Show();
            this.Close();
        }

        //Переход на окно производства
        private void btnFactory_Click(object sender, RoutedEventArgs e)
        {

            BrigadierManufacturingProcess brigadierManufacturing = new BrigadierManufacturingProcess();
            brigadierManufacturing.Show();
            this.Close();
        }

        //Переход на окно авторизации
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Close();
        }
    }
}

