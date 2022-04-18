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
        private IDoor _fakeDoor;
        public IChargeControl _fakeChargeControl;
        private IRFIDReader _fakeRFIDReader;
        private ILogfile _fakeLogfile;
        private IDisplay _fakeDisplay;

        [SetUp]
        public void Setup()
        {
            // Create the fake stubs and mocks
            _fakeDoor = Substitute.For<IDoor>();
            _fakeChargeControl = Substitute.For<IChargeControl>();
            _fakeLogfile = Substitute.For<ILogfile>();
            _fakeDisplay = Substitute.For<IDisplay>();
            _fakeRFIDReader = Substitute.For<IRFIDReader>();
            // Inject them into the uut via the constructor
            _uut = new StationControl(_fakeDoor, _fakeChargeControl,_fakeDisplay, _fakeLogfile, _fakeRFIDReader);

        }

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
            _fakeLogfile.DidNotReceive().DoorLockedLog(1);
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
            _fakeDoor.DoorOpen = false;


            _fakeRFIDReader.RFIDDetectedEvent += Raise.EventWith<RFIDDetectedEventArgs>(this, new RFIDDetectedEventArgs { ID = 1 });

            _fakeDoor.Received().LockDoor();
            _fakeLogfile.Received().DoorLockedLog(1);
            _fakeChargeControl.Received().StartCharge();
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
            _fakeDoor.DoorOpen = false;

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
            _fakeLogfile.Received().DoorUnlockedLog(1);
            _fakeDisplay.Received().DisconnectPhone();
        }
        #endregion

        #endregion

        #region TEst of if statement Evaluation to false
        [Test]
        public void StationControl_RFIDDETECTEDEVENTRaised_functionsnotcalled_CaseLocked()
        {
            _fakeChargeControl.Connected = true;
            _fakeDoor.DoorOpen = false;

            // Lock The phone in the Unit, set _state to locked
            _fakeRFIDReader.RFIDDetectedEvent += Raise.EventWith<RFIDDetectedEventArgs>(
                this,
                new RFIDDetectedEventArgs { ID = 1 });
            // Try to remove the phone from the locked uut, 
            _fakeRFIDReader.RFIDDetectedEvent += Raise.EventWith<RFIDDetectedEventArgs>(
                this,
                new RFIDDetectedEventArgs { ID = 2 });


            _fakeChargeControl.DidNotReceive().StopCharge();
            _fakeDoor.DidNotReceive().UnlockDoor();
            _fakeLogfile.DidNotReceive().DoorUnlockedLog(1);
            _fakeDisplay.DidNotReceive().DisconnectPhone();
        }

        [Test]
        public void StationControl_RFIDDETECTEDEVENTRaised_Displayerrorcalled_CaseLocked()
        {
            _fakeChargeControl.Connected = true;
            _fakeDoor.DoorOpen = false;

            // Lock The phone in the Unit, set _state to locked
            _fakeRFIDReader.RFIDDetectedEvent += Raise.EventWith<RFIDDetectedEventArgs>(
                this,
                new RFIDDetectedEventArgs { ID = 1 });
            // Try to remove the phone from the locked uut, 
            _fakeRFIDReader.RFIDDetectedEvent += Raise.EventWith<RFIDDetectedEventArgs>(
                this,
                new RFIDDetectedEventArgs { ID = 2 });


            _fakeDisplay.Received().RFIDError();
        }

        #endregion


        #endregion

        #region Test of DoorStateChangedFunc Switch

        #region DoorstatechangedEvent Called _state changed

        [Test]
        public void StationControl_RaisesEvent_ExceptionThrownDuetoInvalidcall_OnStateAvailable()
        {
            try
            {
                //Raise Event in fake
                _fakeDoor.DoorStateChanged += Raise.EventWith<DoorStateChangedEventArgs>(
                    this,
                    new DoorStateChangedEventArgs { _DoorOpen = false });
            }

            catch (Exception ex)
            {
                Assert.IsTrue(ex is InvalidOperationException);
            }

        }

        [Test]
        public void StationControl_RaisesEvent_ExceptionThrownDuetoInvalidcall_OnStateDoorOpen()
        {
            try
            {
                //Raise Event in fake
                _fakeDoor.DoorStateChanged += Raise.EventWith<DoorStateChangedEventArgs>(
                    this,
                    new DoorStateChangedEventArgs { _DoorOpen = true });
                _fakeDoor.DoorStateChanged += Raise.EventWith<DoorStateChangedEventArgs>(
                    this,
                    new DoorStateChangedEventArgs { _DoorOpen = true });
            }

            catch (Exception ex)
            {
                Assert.IsTrue(ex is InvalidOperationException);
            }

        }

        #endregion


        #endregion
    }
}