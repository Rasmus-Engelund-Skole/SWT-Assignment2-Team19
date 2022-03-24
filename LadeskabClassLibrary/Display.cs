using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LadeskabClassLibrary
{
    public class Display : IDisplay
    {
        public void ConnectPhone()
        {
            Console.WriteLine("Tilslut Telefon");
        }
        public void DisconnectPhone()
        {
            Console.WriteLine("Fjern Telefon");
        }
        public void ConnectError()
        {
            Console.WriteLine("Tilslutningsfejl");
        }
        public void ReadRFID()
        {
            Console.WriteLine("Indlæs RFID"); //Should be used with DoorClosed()
        }
        public void RFIDError()
        {
            Console.WriteLine("RFID Fejl");
        }
        public void Charging()
        {
            Console.WriteLine("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
        }
        public void CloseDoor()
        {
            Console.WriteLine("Døren er Åben, Den skal lukkes inden skabet kan låses.");
        }
        public void DoorOpen()
        {
            Console.WriteLine("Døren er Åben");
        }
        public void Connected()
        {
            Console.WriteLine("Telefonen er tilsluttet");
        }
        public void Disconnected()
        {
            Console.WriteLine("Telefonen er frakoblet");
        }


    }
}
