using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasaSerwera
{
    public abstract class ComunicationProtocol
    {
        public abstract string GenerateResponse(string message);
        public abstract string GetDescription();
    }
}
