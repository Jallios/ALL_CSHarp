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
    /// Логика взаимодействия для ResearchLabLaboratory.xaml
    /// </summary>
    public partial class ResearchLabLaboratory : Window
    {
        public ResearchLabLaboratory()
        {
            InitializeComponent();
            //Метод выгрузки данных в датагрид
            dtgResearch.ItemsSource = PlaneBuilderEntities.GetContext().Researches.ToList();
        }
        //Метод перехода на окно иследователь
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ResearchLab research = new ResearchLab();
            research.Show();
            this.Close();
        }

        //Метод перехода на окно добавление записи
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ResearchLabLaboratoryAddRed researchAddRed = new ResearchLabLaboratoryAddRed(null);
            researchAddRed.Show();
            this.Close();
        }

        //Метод удаление записи
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

        //Метод перехода на окно редактирования записи
        private void btnRed_Click(object sender, RoutedEventArgs e)
        {
            ResearchLabLaboratoryAddRed researchAddRed = new ResearchLabLaboratoryAddRed((sender as Button).DataContext as Research);
            researchAddRed.Show();
            this.Close();
        }

        //Метод обновления
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                PlaneBuilderEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            }
        }
    }
}