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
        public void ConnectedFalse_StateisAvailable()
        {

            Assert.That(_uut._oldId, Is.EqualTo(0));
            Assert.That(_fakeChargeControl.Connected, Is.EqualTo(false));
            Assert.That(_uut._state, Is.EqualTo(StationControl.LadeskabState.Available));

        }


        [Test]
        public void StationControl_connectedfalse_nofunctionscalled()
        {
            RFIDReader.SetID(1);


            _fakeDoor.DidNotReceive().LockDoor();
            _fakeChargeControl.DidNotReceive().StartCharge();
            Assert.That(_uut._oldId, Is.EqualTo(0));
            _fakeLogfile.DidNotReceive().AppText(_fakeLogfile.LogFile);
            Assert.That(_uut._state, Is.EqualTo(StationControl.LadeskabState.Available));
        }


        [Test]
        [TestCase(1,1)]
        [TestCase(2,2)]
        [TestCase(3,3)]
        [TestCase(int.MaxValue,int.MaxValue)]
        public void StationControl_RecievesIDfromRFID(int id, int result)
        {
            _fakeChargeControl.Connected = true;

            RFIDReader.SetID(id);


            Assert.That(_uut._oldId, Is.EqualTo(result));
        }



    }
}
