namespace WorkManager_A
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
            pnlListMenu = new Panel();
            panel2 = new Panel();
            btnImpostazioni = new Button();
            btnRicaricaMenu = new Button();
            btnGestioneMenu = new Button();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pnlListMenu
            // 
            pnlListMenu.AutoScroll = true;
            pnlListMenu.BorderStyle = BorderStyle.FixedSingle;
            pnlListMenu.Dock = DockStyle.Left;
            pnlListMenu.Location = new Point(0, 0);
            pnlListMenu.Name = "pnlListMenu";
            pnlListMenu.Size = new Size(200, 593);
            pnlListMenu.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(btnImpostazioni);
            panel2.Controls.Add(btnRicaricaMenu);
            panel2.Controls.Add(btnGestioneMenu);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(200, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(900, 76);
            panel2.TabIndex = 1;
            // 
            // btnImpostazioni
            // 
            btnImpostazioni.Dock = DockStyle.Left;
            btnImpostazioni.FlatAppearance.BorderSize = 0;
            btnImpostazioni.FlatStyle = FlatStyle.Flat;
            btnImpostazioni.Image = Properties.Resources.impostazioni;
            btnImpostazioni.Location = new Point(150, 0);
            btnImpostazioni.Name = "btnImpostazioni";
            btnImpostazioni.Size = new Size(75, 74);
            btnImpostazioni.TabIndex = 2;
            btnImpostazioni.Tag = "Impostazioni";
            btnImpostazioni.Text = "Impostazioni";
            btnImpostazioni.TextImageRelation = TextImageRelation.ImageAboveText;
            btnImpostazioni.UseVisualStyleBackColor = true;
            btnImpostazioni.Click += btnImpostazioni_Click;
            // 
            // btnRicaricaMenu
            // 
            btnRicaricaMenu.Dock = DockStyle.Left;
            btnRicaricaMenu.FlatAppearance.BorderSize = 0;
            btnRicaricaMenu.FlatStyle = FlatStyle.Flat;
            btnRicaricaMenu.Image = Properties.Resources.ricarica;
            btnRicaricaMenu.Location = new Point(75, 0);
            btnRicaricaMenu.Name = "btnRicaricaMenu";
            btnRicaricaMenu.Size = new Size(75, 74);
            btnRicaricaMenu.TabIndex = 1;
            btnRicaricaMenu.Tag = "RicaricaMenu";
            btnRicaricaMenu.Text = "Ricarica menù";
            btnRicaricaMenu.TextImageRelation = TextImageRelation.ImageAboveText;
            btnRicaricaMenu.UseVisualStyleBackColor = true;
            btnRicaricaMenu.Click += btnRicaricaMenu_Click;
            // 
            // btnGestioneMenu
            // 
            btnGestioneMenu.Dock = DockStyle.Left;
            btnGestioneMenu.FlatAppearance.BorderSize = 0;
            btnGestioneMenu.FlatStyle = FlatStyle.Flat;
            btnGestioneMenu.Image = Properties.Resources.modifica;
            btnGestioneMenu.Location = new Point(0, 0);
            btnGestioneMenu.Name = "btnGestioneMenu";
            btnGestioneMenu.Size = new Size(75, 74);
            btnGestioneMenu.TabIndex = 0;
            btnGestioneMenu.Tag = "GestioneMenu";
            btnGestioneMenu.Text = "Gestione menù";
            btnGestioneMenu.TextImageRelation = TextImageRelation.ImageAboveText;
            btnGestioneMenu.UseVisualStyleBackColor = true;
            btnGestioneMenu.Click += btnGestioneMenu_Click;
            // 
            // WMmain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 593);
            Controls.Add(panel2);
            Controls.Add(pnlListMenu);
            Name = "WMmain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WorkManager";
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlListMenu;
        private Panel panel2;
        private Button btnGestioneMenu;
        private Button btnRicaricaMenu;
        private Button btnImpostazioni;
    }
}