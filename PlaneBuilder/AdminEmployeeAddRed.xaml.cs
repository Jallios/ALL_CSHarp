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
    /// Логика взаимодействия для AdminEmployeeAddRed.xaml
    /// </summary>
    public partial class AdminEmployeeAddRed : Window
    {
        private Employee _currentEmployee = new Employee();
        public AdminEmployeeAddRed(Employee employee)
        {
            if (employee != null)
                _currentEmployee = employee;

            InitializeComponent();

            DataContext = _currentEmployee;

            Brigade.ItemsSource = PlaneBuilderEntities.GetContext().Brigades.ToList();
            Research.ItemsSource = PlaneBuilderEntities.GetContext().Research_Laboratory.ToList();
            Post.ItemsSource = PlaneBuilderEntities.GetContext().Posts.ToList();

        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                PlaneBuilderEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentEmployee.Surname_Employee.ToString()))
                stringBuilder.AppendLine("Укажите фамилию");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Name_Employee.ToString()))
                stringBuilder.AppendLine("Укажите имя");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Patronymic_Employee.ToString()))
                stringBuilder.AppendLine("Укажите отчество");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Salary_Employee.ToString()))
                stringBuilder.AppendLine("Укажите зарплату");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Login_Employee.ToString()))
                stringBuilder.AppendLine("Укажите логин");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Password_Employee.ToString()))
                stringBuilder.AppendLine("Укажите пароль");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Status_Employee.ToString()))
                stringBuilder.AppendLine("Укажите статус");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Post.ToString()))
                stringBuilder.AppendLine("Укажите должность");


            if (stringBuilder.Length > 0)
            {
                MessageBox.Show(stringBuilder.ToString());
                return;
            }

            if (_currentEmployee.ID_Employee == 0)
            {
                PlaneBuilderEntities.GetContext().Employees.Add(_currentEmployee);
            }

            try
            {
                PlaneBuilderEntities.GetContext().SaveChanges();
                MessageBox.Show("Успешно!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            AdminEmployee adminEmployeeWindow = new AdminEmployee();
            adminEmployeeWindow.Show();
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminEmployee adminEmployeeWindow = new AdminEmployee();
            adminEmployeeWindow.Show();
            this.Close();
        }
    }
}
