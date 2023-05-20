using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManager_A.PanelImpostazioni
{
    public partial class pnlImpostazioniWorkspace : Panel
    {
        public pnlImpostazioniWorkspace()
        {
            InitializeComponent();
            InitializeComponentPersonalizzato();
        }

        public pnlImpostazioniWorkspace(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            InitializeComponentPersonalizzato();
        }

        // 
        // Definizione componenti panel
        // 
        private Label lblPath;
        private TextBox txtPath;
        private GroupBox gbDescrizione;
        private TextBox txtDescrizione;
        private Button btnCambia;
        private Button btnReset;

        private void InitializeComponentPersonalizzato()
        {
            lblPath = new Label();
            txtPath = new TextBox();
            gbDescrizione = new GroupBox();
            txtDescrizione = new TextBox();
            btnCambia = new Button();
            btnReset = new Button();
            gbDescrizione.SuspendLayout();
            SuspendLayout();
            // 
            // pnlOpzioniWorkspace
            // 
            Controls.Add(gbDescrizione);
            Controls.Add(lblPath);
            Controls.Add(txtPath);
            Controls.Add(btnCambia);
            Controls.Add(btnReset);
            Dock = DockStyle.Fill;
            Location = new Point(0, 0);
            Padding = new Padding(20);
            Size = new Size(604, 450);
            // 
            // gbDescrizione
            // 
            gbDescrizione.Controls.Add(txtDescrizione);
            gbDescrizione.Location = new Point(23, 251);
            gbDescrizione.Name = "gbDescrizione";
            gbDescrizione.Size = new Size(558, 176);
            gbDescrizione.TabIndex = 0;
            gbDescrizione.TabStop = false;
            gbDescrizione.Text = "Descrizione";
            // 
            // txtDescrizione
            // 
            txtDescrizione.Location = new Point(6, 22);
            txtDescrizione.Multiline = true;
            txtDescrizione.Name = "txtDescrizione";
            txtDescrizione.Lines = getDescrizione();
            txtDescrizione.Enabled = false;
            txtDescrizione.Size = new Size(546, 138);
            txtDescrizione.TabIndex = 0;
            // 
            // lblPath
            // 
            lblPath.AutoSize = true;
            lblPath.Location = new Point(23, 20);
            lblPath.Name = "lblPath";
            lblPath.Size = new Size(117, 15);
            lblPath.TabIndex = 0;
            lblPath.Text = "Percorso Workspace:";
            // 
            // txtPath
            // 
            txtPath.Location = new Point(23, 38);
            txtPath.Name = "txtPath";
            txtPath.Text = Globale.jwm.getValue(ChiaviRoot.Workspace.ToString());
            txtPath.ReadOnly = true;
            txtPath.Size = new Size(558, 23);
            txtPath.TabIndex = 0;
            // 
            // btnCambia
            // 
            btnCambia.Location = new Point(234, 132);
            btnCambia.Name = "btnCambia";
            btnCambia.Size = new Size(75, 23);
            btnCambia.TabIndex = 0;
            btnCambia.Text = "Cambia";
            btnCambia.UseVisualStyleBackColor = true;
            btnCambia.Click += btnCambia_Click;
            // 
            // btnCambia
            // 
            btnReset.Location = new Point(334, 132);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 23);
            btnReset.TabIndex = 0;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;

            ResumeLayout(false);
        }

        private string[] getDescrizione()
        {
            return new string[]
            {
                "Il Workspace è la cartella di riferimento dove verranno gestiti tutti gli elementi di lavoro.",
                "In assenza di tale cartella o file di configurazione il programma non funzionerà e chiederà nuovamente la cartella di riferimento.",
                "",
                "Premendo il pulsante \"Cambia\" il programma verrà riavviato e resettato il percorso del workspace.",
                "",
                "Premendo il pulsante \"Reset\" la cartella del Workspace verrà ripulita di tutti i file e le cartelle al suo interno."
            };
        }

        private void btnCambia_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Cambiare percorso del Workspace?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                Globale.jwm.setValue(ChiaviRoot.Workspace.ToString(), string.Empty);
                Globale.jwm.salva();
                Application.Restart();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Si perderanno tutte le cartelle e i relativi salvataggi. Continuare?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (DialogResult.Yes == MessageBox.Show("Sicurissimo? Tutto il lavoro andrà perso e non rimarra più niente! Continuare?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    DeleteFileFolder(Globale.jwm.getValue(ChiaviRoot.Workspace.ToString()));
                    Application.Restart();
                }
            }
        }

        private void DeleteFileFolder(string folder)
        {
            foreach (FileInfo file in new DirectoryInfo(folder).GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in new DirectoryInfo(folder).GetDirectories())
            {
                DeleteFileFolder(dir.FullName);
                dir.Delete();
            }
        }
    }
}
