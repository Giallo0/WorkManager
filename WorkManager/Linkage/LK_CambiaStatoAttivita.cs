using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManager.Linkage
{
    internal class LK_CambiaStatoAttivita
    {
        //Input
        public static string percorsoCliente;
        public static string attivita;
        public static string stato;

        //Output
        public static bool erroriElab;

        public static void ClearLinkageInput()
        {
            percorsoCliente = string.Empty;
            attivita = string.Empty;
            stato = string.Empty;
        }

        public static void ClearLinkageOutput()
        {
            erroriElab = false;
        }

        public static void ClearLinkage()
        {
            ClearLinkageInput();
            ClearLinkageOutput();
        }
    }
}
