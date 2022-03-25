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

        public bool DoorOpen { set; get; }

        public Door()
        {
            DoorOpen = false;
        }

        public void LockDoor()
        {
            if (!DoorOpen)
            {
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void UnlockDoor()
        {
            if (!DoorOpen)
            {
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void SetDoorState(bool DoorState)
        {
            if (DoorState != DoorOpen)
            {
                OnDoorStateChanged(new DoorStateChangedEventArgs { _DoorOpen = DoorState });
            }

        }

        private void OnDoorStateChanged(DoorStateChangedEventArgs e)
        {
            DoorStateChanged?.Invoke(this,e);
        }
    }
}
