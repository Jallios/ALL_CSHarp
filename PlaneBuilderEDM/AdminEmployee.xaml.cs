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
    /// Логика взаимодействия для AdminEmployee.xaml
    /// </summary>
    public partial class AdminEmployee : Window
    {
        public AdminEmployee()
        {
            InitializeComponent();

            //Выгрузка данных в датагрид
            dtgUser.ItemsSource = PlaneBuilderEntities.GetContext().Employees.ToList();

        }

        //Метод перехода на окно добавления
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AdminEmployeeAddRed adminEmployeeAddRed = new AdminEmployeeAddRed(null);
            adminEmployeeAddRed.Show();
            this.Close();
        }

        //Метод удаления данных
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var manIsRemoving = dtgUser.SelectedItems.Cast<Employee>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {manIsRemoving.Count} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PlaneBuilderEntities.GetContext().Employees.RemoveRange(manIsRemoving);
                    PlaneBuilderEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!!!");

                    dtgUser.ItemsSource = PlaneBuilderEntities.GetContext().Employees.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        //Метод перехода на окно редактирования
        private void btnRed_Click(object sender, RoutedEventArgs e)
        {
            AdminEmployeeAddRed adminEmployeeAddRed = new AdminEmployeeAddRed((sender as Button).DataContext as Employee);
            adminEmployeeAddRed.Show();
            this.Close();
        }

        //Метод перехода на окно администратора
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Close();
        }

        //Метод обновления данных
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                PlaneBuilderEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            }
        }
    }
}