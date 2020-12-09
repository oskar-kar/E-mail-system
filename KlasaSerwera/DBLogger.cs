using KlasaBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasaSerwera
{
    public class DBLogger : Logger
    {
        private DB db = new DB();

        public override void AddLog(LogMessage log)
        {
            if (!log.message.Trim(' ').Equals(""))
            {
                db.AddLog(log.login, log.sender, log.message.Trim('\0', '\r', '\n', ' '), log.endPoint.ToString());
            }
        }
    }
}
