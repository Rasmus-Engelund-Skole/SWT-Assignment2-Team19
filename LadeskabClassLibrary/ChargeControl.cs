using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabClassLibrary
{
   public class ChargeControl : IChargeControl
   {
        public bool Connected { get; set; }
        private IUsbCharger Charger { get; set; }
        private IDisplay Display { get; set; }
        private bool Messageshown = false;

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
            Messageshown = false;
        }

        public bool IsConnected()
        {
            return Charger.Connected;
        }

        private void DisplayChargeMessage()
        {
            
            if (Current > 0 && Current <= 5)
            {
                Display.DoneCharging();
                
                StopCharge();
            }
            else if (Current > 5 && Current <= 500)
            {
                if (Messageshown == false)
                {
                    Display.Charging();
                    Messageshown = true;
                }
            }
            else if (Current > 500)
            {
                Display.DisconnectPhone();
                StopCharge();  
            }
            
        }

        private void HandleCurrentChangedEvent(object sender, CurrentEventArgs e)
        {
            Current = e.Current;
            DisplayChargeMessage();
        }
    }
}
