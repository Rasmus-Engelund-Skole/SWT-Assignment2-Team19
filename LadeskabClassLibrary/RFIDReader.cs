using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabClassLibrary
{
    public class RFIDReader: IRFIDReader
    {

        public int CurrentID { get; set; }
        // Event triggered on new ID value
        public event EventHandler<RFIDDetectedEventArgs> RFIDDetectedEvent;



        public RFIDReader()
        {
            CurrentID = 0;
        }

        public void SetID(int newID)
        {
            if (newID > 0)
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



        protected virtual void OnRFIDDetected(RFIDDetectedEventArgs e)
        {
            RFIDDetectedEvent?.Invoke(this, e);
        }
    }
}
