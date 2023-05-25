using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkManager_A.Linkage;
using WorkManager_A.Linkage.PnlLinkage;
using WorkManager_A.PanelImpostazioni;

namespace WorkManager_A
{
    public partial class GestioneLinkage : Form
    {
        public GestioneLinkage()
        {
            InitializeComponent();
            PersonalizzaInizializzazione();
        }

        private void PersonalizzaInizializzazione()
        {
            pnlLinkage.Controls.Clear();
            switch (LKGestioneLinkage.nomePgm)
            {
                case "GestioneCartella":
                    pnlLinkage.Controls.Add(new pnlLKGestioneCartella());
                    break;
            }
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            switch (LKGestioneLinkage.nomePgm)
            {
                case "GestioneCartella":
                    LKGestioneLinkage.linkage = LKGestioneCartella.CodificaLinkageString();
                    break;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
