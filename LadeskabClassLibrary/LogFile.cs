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

<<<<<<< HEAD
        public Logfile()
        {
            LogId = 0;  
        }

        public void LogText(string path, string Log)
        {
            LogFile = path;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Id: " + LogId);
            stringBuilder.Append("Log time: " + DateTime.Now);
            stringBuilder.Append("Message: " + Log + "\n");
            File.AppendAllText(LogFile, stringBuilder.ToString());
            stringBuilder.Clear();
            
            LogId++;
        }


        public void FakeAddLogEntry(string message, List<string> logList)
        {
            // Metoden er en fake og er lavet for testing-purpose

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Id: " + LogId + " - ");
            stringBuilder.Append("Log time: " + DateTime.Now + " - ");
            stringBuilder.Append("Message: " + message + "\n");

            logList.Add(stringBuilder.ToString());

            LogId++;
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
