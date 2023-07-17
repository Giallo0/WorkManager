using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManager.Linkage
{
    internal class LKOperaAttivita
    {
        //Input
        public static string cliente;
        public static string percorsoCliente;
        public static string attivita;

        //Output
        

        public static void ClearLinkageInput()
        {
            cliente = string.Empty;
            percorsoCliente = string.Empty;
            attivita = string.Empty;
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
