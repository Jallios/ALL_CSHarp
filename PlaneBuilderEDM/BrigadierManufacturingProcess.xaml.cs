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
    /// Логика взаимодействия для BrigadierManufacturingProcess.xaml
    /// </summary>
    public partial class BrigadierManufacturingProcess : Window
    {
        public BrigadierManufacturingProcess()
        {
            InitializeComponent();
            //Выгрузка данных в датагрид
            dtgManProcess.ItemsSource = PlaneBuilderEntities.GetContext().Manufacturing_Process.ToList();
        }

        //Метод удаления записи
        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var manIsRemoving = dtgManProcess.SelectedItems.Cast<Manufacturing_Process>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {manIsRemoving.Count} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PlaneBuilderEntities.GetContext().Manufacturing_Process.RemoveRange(manIsRemoving);
                    PlaneBuilderEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!!!");

                    dtgManProcess.ItemsSource = PlaneBuilderEntities.GetContext().Manufacturing_Process.ToList();
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
            var manIsAdding = dtgManProcess.SelectedItems.Cast<Manufacturing_Process>().ToList();

            try
            {
                PlaneBuilderEntities.GetContext().Manufacturing_Process.AddRange(manIsAdding);
                PlaneBuilderEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные добавлены!!!");

                dtgManProcess.ItemsSource = PlaneBuilderEntities.GetContext().Manufacturing_Process.ToList();

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
                PlaneBuilderEntities.GetContext().SaveChanges();
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
            Admin admin = new Admin();
            Brigadier brigadier = new Brigadier();

            if (ClassID.ID_Role == 4)
            {

                admin.Show();
                this.Close();
            }
            if (ClassID.ID_Role == 3)
            {

                brigadier.Show();
                this.Close();
            }
        }

        //Метод обновления таблицы
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                PlaneBuilderEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            }
        }
    }
}
