using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbSimulator;

namespace LadeskabClassLibrary
{
   public class ChargeControl : IChargeControl
   {
        public bool Connected { get; set; }
        private IUsbCharger Charger { get; set; }
        private IDisplay Display { get; set; }
        private string lastMessage { get; set; }

        public double Current;
        public ChargeControl(IUsbCharger charger, IDisplay display)
        {
            Charger = charger;
            charger.CurrentValueEvent += HandleCurrentChangedEvent;
            Display = display;
        }

        public void StartCharge()
        {
            Charger.StartCharge();
        }

        public void StopCharge()
        {
            Charger.StopCharge();
        }

        private void DiplayChargeMessage()
        {
            
            if (Current > 0 && Current <= 5)
            {
                Display.ConnectPhone();
            }
            else if (Current > 5 && Current <= 500)
            {
                Display.Charging();
            }
            else if (Current > 500)
            {
                Display.DisconnectPhone();
            }
            
        }

        private void HandleCurrentChangedEvent(object sender, CurrentEventArgs e)
        {
            Current = e.Current;
            DiplayChargeMessage();
        }
    }
}
