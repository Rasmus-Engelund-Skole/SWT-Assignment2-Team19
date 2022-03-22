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
        private RFIDReader RFIDReader;
        private ILogfile _fakeLogfile;
        private IDisplay _fakeDisplay;

        [SetUp]
        public void Setup()
        {
            _fakeTimeProvider = Substitute.For<ITimeProvider>();
            _fakeDoor = Substitute.For<IDoor>();
            _fakeChargeControl = Substitute.For<IChargeControl>();
            _fakeLogfile = Substitute.For<ILogfile>();
            _fakeDisplay = Substitute.For<IDisplay>();
            RFIDReader = new RFIDReader();
            _uut= new StationControl(_fakeDoor, _fakeChargeControl,_fakeDisplay, _fakeLogfile);
        }
        
        [Test]
        public void StationControl_RecievesEventfromRFID()
        {
            RFIDReader.SetID(1);

            Assert.That(_uut., Is.True);
        }

    }
}
