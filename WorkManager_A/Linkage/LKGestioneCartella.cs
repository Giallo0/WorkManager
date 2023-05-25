using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkManager_A.Linkage
{
    internal class LKGestioneCartella
    {
        /* Funzioni:
         * I => Inserimento
         * G => Gestione
         * E => Eliminazione
         */
        public static char funzione = ' ';

        public static void ClearLinkage()
        {
            funzione = ' ';
        }

        public static void DecodificaLinkageString(string linkageString)
        {
            funzione = linkageString.Substring(0, 1).ToCharArray()[0];
        }

        public static string CodificaLinkageString()
        {
            string codifica = string.Empty;

            codifica += funzione;

            return codifica;
        }
    }
}
