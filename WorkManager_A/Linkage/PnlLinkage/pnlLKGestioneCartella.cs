using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkManager_A.Linkage.PnlLinkage
{
    public partial class pnlLKGestioneCartella : UserControl
    {
        public pnlLKGestioneCartella()
        {
            InitializeComponent();
            InitializeComponentPersonalizzato();
        }

        private void InitializeComponentPersonalizzato()
        {
            string[] tipiCartella = Globale.jwm.getParametro("GestioneCartella", "TipoCartella").Valore.ToString().Split(';') ?? new string[0];
            cboTipoCartella.Items.AddRange(tipiCartella);

            //Imposta linkage
            LKGestioneCartella.ClearLinkage();
            if (!string.IsNullOrEmpty(LKGestioneLinkage.linkage))
            {
                LKGestioneCartella.DecodificaLinkageString(LKGestioneLinkage.linkage);
            }

            switch (LKGestioneCartella.funzione)
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

            if (string.IsNullOrEmpty(LKGestioneCartella.TipoCartella))
            {
                cboTipoCartella.SelectedIndex = 0;
                LKGestioneCartella.TipoCartella = cboTipoCartella.Text;
            }
            else
            {
                cboTipoCartella.Text = LKGestioneCartella.TipoCartella;
            }
        }

        private void rbtInserimento_CheckedChanged(object sender, EventArgs e)
        {
            LKGestioneCartella.funzione = "I";
        }

        private void rbtModifica_CheckedChanged(object sender, EventArgs e)
        {
            LKGestioneCartella.funzione = "G";
        }

        private void rbtEliminazione_CheckedChanged(object sender, EventArgs e)
        {
            LKGestioneCartella.funzione = "E";
        }

        private void cboTipoCartella_TextChanged(object sender, EventArgs e)
        {
            LKGestioneCartella.TipoCartella = cboTipoCartella.Text;
        }
    }
}
