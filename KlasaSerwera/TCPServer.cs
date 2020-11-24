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
        protected TcpListener listener;
        protected NetworkStream stream;
        protected Logger logger = new FileLogger();

        public ServerTCP(string ip, int port, Logger logger = null)
        {
            this.listener = new TcpListener(IPAddress.Parse(ip), port);
            this.logger = logger;
        }
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

        protected void Loop(NetworkStream stream, EndPoint endPoint)
        {
            byte[] buffer = new byte[size];
            bool done = false;
            ComunicationProtocol protocol = new T();
            buffer = new ASCIIEncoding().GetBytes(protocol.GetDescription());
            stream.Write(buffer, 0, buffer.Length);
            if (logger != null) logger.AddLog("Server send message : '" + Encoding.UTF8.GetString(buffer).Trim() + "' to client " + endPoint);
            while (done == false)
            {
                buffer = new byte[size];
                stream.Read(buffer, 0, size);
                if (logger != null) logger.AddLog("Server received message : '" + Encoding.UTF8.GetString(buffer).Trim() + "' from client " + endPoint);
                string response = protocol.GenerateResponse(Encoding.UTF8.GetString(buffer));
                if (!response.Equals(""))
                {
                    buffer = new ASCIIEncoding().GetBytes(response);
                    stream.Write(buffer, 0, buffer.Length);
                    if (logger != null) logger.AddLog("Server send message : '" + Encoding.UTF8.GetString(buffer).Trim() + "' to client " + endPoint);
                }
            }
        }
    }
}
