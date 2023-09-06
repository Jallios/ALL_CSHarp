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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        SerialPort serialPort;
        bool ArduinoPortDetected = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool ArduinoDetected()
        {
            try
            {
                serialPort.Open();
                System.Threading.Thread.Sleep(1000);
                string returnMessage = serialPort.ReadLine();
                serialPort.Close();

                if (returnMessage.Contains("Arduino"))
                {
                    lbCheck.Content = "Arduino подключено";
                    lbCheck.Background = Brushes.LightGreen;
                    return true;

                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }

        }

        private void btFound_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                serialPort = new SerialPort(cbCom.SelectedItem.ToString(), 9600);
                if (ArduinoDetected())
                {
                    ArduinoPortDe    tected = true;
                }
                else
                {
                    ArduinoPortDetected = false;
                }
            }
            catch { }
            if (ArduinoPortDetected == false) return;
            serialPort.BaudRate = 9600;
            serialPort.DtrEnable = true;
            serialPort.ReadTimeout = 1000;
            try
            {
                serialPort.Open();
            }
            catch { }
        }

        private void btOpen_Click(object sender, RoutedEventArgs e)
        {
            if (!serialPort.IsOpen) return;
            serialPort.Write("0");
            btOpen.IsEnabled = false;
            btClose.IsEnabled = true;
            btCloseAfter.IsEnabled = true;
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            if (!serialPort.IsOpen) return;
            serialPort.Write("1");
            btOpen.IsEnabled = true;
            btClose.IsEnabled = false;
            btCloseAfter.IsEnabled = false;
        }
        private void cbCom_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < SerialPort.GetPortNames().Length; i++)
            {
                cbCom.Items.Add(SerialPort.GetPortNames()[i]);
            }
            cbCom.SelectedIndex = 0;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            serialPort.Close();
        }

        private void btCloseAfter_Click_1(object sender, RoutedEventArgs e)
        {
            for (int i = -1; i < cbSec.SelectedIndex; i++)
            {
                serialPort.Write("1");
                serialPort.Write("0");
            }
            btOpen.IsEnabled = true;
            btClose.IsEnabled = false;
            btCloseAfter.IsEnabled = false;
        }
    }
}