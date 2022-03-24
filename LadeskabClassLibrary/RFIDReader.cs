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
            try
            {
                if (newID > 0)
                {
                    OnRFIDDetected(new RFIDDetectedEventArgs { ID = newID });
                    CurrentID = newID;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Ugyldigt RFID prøv igen");
            }

        }

        protected virtual void OnRFIDDetected(RFIDDetectedEventArgs e)
        {
            RFIDDetectedEvent?.Invoke(this, e);
        }
    }
}
