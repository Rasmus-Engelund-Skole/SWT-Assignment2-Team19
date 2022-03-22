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

        [SetUp]
        public void Setup()
        {
            _uut = new RFIDReader();
        }

        [Test]
        public void Setid_positiv_int()
        {
            _uut.SetID(10);

            Assert.That(_uut.CurrentID == 10);

        }

        [Test]
        public void Setid_Negativ_int()
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
