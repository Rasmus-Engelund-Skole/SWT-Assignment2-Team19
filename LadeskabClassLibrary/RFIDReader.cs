using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabClassLibrary
{
    public class RFIDReader: IRFIDReader
    {
        // Event triggered on new ID value
        public event EventHandler<RFIDDetectedEventArgs> RFIDDetectedEvent;
    }
}
