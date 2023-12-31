﻿using System;
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
    /// Логика взаимодействия для AdminHistoryEmployee.xaml
    /// </summary>
    public partial class AdminHistoryEmployee : Window
    {
        public AdminHistoryEmployee()
        {
            InitializeComponent();
            //Выгрузка данных в датагрид
            dtgHistoryUser.ItemsSource = PlaneBuilderEntities.GetContext().Employee_History.ToList();
        }

        //Метлд возвращения на окно администратора
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Close();
        }
    }
}
