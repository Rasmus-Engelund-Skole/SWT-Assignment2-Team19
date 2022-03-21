using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabClassLibrary
{
    public class RFIDReader: IRFIDReader
    {

        public int CurrentID { get; private set; }
        // Event triggered on new ID value
        public event EventHandler<RFIDDetectedEventArgs> RFIDDetectedEvent;






        private void OnRFIDDetected()
        {
            RFIDDetectedEvent?.Invoke(this, new RFIDDetectedEventArgs() { ID = this.CurrentID });
        }
    }
}
