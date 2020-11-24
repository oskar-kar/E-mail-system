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
        object x = new object();

        public override void AddLog(string s)
        {
            lock (x)
            {
                string text = DateTime.Now.ToString() + " -> " + s + "\n";
                {
                    File.AppendAllText("log.txt", text);
                }
            }
        }
    }
}
