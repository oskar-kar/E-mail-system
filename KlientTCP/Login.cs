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
using System.Threading;

namespace KlientTCP
{
    public partial class Login : Form
    {
        TcpClient client;
        NetworkStream stream;
        Byte[] data = new byte[2048];
        public delegate void ShowForm(object sender, EventArgs e);
        public Login(String ip, int port)
        {
            client = new TcpClient(ip, port);
            InitializeComponent();
            stream = client.GetStream();
            int bytes = stream.Read(data, 0, data.Length);
            String message = Encoding.ASCII.GetString(data, 0, bytes);
            if (message == "Jesli chcesz dodac nowego uzytkownika wprowadz n, jesli chcesz sie zalogowac napisz l\n")
            {
                txt_messages_box.AppendText("Połączono z serwerem, zaloguj się lub załóż nowe konto" + Environment.NewLine);
            }
            else
            {
                txt_messages_box.AppendText(message + Environment.NewLine);
            }
            download_button.Enabled = false;
            download_button.BackColor = Color.LightGray;
            change_password_button.Enabled = false;
            change_password_button.BackColor = Color.LightGray;
            send_message_button.Enabled = false;
            send_message_button.BackColor = Color.LightGray;
        }

        private void Send_message_button_Click(object sender, EventArgs e)
        {
            data = new byte[2048];
            String message = "wm";
            data = new ASCIIEncoding().GetBytes(message);
            stream.Write(data, 0, data.Length);

            data = new byte[2048];
            int bytes = stream.Read(data, 0, data.Length);

            
            SendMessage sendMessage = new SendMessage(client, txt_messages_box);
            sendMessage.Show();
            

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
            message = message.Trim();
            if (message == "Pomyslnie zalogowano. \nPo zalogowaniu masz dostepne nastepujace opcje:\n - zmiany hasla " +
                                "(jesli chcesz z niej skorzystac wprowadz c),\n - napisania wiadomosci (jesli chcesz z niej skorzystac wprowadz wm)\n" +
                                " - odebrania wiadomosci (jesli chcesz z niej skorzystac wprowadz gm)")
            {
                txt_messages_box.AppendText("Pomyslnie zalogowano." + Environment.NewLine + 
                    "Po zalogowaniu masz dostepne nastepujace opcje:" + Environment.NewLine +  "- zmiany hasla " + Environment.NewLine +
                                "- napisania wiadomosci" + Environment.NewLine +
                                " - odebrania wiadomosci" + Environment.NewLine );

                download_button.Enabled = true;
                download_button.BackColor = Color.White;
                change_password_button.Enabled = true;
                change_password_button.BackColor = Color.White;
                send_message_button.Enabled = true;
                send_message_button.BackColor = Color.White;
            }
            else
            {
                txt_messages_box.AppendText(message);
            }
        }

        private void messages_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void new_account_button_Click(object sender, EventArgs e)
        {
            data = new byte[2048];
            String message = "n";
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
            message = Encoding.UTF8.GetString(data, 0, bytes);
            message = message.Trim();
            if (message == "Utworzono nowego uzytkownika i zalogowano sie. \nPo zalogowaniu masz dostepne nastepujace opcje:\n - zmiany hasla " +
                                "(jesli chcesz z niej skorzystac wprowadz c),\n - napisania wiadomosci (jesli chcesz z niej skorzystac wprowadz wm)\n" +
                                " - odebrania wiadomosci (jesli chcesz z niej skorzystac wprowadz gm)")
            {
                txt_messages_box.AppendText("Pomyslnie utworzone konto i zalogowano." + Environment.NewLine +
                    "Po zalogowaniu masz dostepne nastepujace opcje:" + Environment.NewLine + "- zmiany hasla " + Environment.NewLine +
                                "- napisania wiadomosci" + Environment.NewLine +
                                " - odebrania wiadomosci" + Environment.NewLine);

                download_button.Enabled = true;
                download_button.BackColor = Color.White;
                change_password_button.Enabled = true;
                change_password_button.BackColor = Color.White;
                send_message_button.Enabled = true;
                send_message_button.BackColor = Color.White;
            }
            else
            {
                txt_messages_box.AppendText(message);
            }
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
            data = new byte[2048];
            String message = "gm";
            data = new ASCIIEncoding().GetBytes(message);
            stream.Write(data, 0, data.Length);

            data = new byte[4096];
            int bytes = stream.Read(data, 0, data.Length);
            message = Encoding.ASCII.GetString(data, 0, bytes);
            txt_messages_box.AppendText(message + Environment.NewLine);
        }

        private void txt_messages_box_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
