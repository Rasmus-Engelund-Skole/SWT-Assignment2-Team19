﻿using System;
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
        public void Logfile_Exist()
        {
            _uut.DoorLockedLog(1);

            Assert.IsTrue(File.Exists(Logfile._filePath));

        }

        [Test]
        public void LogFile_Locked_LogAdded()
        {
                string currentLog = Insertlog();
                _uut.DoorLockedLog(1);
                string newlog = Insertlog();

                Assert.That(newlog.Length, Is.GreaterThan(currentLog.Length));


        }

        [Test]
        public void LogFile_UnLocked_LogAdded()
        {
                string currentLog = Insertlog();
                _uut.DoorUnlockedLog(1);
                string newlog = Insertlog();


                Assert.That(newlog.Length, Is.GreaterThan(currentLog.Length));


        }

        //[Test]
        //public void LogFile_Unlocked_LogQuantity()
        //{
        //    if(!File.Exists(Logfile._filePath))
        //    {
        //        int; 

        //    }



        
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
    }
}
