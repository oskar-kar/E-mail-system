using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCP_Server;
using KlasaSerwera;

namespace SerwerTCP
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerTAP<LoginProtocol> server = new ServerTAP<LoginProtocol>();

            server.Start();
        }
    }
}