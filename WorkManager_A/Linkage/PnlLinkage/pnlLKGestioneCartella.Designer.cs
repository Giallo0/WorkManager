namespace WorkManager_A.Linkage.PnlLinkage
{
    partial class pnlLKGestioneCartella
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
            gbxFunzione = new GroupBox();
            rbtEliminazione = new RadioButton();
            rbtModifica = new RadioButton();
            rbtInserimento = new RadioButton();
            label1 = new Label();
            cboTipoCartella = new ComboBox();
            gbxFunzione.SuspendLayout();
            SuspendLayout();
            // 
            // gbxFunzione
            // 
            gbxFunzione.Controls.Add(rbtEliminazione);
            gbxFunzione.Controls.Add(rbtModifica);
            gbxFunzione.Controls.Add(rbtInserimento);
            gbxFunzione.Location = new Point(20, 20);
            gbxFunzione.Name = "gbxFunzione";
            gbxFunzione.Size = new Size(200, 101);
            gbxFunzione.TabIndex = 0;
            gbxFunzione.TabStop = false;
            gbxFunzione.Text = "Funzione";
            // 
            // rbtEliminazione
            // 
            rbtEliminazione.AutoSize = true;
            rbtEliminazione.Location = new Point(10, 74);
            rbtEliminazione.Name = "rbtEliminazione";
            rbtEliminazione.Size = new Size(106, 21);
            rbtEliminazione.TabIndex = 2;
            rbtEliminazione.TabStop = true;
            rbtEliminazione.Text = "Eliminazione";
            rbtEliminazione.UseVisualStyleBackColor = true;
            rbtEliminazione.CheckedChanged += rbtEliminazione_CheckedChanged;
            // 
            // rbtModifica
            // 
            rbtModifica.AutoSize = true;
            rbtModifica.Location = new Point(10, 47);
            rbtModifica.Name = "rbtModifica";
            rbtModifica.Size = new Size(82, 21);
            rbtModifica.TabIndex = 1;
            rbtModifica.TabStop = true;
            rbtModifica.Text = "Modifica";
            rbtModifica.UseVisualStyleBackColor = true;
            rbtModifica.CheckedChanged += rbtModifica_CheckedChanged;
            // 
            // rbtInserimento
            // 
            rbtInserimento.AutoSize = true;
            rbtInserimento.Location = new Point(10, 20);
            rbtInserimento.Name = "rbtInserimento";
            rbtInserimento.Size = new Size(100, 21);
            rbtInserimento.TabIndex = 0;
            rbtInserimento.TabStop = true;
            rbtInserimento.Text = "Inserimento";
            rbtInserimento.UseVisualStyleBackColor = true;
            rbtInserimento.CheckedChanged += rbtInserimento_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(240, 40);
            label1.Name = "label1";
            label1.Size = new Size(90, 17);
            label1.TabIndex = 1;
            label1.Text = "TipoCartella:";
            // 
            // cboTipoCartella
            // 
            cboTipoCartella.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoCartella.FormattingEnabled = true;
            cboTipoCartella.Location = new Point(336, 37);
            cboTipoCartella.Name = "cboTipoCartella";
            cboTipoCartella.Size = new Size(180, 25);
            cboTipoCartella.TabIndex = 2;
            cboTipoCartella.TextChanged += cboTipoCartella_TextChanged;
            // 
            // pnlLKGestioneCartella
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cboTipoCartella);
            Controls.Add(label1);
            Controls.Add(gbxFunzione);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "pnlLKGestioneCartella";
            Size = new Size(1250, 640);
            gbxFunzione.ResumeLayout(false);
            gbxFunzione.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbxFunzione;
        private RadioButton rbtEliminazione;
        private RadioButton rbtModifica;
        private RadioButton rbtInserimento;
        private Label label1;
        private ComboBox cboTipoCartella;
    }
}
