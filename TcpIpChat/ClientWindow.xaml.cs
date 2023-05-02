using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace TcpIpChat
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        string ip;
        int port;
        TcpClient client;
        StreamWriter sw;
        StreamReader sr;
        string name;
        public ClientWindow(string name, string ip)
        {
            InitializeComponent();
            this.ip = ip;
            port = 5050;
            this.name = name;
            Task.Run(Connect);
            Task.Run(ChatListener);
        }

        private void Connect()
        {
            try
            {
                client = new TcpClient();
                client.Connect(this.ip, port);
                sr = new StreamReader(client.GetStream());
                sw = new StreamWriter(client.GetStream());
                sw.AutoFlush = true;
                sw.WriteLine($"/connect: {name}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Dispatcher.Invoke(() =>
                {
                    Close();
                });
            }
        }

        private void Disconnect()
        {
            try
            {
                sw.WriteLine($"/disconnect: {name}");
            }
            catch
            {

            }
        }

        private void ChatListener()
        {
            while (true)
            {
                try
                {
                    if (client != null && client.Connected == true)
                    {
                        string line = sr.ReadLine();
                        if (line != null)
                        {
                            Dispatcher.Invoke(() =>
                            {
                                if (line.Contains("/connect: ") && !string.IsNullOrWhiteSpace(line.Replace("/connect: ", "")))
                                {
                                    string clientName = line.Replace("/connect: ", "");
                                    if (!UsersListBox.Items.Contains($"[{clientName}]"))
                                    {
                                        UsersListBox.Items.Add($"[{clientName}]");
                                    }
                                }
                                else if (line.Contains("/disconnect: ") && !string.IsNullOrWhiteSpace(line.Replace("/disconnect: ", "")))
                                {
                                    string clientName = line.Replace("/disconnect: ", "");
                                    if (UsersListBox.Items.Contains($"[{clientName}]"))
                                    {
                                        UsersListBox.Items.Remove($"[{clientName}]");
                                    }
                                }
                                else if (line == "/exit")
                                {
                                    MessageBox.Show("Сервер чата остановлен");
                                    Close();
                                }
                                else if (line == "/name_already_exists")
                                {
                                    MessageBox.Show("Данное имя уже используется");
                                    Close();
                                }
                                else
                                {
                                    string[] lineSplit = line.Split(':');
                                    ChatTextBox.AppendText($"[{DateTime.Now}] [{lineSplit[0]}]: {lineSplit[1]}\n");
                                }
                            });
                        }
                        else
                        {
                            client.Close();
                            Close();
                        }
                    }
                    
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void DiscconectButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string message = MessageTextBox.Text;
            if (string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("Нельзя отправить пустое сообщение");
            }
            else if (message.ToLower() == "/disconnect")
            {
                Close();
            }
            else if (message[0] == '/')
            {
                MessageBox.Show("Нет такой команды");
            }
            else
            {
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        Dispatcher.Invoke(() =>
                        {
                            sw.WriteLine($"{name}: {message}");
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
            MessageTextBox.Clear();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Task.Run(Disconnect);
            Application.Current?.MainWindow.Show();
        }
    }
}
