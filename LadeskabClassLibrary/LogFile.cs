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
        public int LogId { get; set; }

        public string LogFile { get; set; }

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
    }
}
