using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public partial class ClientStart : Form
    {
        public static Socket socket;
        public ClientStart()
        {
            InitializeComponent();
        }

        private void ClientDisplay_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress SERVER_IP = IPAddress.Parse(ip.Text);
            int PORT = int.Parse(Port.Text);
            IPEndPoint endPoint = new IPEndPoint(SERVER_IP, PORT);
            string NICKNAME = Nickname.Text;
            byte[] buffer = new byte[1024];
            buffer = Encoding.UTF8.GetBytes(NICKNAME);

            socket = new Socket(

                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
            );
            socket.Connect(endPoint);
            socket.Send(buffer);

            this.Visible = false;
            ClientChat showChat = new ClientChat();
            showChat.ShowDialog();
        }
    }
}
