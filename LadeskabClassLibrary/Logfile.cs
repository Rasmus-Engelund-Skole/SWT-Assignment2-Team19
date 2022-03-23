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
        public string LogFile { get; set; }

        public StreamWriter AppText(string logfile)
        {
            return File.AppendText(logfile);
        }
        public void DoorUnlockedLog(RFIDReader id, TimeProvider hour, TimeProvider minute, TimeProvider second)
        {
            Log(DateTime.Now + ": Skab låst op med RFID: { 0 } ", id);

        }
        private void Log(string logEntry, RFIDReader id)
        {
            using (StreamWriter writer = File.AppendText(_filePath))
            {
                writer.Write("LogEntries for Charges: ");
                writer.WriteLine($" :{logEntry}");

            }
        }
    }
}
