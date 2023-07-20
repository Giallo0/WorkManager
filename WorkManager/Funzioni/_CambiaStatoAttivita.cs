using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManager.Linkage;

namespace WorkManager.Funzioni
{
    internal class _CambiaStatoAttivita
    {
        public _CambiaStatoAttivita() 
        {
            CambiaStato();
        }

        //Programma di elaborazione cambio stato attività
        public void CambiaStato()
        {
            if (ControllaLinkage())
            {
                JSONwsFolder jwsF = new JSONwsFolder($"{LK_CambiaStatoAttivita.percorsoCliente}\\{LK_CambiaStatoAttivita.attivita}");

                string statoNew = LK_CambiaStatoAttivita.stato;

                jwsF.setValue(ChiaviwsFolder.Stato, statoNew);
                jwsF.salva();

                MessageBox.Show("Stato attività cambiato con successo", "Cambio stato attivita", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ControllaLinkage()
        {
            bool noerrori = true;

            if (string.IsNullOrEmpty(LK_CambiaStatoAttivita.percorsoCliente))
            {
                MessageBox.Show("Percorso cliente non valorizzato in linkage", "Cambio stato attivita", MessageBoxButtons.OK, MessageBoxIcon.Error);
                noerrori = false;
                LK_CambiaStatoAttivita.erroriElab = true;
                goto ControllaLinkageErr;
            }
            if (string.IsNullOrEmpty(LK_CambiaStatoAttivita.attivita))
            {
                MessageBox.Show("Attività non valorizzata in linkage", "Cambio stato attivita", MessageBoxButtons.OK, MessageBoxIcon.Error);
                noerrori = false;
                LK_CambiaStatoAttivita.erroriElab = true;
                goto ControllaLinkageErr;
            }
            if (string.IsNullOrEmpty(LK_CambiaStatoAttivita.stato))
            {
                MessageBox.Show("Stato non valorizzato in linkage", "Cambio stato attivita", MessageBoxButtons.OK, MessageBoxIcon.Error);
                noerrori = false;
                LK_CambiaStatoAttivita.erroriElab = true;
                goto ControllaLinkageErr;
            }
            if (!ParametriCostanti<StatiAttivita>.getNamesWithId().Contains(LK_CambiaStatoAttivita.stato))
            {
                MessageBox.Show($"Stato '{LK_CambiaStatoAttivita.stato}' non esistente tra gli stati disponibili", "Cambio stato attivita", MessageBoxButtons.OK, MessageBoxIcon.Error);
                noerrori = false;
                LK_CambiaStatoAttivita.erroriElab = true;
                goto ControllaLinkageErr;
            }

        ControllaLinkageErr:
            return noerrori;
        }
    }
}
