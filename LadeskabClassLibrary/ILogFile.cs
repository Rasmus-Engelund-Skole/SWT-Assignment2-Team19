using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabClassLibrary
{
    public interface ILogfile
    {
        public string LogFile { get; set; }

        public StreamWriter AppText(string logfile);

        public void DoorUnlockedLog(int id, int hour, int minute, int second);

        public void DoorlockedLog(int id, int hour, int minute, int second);
    }
}
