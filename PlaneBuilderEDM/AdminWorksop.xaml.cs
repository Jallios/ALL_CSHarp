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
    /// Логика взаимодействия для AdminWorksop.xaml
    /// </summary>
    public partial class AdminWorksop : Window
    {
        public AdminWorksop()
        {
            InitializeComponent();
            //Выгрузка данных в датагрид
            dtgWorkshop.ItemsSource = PlaneBuilderEntities.GetContext().Workshops.ToList();
        }

        //Метод перехода на страницу добавления
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AdminWorksopAddRed worksopAddRed = new AdminWorksopAddRed(null);
            worksopAddRed.Show();
            this.Close();
        }

        //Метод удаления данных
        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var manIsRemoving = dtgWorkshop.SelectedItems.Cast<Workshop>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {manIsRemoving.Count} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PlaneBuilderEntities.GetContext().Workshops.RemoveRange(manIsRemoving);
                    PlaneBuilderEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!!!");

                    dtgWorkshop.ItemsSource = PlaneBuilderEntities.GetContext().Workshops.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        //Метод перехода на страницу редактирования
        private void btnRed_Click(object sender, RoutedEventArgs e)
        {
            AdminWorksopAddRed worksopAddRed = new AdminWorksopAddRed((sender as Button).DataContext as Workshop);
            worksopAddRed.Show();
            this.Close();
        }

        //Метод перехода на страницу администратора
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Close();
        }

        //Метод обновления записей
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                PlaneBuilderEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            }
        }
    }
}
