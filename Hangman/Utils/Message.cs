using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Utils
{
    internal class Message
    {
        public void PrintMessage(string msg)
        { 
            Console.Clear();
            Console.WriteLine(msg); 
        }

        public static void ErrorMessage()
        {
            Console.Clear();
            Console.WriteLine("Noget gik galt, prøv igen.");
        }

        public static void StartMenu()
        {
            Console.Clear();
            Console.Write("Velkommen til hangman spillet." +
                $"\nValgt sværhedsgrad: {Settings.Sværhedsgrad} bogstavs ord" +
                $"\n\nDu har nu følgende muligheder" +
                $"\n1: Start spil" +
                $"\n2: Vælg sværhedsgrad" +
                $"\n3: Regler" +
                $"\n9: Afslut" +
                $"\n\n> ");
        }

        public static void SeRegler()
        { 
            Console.Clear();
            Console.Write("Reglerne til hangman er som følger" +
                "\n\nSpillet generere et hemmeligt ord på baggrund af hvilken længede ord du har valgt " +
                "\nHver rundte indtaster du et bogstav, hvis det hemmelige ord indeholder bogstavet, bliver bogstavete sat ind på sig plads, hvis ikke bliver der tilføjet en kropsdel til hangmanen og det forkerte bogstav bliver tilføjet til en liste af gættede bogstaver" +
                "\nDu vinder hvis du gætter hele ordet, du taber hvis du gætter forkert 7 gange." +
                "\n\nTryk på en tast for at komme tilbage til menuen");
            Console.ReadKey();
        }

        public static void VælgSværhedsgradMessage()
        {
            Console.Clear();
            Console.Write("Indtast hvor mange bogstaver det ord du vil gætte skal indholde\nDu skal indtaste et tal mellem 4 og 6\n\n> ");
        }

        public static void SpilSkærm()
        {
            Console.Clear();
            Console.WriteLine($"Du har {Settings.gætTilbage} gæt tilbage\n\n");

            Console.WriteLine("  _______");
            Console.WriteLine("  |     |");

            if (Settings.gætTilbage <= 6)
                Console.WriteLine("  O     |"); // hoved
            else
                Console.WriteLine("        |");

            if (Settings.gætTilbage == 5)
                Console.WriteLine("  |     |"); // krop uden arme
            else if (Settings.gætTilbage == 4)
                Console.WriteLine(" /|     |"); // krop + en arm
            else if (Settings.gætTilbage < 4)
                Console.WriteLine(" /|\\    |"); // krop + to arme
            else
                Console.WriteLine("        |");

            if (Settings.gætTilbage <= 2)
                Console.WriteLine("  |     |"); // mave/stamme
            else
                Console.WriteLine("        |");

            if (Settings.gætTilbage == 1)
                Console.WriteLine(" /      |"); // et ben
            else if (Settings.gætTilbage <= 0)
                Console.WriteLine(" / \\    |"); // to ben
            else
                Console.WriteLine("        |");

            Console.WriteLine("        |");
            Console.WriteLine(" _______|_");

            Console.WriteLine($"\n\nDet rigtige ord: {Settings.gættedeBogstaver}        Forkerte bogstaver: {Settings.forkertGættedeBogstaver}");
            Console.Write("Indtast det bogstav du vil gætte på > ");
        }

        public static void BogstavAlleredeBrugt()
        {
            Console.Clear();
            Console.WriteLine("Bogstav allerede brugt, prøv igen");
            Console.ReadKey();
        }
    }
}
