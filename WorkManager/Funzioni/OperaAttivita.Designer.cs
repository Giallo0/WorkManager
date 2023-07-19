namespace WorkManager.Funzioni
{
    partial class OperaAttivita
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperaAttivita));
            pnlTop = new Panel();
            pnlPrimaParte = new Panel();
            txtCliente = new TextBox();
            btnCercaCliente = new Button();
            lblCliente = new Label();
            cboAttivita = new ComboBox();
            lblAttivita = new Label();
            pnlPulsanti = new Panel();
            btnAnnulla = new Button();
            btnConferma = new Button();
            pnlSecondaParte = new Panel();
            pnlContenuto = new Panel();
            gridContenuto = new DataGridView();
            colNome = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colPercorso = new DataGridViewTextBoxColumn();
            pnlFunzioni = new Panel();
            btnRimuovi = new Button();
            btnRinomina = new Button();
            btnChiudiAttivita = new Button();
            btnAddFile = new Button();
            btnAddCartella = new Button();
            pnlTop.SuspendLayout();
            pnlPrimaParte.SuspendLayout();
            pnlPulsanti.SuspendLayout();
            pnlSecondaParte.SuspendLayout();
            pnlContenuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridContenuto).BeginInit();
            pnlFunzioni.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(pnlPrimaParte);
            pnlTop.Controls.Add(pnlPulsanti);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1250, 50);
            pnlTop.TabIndex = 0;
            // 
            // pnlPrimaParte
            // 
            pnlPrimaParte.Controls.Add(txtCliente);
            pnlPrimaParte.Controls.Add(btnCercaCliente);
            pnlPrimaParte.Controls.Add(lblCliente);
            pnlPrimaParte.Controls.Add(cboAttivita);
            pnlPrimaParte.Controls.Add(lblAttivita);
            pnlPrimaParte.Dock = DockStyle.Fill;
            pnlPrimaParte.Location = new Point(0, 0);
            pnlPrimaParte.Name = "pnlPrimaParte";
            pnlPrimaParte.Size = new Size(1050, 50);
            pnlPrimaParte.TabIndex = 5;
            // 
            // txtCliente
            // 
            txtCliente.Enabled = false;
            txtCliente.Location = new Point(76, 12);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(125, 23);
            txtCliente.TabIndex = 4;
            // 
            // btnCercaCliente
            // 
            btnCercaCliente.Image = Properties.Resources.cerca_24x24;
            btnCercaCliente.Location = new Point(207, 7);
            btnCercaCliente.Name = "btnCercaCliente";
            btnCercaCliente.Size = new Size(32, 32);
            btnCercaCliente.TabIndex = 3;
            btnCercaCliente.UseVisualStyleBackColor = true;
            btnCercaCliente.Click += btnCercaCliente_Click;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(12, 15);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(58, 17);
            lblCliente.TabIndex = 2;
            lblCliente.Text = "Cliente:";
            // 
            // cboAttivita
            // 
            cboAttivita.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAttivita.FormattingEnabled = true;
            cboAttivita.Location = new Point(365, 12);
            cboAttivita.Name = "cboAttivita";
            cboAttivita.Size = new Size(675, 25);
            cboAttivita.TabIndex = 1;
            // 
            // lblAttivita
            // 
            lblAttivita.AutoSize = true;
            lblAttivita.Location = new Point(300, 15);
            lblAttivita.Name = "lblAttivita";
            lblAttivita.Size = new Size(59, 17);
            lblAttivita.TabIndex = 0;
            lblAttivita.Text = "Attività:";
            // 
            // pnlPulsanti
            // 
            pnlPulsanti.BorderStyle = BorderStyle.FixedSingle;
            pnlPulsanti.Controls.Add(btnAnnulla);
            pnlPulsanti.Controls.Add(btnConferma);
            pnlPulsanti.Dock = DockStyle.Right;
            pnlPulsanti.Location = new Point(1050, 0);
            pnlPulsanti.Name = "pnlPulsanti";
            pnlPulsanti.Size = new Size(200, 50);
            pnlPulsanti.TabIndex = 4;
            // 
            // btnAnnulla
            // 
            btnAnnulla.Dock = DockStyle.Top;
            btnAnnulla.FlatAppearance.BorderSize = 0;
            btnAnnulla.FlatStyle = FlatStyle.Flat;
            btnAnnulla.Location = new Point(0, 24);
            btnAnnulla.Name = "btnAnnulla";
            btnAnnulla.Size = new Size(198, 24);
            btnAnnulla.TabIndex = 3;
            btnAnnulla.Text = "Annulla";
            btnAnnulla.UseVisualStyleBackColor = true;
            btnAnnulla.Click += btnAnnulla_Click;
            // 
            // btnConferma
            // 
            btnConferma.Dock = DockStyle.Top;
            btnConferma.FlatAppearance.BorderSize = 0;
            btnConferma.FlatStyle = FlatStyle.Flat;
            btnConferma.Location = new Point(0, 0);
            btnConferma.Name = "btnConferma";
            btnConferma.Size = new Size(198, 24);
            btnConferma.TabIndex = 2;
            btnConferma.Text = "Conferma";
            btnConferma.UseVisualStyleBackColor = true;
            btnConferma.Click += btnConferma_Click;
            // 
            // pnlSecondaParte
            // 
            pnlSecondaParte.Controls.Add(pnlContenuto);
            pnlSecondaParte.Controls.Add(pnlFunzioni);
            pnlSecondaParte.Dock = DockStyle.Fill;
            pnlSecondaParte.Location = new Point(0, 50);
            pnlSecondaParte.Name = "pnlSecondaParte";
            pnlSecondaParte.Size = new Size(1250, 650);
            pnlSecondaParte.TabIndex = 1;
            // 
            // pnlContenuto
            // 
            pnlContenuto.Controls.Add(gridContenuto);
            pnlContenuto.Dock = DockStyle.Fill;
            pnlContenuto.Location = new Point(0, 0);
            pnlContenuto.Name = "pnlContenuto";
            pnlContenuto.Padding = new Padding(10);
            pnlContenuto.Size = new Size(1050, 650);
            pnlContenuto.TabIndex = 0;
            // 
            // gridContenuto
            // 
            gridContenuto.AllowUserToAddRows = false;
            gridContenuto.AllowUserToDeleteRows = false;
            gridContenuto.AllowUserToResizeRows = false;
            gridContenuto.BackgroundColor = SystemColors.Control;
            gridContenuto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridContenuto.Columns.AddRange(new DataGridViewColumn[] { colNome, colTipo, colPercorso });
            gridContenuto.Dock = DockStyle.Fill;
            gridContenuto.Location = new Point(10, 10);
            gridContenuto.MultiSelect = false;
            gridContenuto.Name = "gridContenuto";
            gridContenuto.RowTemplate.Height = 25;
            gridContenuto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridContenuto.Size = new Size(1030, 630);
            gridContenuto.TabIndex = 0;
            // 
            // colNome
            // 
            colNome.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colNome.HeaderText = "Nome";
            colNome.Name = "colNome";
            colNome.ReadOnly = true;
            colNome.Width = 73;
            // 
            // colTipo
            // 
            colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colTipo.HeaderText = "Tipo";
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            colTipo.Width = 59;
            // 
            // colPercorso
            // 
            colPercorso.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPercorso.HeaderText = "Percorso";
            colPercorso.Name = "colPercorso";
            colPercorso.ReadOnly = true;
            // 
            // pnlFunzioni
            // 
            pnlFunzioni.Controls.Add(btnRimuovi);
            pnlFunzioni.Controls.Add(btnRinomina);
            pnlFunzioni.Controls.Add(btnChiudiAttivita);
            pnlFunzioni.Controls.Add(btnAddFile);
            pnlFunzioni.Controls.Add(btnAddCartella);
            pnlFunzioni.Dock = DockStyle.Right;
            pnlFunzioni.Location = new Point(1050, 0);
            pnlFunzioni.Name = "pnlFunzioni";
            pnlFunzioni.Size = new Size(200, 650);
            pnlFunzioni.TabIndex = 1;
            // 
            // btnRimuovi
            // 
            btnRimuovi.Location = new Point(3, 98);
            btnRimuovi.Name = "btnRimuovi";
            btnRimuovi.Size = new Size(191, 25);
            btnRimuovi.TabIndex = 4;
            btnRimuovi.Text = "Rimuovi";
            btnRimuovi.UseVisualStyleBackColor = true;
            btnRimuovi.Click += btnRimuovi_Click;
            // 
            // btnRinomina
            // 
            btnRinomina.Location = new Point(3, 67);
            btnRinomina.Name = "btnRinomina";
            btnRinomina.Size = new Size(191, 25);
            btnRinomina.TabIndex = 3;
            btnRinomina.Text = "Rinomina";
            btnRinomina.UseVisualStyleBackColor = true;
            btnRinomina.Click += btnRinomina_Click;
            // 
            // btnChiudiAttivita
            // 
            btnChiudiAttivita.Location = new Point(3, 129);
            btnChiudiAttivita.Name = "btnChiudiAttivita";
            btnChiudiAttivita.Size = new Size(191, 25);
            btnChiudiAttivita.TabIndex = 2;
            btnChiudiAttivita.Text = "Chiudi attività";
            btnChiudiAttivita.UseVisualStyleBackColor = true;
            btnChiudiAttivita.Click += btnChiudiAttivita_Click;
            // 
            // btnAddFile
            // 
            btnAddFile.Location = new Point(3, 36);
            btnAddFile.Name = "btnAddFile";
            btnAddFile.Size = new Size(191, 25);
            btnAddFile.TabIndex = 1;
            btnAddFile.Text = "Aggiungi file";
            btnAddFile.UseVisualStyleBackColor = true;
            btnAddFile.Click += btnAddFile_Click;
            // 
            // btnAddCartella
            // 
            btnAddCartella.Location = new Point(3, 5);
            btnAddCartella.Name = "btnAddCartella";
            btnAddCartella.Size = new Size(191, 25);
            btnAddCartella.TabIndex = 0;
            btnAddCartella.Text = "Aggiungi cartella";
            btnAddCartella.UseVisualStyleBackColor = true;
            btnAddCartella.Click += btnAddCartella_Click;
            // 
            // OperaAttivita
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 700);
            Controls.Add(pnlSecondaParte);
            Controls.Add(pnlTop);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "OperaAttivita";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Opera Attività";
            pnlTop.ResumeLayout(false);
            pnlPrimaParte.ResumeLayout(false);
            pnlPrimaParte.PerformLayout();
            pnlPulsanti.ResumeLayout(false);
            pnlSecondaParte.ResumeLayout(false);
            pnlContenuto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridContenuto).EndInit();
            pnlFunzioni.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Panel pnlPulsanti;
        private Button btnAnnulla;
        private Button btnConferma;
        private ComboBox cboAttivita;
        private Label lblAttivita;
        private Panel pnlSecondaParte;
        private Panel pnlContenuto;
        private DataGridView gridContenuto;
        private DataGridViewTextBoxColumn colNome;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colPercorso;
        private Panel pnlFunzioni;
        private Button btnChiudiAttivita;
        private Button btnAddFile;
        private Button btnAddCartella;
        private Button btnRinomina;
        private Button btnRimuovi;
        private Panel pnlPrimaParte;
        private TextBox txtCliente;
        private Button btnCercaCliente;
        private Label lblCliente;
    }
}