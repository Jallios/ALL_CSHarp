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
    /// Логика взаимодействия для HistoryEmployee.xaml
    /// </summary>
    public partial class HistoryEmployee : Window
    {
        public HistoryEmployee()
        {
            InitializeComponent();
            dtgHistoryUser.ItemsSource = PlaneBuilderEntities.GetContext().Employee_History.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Close();
        }
    }
}
