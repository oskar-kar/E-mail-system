using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using KlasaBD;

namespace TCP_Server
{

    /// <summary>
    /// TCP Server Class with asynchronous connection
    /// </summary>

    public class ServerTCPAPM : ServerTCP
    {
        public delegate void TransmissionDelegate(NetworkStream stream);

        /// <summary>
        /// TCP Listener initialization function
        /// </summary>

        public override void Start()
        {
            listener.Start();
            Accept();
        }

        /// <summary>
        /// Function accepting connection from client
        /// </summary>

        protected override void Accept()
        {
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                stream = client.GetStream();
                TransmissionDelegate Tdelegate = new TransmissionDelegate(Loop);
                Tdelegate.BeginInvoke(stream, Callback, client);
            }
        }

        /// <summary>
        /// Function ending Transmission delegate
        /// </summary>

        private void Callback(IAsyncResult r)
        {
            TcpClient client = (TcpClient)r.AsyncState;
            client.Close();
        }

        /// <summary>
        /// Main TCP Server work cycle function
        /// </summary>

        protected override void Loop(NetworkStream stream)
        {
            DB db = new DB();
            int first = 1;
            byte[] buffer = new byte[size];
            bool done = false, newUser = false, connected = false, l_once = false, p_once = false;
            string login = "", password = "";
            while(done == false)
            {
                if (first == 1)
                {
                    string firstText = "Jesli chcesz dodac nowego uzytkownika wprowadz n, jesli chcesz sie zalogowac napisz l\n";
                    byte[] outbuffer = new ASCIIEncoding().GetBytes(firstText);
                    stream.Write(outbuffer, 0, outbuffer.Length);
                    first = first + 1;
                }
                else
                {
                    stream.Read(buffer, 0, size);
                    text = Encoding.UTF8.GetString(buffer, 0, buffer.Length).Trim('\0');
                    if (text.Contains("n"))
                    {
                        while(newUser == false)
                        {
                            if (l_once == false)
                            {
                                stream.Read(buffer, 0, size);
                                string mess = "Wpisz login dla nowego uzytkownika: ";
                                byte[] outbuffer = new ASCIIEncoding().GetBytes(mess);
                                stream.Write(outbuffer, 0, outbuffer.Length);
                                Array.Clear(buffer, 0, buffer.Length);
                                stream.Read(buffer, 0, size);
                                text = Encoding.UTF8.GetString(buffer, 0, buffer.Length).Trim('\0');
                                login = text;
                                l_once = true;
                            }
                            else if(l_once == true && p_once == false)
                            {
                                stream.Read(buffer, 0, size);
                                string mess = "Wpisz haslo dla nowego uzytkownika: ";
                                byte[] outbuffer = new ASCIIEncoding().GetBytes(mess);
                                stream.Write(outbuffer, 0, outbuffer.Length);
                                Array.Clear(buffer, 0, buffer.Length);
                                stream.Read(buffer, 0, size);
                                text = Encoding.UTF8.GetString(buffer, 0, buffer.Length).Trim('\0');
                                password = text;
                                p_once = true;
                            } else if (l_once == true && p_once == true)
                            {
                                newUser = db.AddUser(login, password);
								if(newUser == false)
								{
									string mess = "Nie utworzono nowego uzytkownika.\n";
									byte[] outbuffer = new ASCIIEncoding().GetBytes(mess);
									stream.Write(outbuffer, 0, outbuffer.Length);
									Array.Clear(buffer, 0, buffer.Length);
									login = "";
									password = "";
                                    first = 1;
								} else 
								{
							        string mess = "Utworzono nowego uzytkownika i zalogowano sie. \n";
                                    byte[] outbuffer = new ASCIIEncoding().GetBytes(mess);
                                    stream.Write(outbuffer, 0, outbuffer.Length);
                                    Array.Clear(buffer, 0, buffer.Length);
                                    done = true;
								}
                                l_once = false;
                                p_once = false;
                            }
                        }
                    } else if (text.Contains("l"))
                    {
                        while (connected == false)
                        {
                            if (login.Length == 0 && l_once == false)
                            {
                                stream.Read(buffer, 0, size);
                                string mess = "Wpisz login uzytkownika: ";
                                byte[] outbuffer = new ASCIIEncoding().GetBytes(mess);
                                stream.Write(outbuffer, 0, outbuffer.Length);
                                Array.Clear(buffer, 0, buffer.Length);
                                stream.Read(buffer, 0, size);
                                text = Encoding.UTF8.GetString(buffer, 0, buffer.Length).Trim('\0');
                                login = text;
                                l_once = true;
                            }
                            else if (password.Length == 0 && l_once == true && p_once == false)
                            {
                                stream.Read(buffer, 0, size);
                                string mess = "Wpisz haslo uzytkownika: ";
                                byte[] outbuffer = new ASCIIEncoding().GetBytes(mess);
                                stream.Write(outbuffer, 0, outbuffer.Length);
                                Array.Clear(buffer, 0, buffer.Length);
                                stream.Read(buffer, 0, size);
                                text = Encoding.UTF8.GetString(buffer, 0, buffer.Length).Trim('\0');
                                password = text;
                                p_once = true;
                            }
                            else if (l_once == true && p_once == true)
                            {
                                connected = db.AuthenticateUser(login, password);
                                if(connected == false)
                                {
                                    String mess = "Zostalo podane zle haslo lub/i login.\n";
                                    byte[] outbuffer = new ASCIIEncoding().GetBytes(mess);
                                    stream.Write(outbuffer, 0, outbuffer.Length);
                                    Array.Clear(buffer, 0, buffer.Length);
                                    login = "";
                                    password = "";
                                    first = 1;
                                } else
                                {
                                    string mess = "Zalogowano uzytkownika.\n";
                                    byte[] outbuffer = new ASCIIEncoding().GetBytes(mess);
                                    stream.Write(outbuffer, 0, outbuffer.Length);
                                    Array.Clear(buffer, 0, buffer.Length);
                                    done = true;
                                }
                                l_once = false;
                                p_once = false;
                            }
                        }
                    }
                    else
                    {
                        stream.Read(buffer, 0, size);
						first = 1;
                        string mess = "Niepoprawna komenda.\n";
                        byte[] outbuffer = new ASCIIEncoding().GetBytes(mess);
                        stream.Write(outbuffer, 0, outbuffer.Length);
                        Array.Clear(buffer, 0, buffer.Length);
                    }
                }
            }
            while(done == true)
                {
                }
            

            /*while (true)
            {
                stream.Read(buffer, 0, size);
                text = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                if (int.TryParse(text, out x))
                {
                    outcome = x;
                    while (x > 1)
                    {
                        x--;
                        outcome = outcome * x;
                    }
                    string mess = outcome.ToString();
                    byte[] outbuffer = new ASCIIEncoding().GetBytes(mess);
                    stream.Write(outbuffer, 0, outbuffer.Length);
                    Array.Clear(buffer, 0, buffer.Length);
                }
            }*/
        }
    }
}