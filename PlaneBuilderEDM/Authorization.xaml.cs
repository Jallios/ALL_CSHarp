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

namespace PlaneBuilderEDM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        //Экземпляр класса модели базы данных
        PlaneBuilderEntities db = new PlaneBuilderEntities();

        //Метод выхода из приложения
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        //Метод авторизации по ролям
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
                            ClassID.ID_Role = employee.ID_Post;
                            ClassID.ID_Brigade = (int)employee.ID_Brigade;
                            switch (role.Name_Post)
                            {
                                case "Администратор":
                                    Admin adminWindow = new Admin();
                                    adminWindow.Show();
                                    this.Close();
                                    break;
                                case "Бригадир":
                                    Brigadier brigadierWindow = new Brigadier();
                                    brigadierWindow.Show();
                                    this.Close();
                                    break;
                                case "Исследователь":
                                    ResearchLab researchLabWindow = new ResearchLab();
                                    researchLabWindow.Show();
                                    this.Close();
                                    break;
                                case "Рабочий":
                                    Worker workerWindow = new Worker();
                                    workerWindow.Show();
                                    this.Close();
                                    break;
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

