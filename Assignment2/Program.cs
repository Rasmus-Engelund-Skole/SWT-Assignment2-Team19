using LadeskabClassLibrary;
class Program
{
    static void Main(string[] args)
    {
        // Assemble your system here from all the classes
        var door = new Door();
        var rfidReader = new RFIDReader(); 


        bool finish = false;
        do
        {
            string input;
            System.Console.WriteLine("Indtast E, O, C, R: ");
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) continue;

            switch (input[0])
            {
                case 'E':
                    finish = true;
                    break;

                case 'O':
                    door.OnDoorStateChanged();
                    break;

                case 'C':
                    door.OnDoorStateChanged();
                    break;

                case 'R':
                    System.Console.WriteLine("Indtast RFID id: ");
                    string idString = System.Console.ReadLine();

                    int id = Convert.ToInt32(idString);
                    rfidReader.OnRFIDDetected(id);
                    break;

                default:
                    break;
            }

        } while (!finish);
    }
}
