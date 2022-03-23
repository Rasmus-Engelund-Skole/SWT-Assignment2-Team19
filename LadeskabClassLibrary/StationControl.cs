using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabClassLibrary
{
    public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        public enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        public event EventHandler<RFIDDetectedEventArgs> RFIDDetectedEvent;
        public event EventHandler<DoorStateChangedEventArgs> DoorStateChanged;
        public LadeskabState _state { get; private set; }
        private IChargeControl _charger;
        private IDoor _door;
        private IDisplay _display;
        private ILogfile _logfile;
        public IRFIDReader _reader;
        public int _oldId;



        // Her mangler constructor
        public StationControl(IDoor Door,
                              IChargeControl Charger,
                              IDisplay Display,
                              ILogfile Logfile,
                              IRFIDReader RFIDReader)
        {
            _door = Door;
            _charger = Charger;
            _display = Display;
            _logfile = Logfile;
            _door.DoorStateChanged += HandleDoorStateChangedEvent;
            _reader = RFIDReader;
            _reader.RFIDDetectedEvent += HandleRFIDDetectedEvent;

            _oldId = 0;
            _state = LadeskabState.Available;
            _charger.Connected = false;


        }



        private void HandleRFIDDetectedEvent(object sender, RFIDDetectedEventArgs e)
        {
            int id = e.ID;
            RfidDetected(id);
        }

        private void HandleDoorStateChangedEvent(object sender, DoorStateChangedEventArgs e)
        {
            DoorStateChangedFunc(e._DoorOpen);
        }

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        public void RfidDetected(int id)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_charger.Connected)
                    {
                        _door.LockDoor();
                        _charger.StartCharge();
                        _oldId = id;
                        _logfile.DoorLockedLog(id);

                        _display.Charging(); //Ladeskav optaget
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        _display.ConnectError();
                    }

                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (id == _oldId)
                    {
                        _charger.StopCharge();
                        _door.UnlockDoor();
                        _logfile.DoorUnlockedLog(id);

                        _display.DisconnectPhone();
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        _display.RFIDError();
                    }

                    break;
            }
        }

        // Her mangler de andre trigger handlere
        private void DoorStateChangedFunc(bool DoorOpen)
        {



        }
    
    }
}
