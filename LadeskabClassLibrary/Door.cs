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

        public void OnDoorOpen()
        { }

        public void OnDoorClose()
        { }


        public event EventHandler<DoorStateChangedEventArgs> DoorStateChangedEventArgs;

    }
}
