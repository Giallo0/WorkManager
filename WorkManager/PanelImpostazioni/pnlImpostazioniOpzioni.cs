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
    public partial class pnlImpostazioniOpzioni : UserControl
    {
        public pnlImpostazioniOpzioni()
        {
            InitializeComponent();
            InitializeComponentPersonalizzato();
        }

        private void InitializeComponentPersonalizzato()
        {
            string chiusura = string.IsNullOrEmpty(Globale.jwm.getValue(ChiaviRoot.Chiusura)) ? "F" : Globale.jwm.getValue(ChiaviRoot.Chiusura);
            chkChiusura.Checked = chiusura == "B" ? true : false;
        }

        private void chkChiusura_CheckedChanged(object sender, EventArgs e)
        {
            Globale.jwm.setValue(ChiaviRoot.Chiusura, chkChiusura.Checked ? "B" : "F");
            Globale.jwm.salva();
        }
    }
}
