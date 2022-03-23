using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace LadeskabClassLibrary
{
    public class TestChargeControl
    {
        private ChargeControl _uut;
        private IDisplay _fakeDisplay;
        //private IUsbCharger _fakeUsbCharger;


        [SetUp]
        public void SetUp()
        {
            _fakeDisplay = Substitute.For<IDisplay>();
            //_fakeUsbCharger = Substitute.For<IUsbCharger>();

            //_uut = new ChargeControl(_fakeUsbCharger, _fakeDisplay);
        }

        [Test]
        public void StartCharge()
        {

        }

        [Test]
        public void StopCharge()
        {

        }

    }
}
