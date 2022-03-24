using LadeskabClassLibrary;

        // Assemble your system here from all the classes
var door = new Door();
var rfidReader = new RFIDReader(); 
var display = new Display();
var logfile = new Logfile();
var usbcharger = new UsbChargerSimulator();
var Charger = new ChargeControl(usbcharger,display);
var Station = new StationControl(door, Charger, display, logfile, rfidReader);

bool finish = false;
do
{
    string input;
    System.Console.WriteLine("Indtast E, O, C, R, T, Y: ");
    input = Console.ReadLine();
    if (string.IsNullOrEmpty(input)) continue;

    switch (input[0])
    {
        case 'E':
            finish = true;
            break;

        case 'O':
            door.SetDoorState(true);
            break;

        case 'C':
            door.SetDoorState(false);
            break;

        case 'R':
            System.Console.WriteLine("Indtast RFID id: ");
            string idString = System.Console.ReadLine();

            int id = Convert.ToInt32(idString);
            rfidReader.SetID(id);
            break;

        case 'T':
            Charger.Connected = true;
            display.Connected();
            break;

        case 'Y':
            Charger.Connected = false;
            display.Disconnected();
            break;
                    
        default:
            break;
    }

} while (!finish);
