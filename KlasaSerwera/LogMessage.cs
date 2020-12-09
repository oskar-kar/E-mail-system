using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KlasaSerwera
{
    public class LogMessage
    {
        public string login;
        public string message;
        public EndPoint endPoint;
        public string sender;

        public LogMessage(string message, string sender, EndPoint endPoint, string login = "")
        {
            this.login = login;
            this.message = message;
            this.sender = sender;
            this.endPoint = endPoint;
        }
    }
}
