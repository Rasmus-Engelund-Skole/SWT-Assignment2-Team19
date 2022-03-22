using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace LadeskabClassLibrary
{
    public class TestStationControl
    {
        private StationControl _uut;
        private ITimeProvider _fakeTimeProvider;
        private IDoor _fakeDoor;
        private IChargeControl _fakeChargeControl;
        private IRFIDReader _fakeRFIDReader;
        private ILogfile _fakeLogfile;

        [SetUp]
        public void Setup()
        {
            _fakeTimeProvider = Substitute.For<ITimeProvider>();
            _fakeDoor = Substitute.For<IDoor>();
            _fakeChargeControl = Substitute.For<IChargeControl>();
            _fakeLogfile = Substitute.For<ILogfile>();
        
        }
        
        [Test]
        public void GetHour()
        {

        }

    }
}
