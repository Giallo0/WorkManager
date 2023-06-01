namespace WorkManager_A
{
    partial class FinFolder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinFolder));
            btnConferma = new Button();
            btnAnnulla = new Button();
            pnlPulsanti = new Panel();
            gridCartelle = new DataGridView();
            cboCliente = new ComboBox();
            lblCliente = new Label();
            groupBox1 = new GroupBox();
            cboTipo = new ComboBox();
            lblTipo = new Label();
            chbProgDec = new CheckBox();
            pnlPulsanti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridCartelle).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnConferma
            // 
            btnConferma.Dock = DockStyle.Right;
            btnConferma.FlatAppearance.BorderSize = 0;
            btnConferma.FlatStyle = FlatStyle.Flat;
            btnConferma.Location = new Point(611, 0);
            btnConferma.Name = "btnConferma";
            btnConferma.Size = new Size(92, 59);
            btnConferma.TabIndex = 0;
            btnConferma.Text = "Seleziona";
            btnConferma.UseVisualStyleBackColor = true;
            btnConferma.Click += btnConferma_Click;
            // 
            // btnAnnulla
            // 
            btnAnnulla.Dock = DockStyle.Right;
            btnAnnulla.FlatAppearance.BorderSize = 0;
            btnAnnulla.FlatStyle = FlatStyle.Flat;
            btnAnnulla.Location = new Point(703, 0);
            btnAnnulla.Name = "btnAnnulla";
            btnAnnulla.Size = new Size(95, 59);
            btnAnnulla.TabIndex = 1;
            btnAnnulla.Text = "Annulla";
            btnAnnulla.UseVisualStyleBackColor = true;
            btnAnnulla.Click += btnAnnulla_Click;
            // 
            // pnlPulsanti
            // 
            pnlPulsanti.BorderStyle = BorderStyle.FixedSingle;
            pnlPulsanti.Controls.Add(btnConferma);
            pnlPulsanti.Controls.Add(btnAnnulla);
            pnlPulsanti.Dock = DockStyle.Bottom;
            pnlPulsanti.Location = new Point(0, 389);
            pnlPulsanti.Name = "pnlPulsanti";
            pnlPulsanti.Size = new Size(800, 61);
            pnlPulsanti.TabIndex = 0;
            // 
            // gridCartelle
            // 
            gridCartelle.AllowUserToAddRows = false;
            gridCartelle.AllowUserToDeleteRows = false;
            gridCartelle.AllowUserToOrderColumns = true;
            gridCartelle.AllowUserToResizeRows = false;
            gridCartelle.BackgroundColor = SystemColors.Control;
            gridCartelle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridCartelle.Dock = DockStyle.Fill;
            gridCartelle.Location = new Point(0, 66);
            gridCartelle.MultiSelect = false;
            gridCartelle.Name = "gridCartelle";
            gridCartelle.ReadOnly = true;
            gridCartelle.RowTemplate.Height = 25;
            gridCartelle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridCartelle.Size = new Size(800, 323);
            gridCartelle.TabIndex = 1;
            gridCartelle.MouseDoubleClick += gridCartelle_MouseDoubleClick;
            // 
            // cboCliente
            // 
            cboCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(258, 27);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(144, 23);
            cboCliente.TabIndex = 0;
            cboCliente.TextChanged += cboCliente_TextChanged;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(205, 30);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(47, 15);
            lblCliente.TabIndex = 1;
            lblCliente.Text = "Cliente:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chbProgDec);
            groupBox1.Controls.Add(cboTipo);
            groupBox1.Controls.Add(lblTipo);
            groupBox1.Controls.Add(lblCliente);
            groupBox1.Controls.Add(cboCliente);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(800, 66);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtri di ricerca";
            // 
            // cboTipo
            // 
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.FormattingEnabled = true;
            cboTipo.Location = new Point(51, 27);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(121, 23);
            cboTipo.TabIndex = 3;
            cboTipo.TextChanged += cboTipo_TextChanged;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(12, 30);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(33, 15);
            lblTipo.TabIndex = 2;
            lblTipo.Text = "Tipo:";
            // 
            // chbProgDec
            // 
            chbProgDec.AutoSize = true;
            chbProgDec.Location = new Point(421, 29);
            chbProgDec.Name = "chbProgDec";
            chbProgDec.Size = new Size(153, 19);
            chbProgDec.TabIndex = 4;
            chbProgDec.Text = "Progressivo decrescente";
            chbProgDec.UseVisualStyleBackColor = true;
            chbProgDec.CheckedChanged += chbProgDec_CheckedChanged;
            // 
            // FinFolder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gridCartelle);
            Controls.Add(groupBox1);
            Controls.Add(pnlPulsanti);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FinFolder";
            Text = "Cerca Percorso";
            pnlPulsanti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridCartelle).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnConferma;
        private Button btnAnnulla;
        private Panel pnlPulsanti;
        private DataGridView gridCartelle;
        private ComboBox cboCliente;
        private Label lblCliente;
        private GroupBox groupBox1;
        private ComboBox cboTipo;
        private Label lblTipo;
        private CheckBox chbProgDec;
    }
}