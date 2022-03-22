using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LadeskabClassLibrary
{
    public class Logfile : ILogfile
    {
        public string LogFile { get; set; }

        public StreamWriter AppText(string logfile)
        {
            return File.AppendText(logfile);
        }
    }
}
