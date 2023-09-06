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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            dtgUser.ItemsSource = BDEntities.GetContext().Employees.ToList();

        }

        //Метод перехода на окно добавления
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AdminAddAndUpdate adminEmployeeAddRed = new AdminAddAndUpdate(null);
            adminEmployeeAddRed.Show();
            this.Close();
        }

        //Метод удаления данных
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var manIsRemoving = dtgUser.SelectedItems.Cast<Employee>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {manIsRemoving.Count} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    BDEntities.GetContext().Employees.RemoveRange(manIsRemoving);
                    BDEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!!!");

                    dtgUser.ItemsSource = BDEntities.GetContext().Reading_Room.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        //Метод перехода на окно редактирования
        private void btnRed_Click(object sender, RoutedEventArgs e)
        {
            AdminAddAndUpdate adminEmployeeAddRed = new AdminAddAndUpdate((sender as Button).DataContext as Employee);
            adminEmployeeAddRed.Show();
            this.Close();
        }

        //Метод перехода на окно администратора
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Close();
        }

        //Метод обновления данных
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BDEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            }
        }
    }
}
