using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabClassLibrary
{
    public class RFIDDetectedEventArgs : EventArgs
    {
        //RFID ID as int
        public int ID { set; get; }
    }
    public class RFIDReader: IRFIDReaders
    {
        // Event triggered on new ID value
        event EventHandler<CurrentEventArgs> CurrentValueEvent;
    }
}
