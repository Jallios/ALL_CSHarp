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

namespace BD
{
    /// <summary>
    /// Логика взаимодействия для AdminAddAndUpdate.xaml
    /// </summary>
    public partial class AdminAddAndUpdate : Window
    {
        private Employee _currentEmployee = new Employee();
        public AdminAddAndUpdate(Employee employee)
        {
            if (employee != null)
                _currentEmployee = employee;
            InitializeComponent();

            DataContext = _currentEmployee;

            //Выгрузка данных в выпадающие списки
            Brigade.ItemsSource = BDEntities.GetContext().Reading_Room.ToList();
        }
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BDEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            }
        }

        //Метод сохранения данных
        private void Save_Click(object sender, RoutedEventArgs e)
        {

            if (_currentEmployee.ID_Employee == 0)
            {
                BDEntities.GetContext().Employees.Add(_currentEmployee);
            }

            try
            {
                BDEntities.GetContext().SaveChanges();
                MessageBox.Show("Успешно!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            SubscriptionS adminEmployeeWindow = new SubscriptionS();
            adminEmployeeWindow.Show();
            this.Close();
        }

        //Метод возвращения на окно работы с сотрудниками
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SubscriptionS adminEmployeeWindow = new SubscriptionS();
            adminEmployeeWindow.Show();
            this.Close();
        }
    }
}

