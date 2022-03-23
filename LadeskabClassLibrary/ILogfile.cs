using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabClassLibrary
{
    public interface ILogfile
    {
        public int LogId { get; set; }

        public string LogFile { get; set; }

        public void LogText(string path, string Log);

    }
}
