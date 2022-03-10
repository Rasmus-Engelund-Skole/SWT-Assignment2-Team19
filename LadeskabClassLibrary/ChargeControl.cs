using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabClassLibrary
{
   public class ChargeControl : IChargeControl
   {
        bool IChargeControl.Connected { get; set; }

        void IChargeControl.StartCharge()
        { }

        void IChargeControl.StopCharge()
        { }
    }
}
