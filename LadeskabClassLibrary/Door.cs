using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabClassLibrary
{

    public class Door : IDoor
    {
        public Door()
        { }

        void IDoor.LockDoor()
        {

        }

        void IDoor.UnlockDoor()
        {

        }

        public void OnDoorStateChanged()
        { 
        }

        void IDoor.SetDoorState(bool DoorOpen)
        {
        
        }


        public event EventHandler<DoorStateChangedEventArgs> DoorStateChangedEventArgs;

    }
}
