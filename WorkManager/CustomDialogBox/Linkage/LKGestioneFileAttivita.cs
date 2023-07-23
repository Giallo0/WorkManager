using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManager.CustomDialogBox.Linkage
{
    internal class LKGestioneFileAttivita
    {
        //Input
        /**
         * Funzioni:
         * I -> Inserimento nuovo file
         * M -> Modifica di un file
         * C -> Cancellazione di un file
         */
        public static string funzione;

        /**
         * In funzione M e C nel percorso deve essere presente anche il file da gestire
         */
        public static string percorso;

        //Output


        public static void ClearLinkageInput()
        {
            funzione = string.Empty;
            percorso = string.Empty;
        }

        public static void ClearLinkageOutput()
        {

        }

        public static void ClearLinkage()
        {
            ClearLinkageInput();
            ClearLinkageOutput();
        }
    }
}
