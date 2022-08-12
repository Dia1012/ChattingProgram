using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public partial class ClientChat : Form
    {
        private Thread receiveTh;
        public ClientChat()
        {
            InitializeComponent();
        }

        private void Receive()
        {
            while (true)
            {
                byte[] msgBuffer = new byte[1024];
                int msgLength = ClientStart.socket.Receive(msgBuffer, msgBuffer.Length, SocketFlags.None);
                string showText = Encoding.UTF8.GetString(msgBuffer, 0, msgLength);
                ChatBox.AppendText(showText);
                ChatBox.AppendText("\r\n");
                this.Activate();
                ChatBox.Focus();
                ChatBox.SelectionStart = ChatBox.Text.Length;
                ChatBox.ScrollToCaret();
            }
        }

        private void ClientChat_Load(object sender, EventArgs e)
        {
            receiveTh = new Thread(new ThreadStart(Receive));
            receiveTh.IsBackground = true;
            receiveTh.Start();
        }

        private void Sender_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[1024];
            buffer = Encoding.UTF8.GetBytes(SendBox.Text);
            ClientStart.socket.Send(buffer);
            SendBox.Text = "";
        }
    }
}
