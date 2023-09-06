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
    /// Логика взаимодействия для BrigadierEmployee.xaml
    /// </summary>
    public partial class BrigadierEmployee : Window
    {
        public BrigadierEmployee()
        {
            InitializeComponent();
            //Выгрузка данных в датагрид
            dtgUser.ItemsSource = PlaneBuilderEntities.GetContext().Employees.Where(s => s.ID_Employee == ClassID.ID_Brigade).ToList();
        }

        //Метод возвращения на окно бригадира
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Brigadier brigadier = new Brigadier();
            brigadier.Show();
            this.Close();
        }
    }
}
