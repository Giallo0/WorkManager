using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManager_A.Linkage;

namespace WorkManager_A.Funzioni
{
    internal class ApriCartella
    {
        public ApriCartella() 
        {
            LKFinFolder.ClearLinkage();
            LKFinFolder.mostraRoot = true;
            if (Funzione.Apri("FinFolder", "WorkManager_A") == DialogResult.OK)
            {
                Process.Start("explorer.exe", LKFinFolder.percorsoCartella);
            }
        }
    }
}
