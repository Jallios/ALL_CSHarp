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
    /// Логика взаимодействия для BrigadeEmployee.xaml
    /// </summary>
    public partial class BrigadeEmployee : Window
    {
        public BrigadeEmployee()
        {
            InitializeComponent();
            dtgUser.ItemsSource = PlaneBuilderEntities.GetContext().Employees.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Brigader brigader = new Brigader();
            brigader.Show();
            this.Close();   
        }
    }
}
