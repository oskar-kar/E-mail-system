using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using KlasaSerwera;

namespace TCP_Server
{

    /// <summary>
    /// Abstract TCP Server Class
    /// </summary>

    public abstract class ServerTCP<T> where T : ComunicationProtocol, new()
    {
        protected int x;
        protected long outcome;
        protected static int size = 2048;
        protected string text;
        protected TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 4444);
        protected NetworkStream stream;

        /// <summary>
        /// TCP Listener initialization function
        /// </summary>

        public abstract void Start();

        /// <summary>
        /// Function accepting connection from client
        /// </summary>

        protected abstract void Accept();

        /// <summary>
        /// Main TCP Server work cycle function
        /// returns factorial (silnia) of positive integer (up to 20)
        /// </summary>

        protected void Loop(NetworkStream stream)
        {
            byte[] buffer = new byte[size];
            bool done = false;
            ComunicationProtocol protocol = new T();
            buffer = new ASCIIEncoding().GetBytes(protocol.GetDescription());
            stream.Write(buffer, 0, buffer.Length);
            while (done == false)
            {
                buffer = new byte[size];
                stream.Read(buffer, 0, size);
                string response = protocol.GenerateResponse(Encoding.UTF8.GetString(buffer));
                if (!response.Equals(""))
                {
                    buffer = new ASCIIEncoding().GetBytes(response);
                    stream.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}