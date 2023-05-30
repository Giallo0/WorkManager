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
            colNome = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colPercorso = new DataGridViewTextBoxColumn();
            pnlPulsanti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridCartelle).BeginInit();
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
            gridCartelle.Columns.AddRange(new DataGridViewColumn[] { colNome, colTipo, colPercorso });
            gridCartelle.Dock = DockStyle.Fill;
            gridCartelle.Location = new Point(0, 0);
            gridCartelle.MultiSelect = false;
            gridCartelle.Name = "gridCartelle";
            gridCartelle.ReadOnly = true;
            gridCartelle.RowTemplate.Height = 25;
            gridCartelle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridCartelle.Size = new Size(800, 389);
            gridCartelle.TabIndex = 1;
            gridCartelle.MouseDoubleClick += gridCartelle_MouseDoubleClick;
            // 
            // colNome
            // 
            colNome.HeaderText = "Nome";
            colNome.Name = "colNome";
            colNome.ReadOnly = true;
            // 
            // colTipo
            // 
            colTipo.HeaderText = "Tipo";
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            // 
            // colPercorso
            // 
            colPercorso.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPercorso.HeaderText = "Percorso";
            colPercorso.Name = "colPercorso";
            colPercorso.ReadOnly = true;
            // 
            // FinFolder2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gridCartelle);
            Controls.Add(pnlPulsanti);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FinFolder2";
            Text = "Cerca Percorso";
            pnlPulsanti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridCartelle).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnConferma;
        private Button btnAnnulla;
        private Panel pnlPulsanti;
        private DataGridView gridCartelle;
        private DataGridViewTextBoxColumn colNome;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colPercorso;
    }
}