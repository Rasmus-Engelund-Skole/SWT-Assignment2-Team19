using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabClassLibrary
{
    public interface IDisplay
    {
        void ConnectPhone();
        void DisconnectPhone();
        void ConnectError();
        void ReadRFID();
        void RFIDError();
        void Charging();
        void CloseDoor();
        void DoorOpen();
        void Connected();
        void Disconnected();
        public void DoneCharging();
    }
}
