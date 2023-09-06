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
    /// Логика взаимодействия для Book_Storage.xaml
    /// </summary>
    public partial class Book_StorageS : Window
    {
        public Book_StorageS()
        {
            InitializeComponent();
            dtgManProcess.ItemsSource = BDEntities.GetContext().Book_Storage.ToList();
        }

        //Метод удаления записи
        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var manIsRemoving = dtgManProcess.SelectedItems.Cast<Book_Storage>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {manIsRemoving.Count} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    BDEntities.GetContext().Book_Storage.RemoveRange(manIsRemoving);
                    BDEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!!!");

                    dtgManProcess.ItemsSource = BDEntities.GetContext().Book_Storage.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        //Метод добавления записи
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var manIsAdding = dtgManProcess.SelectedItems.Cast<Book_Storage>().ToList();

            try
            {
                BDEntities.GetContext().Book_Storage.AddRange(manIsAdding);
                BDEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные добавлены!!!");

                dtgManProcess.ItemsSource = BDEntities.GetContext().Book_Storage.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }

        }

        //Метод редактирование записи
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BDEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные изменены!!!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        //Метод возвращения на предыдущее окно
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            EmployeeS employee = new EmployeeS();
            employee.Show();
            this.Close();
        }

        //Метод обновления таблицы
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BDEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            }
        }
    }
}
