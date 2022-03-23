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
        // member variables to hold uut and fakes
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
            // Create the fake stubs and mocks
            _fakeTimeProvider = Substitute.For<ITimeProvider>();
            _fakeDoor = Substitute.For<IDoor>();
            _fakeChargeControl = Substitute.For<IChargeControl>();
            _fakeLogfile = Substitute.For<ILogfile>();
            _fakeDisplay = Substitute.For<IDisplay>();
            _fakeRFIDReader = Substitute.For<IRFIDReader>();
            // Inject them into the uut via the constructor
            _uut = new StationControl(_fakeDoor, _fakeChargeControl,_fakeDisplay, _fakeLogfile, _fakeRFIDReader);

        }

        #region VirginValues _uut
        [Test]
        public void StationControl_VirginValues_CorrectValues()
        {

            Assert.That(_uut._oldId, Is.EqualTo(0));
            Assert.That(_fakeChargeControl.Connected, Is.EqualTo(false));
            Assert.That(_uut._state, Is.EqualTo(StationControl.LadeskabState.Available));

        }
        #endregion

        #region Test of RFIDDetected Swicth statement, Case Ladeskabsstate.Available

        #region RFIDEvent called but no functions called
        [Test]
        public void StationControl_connectedfalse_nofunctionscalled()
        {
            _fakeRFIDReader.RFIDDetectedEvent += Raise.EventWith<RFIDDetectedEventArgs>(
                this,
                new RFIDDetectedEventArgs { ID = 1 });


            _fakeDoor.DidNotReceive().LockDoor();
            _fakeChargeControl.DidNotReceive().StartCharge();
            Assert.That(_uut._oldId, Is.EqualTo(0));
            _fakeLogfile.DidNotReceive().AppText(_fakeLogfile.LogFile);
            Assert.That(_uut._state, Is.EqualTo(StationControl.LadeskabState.Available));
        }
        #endregion

        #region RFIDEvent called but no Phone connected, state = Available
        [Test]
        public void StationControl_connectedfalse_DisplayConnectErrorcalled()
        {
            _fakeRFIDReader.RFIDDetectedEvent += Raise.EventWith<RFIDDetectedEventArgs>(
                this,
                new RFIDDetectedEventArgs { ID = 1 });

            _fakeDisplay.Received(1).ConnectError();
        }
        #endregion

        #region RFIDEvent Calls Function
        [Test]
        public void StationControl_EventHandling_connectedtrue_RFIDDETECTEDEVENTRaised_functionscalled()
        {
            _fakeChargeControl.Connected = true;
            _fakeDoor.IsLocked = false;


            _fakeRFIDReader.RFIDDetectedEvent += Raise.EventWith<RFIDDetectedEventArgs>(this, new RFIDDetectedEventArgs { ID = 1 });

            _fakeDoor.Received().LockDoor();
            _fakeChargeControl.Received().StartCharge();
            Assert.That(_uut._state, Is.EqualTo(StationControl.LadeskabState.Locked));
        }
        #endregion

        #region RFIDEVent reception test
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(int.MaxValue)]
        public void StationControl_RecievesIDfromRFID(int id)
        {
            //Make sure we take the right way through the RFIDDetected switch
            _fakeChargeControl.Connected = true;
            //Raise Event in fake
            _fakeRFIDReader.RFIDDetectedEvent += Raise.EventWith<RFIDDetectedEventArgs>(
                this,
                new RFIDDetectedEventArgs { ID = id });

            // This asserts that uut has connected to the event
            // And handles value correctly
            Assert.That(_uut._oldId, Is.EqualTo(id));
        }


        #endregion

        #endregion

        #region Test of RFIDDetected Switch statement, Case LadeSkabsstate.Locked 

        #region Test of if statement evaluation to true.

        #region Test that the functions to be called are called
        [Test]
        public void StationControl_RFIDDETECTEDEVENTRaised_functionscalled_CaseLocked()
        {
            _fakeChargeControl.Connected = true;
            _fakeDoor.IsLocked = false;

            // Lock The phone in the Unit, set _state to locked
            _fakeRFIDReader.RFIDDetectedEvent += Raise.EventWith<RFIDDetectedEventArgs>(
                this,
                new RFIDDetectedEventArgs { ID = 1 });
            // Try to remove the phone from the locked uut, 
            _fakeRFIDReader.RFIDDetectedEvent += Raise.EventWith<RFIDDetectedEventArgs>(
                this,
                new RFIDDetectedEventArgs { ID = 1 });


            _fakeChargeControl.Received(1).StopCharge();
            _fakeDoor.Received().UnlockDoor();
            _fakeDisplay.Received().DisconnectPhone();
            Assert.That(_uut._state, Is.EqualTo(StationControl.LadeskabState.Available));
        }
        #endregion

        #region Test that OldId equals Id
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(int.MaxValue,int.MaxValue)]
        public void StationControl_RFIDDETECTEDEVENTRaised_OldId_isequal_toNewId_CaseLocked(int id)
        {
            _fakeChargeControl.Connected = true;
            _fakeDoor.IsLocked = false;

            // Lock The phone in the Unit, set _state to locked
            _fakeRFIDReader.RFIDDetectedEvent += Raise.EventWith<RFIDDetectedEventArgs>(
                this,
                new RFIDDetectedEventArgs { ID = id});
            // Try to remove the phone from the locked uut, 
            _fakeRFIDReader.RFIDDetectedEvent += Raise.EventWith<RFIDDetectedEventArgs>(
                this,
                new RFIDDetectedEventArgs { ID = id });

            // This asserts that uut has connected to the event
            // And handles value correctly
            Assert.That(_uut._oldId, Is.EqualTo(id));
        }
        #endregion

        #endregion



        #endregion
    }
}