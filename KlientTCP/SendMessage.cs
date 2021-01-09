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
        TextBox messages;
        public SendMessage(TcpClient client, TextBox textBox)
        {
            InitializeComponent();
            this.client = client;
            stream = client.GetStream();
            messages = textBox;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void message_richTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        public string get_message()
        {
            return message_TextBox.Text;
        }
        private void send_button_Click(object sender, EventArgs e)
        {
            data = new byte[2048];
            String message = receiver_textBox.Text;
            data = new ASCIIEncoding().GetBytes(message);
            stream.Write(data, 0, data.Length);

            data = new byte[2048];
            int bytes = stream.Read(data, 0, data.Length);

            message = message_TextBox.Text;
            data = new byte[2048];
            data = new ASCIIEncoding().GetBytes(message);
            stream.Write(data, 0, data.Length);

            data = new byte[2048];
            bytes = stream.Read(data, 0, data.Length);
            message = Encoding.ASCII.GetString(data, 0, bytes);
            if (message == "Twoja wiadomosc zostala wyslana.\n" +
                            "Masz dostepne nastepujace opcje:\n - zmiany hasla (wprowadz c),\n - napisania wiadomosci (wprowadz wm)\n" +
                                " - odebrania wiadomosci (wprowadz gm)")
            {
                messages.AppendText("Twoja wiadomosc zostala wyslana." + Environment.NewLine);
            }
            else messages.AppendText(message + Environment.NewLine);

            this.Close();

        }
    }
}
