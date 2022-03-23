using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace LadeskabClassLibrary
{
    public class TestLogfile
    {
<<<<<<< HEAD
        private Logfile _uut;
=======

        private Logfile _uut;
        private string path;

>>>>>>> daaa0956dfdf069e0ea80660562e7c776ea86165
        [SetUp]
        public void Setup()
        {
            _uut = new Logfile();
<<<<<<< HEAD
        }

        [Test]
        public void LogFile_Locked()
        {
            if (File.Exists(Logfile._filePath))
            {
                string currentLog = Insertlog();
                _uut.DoorLockedLog(1);
                string newlog = Insertlog();
                Assert.That(newlog.Length, Is.GreaterThan(currentLog.Length));

            }

        }

        [Test]
        public void LogFile_UnLocked()
        {
            if (File.Exists(Logfile._filePath))
            {
                string currentLog = Insertlog();
                _uut.DoorUnlockedLog(1);
                string newlog = Insertlog();
                Assert.That(newlog.Length, Is.GreaterThan(currentLog.Length));

            }

        }
        private string Insertlog()
        {
            string log = "";

            using (StreamReader sr = new StreamReader(Logfile._filePath))
            {
                string xline;
                while ((xline = sr.ReadToEnd()) != null)
                {
                    log = log.Insert(log.Length, xline);
                }
            }
            return log;

        }
=======
            path = "log.txt";

        }


        [Test]
        public void StartCounterIsZero()
        {
            Assert.That(_uut.LogId, Is.Zero);
        }

        [Test]
        public void CounterIsIncrementedAfterLogEntry()
        {
            long counterValueStorage = _uut.LogId;
            string logMessage = "Testing Log Message";

            _uut.LogText(path, logMessage);

            Assert.That(_uut.LogId, Is.EqualTo(counterValueStorage + 1));
        }

        [Test]
        public void LogFileWritesStringToTarget()
        {
            string message = "Testing log writing to test list";
            List<string> logFileListTest = new List<string>();

            _uut.FakeAddLogEntry(message, logFileListTest);

            Assert.That(logFileListTest, Is.Not.Empty);
        }



>>>>>>> daaa0956dfdf069e0ea80660562e7c776ea86165
    }
}
