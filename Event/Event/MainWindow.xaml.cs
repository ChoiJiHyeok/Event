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
using System.Net.Sockets;
using System.Net;


namespace Event
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private Socket serverSocket;
        private Socket clientSocket;
        private int port = 9001;
        private string IP = "192.168.1.107";
        private bool isOpen = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            IPAddress serverIPAddress = null; // 서버 주소
            bool? result = null;
            bool change;
            int maxBacklog;

            bool? qwer = null;


            if (isOpen == false)
            {
                result = IPAddress.TryParse(IP, out serverIPAddress);

            }
            else
            {
                MessageBox.Show("Server is already opened");
            }

            if (result == true)
            {
                IPEndPoint serverIP = new IPEndPoint(serverIPAddress, port);

                isOpen = true;

                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(serverIP);

                change = int.TryParse(SocketOptionName.MaxConnections.ToString(), out maxBacklog);

                MessageBox.Show(maxBacklog.ToString());

                if(change)
                {
                    serverSocket.Listen(maxBacklog);
                }
                else
                {
                    serverSocket.Listen(10);
                }

            }
            else
            {
                MessageBox.Show("Cannot Openn server");
            }
           //


        }
    }
}
