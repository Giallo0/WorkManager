using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManager.Linkage
{
    internal class LKFinFolder
    {
        //Input
        public static bool mostraRoot;
        //Se non valorizzato, impostato a true
        //public static string tipologiaCartella;
        //Tipologia da mostrare nella ricerca delle cartelle. Se spazio mostra tutto
        public static string TipoCartella;
        //Tipologia da limitare nella visualizzazione delle cartelle. Se spazio mostro tutto

        //Output
        public static string percorsoCartella;
        //Percorso cartella selezionato dalla ricerca
        public static string nomeCartella;
        //Nome della cartella selezionataa dalla ricerca

        public static void ClearLinkageInput()
        {
            mostraRoot = true;
            TipoCartella = string.Empty;
        }

        public static void ClearLinkageOutput()
        {
            percorsoCartella = string.Empty;
            nomeCartella = string.Empty;
        }

        public static void ClearLinkage()
        {
            ClearLinkageInput();
            ClearLinkageOutput();
        }
    }
}
