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

        public RFIDReader()
        {
            CurrentID = 0;
        }

        public void SetID(int newID)
        {
            if (newID < 0)
            {
                if (newID != CurrentID)
                {
                    OnRFIDDetected(new RFIDDetectedEventArgs { ID = newID });
                    CurrentID = newID;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

        }



        private void OnRFIDDetected(RFIDDetectedEventArgs e)
        {
            RFIDDetectedEvent?.Invoke(this, new RFIDDetectedEventArgs() { ID = this.CurrentID });
        }
    }
}
