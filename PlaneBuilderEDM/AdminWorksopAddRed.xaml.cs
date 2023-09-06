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
    /// Логика взаимодействия для AdminWorksopAddRed.xaml
    /// </summary>
    public partial class AdminWorksopAddRed : Window
    {
        private Workshop _currentWorkshop = new Workshop();
        public AdminWorksopAddRed(Workshop cex)
        {
            if (cex != null)
                _currentWorkshop = cex;

            InitializeComponent();

            DataContext = _currentWorkshop;

            //Метод выгрузки данных в выпадающий список
            Area.ItemsSource = PlaneBuilderEntities.GetContext().Areas.ToList();
        }

        //Метод сохранения данных
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentWorkshop.Name_Workshop.ToString()))
                stringBuilder.AppendLine("Укажите название");
            if (string.IsNullOrWhiteSpace(_currentWorkshop.Location_Workshop.ToString()))
                stringBuilder.AppendLine("Укажите адрес");
            if (string.IsNullOrWhiteSpace(_currentWorkshop.Area.ToString()))
                stringBuilder.AppendLine("Укажите участок");


            if (stringBuilder.Length > 0)
            {
                MessageBox.Show(stringBuilder.ToString());
                return;
            }

            if (_currentWorkshop.ID_Workshop == 0)
            {
                PlaneBuilderEntities.GetContext().Workshops.Add(_currentWorkshop);
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

            AdminWorksop adminWorksop = new AdminWorksop();
            adminWorksop.Show();
            this.Close();
        }

        //Метод перехода на страницу цех
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminWorksop adminWorksop = new AdminWorksop();
            adminWorksop.Show();
            this.Close();
        }

        //Метод обновления данных
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                PlaneBuilderEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            }
        }
    }
}
