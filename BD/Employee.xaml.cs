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
    /// Логика взаимодействия для Employee.xaml
    /// </summary>
    public partial class EmployeeS : Window
    {
        public EmployeeS()
        {
            InitializeComponent();
        }

        private void btnSubscription_Click(object sender, RoutedEventArgs e)
        {
            SubscriptionS subscription = new SubscriptionS();
            subscription.Show();
            this.Close();
        }

        private void btnReaderCategory_Click(object sender, RoutedEventArgs e)
        {
            Reader_CategoryS reader_CategoryS = new Reader_CategoryS();
            reader_CategoryS.Show();
            this.Close();
        }

        private void btnBookStorage_Click(object sender, RoutedEventArgs e)
        {
            Book_StorageS book_StorageS = new Book_StorageS();
            book_StorageS.Show();
            this.Close();
        }

        private void btnReadingRoom_Click(object sender, RoutedEventArgs e)
        {
            Reading_RoomS reading_RoomS = new Reading_RoomS();
            reading_RoomS.Show();
            this.Close();
        }
    }
}
