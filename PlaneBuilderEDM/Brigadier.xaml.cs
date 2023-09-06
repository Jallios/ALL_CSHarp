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
    /// Логика взаимодействия для Brigadier.xaml
    /// </summary>
    public partial class Brigadier : Window
    {
        public Brigadier()
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
        //Метод перехода на окно просмотра сотрудников
        private void btnBE_Click(object sender, RoutedEventArgs e)
        {
            BrigadierEmployee brigadierEmployee = new BrigadierEmployee();
            brigadierEmployee.Show();
            this.Close();
        }
        //Метод перехода на окно производственных процессов
        private void btnMFP_Click(object sender, RoutedEventArgs e)
        {
            BrigadierManufacturingProcess brigadierManufacturingProcess = new BrigadierManufacturingProcess();
            brigadierManufacturingProcess.Show();
            this.Close();
        }
    }
}
