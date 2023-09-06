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
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        private Reader _currentReader = new Reader();
        public SignUp()
        {
           
            InitializeComponent();

            DataContext = _currentReader;

            
            cmbReaderCategory.ItemsSource = BDEntities.GetContext().Reader_Category.ToList();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentReader.Full_Name_Reader.ToString()))
                stringBuilder.AppendLine("Укажите ФИО");
            if (string.IsNullOrWhiteSpace(_currentReader.Reader_Birth.ToString()))
                stringBuilder.AppendLine("Укажите дату рождени");
            if (string.IsNullOrWhiteSpace(_currentReader.Reader_Login.ToString()))
                stringBuilder.AppendLine("Укажите логин");
            if (string.IsNullOrWhiteSpace(_currentReader.Reader_Password.ToString()))
                stringBuilder.AppendLine("Укажите пароль");
            if (string.IsNullOrWhiteSpace(_currentReader.Reader_Category.ToString()))
                stringBuilder.AppendLine("Укажите категорию");

            if (stringBuilder.Length > 0)
            {
                MessageBox.Show(stringBuilder.ToString());
                return;
            }

            try
            {
                BDEntities.GetContext().Readers.Add(_currentReader);
                BDEntities.GetContext().SaveChanges();
                MessageBox.Show("Успешно!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
