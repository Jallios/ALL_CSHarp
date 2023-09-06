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
    /// Логика взаимодействия для HistoryManufacturing.xaml
    /// </summary>
    public partial class HistoryManufacturing : Window
    {
        public HistoryManufacturing()
        {
            InitializeComponent();
            dtgHistoryFactor.ItemsSource = PlaneBuilderEntities.GetContext().Manufacturing_History.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            ResearchW research = new ResearchW();

            if (ClassID.ID == 5)
            {

                admin.Show();
                this.Close();
            }
            if (ClassID.ID == 3)
            {

                research.Show();
                this.Close();
            }
        }
    }
}
