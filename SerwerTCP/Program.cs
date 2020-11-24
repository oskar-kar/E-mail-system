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
            Logger log = new FileLogger();
            ServerTAP<LoginProtocol> server = new ServerTAP<LoginProtocol>("127.0.0.1", 4444, log);
            server.Start();
        }
    }
}