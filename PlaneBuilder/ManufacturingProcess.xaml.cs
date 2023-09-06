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

namespace PlaneBuilder
{
    /// <summary>
    /// Логика взаимодействия для ManufacturingProcess.xaml
    /// </summary>
    public partial class ManufacturingProcess : Window
    {
        public ManufacturingProcess()
        {
            InitializeComponent();
            dtgManProcess.ItemsSource = PlaneBuilderEntities.GetContext().Manufacturing_Process.ToList();
        }

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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            Brigader brigader = new Brigader();

            if (ClassID.ID == 5)
            {
                
                admin.Show();
                this.Close();
            }
            if(ClassID.ID == 4)
            {
                
                brigader.Show();
                this.Close();
            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                PlaneBuilderEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            }
        }

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
    }
}
