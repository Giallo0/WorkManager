namespace WorkManager.PanelImpostazioni
{
    partial class pnlImpostazioniOpzioni
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
            chkChiusura = new CheckBox();
            SuspendLayout();
            // 
            // chkChiusura
            // 
            chkChiusura.AutoSize = true;
            chkChiusura.Location = new Point(20, 20);
            chkChiusura.Name = "chkChiusura";
            chkChiusura.Size = new Size(259, 21);
            chkChiusura.TabIndex = 0;
            chkChiusura.Text = "Alla chiusura mantieni in esecuzione";
            chkChiusura.UseVisualStyleBackColor = true;
            chkChiusura.CheckedChanged += chkChiusura_CheckedChanged;
            // 
            // pnlImpostazioniOpzioni
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(chkChiusura);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "pnlImpostazioniOpzioni";
            Size = new Size(1050, 700);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox chkChiusura;
    }
}
