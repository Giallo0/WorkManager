namespace WorkManager.PanelImpostazioni
{
    partial class pnlImpostazioniWorkspace
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            lblPath = new Label();
            txtPath = new TextBox();
            btnCambia = new Button();
            gbxDescrizione = new GroupBox();
            txtDescrizione = new TextBox();
            gbxDescrizione.SuspendLayout();
            SuspendLayout();
            // 
            // lblPath
            // 
            lblPath.AutoSize = true;
            lblPath.Location = new Point(20, 20);
            lblPath.Name = "lblPath";
            lblPath.Size = new Size(143, 17);
            lblPath.TabIndex = 0;
            lblPath.Text = "Percorso Workspace:";
            // 
            // txtPath
            // 
            txtPath.Location = new Point(169, 17);
            txtPath.Name = "txtPath";
            txtPath.ReadOnly = true;
            txtPath.Size = new Size(705, 23);
            txtPath.TabIndex = 1;
            // 
            // btnCambia
            // 
            btnCambia.Location = new Point(880, 17);
            btnCambia.Name = "btnCambia";
            btnCambia.Size = new Size(150, 26);
            btnCambia.TabIndex = 2;
            btnCambia.Text = "Cambia percorso";
            btnCambia.UseVisualStyleBackColor = true;
            btnCambia.Click += btnCambia_Click;
            // 
            // gbxDescrizione
            // 
            gbxDescrizione.Controls.Add(txtDescrizione);
            gbxDescrizione.Location = new Point(20, 460);
            gbxDescrizione.Name = "gbxDescrizione";
            gbxDescrizione.Padding = new Padding(11, 3, 11, 11);
            gbxDescrizione.Size = new Size(1010, 220);
            gbxDescrizione.TabIndex = 3;
            gbxDescrizione.TabStop = false;
            gbxDescrizione.Text = "Descrizione";
            // 
            // txtDescrizione
            // 
            txtDescrizione.Dock = DockStyle.Fill;
            txtDescrizione.Location = new Point(11, 19);
            txtDescrizione.Multiline = true;
            txtDescrizione.Name = "txtDescrizione";
            txtDescrizione.ReadOnly = true;
            txtDescrizione.Size = new Size(988, 190);
            txtDescrizione.TabIndex = 0;
            // 
            // pnlImpostazioniWorkspace
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gbxDescrizione);
            Controls.Add(btnCambia);
            Controls.Add(txtPath);
            Controls.Add(lblPath);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "pnlImpostazioniWorkspace";
            Size = new Size(1050, 700);
            gbxDescrizione.ResumeLayout(false);
            gbxDescrizione.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPath;
        private TextBox txtPath;
        private Button btnCambia;
        private GroupBox gbxDescrizione;
        private TextBox txtDescrizione;
    }
}
