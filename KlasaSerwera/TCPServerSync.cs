using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using KlasaBD;
using KlasaSerwera;

namespace TCP_Server
{

    /// <summary>
    /// TCP Server Class with synchronous connection
    /// </summary>

    public class ServerTCPSync<T> : ServerTCP<T> where T : ComunicationProtocol, new()
    {
        public ServerTCPSync(string ip, int port, Logger logger = null) : base(ip, port, logger)
        {
        }
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
            Loop(stream, client.Client.RemoteEndPoint);
        }
    }
}