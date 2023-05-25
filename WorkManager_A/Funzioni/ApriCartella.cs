using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManager_A.Funzioni
{
    internal class ApriCartella
    {
        public ApriCartella() 
        {
            if (Funzione.Apri("FinFolder", "WorkManager_A") == DialogResult.OK)
            {
                Process.Start("explorer.exe", Globale.percorsoCartella);
            }
        }
    }
}
