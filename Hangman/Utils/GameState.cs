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
            while(Settings.spilKøre)
            {
                Message.SpilSkærm();
                Settings.gættetOrd = Console.ReadLine();
                if (Settings.forkerteGæt.Contains(Settings.gættetOrd) || Settings.gættedeBogstaver.Contains(Settings.gættetOrd))
                {
                    Message.BogstavAlleredeBrugt();
                }

                else if (Settings.genereretOrd.Contains(Settings.gættetOrd))
                {
                    KorrektBogstav();
                }

                else if (!Settings.genereretOrd.Contains(Settings.gættetOrd))
                {
                    ForketBogstav();
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

    }
}
