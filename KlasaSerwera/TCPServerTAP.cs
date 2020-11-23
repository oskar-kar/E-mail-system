using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using KlasaSerwera;
using TCP_Server;

namespace KlasaSerwera

{   /// <summary>
    /// TCP Server Class with asynchronous connection
     /// </summary>
    public class ServerTAP<T> : ServerTCP<T> where T : ComunicationProtocol, new()
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
                Task task = listener.AcceptTcpClientAsync().ContinueWith(
                    (accept_task) =>
                    {
                        TcpClient client = accept_task.Result;
                        Loop(client.GetStream());
                    }
                    );   
                
            }
        }

    }
}
