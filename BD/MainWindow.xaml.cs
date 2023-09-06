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

namespace BD
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

        BDEntities db = new BDEntities();

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Close();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var Login = txtlogin.Text;
            var Password = txtPassword.Password;

            try
            {
                if(Login == "admin")
                {
                    if(Password == "admin")
                    {
                        Admin admin = new Admin();
                        admin.Show();
                        this.Close();
                    }
                }
                foreach (var employee in db.Employees)
                {
                    if (employee.Employee_Login == Login)
                    {
                        if (employee.Employee_Password == Password)
                        {
                            Employee emp = new Employee();
                            emp.Show();
                            this.Close();
                        }
                    }
                }
                foreach (var reader in db.Readers)
                {
                    if (reader.Reader_Login == Login)
                    {
                        if (reader.Reader_Password == Password)
                        {
                            ReaderS read = new ReaderS();
                            read.Show();
                            this.Close();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка!!!");
            }
            
        }
    }
}
