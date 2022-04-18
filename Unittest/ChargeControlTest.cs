using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using UsbSimulator;

namespace LadeskabClassLibrary
{
    public class ChargeControlTest
    {
        private ChargeControl _uut;
        private IUsbCharger _fakeCharger;
        private IDisplay _fakeDisplay;


        [SetUp]
        public void Setup()
        {
            _fakeCharger = Substitute.For<IUsbCharger>();
            _fakeDisplay = Substitute.For<IDisplay>();
            _uut = new ChargeControl(_fakeCharger, _fakeDisplay);

        }

        [Test]
        public void IsConnectedIsTrue()
        {
            _uut.Connected = true;

            Assert.That(_uut.Connected, Is.True);

        }
      
        [Test]
        public void StopChargeCalled()
        {
            // Act
            _uut.StopCharge();

            // Assert
            _fakeCharger.Received(1).StopCharge();

        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void IsConnected_Returns(bool connectionSts)
        {
            // Assert stub
            _fakeCharger.Connected.Returns(connectionSts);

            // Act
            bool result = _uut.IsConnected();

            // Assert
            Assert.That(result, Is.EqualTo(connectionSts));
        }

        [TestCase(Int32.MinValue)]
        [TestCase(-2)]
        [TestCase(-1)]
        [TestCase(0)]
        public void HandleCurrentChangedEvent_Current0(double newCurrent)
        {
            _fakeCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = newCurrent });
            _fakeDisplay.DidNotReceive().Charging();
            _fakeDisplay.DidNotReceive().DisconnectPhone();
            _fakeDisplay.DidNotReceive().DoneCharging();
            _fakeDisplay.DidNotReceive().ConnectPhone();

        }

        [TestCase(0.1)]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(5)]
        public void HandleCurrentChangedEvent_Current5orLess(double newCurrent)
        {
            _fakeCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = newCurrent });
            _fakeDisplay.DidNotReceive().Charging();
            _fakeDisplay.DidNotReceive().DisconnectPhone();
            _fakeDisplay.Received().DoneCharging();

        }


        [Test]
        [TestCase(5.1)]
        [TestCase(6)]
        [TestCase(300)]
        [TestCase(500)]
        public void HandleCurrentChangedEvent_CurrentCharging(double newCurrent)
        {
            _fakeCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = newCurrent });
            _fakeDisplay.Received().Charging();
            _fakeDisplay.DidNotReceive().DisconnectPhone();
            _fakeDisplay.DidNotReceive().ConnectPhone();

        }

        [Test]
        [TestCase(500.1)]
        [TestCase(525)]
        [TestCase(600)]
        [TestCase(Int32.MaxValue)]
        public void HandleCurrentChangedEvent_currentOver500(double newCurrent)
        {
            _fakeCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = newCurrent });
            _fakeDisplay.Received().DisconnectPhone();
            _fakeDisplay.DidNotReceive().Charging();
        }

        [Test]
        public void StartChargeCalled()
        {
            // Act
            _uut.StartCharge();

            // Assert
            _fakeCharger.Received(1).StartCharge();

        }


    }
}
