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

        public string logFile = "logfile.txt"; // Navnet på systemets log-fil
        StreamWriter ILogfile.AppText(string logfile)
        {
            return File.AppendText(logfile);
        }
    }
}
