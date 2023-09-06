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
    /// Логика взаимодействия для Worker.xaml
    /// </summary>
    public partial class Worker : Window
    {
        public Worker()
        {
            InitializeComponent();

            //Выгрузка дынных в датагрид
            dtgEmployeeManufacturing.ItemsSource = PlaneBuilderEntities.GetContext().Manufacturing_Process.Where(s => s.ID_Process == ClassID.ID_Brigade).ToList();
        }

        //Метод возвращения на страницу авторизации
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorizationWindow = new Authorization();
            authorizationWindow.Show();
            this.Close();
        }
    }
}
