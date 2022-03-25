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

        static public string _filePath = "logfile.txt";



        public void DoorUnlockedLog(int id)
        {
            if (id != 0)
            {
                using (StreamWriter writer = File.AppendText(_filePath))
                {
                    writer.WriteLine(DateTime.Now);
                    writer.WriteLine($"Skab låst op med RFID: {id}\n", id);
                    

                }
            }
        }
        public void DoorLockedLog(int id)
        {
            if (id != 0)
            {
                using (StreamWriter writer = File.AppendText(_filePath))
                {
                    writer.WriteLine(DateTime.Now);
                    writer.WriteLine($"Skab låst med RFID: {id}",id);

                }
            }
        }

    }
}
