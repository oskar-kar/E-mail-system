using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCP_Server;
using KlasaBD;

namespace SerwerTCP
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerTCP server = new ServerTCPAPM();

            server.Start();
        }
    }
}