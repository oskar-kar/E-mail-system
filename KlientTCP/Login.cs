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
    public partial class Login : Form
    {
        TcpClient client;
        NetworkStream stream;
        Byte[] data = new byte[2048];
        public Login(String ip, int port)
        {
            client = new TcpClient(ip, port);
            InitializeComponent();
            stream = client.GetStream();
            int bytes = stream.Read(data, 0, data.Length);
            String message = Encoding.ASCII.GetString(data, 0, bytes);
            txt_messages_box.AppendText(message + "\n");
            download_button.Enabled = false;
            download_button.BackColor = Color.LightGray;
            change_password_button.Enabled = false;
            change_password_button.BackColor = Color.LightGray;
            send_message_button.Enabled = false;
            send_message_button.BackColor = Color.LightGray;
        }

        private void send_message_button_Click(object sender, EventArgs e)
        { 
            SendMessage sendMessage = new SendMessage(client);
            sendMessage.ShowDialog(this);

            data = new byte[2048];
            int bytes = stream.Read(data, 0, data.Length);
            String message = Encoding.ASCII.GetString(data, 0, bytes);
            txt_messages_box.AppendText(message);

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void login_button_Click(object sender, EventArgs e)
        {
            data = new byte[2048];
            String message = "l";
            data = new ASCIIEncoding().GetBytes(message);
            stream.Write(data, 0, data.Length);

            data = new byte[2048];
            int bytes = stream.Read(data, 0, data.Length);

            data = new byte[2048];
            message = txtLogin.Text + ":" + txtPassword.Text;
            data = new ASCIIEncoding().GetBytes(message);
            stream.Write(data, 0, data.Length);

            data = new byte[2048];
            bytes = stream.Read(data, 0, data.Length);
            message = Encoding.ASCII.GetString(data, 0, bytes);
            txt_messages_box.AppendText(message);

            download_button.Enabled = true;
            download_button.BackColor = Color.White;
            change_password_button.Enabled = true;
            change_password_button.BackColor = Color.White;
            send_message_button.Enabled = true;
            send_message_button.BackColor = Color.White;
        }

        private void messages_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void new_account_button_Click(object sender, EventArgs e)
        {
            data = new byte[2048];
            String message = "l";
            data = new ASCIIEncoding().GetBytes(message);
            stream.Write(data, 0, data.Length);

            data = new byte[2048];
            int bytes = stream.Read(data, 0, data.Length);

            data = new byte[2048];
            message = txtLogin.Text + ":" + txtPassword.Text;
            data = new ASCIIEncoding().GetBytes(message);
            stream.Write(data, 0, data.Length);

            data = new byte[2048];
            bytes = stream.Read(data, 0, data.Length);
            message = Encoding.ASCII.GetString(data, 0, bytes);
            txt_messages_box.AppendText(message);

            download_button.Enabled = true;
            download_button.BackColor = Color.White;
            change_password_button.Enabled = true;
            change_password_button.BackColor = Color.White;
            send_message_button.Enabled = true;
            send_message_button.BackColor = Color.White;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void change_password_button_Click(object sender, EventArgs e)
        {
            data = new byte[2048];
            String message = "c";
            data = new ASCIIEncoding().GetBytes(message);
            stream.Write(data, 0, data.Length);

            data = new byte[2048];
            int bytes = stream.Read(data, 0, data.Length);

            data = new byte[2048];
            message = txtPassword.Text;
            data = new ASCIIEncoding().GetBytes(message);
            stream.Write(data, 0, data.Length);

            data = new byte[2048];
            bytes = stream.Read(data, 0, data.Length);
            message = Encoding.ASCII.GetString(data, 0, bytes);
            txt_messages_box.AppendText(message);
        }

        private void download_button_Click(object sender, EventArgs e)
        {

        }

        private void txt_messages_box_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
