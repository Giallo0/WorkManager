namespace WorkManager
{
    partial class WMmain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WMmain));
            pnlListMenu = new Panel();
            pnlFunction = new Panel();
            btnBonifica = new Button();
            btnEsci = new Button();
            btnImpostazioni = new Button();
            btnGestioneMenu = new Button();
            btnAggiornaGriglia = new Button();
            pnlAttivita = new Panel();
            gridAttivitaAperte = new DataGridView();
            notifyPrgm = new NotifyIcon(components);
            mnuNotifyPrgm = new ContextMenuStrip(components);
            apriToolStripMenuItem = new ToolStripMenuItem();
            chiudiToolStripMenuItem = new ToolStripMenuItem();
            pnlFunction.SuspendLayout();
            pnlAttivita.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridAttivitaAperte).BeginInit();
            mnuNotifyPrgm.SuspendLayout();
            SuspendLayout();
            // 
            // pnlListMenu
            // 
            resources.ApplyResources(pnlListMenu, "pnlListMenu");
            pnlListMenu.BorderStyle = BorderStyle.FixedSingle;
            pnlListMenu.Name = "pnlListMenu";
            // 
            // pnlFunction
            // 
            resources.ApplyResources(pnlFunction, "pnlFunction");
            pnlFunction.BorderStyle = BorderStyle.FixedSingle;
            pnlFunction.Controls.Add(btnBonifica);
            pnlFunction.Controls.Add(btnEsci);
            pnlFunction.Controls.Add(btnImpostazioni);
            pnlFunction.Controls.Add(btnGestioneMenu);
            pnlFunction.Controls.Add(btnAggiornaGriglia);
            pnlFunction.Name = "pnlFunction";
            // 
            // btnBonifica
            // 
            resources.ApplyResources(btnBonifica, "btnBonifica");
            btnBonifica.FlatAppearance.BorderSize = 0;
            btnBonifica.Image = Properties.Resources.Bonifica_32x32;
            btnBonifica.Name = "btnBonifica";
            btnBonifica.Tag = "BonificaCartelle";
            btnBonifica.UseVisualStyleBackColor = true;
            btnBonifica.Click += btnBonifica_Click;
            // 
            // btnEsci
            // 
            resources.ApplyResources(btnEsci, "btnEsci");
            btnEsci.FlatAppearance.BorderSize = 0;
            btnEsci.Image = Properties.Resources.Chiudi_32x32;
            btnEsci.Name = "btnEsci";
            btnEsci.Tag = "Esci";
            btnEsci.UseVisualStyleBackColor = true;
            btnEsci.Click += btnEsci_Click;
            // 
            // btnImpostazioni
            // 
            resources.ApplyResources(btnImpostazioni, "btnImpostazioni");
            btnImpostazioni.FlatAppearance.BorderSize = 0;
            btnImpostazioni.Image = Properties.Resources.Impostazioni_32x32;
            btnImpostazioni.Name = "btnImpostazioni";
            btnImpostazioni.Tag = "Impostazioni";
            btnImpostazioni.UseVisualStyleBackColor = true;
            btnImpostazioni.Click += btnImpostazioni_Click;
            // 
            // btnGestioneMenu
            // 
            resources.ApplyResources(btnGestioneMenu, "btnGestioneMenu");
            btnGestioneMenu.FlatAppearance.BorderSize = 0;
            btnGestioneMenu.Image = Properties.Resources.GestioneMenu_32x32;
            btnGestioneMenu.Name = "btnGestioneMenu";
            btnGestioneMenu.Tag = "GestioneMenu";
            btnGestioneMenu.UseVisualStyleBackColor = true;
            btnGestioneMenu.Click += btnGestioneMenu_Click;
            // 
            // btnAggiornaGriglia
            // 
            resources.ApplyResources(btnAggiornaGriglia, "btnAggiornaGriglia");
            btnAggiornaGriglia.FlatAppearance.BorderSize = 0;
            btnAggiornaGriglia.Image = Properties.Resources.RicaricaMenu_32x32;
            btnAggiornaGriglia.Name = "btnAggiornaGriglia";
            btnAggiornaGriglia.Tag = "GestioneMenu";
            btnAggiornaGriglia.UseVisualStyleBackColor = true;
            btnAggiornaGriglia.Click += btnAggiornaGriglia_Click;
            // 
            // pnlAttivita
            // 
            resources.ApplyResources(pnlAttivita, "pnlAttivita");
            pnlAttivita.Controls.Add(gridAttivitaAperte);
            pnlAttivita.Name = "pnlAttivita";
            // 
            // gridAttivitaAperte
            // 
            resources.ApplyResources(gridAttivitaAperte, "gridAttivitaAperte");
            gridAttivitaAperte.AllowUserToAddRows = false;
            gridAttivitaAperte.AllowUserToDeleteRows = false;
            gridAttivitaAperte.AllowUserToResizeColumns = false;
            gridAttivitaAperte.AllowUserToResizeRows = false;
            gridAttivitaAperte.BackgroundColor = SystemColors.ButtonFace;
            gridAttivitaAperte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridAttivitaAperte.MultiSelect = false;
            gridAttivitaAperte.Name = "gridAttivitaAperte";
            gridAttivitaAperte.ReadOnly = true;
            gridAttivitaAperte.RowTemplate.Height = 25;
            gridAttivitaAperte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridAttivitaAperte.MouseDoubleClick += gridAttivitaAperte_MouseDoubleClick;
            // 
            // notifyPrgm
            // 
            resources.ApplyResources(notifyPrgm, "notifyPrgm");
            notifyPrgm.ContextMenuStrip = mnuNotifyPrgm;
            notifyPrgm.MouseDoubleClick += notifyPrgm_MouseDoubleClick;
            // 
            // mnuNotifyPrgm
            // 
            resources.ApplyResources(mnuNotifyPrgm, "mnuNotifyPrgm");
            mnuNotifyPrgm.Items.AddRange(new ToolStripItem[] { apriToolStripMenuItem, chiudiToolStripMenuItem });
            mnuNotifyPrgm.Name = "contextMenuStrip1";
            // 
            // apriToolStripMenuItem
            // 
            resources.ApplyResources(apriToolStripMenuItem, "apriToolStripMenuItem");
            apriToolStripMenuItem.Name = "apriToolStripMenuItem";
            apriToolStripMenuItem.Click += apriToolStripMenuItem_Click;
            // 
            // chiudiToolStripMenuItem
            // 
            resources.ApplyResources(chiudiToolStripMenuItem, "chiudiToolStripMenuItem");
            chiudiToolStripMenuItem.Name = "chiudiToolStripMenuItem";
            chiudiToolStripMenuItem.Click += chiudiToolStripMenuItem_Click;
            // 
            // WMmain
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlAttivita);
            Controls.Add(pnlFunction);
            Controls.Add(pnlListMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "WMmain";
            FormClosing += WMmain_FormClosing;
            pnlFunction.ResumeLayout(false);
            pnlAttivita.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridAttivitaAperte).EndInit();
            mnuNotifyPrgm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlListMenu;
        private Panel pnlFunction;
        private Button btnGestioneMenu;
        private Button btnImpostazioni;
        private Panel pnlAttivita;
        private Button btnEsci;
        private NotifyIcon notifyPrgm;
        private ContextMenuStrip mnuNotifyPrgm;
        private ToolStripMenuItem apriToolStripMenuItem;
        private ToolStripMenuItem chiudiToolStripMenuItem;
        private DataGridView gridAttivitaAperte;
        private Button btnAggiornaGriglia;
        private Button btnBonifica;
    }
}