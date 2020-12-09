using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasaSerwera
{
    public class ProtocolResponse
    {
        public string message;
        public string login;

        public ProtocolResponse(string message)
        {
            this.message = message;
            this.login = "";
        }

        public ProtocolResponse(string message, string login)
        {
            this.message = message;
            this.login = login;
        }
    }
}
