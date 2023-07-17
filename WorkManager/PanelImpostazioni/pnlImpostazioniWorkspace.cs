using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkManager.PanelImpostazioni
{
    public partial class pnlImpostazioniWorkspace : UserControl
    {
        public pnlImpostazioniWorkspace()
        {
            InitializeComponent();
            InitializeComponentPersonalizzato();
        }

        private void InitializeComponentPersonalizzato()
        {
            txtPath.Text = Globale.jwm.getValue(ChiaviRoot.Workspace);

            txtDescrizione.Lines = getDescrizione();
        }

        private void btnCambia_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Cambiare percorso del Workspace?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                Globale.jwm.setValue(ChiaviRoot.Workspace, string.Empty);
                Globale.jwm.salva();
                Application.Restart();
            }
        }

        private string[] getDescrizione()
        {
            return new string[]
            {
                "Il Workspace è la cartella di riferimento dove verranno gestiti tutti gli elementi di lavoro.",
                "In assenza di tale cartella o file di configurazione il programma non funzionerà e chiederà nuovamente la cartella di riferimento.",
                "",
                "Premendo il pulsante \"Cambia\" il programma verrà riavviato e resettato il percorso del workspace.",
            };
        }
    }
}
