using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace LadeskabClassLibrary
{
    [TestFixture]
    public class TestDisplay
    {
        private Display _display;

        [SetUp]
        public void SetUp()
        {
            _display = new Display();
        }

        [Test]
        public void ConnectPhone()
        {
            //_display.ConnectPhone();
            //_display.Received(1).ConnectPhone();
        }

        [Test]
        public void DisconnectPhone()
        {
            _display.DisconnectPhone();
            _display.Received(1).DisconnectPhone();
        }

        [Test]
        public void ConnectError()
        {
            _display.ConnectError();
            _display.Received(1).ConnectError();
        }

        [Test]
        public void ReadRFID()
        {
            _display.ReadRFID();
            _display.Received(1).ReadRFID();
        }

        [Test]
        public void RFIDError()
        {
            _display.RFIDError();
            _display.Received(1).RFIDError();
        }
        
        [Test]
        public void Charging()
        {
            _display.Charging();
            _display.Received(1).Charging();
        }
    }
}
