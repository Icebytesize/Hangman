using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Utils
{
    internal class GameState
    {
        
        /// <summary>
        /// En metode brugt som hovedmenu, kalder på andre metoder for at vise indhold
        /// </summary>
        public static void StartMenu()
        {
            while (Settings.programKøre)
            {
                int input = 0;
                Message.StartMenu();
                int.TryParse(Console.ReadLine(), out input);
                if (input == 1) KørSpil();
                else if (input == 2) VælgSværhedsgrad();
                else if (input == 3) Message.SeRegler();
                else if (input == 9) Settings.programKøre = false;
                else Message.ErrorMessage();

            }
        }

        /// <summary>
        /// En metode til at køre spillet
        /// </summary>
        public static void KørSpil()
        {
            Settings.spilKøre = true;
            Settings.gætTilbage = 7;
            Settings.HentOrdListe();
            Settings.GenererOrd();
            Settings.gættedeBogstaver = new string('_', Settings.genereretOrd.Length);
            Settings.gættedeBogstaverChar = Settings.gættedeBogstaver.ToCharArray();
            while(Settings.spilKøre)
            {
                Message.SpilSkærm();
                Settings.gættetOrd = Console.ReadLine().ToLower();
                char gæt = Settings.gættetOrd[0];
                if (Settings.forkertGættedeBogstaver.Contains(gæt) || Settings.gættedeBogstaver.Contains(gæt))
                {
                    Message.BogstavAlleredeBrugt();
                }

                else if (Settings.genereretOrd.Contains(Settings.gættetOrd))
                {
                    KorrektBogstav();
                }

                else if (!Settings.genereretOrd.Contains(Settings.gættetOrd))
                {
                    ForkertBogstav();
                }

                else
                {
                    Message.ErrorMessage();
                }

                if (Settings.gættetOrd == Settings.genereretOrd)
                {
                    VundetSpil();
                }

                if (Settings.gætTilbage == 0)
                {
                    TabtSpil();
                }

            }
        }

        /// <summary>
        /// En kort metode til at skifte sværhedsgrad på spillet
        /// </summary>
        public static void VælgSværhedsgrad()
        {
            int input;
            Message.VælgSværhedsgradMessage();
            int.TryParse(Console.ReadLine(), out input);
            if (input >= 4 && input <= 6) Settings.Sværhedsgrad = input;
            else Message.ErrorMessage();
        }

        public static void KorrektBogstav()
        {
            for (int i = 0; i < Settings.genereretOrd.Length; i++)
            { 
                if (Settings.gættetOrd[0] == Settings.genereretOrd[i])
                {
                    Settings.gættedeBogstaverChar[i] = Settings.gættetOrd[0];
                    Settings.gættedeBogstaver = new string(Settings.gættedeBogstaverChar);
                }
            }
        }

        public static void ForkertBogstav()
        {
            Settings.forkertGættedeBogstaver = Settings.forkertGættedeBogstaver + $"{Settings.gættetOrd} ";
            Settings.gætTilbage--;
        }

        public static void VundetSpil()
        {
            Console.Clear();
            Console.WriteLine($"Tilykke du har vundet spillet med {Settings.gætTilbage} gæt tilbage");
            Console.ReadKey();
            Settings.spilKøre = false;
        }

        public static void TabtSpil()
        {
            Console.Clear();
            Console.WriteLine("Du har desværre tabt spillet og vil nu blive sendt tilbage til menuen");
            Console.ReadKey();
            Settings.spilKøre = false;

        }

    }
}
