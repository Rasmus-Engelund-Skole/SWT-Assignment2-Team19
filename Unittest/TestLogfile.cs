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
        [SetUp]
        public void Setup()
        {
            _uut = new Logfile();
        }

        [Test]
        public void LogFile_Received_Locked(string logfile,int id)
        {

            StreamWriter sw = new StreamWriter(logfile);
            sw.WriteLine(id);


        }
    }
}
