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

        [SetUp]
        public void Setup()
        {
            _fakeTimeProvider = Substitute.For<ITimeProvider>();
            _fakeDoor = Substitute.For<IDoor>();
            _fakeChargeControl = Substitute.For<IChargeControl>();
        
        }
        
        [Test]
        public void GetHour()
        {

        }

    }
}
