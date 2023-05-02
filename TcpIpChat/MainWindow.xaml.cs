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
using System.Xml.Linq;

namespace TcpIpChat
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewChatButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Заполните имя пользователя", "Информация");
            }
            else
            {
                AdminWindow adminWindow = new AdminWindow(name);
                adminWindow.Show();
                NameTextBox.Clear();
                IPTextBox.Clear();
                if (adminWindow.IsVisible)
                {
                    Hide();
                }           
            }
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string ip = IPTextBox.Text;
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ip))
            {
                MessageBox.Show("Заполните имя пользователя и IP адрес чата", "Информация");
            }
            else
            {
                ClientWindow clientWindow = new ClientWindow(name, ip);
                clientWindow.Show();
                NameTextBox.Clear();
                IPTextBox.Clear();
                if (clientWindow.IsVisible)
                {
                    Hide();
                }
            }
        }
    }
}
