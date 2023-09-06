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
    /// Логика взаимодействия для Cex.xaml
    /// </summary>
    public partial class Cex : Window
    {
        public Cex()
        {
            InitializeComponent();
            dtgWorkshop.ItemsSource = PlaneBuilderEntities.GetContext().Workshops.ToList();

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            CexAddRed cexAddRed = new CexAddRed(null);
            cexAddRed.Show();
            this.Close();
        }

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

        private void btnRed_Click(object sender, RoutedEventArgs e)
        {
            CexAddRed cexAddRed = new CexAddRed((sender as Button).DataContext as Workshop);
            cexAddRed.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Close();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                PlaneBuilderEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            }
        }
    }
}
