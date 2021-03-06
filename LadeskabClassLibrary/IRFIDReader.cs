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
        public int ID { get; set; }
    }
    public interface IRFIDReader
    {
        // Direct access to the current ID
        int CurrentID { get; }

        // Event triggered on new ID value
        event EventHandler<RFIDDetectedEventArgs> RFIDDetectedEvent;
    }

}
