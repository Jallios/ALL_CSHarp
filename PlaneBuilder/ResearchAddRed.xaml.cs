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
    /// Логика взаимодействия для ResearchAddRed.xaml
    /// </summary>
    public partial class ResearchAddRed : Window
    {
        private Research _currentResearch = new Research();
        public ResearchAddRed(Research research)
        {
            if (research != null)
                _currentResearch = research;

            InitializeComponent();

            DataContext = _currentResearch;

            Result.ItemsSource = PlaneBuilderEntities.GetContext().Result_Research.ToList();
            Status.ItemsSource = PlaneBuilderEntities.GetContext().Status_Research.ToList();
            Laboratory.ItemsSource = PlaneBuilderEntities.GetContext().Research_Laboratory.ToList();

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentResearch.Name_Research.ToString()))
                stringBuilder.AppendLine("Укажите название");
            if (string.IsNullOrWhiteSpace(_currentResearch.Result_Research.ToString()))
                stringBuilder.AppendLine("Укажите результат");
            if (string.IsNullOrWhiteSpace(_currentResearch.Status_Research.ToString()))
                stringBuilder.AppendLine("Укажите статус");
            if (string.IsNullOrWhiteSpace(_currentResearch.Research_Laboratory.ToString()))
                stringBuilder.AppendLine("Укажите лабораторию");

            if (stringBuilder.Length > 0)
            {
                MessageBox.Show(stringBuilder.ToString());
                return;
            }

            if (_currentResearch.ID_Research == 0)
            {
                PlaneBuilderEntities.GetContext().Researches.Add(_currentResearch);
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

            ResearchR research = new ResearchR();
            research.Show();
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ResearchR research = new ResearchR();
            research.Show();
            this.Close();
        }
    }
}
