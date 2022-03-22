using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;


namespace LadeskabClassLibrary
{
    public class TestTimeProvider
    {
        private ITimeProvider _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new TimeProvider();
        }

        [Test]
        public void GetHour_()
        {
            var hour = _uut.getHour();

            var now = DateTime.Now.Hour;

            //assert
            Assert.AreEqual(now, hour);
        }

        [Test]
        public void GetMinute_()
        {
            var min = _uut.getMinute();

            var now = DateTime.Now.Minute;

            //assert
            Assert.AreEqual(now, min);
        }

        [Test]
        public void GetSecond_()
        {
            var sec = _uut.getSecond();

            var now = DateTime.Now.Second;

            //assert
            Assert.AreEqual(now, sec);
        }

    }

    
}
