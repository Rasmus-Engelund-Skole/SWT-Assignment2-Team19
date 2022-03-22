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
        void ILogfile.AppText(string logfile)
        {
            File.AppendText(logfile);
        }
    }
}
