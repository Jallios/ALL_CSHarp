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
    /// Логика взаимодействия для AdminArea.xaml
    /// </summary>
    public partial class AdminArea : Window
    {
        public AdminArea()
        {
            InitializeComponent();
            //Выгрузка записей  датагрид
            dtgArea.ItemsSource = PlaneBuilderEntities.GetContext().Areas.ToList();
        }

        //Переход на окно администратора
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Close();
        }

        //Метод добавления записи
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var manIsAdding = dtgArea.SelectedItems.Cast<Area>().ToList();

            try
            {
                PlaneBuilderEntities.GetContext().Areas.AddRange(manIsAdding);
                PlaneBuilderEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные добавлены!!!");

                dtgArea.ItemsSource = PlaneBuilderEntities.GetContext().Areas.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        //Метод удаление записи
        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var manIsRemoving = dtgArea.SelectedItems.Cast<Area>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {manIsRemoving.Count} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PlaneBuilderEntities.GetContext().Areas.RemoveRange(manIsRemoving);
                    PlaneBuilderEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!!!");

                    dtgArea.ItemsSource = PlaneBuilderEntities.GetContext().Areas.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        //Метод редактирования записи
        private void btnRed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlaneBuilderEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные изменены!!!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
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
