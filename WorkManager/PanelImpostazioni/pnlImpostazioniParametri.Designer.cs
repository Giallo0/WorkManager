namespace WorkManager.PanelImpostazioni
{
    partial class pnlImpostazioniParametri
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
            components = new System.ComponentModel.Container();
            gridGestioneCartella = new DataGridView();
            colParametro = new DataGridViewTextBoxColumn();
            colValore = new DataGridViewTextBoxColumn();
            colDescrizione = new DataGridViewTextBoxColumn();
            mnuGridGestioneCartella = new ContextMenuStrip(components);
            eliminaRigaToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            lblGruppo = new Label();
            cboGruppo = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)gridGestioneCartella).BeginInit();
            mnuGridGestioneCartella.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // gridGestioneCartella
            // 
            gridGestioneCartella.BackgroundColor = SystemColors.Control;
            gridGestioneCartella.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridGestioneCartella.Columns.AddRange(new DataGridViewColumn[] { colParametro, colValore, colDescrizione });
            gridGestioneCartella.Dock = DockStyle.Fill;
            gridGestioneCartella.Location = new Point(3, 103);
            gridGestioneCartella.MultiSelect = false;
            gridGestioneCartella.Name = "gridGestioneCartella";
            gridGestioneCartella.RowTemplate.Height = 25;
            gridGestioneCartella.Size = new Size(1044, 594);
            gridGestioneCartella.TabIndex = 0;
            gridGestioneCartella.RowEnter += gridGestioneCartella_RowEnter;
            gridGestioneCartella.RowValidating += gridGestioneCartella_RowValidating;
            gridGestioneCartella.MouseClick += gridGestioneCartella_MouseClick;
            // 
            // colParametro
            // 
            colParametro.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colParametro.HeaderText = "Parametro";
            colParametro.Name = "colParametro";
            colParametro.Width = 102;
            // 
            // colValore
            // 
            colValore.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colValore.HeaderText = "Valore";
            colValore.Name = "colValore";
            colValore.Width = 75;
            // 
            // colDescrizione
            // 
            colDescrizione.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescrizione.HeaderText = "Descrizione";
            colDescrizione.Name = "colDescrizione";
            // 
            // mnuGridGestioneCartella
            // 
            mnuGridGestioneCartella.Items.AddRange(new ToolStripItem[] { eliminaRigaToolStripMenuItem });
            mnuGridGestioneCartella.Name = "mnuGridGestioneCartella";
            mnuGridGestioneCartella.Size = new Size(137, 26);
            // 
            // eliminaRigaToolStripMenuItem
            // 
            eliminaRigaToolStripMenuItem.Name = "eliminaRigaToolStripMenuItem";
            eliminaRigaToolStripMenuItem.Size = new Size(136, 22);
            eliminaRigaToolStripMenuItem.Text = "Elimina riga";
            eliminaRigaToolStripMenuItem.Click += eliminaRigaToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(cboGruppo);
            panel1.Controls.Add(lblGruppo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1044, 100);
            panel1.TabIndex = 1;
            // 
            // lblGruppo
            // 
            lblGruppo.AutoSize = true;
            lblGruppo.Location = new Point(20, 20);
            lblGruppo.Name = "lblGruppo";
            lblGruppo.Size = new Size(62, 17);
            lblGruppo.TabIndex = 0;
            lblGruppo.Text = "Gruppo:";
            // 
            // cboGruppo
            // 
            cboGruppo.FormattingEnabled = true;
            cboGruppo.Location = new Point(88, 17);
            cboGruppo.Name = "cboGruppo";
            cboGruppo.Size = new Size(200, 25);
            cboGruppo.TabIndex = 1;
            cboGruppo.TextChanged += cboGruppo_TextChanged;
            // 
            // pnlImpostazioniParametri
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridGestioneCartella);
            Controls.Add(panel1);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "pnlImpostazioniParametri";
            Padding = new Padding(3);
            Size = new Size(1050, 700);
            ((System.ComponentModel.ISupportInitialize)gridGestioneCartella).EndInit();
            mnuGridGestioneCartella.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridGestioneCartella;
        private ContextMenuStrip mnuGridGestioneCartella;
        private ToolStripMenuItem eliminaRigaToolStripMenuItem;
        private DataGridViewTextBoxColumn colParametro;
        private DataGridViewTextBoxColumn colValore;
        private DataGridViewTextBoxColumn colDescrizione;
        private Panel panel1;
        private ComboBox cboGruppo;
        private Label lblGruppo;
    }
}
