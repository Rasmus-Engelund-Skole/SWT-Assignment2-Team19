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
            Assert.That(output, Is.EqualTo("Indlæs RFID\r\n"));
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

            var output = stringWriter.ToString();
            Assert.That(output, Is.EqualTo("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.\r\n"));

        }
    }
}
