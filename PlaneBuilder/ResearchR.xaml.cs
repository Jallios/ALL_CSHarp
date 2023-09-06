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
    /// Логика взаимодействия для ShowResearch.xaml
    /// </summary>
    public partial class ResearchR : Window
    {
        public ResearchR()
        {
            InitializeComponent();
            dtgResearch.ItemsSource = PlaneBuilderEntities.GetContext().Researches.ToList();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ResearchW researchWPF = new ResearchW();
            researchWPF.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ResearchAddRed researchAddRed = new ResearchAddRed(null);
            researchAddRed.Show();
            this.Close();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var manIsRemoving = dtgResearch.SelectedItems.Cast<Research>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {manIsRemoving.Count} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PlaneBuilderEntities.GetContext().Researches.RemoveRange(manIsRemoving);
                    PlaneBuilderEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!!!");

                    dtgResearch.ItemsSource = PlaneBuilderEntities.GetContext().Researches.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnRed_Click(object sender, RoutedEventArgs e)
        {
            ResearchAddRed researchAddRed = new ResearchAddRed((sender as Button).DataContext as Research);
            researchAddRed.Show();
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
