using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkManager.Linkage.PnlLinkage
{
    public partial class pnlLKGestioneAttivita : UserControl
    {
        public pnlLKGestioneAttivita()
        {
            InitializeComponent();
            InitializeComponentPersonalizzato();
        }

        private void InitializeComponentPersonalizzato()
        {
            //Imposta linkage
            LKGestioneCliente.ClearLinkage();
            if (!string.IsNullOrEmpty(LKGestioneLinkage.linkage))
            {
                LKGestioneCliente.DecodificaLinkageString(LKGestioneLinkage.linkage);
            }

            switch (LKGestioneCliente.funzione)
            {
                case "I":
                    rbtInserimento.Checked = true;
                    break;
                case "G":
                    rbtModifica.Checked = true;
                    break;
                case "E":
                    rbtEliminazione.Checked = true;
                    break;
                default:
                    rbtInserimento.Checked = true;
                    break;
            }
        }

        private void rbtInserimento_CheckedChanged(object sender, EventArgs e)
        {
            LKGestioneCliente.funzione = "I";
        }

        private void rbtModifica_CheckedChanged(object sender, EventArgs e)
        {
            LKGestioneCliente.funzione = "G";
        }

        private void rbtEliminazione_CheckedChanged(object sender, EventArgs e)
        {
            LKGestioneCliente.funzione = "E";
        }
    }
}
