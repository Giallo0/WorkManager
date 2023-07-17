using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManager.Linkage
{
    internal class LKGestioneAttivita
    {
        /* Funzioni:
         * I => Inserimento
         * G => Gestione
         * E => Eliminazione
         */
        public static string funzione = ""; // 1 byte

        public static void ClearLinkage()
        {
            funzione = string.Empty;
        }

        public static void DecodificaLinkageString(string linkageString)
        {
            linkageString = linkageString.PadRight(11);

            funzione = linkageString.Substring(0, 1);
        }

        public static string CodificaLinkageString()
        {
            string codifica = string.Empty;

            codifica += funzione.PadRight(1);

            return codifica;
        }
    }
}
