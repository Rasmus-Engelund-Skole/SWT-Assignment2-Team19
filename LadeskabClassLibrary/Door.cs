using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabClassLibrary
{
  
    public class Door : IDoor
    {
        public event EventHandler<DoorStateChangedEventArgs> DoorStateChanged;

        public bool State { set; get; }

        public Door()
        {
            State = true;
        }

        void IDoor.LockDoor()
        {
            if (!State)
            {
                OnDoorStateChanged(new DoorStateChangedEventArgs { _DoorOpen = false });
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        void IDoor.UnlockDoor()
        {
            if (State)
            {
                OnDoorStateChanged(new DoorStateChangedEventArgs { _DoorOpen = true });
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private void OnDoorStateChanged(DoorStateChangedEventArgs e)
        {
            DoorStateChanged?.Invoke(this, new DoorStateChangedEventArgs() { _DoorOpen = this.State });
        }



        

    }
}
