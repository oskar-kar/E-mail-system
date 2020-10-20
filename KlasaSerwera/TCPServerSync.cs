using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TCP_Server
{

    /// <summary>
    /// TCP Server Class with synchronous connection
    /// </summary>

    public class ServerTCPSync : ServerTCP
    {

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
            TcpClient client = listener.AcceptTcpClient();
            stream = client.GetStream();
            Loop(stream);
        }

        /// <summary>
        /// Main TCP Server work cycle function
        /// returns factorial (silnia) of positive integer (up to 20)
        /// </summary>

        protected override void Loop(NetworkStream stream)
        {
            byte[] buffer = new byte[size];
            while (true)
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
            }
        }
    }
}