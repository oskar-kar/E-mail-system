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

        public override void AddLog(string s)
        {
            lock (locker)
            {
                string text = DateTime.Now.ToString() + " -> " + s + "\n";
                {
                    File.AppendAllText("log.txt", text);
                }
            }
        }
    }
}
