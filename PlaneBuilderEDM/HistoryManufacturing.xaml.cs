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
    /// Логика взаимодействия для HistoryManufacturing.xaml
    /// </summary>
    public partial class HistoryManufacturing : Window
    {
        public HistoryManufacturing()
        {
            InitializeComponent();
            //Выгрузка данных в датагрид
            dtgHistoryFactor.ItemsSource = PlaneBuilderEntities.GetContext().Manufacturing_History.ToList();
        }

        //Метод возвращения на предыдущую страницу
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            ResearchLab research = new ResearchLab();

            if (ClassID.ID_Role == 4)
            {

                admin.Show();
                this.Close();
            }
            if (ClassID.ID_Role == 2)
            {

                research.Show();
                this.Close();
            }
        }
    }
}