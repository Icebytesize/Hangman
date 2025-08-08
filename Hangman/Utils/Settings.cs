using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hangman.Utils
{
    internal class Settings
    {
        public static string genereretOrd, gættetOrd, forkerteGæt; 
        public static int Sværhedsgrad = 4, gætTilbage;
        public static bool programKøre = true, spilKøre = true;
        public static List<string> ordListe;

        public static void HentOrdListe()
        {
            if (Sværhedsgrad == 4) ordListe = new List<string>(File.ReadAllLines("fireBogstavsOrd.txt"));
            else if (Sværhedsgrad == 5) ordListe = new List<string>(File.ReadAllLines("femBogstavsOrd.txt"));
            else if (Sværhedsgrad == 6) ordListe = new List<string>(File.ReadAllLines("seksBogstavsOrd.txt"));

            //HUSK!! udvid fem bogstavsfilen og seks bogstavsfilen
        }

        public static void GenererOrd()
        {
            Random random = new Random();
            int index = random.Next(ordListe.Count);
            genereretOrd = ordListe[index];
        }

    }
}
