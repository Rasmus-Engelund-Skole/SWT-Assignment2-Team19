using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace LadeskabClassLibrary
{
    
    public class TestRFIDReader
    {
        private RFIDReader _uut;
        private RFIDDetectedEventArgs _detectedEventArgs;

        [SetUp]
        public void Setup()
        {
            _uut = new RFIDReader();
            _detectedEventArgs = null;

            //Event listener to check the event occurence and event data
            _uut.RFIDDetectedEvent +=
                (o, args) =>
                {
                    _detectedEventArgs = args;
                };

        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        public void PositiveSetid_EventFired(int id) //tester om vi har modtaget eventet i vores rfid subjekt med postive ID'er
        {
            _uut.SetID(id);
            Assert.That(_detectedEventArgs, Is.Not.Null);
        }

        [Test]
        [TestCase(0)]
        public void ZeroSetid_ThrowsException(int id) //tester om exception bliver kastet ved ID = 0
        {
            try
            {
                _uut.SetID(id);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentOutOfRangeException);
            }
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-4)]
        public void NegativeSetid_ThrowsException(int id) //tester om exception bliver kastet ved negative værdier til ID
        {
            try
            {
                _uut.SetID(id);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentOutOfRangeException);
            }
        }


        [Test]
        public void Virgin_idValue()
        {

            Assert.That(_uut.CurrentID == 0);

        }


        [Test]
        public void Setid_positiv_int()
        {
            _uut.SetID(10);

            Assert.That(_uut.CurrentID == 10);

        }

        [Test]
        public void Setid_Negativ_int_ThrowsException()
        {
            try
            {
                _uut.SetID(-10);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentOutOfRangeException);
            }
        }

    }
}
