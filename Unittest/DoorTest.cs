﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;

namespace LadeskabClassLibrary
{
    public class DoorTest
    {
        private Door _uut;
        private DoorStateChangedEventArgs _receivedEventArgs;


        [SetUp]
        public void Setup()
        {
            _receivedEventArgs = null;
            _uut = new Door();
            _uut.IsLocked = false;
            
            //Event listener to check the event occurence and event data
            _uut.DoorStateChanged +=
                (o, args) =>
                {
                    _receivedEventArgs = args;
                };
        }

        [Test]
        public void OnDoorOpen_EventFired() //tester om vi har modtaget eventet i vores door subjekt
        {
            _uut.IsLocked = true;
            _uut.SetDoorState(false);
            Assert.That(_receivedEventArgs, Is.Not.Null);
        }

        [Test]
        public void DoorOpen_CorrectValueReceived() //tester at DoorOpen er true
        {
            _uut.SetDoorState(true);

            Assert.That(_receivedEventArgs._DoorOpen, Is.EqualTo(true));
        }


        [Test]
        public void DoorClose_CorrectValueReceived() //tester at DoorClose er false
        {
            _uut.IsLocked = true;
            _uut.SetDoorState(false);
            Assert.That(_receivedEventArgs._DoorOpen, Is.EqualTo(false));
        }

        [Test]
        public void LockDoor_CorrectValueReceived() //tester at isLock er true
        {
            _uut.LockDoor();

            Assert.That(_uut.IsLocked, Is.EqualTo(true));
        }

        [Test]
        public void UnLockDoor_CorrectValueReceived() //tester at isLock er false
        {
            _uut.UnlockDoor();
            Assert.That(_uut.IsLocked, Is.EqualTo(false));
        }
    }
}
