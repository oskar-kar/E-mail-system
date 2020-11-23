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
    /// TCP Server Class with asynchronous connection
    /// </summary>

    public class ServerTCPAPM<T> : ServerTCP<T> where T : ComunicationProtocol, new()
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

    }
}