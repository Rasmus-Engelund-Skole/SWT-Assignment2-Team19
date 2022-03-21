using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabClassLibrary
{
    public class DoorStateChangedEventArgs : EventArgs
    {
        public bool Open { set; get; }
    }

    public interface IDoor
    {
        public void LockDoor();

        public void UnlockDoor();

        event EventHandler<DoorStateChangedEventArgs> DoorStateChangedEventArgs;
    }
}
