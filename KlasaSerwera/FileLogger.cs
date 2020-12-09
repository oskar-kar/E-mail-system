using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KlasaSerwera
{
    public class FileLogger : Logger
    {
        private object locker = new object();

        public override void AddLog(LogMessage log)
        {
            if (!log.message.Trim(' ').Equals(""))
            {
                string text = DateTime.Now.ToString() + " -> " + log.sender + " " + log.endPoint.ToString() + " send message:'" + log.message + "'\n";

                lock (locker)
                {
                    File.AppendAllText("log.txt", text);

                }
            }
        }
    }
}
