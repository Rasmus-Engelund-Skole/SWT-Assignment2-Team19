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
        public void DoorUnlockedLog(int id)
        {
            Log("Skab låst op med RFID: { 0 } ", id);

        }
        public void DoorLockedLog(int id)
        {
            Log("Skab låst med RFID: { 0 } ", id);

        }
        private void Log(string logEntry, int id)
        {
            using (StreamWriter writer = File.AppendText(_filePath))
            {

                writer.Write("Log indlæg for opladninger: ");
                writer.WriteLine($" :{logEntry}");
                writer.WriteLine(DateTime.Now);

            }
        }
    }
}
