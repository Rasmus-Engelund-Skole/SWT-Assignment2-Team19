using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabClassLibrary
{

    public interface ILogfile
    {
<<<<<<< HEAD
        public int LogId { get; set; }

        public string LogFile { get; set; }

        public void LogText(string path, string Log);

=======
        static public string _filePath;
>>>>>>> 4a7d1ca14822984b2fb8aecfc18950f026b9a710
        public void DoorUnlockedLog(int id);

        public void DoorLockedLog(int id);
    }
}
