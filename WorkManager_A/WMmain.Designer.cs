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
            pnlFunction = new Panel();
            btnEsci = new Button();
            btnImpostazioni = new Button();
            btnRicaricaMenu = new Button();
            btnGestioneMenu = new Button();
            pnlAttivita = new Panel();
            pnlFunction.SuspendLayout();
            SuspendLayout();
            // 
            // pnlListMenu
            // 
            pnlListMenu.AutoScroll = true;
            pnlListMenu.BorderStyle = BorderStyle.FixedSingle;
            pnlListMenu.Dock = DockStyle.Left;
            pnlListMenu.Location = new Point(0, 0);
            pnlListMenu.Name = "pnlListMenu";
            pnlListMenu.Size = new Size(228, 672);
            pnlListMenu.TabIndex = 0;
            // 
            // pnlFunction
            // 
            pnlFunction.BorderStyle = BorderStyle.FixedSingle;
            pnlFunction.Controls.Add(btnEsci);
            pnlFunction.Controls.Add(btnImpostazioni);
            pnlFunction.Controls.Add(btnRicaricaMenu);
            pnlFunction.Controls.Add(btnGestioneMenu);
            pnlFunction.Dock = DockStyle.Top;
            pnlFunction.Location = new Point(228, 0);
            pnlFunction.Name = "pnlFunction";
            pnlFunction.Size = new Size(1029, 86);
            pnlFunction.TabIndex = 1;
            // 
            // btnEsci
            // 
            btnEsci.Dock = DockStyle.Left;
            btnEsci.FlatAppearance.BorderSize = 0;
            btnEsci.FlatStyle = FlatStyle.Flat;
            btnEsci.Image = Properties.Resources.esci_24x24;
            btnEsci.Location = new Point(300, 0);
            btnEsci.Name = "btnEsci";
            btnEsci.Size = new Size(100, 84);
            btnEsci.TabIndex = 3;
            btnEsci.Tag = "Esci";
            btnEsci.Text = "Esci";
            btnEsci.TextAlign = ContentAlignment.BottomCenter;
            btnEsci.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEsci.UseVisualStyleBackColor = true;
            btnEsci.Click += btnEsci_Click;
            // 
            // btnImpostazioni
            // 
            btnImpostazioni.Dock = DockStyle.Left;
            btnImpostazioni.FlatAppearance.BorderSize = 0;
            btnImpostazioni.FlatStyle = FlatStyle.Flat;
            btnImpostazioni.Image = Properties.Resources.impostazioni_24x24;
            btnImpostazioni.Location = new Point(200, 0);
            btnImpostazioni.Name = "btnImpostazioni";
            btnImpostazioni.Size = new Size(100, 84);
            btnImpostazioni.TabIndex = 2;
            btnImpostazioni.Tag = "Impostazioni";
            btnImpostazioni.Text = "Impostazioni";
            btnImpostazioni.TextAlign = ContentAlignment.BottomCenter;
            btnImpostazioni.TextImageRelation = TextImageRelation.ImageAboveText;
            btnImpostazioni.UseVisualStyleBackColor = true;
            btnImpostazioni.Click += btnImpostazioni_Click;
            // 
            // btnRicaricaMenu
            // 
            btnRicaricaMenu.Dock = DockStyle.Left;
            btnRicaricaMenu.FlatAppearance.BorderSize = 0;
            btnRicaricaMenu.FlatStyle = FlatStyle.Flat;
            btnRicaricaMenu.Image = Properties.Resources.ricarica_24x24;
            btnRicaricaMenu.Location = new Point(100, 0);
            btnRicaricaMenu.Name = "btnRicaricaMenu";
            btnRicaricaMenu.Size = new Size(100, 84);
            btnRicaricaMenu.TabIndex = 1;
            btnRicaricaMenu.Tag = "RicaricaMenu";
            btnRicaricaMenu.Text = "Ricarica menù";
            btnRicaricaMenu.TextAlign = ContentAlignment.BottomCenter;
            btnRicaricaMenu.TextImageRelation = TextImageRelation.ImageAboveText;
            btnRicaricaMenu.UseVisualStyleBackColor = true;
            btnRicaricaMenu.Click += btnRicaricaMenu_Click;
            // 
            // btnGestioneMenu
            // 
            btnGestioneMenu.Dock = DockStyle.Left;
            btnGestioneMenu.FlatAppearance.BorderSize = 0;
            btnGestioneMenu.FlatStyle = FlatStyle.Flat;
            btnGestioneMenu.Image = Properties.Resources.modifica_24x24;
            btnGestioneMenu.Location = new Point(0, 0);
            btnGestioneMenu.Name = "btnGestioneMenu";
            btnGestioneMenu.Size = new Size(100, 84);
            btnGestioneMenu.TabIndex = 0;
            btnGestioneMenu.Tag = "GestioneMenu";
            btnGestioneMenu.Text = "Gestione menù";
            btnGestioneMenu.TextAlign = ContentAlignment.BottomCenter;
            btnGestioneMenu.TextImageRelation = TextImageRelation.ImageAboveText;
            btnGestioneMenu.UseVisualStyleBackColor = true;
            btnGestioneMenu.Click += btnGestioneMenu_Click;
            // 
            // pnlAttivita
            // 
            pnlAttivita.Dock = DockStyle.Fill;
            pnlAttivita.Location = new Point(228, 86);
            pnlAttivita.Name = "pnlAttivita";
            pnlAttivita.Size = new Size(1029, 586);
            pnlAttivita.TabIndex = 2;
            // 
            // WMmain
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 672);
            Controls.Add(pnlAttivita);
            Controls.Add(pnlFunction);
            Controls.Add(pnlListMenu);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "WMmain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WorkManager";
            pnlFunction.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlListMenu;
        private Panel pnlFunction;
        private Button btnGestioneMenu;
        private Button btnRicaricaMenu;
        private Button btnImpostazioni;
        private Panel pnlAttivita;
        private Button btnEsci;
    }
}