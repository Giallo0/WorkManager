using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManager_A.PanelImpostazioni
{
    public partial class pnlImpostazioniOpzioni : Panel
    {
        public pnlImpostazioniOpzioni()
        {
            InitializeComponent();
            InitializeComponentPersonalizzato();
        }

        public pnlImpostazioniOpzioni(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            InitializeComponentPersonalizzato();
        }

        // 
        // Definizione componenti panel
        //
        private CheckBox chkChiusura;

        private void InitializeComponentPersonalizzato() 
        {
            chkChiusura = new CheckBox();
            SuspendLayout();

            // 
            // pnlImpostazioniOpzioni
            // 
            Controls.Add(chkChiusura);
            Dock = DockStyle.Fill;
            Location = new Point(0, 0);
            Size = new Size(604, 450);
            // 
            // chkChiusura
            // 
            chkChiusura.AutoSize = true;
            chkChiusura.Location = new Point(39, 27);
            chkChiusura.Name = "chkChiusura";
            chkChiusura.Size = new Size(218, 19);
            chkChiusura.TabIndex = 0;
            chkChiusura.Text = "Alla chiusura mantieni in esecuzione";
            chkChiusura.UseVisualStyleBackColor = true;
            string chiusura = string.IsNullOrEmpty(Globale.jwm.getValue(ChiaviRoot.Chiusura.ToString())) ? "F" : Globale.jwm.getValue(ChiaviRoot.Chiusura.ToString());
            chkChiusura.Checked = chiusura == "B" ? true : false;
            chkChiusura.CheckedChanged += chkChiusura_CheckedChanged;

            ResumeLayout(false);
        }

        private void chkChiusura_CheckedChanged(object sender, EventArgs e)
        {
            Globale.jwm.setValue(ChiaviRoot.Chiusura.ToString(), chkChiusura.Checked ? "B" : "F");
            Globale.jwm.salva();
        }
    }
}
