using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabClassLibrary
{
    public class DoorStateChangedEventArgs : EventArgs
    {
        public bool _DoorOpen { set; get; }
    }

    public interface IDoor
    {
        public void LockDoor();

        public void UnlockDoor();

        bool State { set; get; }

        // Event triggered on new state
        public event EventHandler<DoorStateChangedEventArgs> DoorStateChanged;
    }
}
