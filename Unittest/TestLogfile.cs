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

        private Logfile _uut;
        private string path;

        [SetUp]
        public void Setup()
        {
            _uut = new Logfile();
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



    }
}
