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
            try
            {
                if (!DoorOpen)
                {
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Døren er åben, luk døren, prøv igen");
            }
        }

        public void UnlockDoor()
        {
            try
            {
                if (!DoorOpen)
                {
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Døren er åben, luk døren, prøv igen");
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
