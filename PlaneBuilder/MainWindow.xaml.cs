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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlaneBuilder
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        PlaneBuilderEntities db = new PlaneBuilderEntities();

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            var Login = txtlogin.Text;
            var Password = txtParol.Password;
            if (db.Employees.Any(u => u.Login_Employee == Login) == true)
            {
                foreach (var employee in db.Employees)
                {
                    if (employee.Login_Employee == Login)
                    {
                        if (employee.Password_Employee == Password)
                        {
                            var role = db.Posts.Find(employee.ID_Post);
                            ClassID.ID = employee.ID_Post;
                            if (role.Name_Post == "Администратор")
                            {
                                Admin administratorWindow = new Admin();
                                administratorWindow.Show();
                                this.Close();
                            }
                            if (role.Name_Post == "Бригадир")
                            {
                                Brigader brigadeWindow = new Brigader();
                                brigadeWindow.Show();
                                this.Close();
                            }
                            if (role.Name_Post == "Исследователь")
                            { 
                                ResearchW workersWindow = new ResearchW();
                                workersWindow.Show();
                                this.Close();
                            }
                            if (role.Name_Post == "Рабочий")
                            {
                                Worker workersWindow = new Worker();
                                workersWindow.Show();
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Вы ввели неправильный пароль");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует");
            }
        }
    }
}
