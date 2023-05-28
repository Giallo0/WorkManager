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
        public static string funzione = ""; // 1 byte

        /* Tipo Cartella:
         * Tutti => Al momento della gestione si sceglie il tipo
         * Cliente => è possibile gestire solo le cartelle di tipo Cliente
         * Attivita => è possibile gestire solo le cartelle di tipo attivita
         */
        public static string TipoCartella = ""; // 10 byte

        public static void ClearLinkage()
        {
            funzione = string.Empty;
            TipoCartella = string.Empty;
        }

        public static void DecodificaLinkageString(string linkageString)
        {
            linkageString = linkageString.PadRight(11);

            funzione = linkageString.Substring(0, 1);
            TipoCartella = linkageString.Substring(1, 10).Trim();
        }

        public static string CodificaLinkageString()
        {
            string codifica = string.Empty;

            codifica += funzione.PadRight(1);
            codifica += TipoCartella.PadRight(10);

            return codifica;
        }
    }
}
