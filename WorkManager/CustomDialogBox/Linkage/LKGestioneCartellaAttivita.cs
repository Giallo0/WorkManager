using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManager.CustomDialogBox.Linkage
{
    internal class LKGestioneCartellaAttivita
    {
        //Input
        /**
         * Funzioni:
         * I -> Inserimento nuova cartella
         * M -> Modifica di una cartella
         * C -> Cancellazione di una cartella
         */
        public static string funzione;

        /**
         * In funzione M e C nel percorso deve essere presente anche la cartella da gestire
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
