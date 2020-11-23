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
            ServerTCP<LoginProtocol> server = new ServerTCPAPM<LoginProtocol>();

            server.Start();
        }
    }
}