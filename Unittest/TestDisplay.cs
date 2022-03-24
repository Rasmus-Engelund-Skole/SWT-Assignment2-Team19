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
        private Display _uut;

        [SetUp]
        public void SetUp()
        {
            _uut = new Display();
        }

        [Test]
        public void ConnectPhone()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            _uut.ConnectPhone();

            //assert
            var output = stringWriter.ToString();
            Assert.That(output, Is.EqualTo("Tilslut Telefon\r\n"));
        }

        [Test]
        public void DisconnectPhone()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            _uut.DisconnectPhone();

            //assert
            var output = stringWriter.ToString();
            Assert.That(output, Is.EqualTo("Fjern Telefon\r\n"));

        }

        [Test]
        public void ConnectError()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            _uut.ConnectError();

            //assert
            var output = stringWriter.ToString();
            Assert.That(output, Is.EqualTo("Tilslutningsfejl\r\n"));
        }

        [Test]
        public void ReadRFID()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            _uut.ReadRFID();

            //assert
            var output = stringWriter.ToString();
            Assert.That(output, Is.EqualTo("Døren er lukket, Indlæs RFID\r\n"));
        }

        [Test]
        public void RFIDError()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            _uut.RFIDError();

            //assert
            var output = stringWriter.ToString();
            Assert.That(output, Is.EqualTo("RFID Fejl\r\n"));
        }

        [Test]
        public void Charging()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            _uut.Charging();

            //assert 
            var output = stringWriter.ToString();
            Assert.That(output, Is.EqualTo("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.\r\n"));

        }
        [Test]
        public void CloseDoor()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            _uut.CloseDoor();

            //assert
            var output = stringWriter.ToString();
            Assert.That(output, Is.EqualTo("Døren er Åben, Den skal lukkes inden skabet kan låses.\r\n"));
        }
        [Test]
        public void DoorOpen()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            _uut.DoorOpen();

            //assert
            var output = stringWriter.ToString();
            Assert.That(output, Is.EqualTo("Døren er Åben\r\n"));
        }
        [Test]
        public void Connected()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            _uut.Connected();

            //assert
            var output = stringWriter.ToString();
            Assert.That(output, Is.EqualTo("Telefonen er tilsluttet\r\n"));
        }
        [Test]
        public void Disconnected()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            _uut.Disconnected();

            //assert
            var output = stringWriter.ToString();
            Assert.That(output, Is.EqualTo("Telefonen er frakoblet\r\n"));

        }
        [Test]
        public void DoneCharging()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            _uut.DoneCharging();

            //assert
            var output = stringWriter.ToString();
            Assert.That(output, Is.EqualTo("Skabet er låst og din telefon er færdig med at lade op. Brug dit RFID tag til at låse skabet op.\r\n"));

        }
    }
}
