using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace KlientTCP
{
    public partial class SendMessage : Form
    {
        TcpClient client;
        NetworkStream stream;
        Byte[] data = new byte[2048];
        public SendMessage(TcpClient client)
        {
            InitializeComponent();
            this.client = client;
            stream = client.GetStream();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void message_richTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void send_button_Click(object sender, EventArgs e)
        {
            data = new byte[2048];
            String message = "w";
            data = new ASCIIEncoding().GetBytes(message);
            stream.Write(data, 0, data.Length);

            data = new byte[2048];
            int bytes = stream.Read(data, 0, data.Length);

            data = new byte[2048];
            message = receiver_textBox.Text + ":" + message_TextBox.Text;
            data = new ASCIIEncoding().GetBytes(message);
            stream.Write(data, 0, data.Length);

        }
    }
}
