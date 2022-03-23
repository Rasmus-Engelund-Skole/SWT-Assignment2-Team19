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

        public bool IsLocked { set; get; }

        public Door()
        {
            IsLocked = true;
        }

        public void LockDoor()
        {
            if (!IsLocked)
            {
                IsLocked = true;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void UnlockDoor()
        {
            if (IsLocked)
            {
                IsLocked = false;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void SetDoorState(bool DoorState)
        {
            if (DoorState != IsLocked)
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
