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
        public IChargeControl _fakeChargeControl;
        private IRFIDReader _fakeRFIDReader;
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
            _fakeRFIDReader = Substitute.For<IRFIDReader>();
            _uut= new StationControl(_fakeDoor, _fakeChargeControl,_fakeDisplay, _fakeLogfile, _fakeRFIDReader);

        }




        [Test]
        public void ConnectedFalse_StateisAvailable()
        {

            Assert.That(_uut._oldId, Is.EqualTo(0));
            Assert.That(_fakeChargeControl.Connected, Is.EqualTo(false));
            Assert.That(_uut._state, Is.EqualTo(StationControl.LadeskabState.Available));

        }


        [Test]
        public void StationControl_connectedfalse_nofunctionscalled()
        {
            //RFIDReader.SetID(1);


            _fakeDoor.DidNotReceive().LockDoor();
            _fakeChargeControl.DidNotReceive().StartCharge();
            Assert.That(_uut._oldId, Is.EqualTo(0));
            //_fakeLogfile.DidNotReceive().AppText(_fakeLogfile.LogFile);
            Assert.That(_uut._state, Is.EqualTo(StationControl.LadeskabState.Available));
        }


        [Test]
        public void StationControl_connectedtrue_functionscalled()
        {
            _fakeChargeControl.Connected = true;
            _fakeDoor.DoorOpen = false;
            
            //RFIDReader.SetID(1);

            _fakeDoor.Received().LockDoor();
            _fakeChargeControl.Received().StartCharge();
        }


        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(int.MaxValue)]
        public void StationControl_RecievesIDfromRFID(int id)
        {
            _fakeChargeControl.Connected = true;
            _fakeRFIDReader.RFIDDetectedEvent += Raise.EventWith(new RFIDDetectedEventArgs { ID = id });


            Assert.That(_uut._oldId, Is.EqualTo(id));
        }



    }
}
