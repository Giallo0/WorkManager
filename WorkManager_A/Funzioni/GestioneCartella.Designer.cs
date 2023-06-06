namespace WorkManager.Funzioni
{
    partial class GestioneCartella
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestioneCartella));
            lblPercorso = new Label();
            txtPercorso = new TextBox();
            txtNome = new TextBox();
            lblNome = new Label();
            panel1 = new Panel();
            txtProgressivo = new TextBox();
            lblProgressivo = new Label();
            cboTipoCartella = new ComboBox();
            lblTipoCartella = new Label();
            btnCerca = new Button();
            panel2 = new Panel();
            btnConferma = new Button();
            btnAnnulla = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblPercorso
            // 
            lblPercorso.AutoSize = true;
            lblPercorso.Location = new Point(87, 42);
            lblPercorso.Name = "lblPercorso";
            lblPercorso.Size = new Size(67, 17);
            lblPercorso.TabIndex = 0;
            lblPercorso.Text = "Percorso:";
            // 
            // txtPercorso
            // 
            txtPercorso.Enabled = false;
            txtPercorso.Location = new Point(158, 39);
            txtPercorso.Name = "txtPercorso";
            txtPercorso.Size = new Size(587, 23);
            txtPercorso.TabIndex = 1;
            txtPercorso.TextChanged += txtPercorso_TextChanged;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(320, 76);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(425, 23);
            txtNome.TabIndex = 2;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(262, 79);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(52, 17);
            lblNome.TabIndex = 3;
            lblNome.Text = "Nome:";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtProgressivo);
            panel1.Controls.Add(lblProgressivo);
            panel1.Controls.Add(cboTipoCartella);
            panel1.Controls.Add(lblTipoCartella);
            panel1.Controls.Add(btnCerca);
            panel1.Controls.Add(txtNome);
            panel1.Controls.Add(lblPercorso);
            panel1.Controls.Add(lblNome);
            panel1.Controls.Add(txtPercorso);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1250, 640);
            panel1.TabIndex = 4;
            // 
            // txtProgressivo
            // 
            txtProgressivo.Enabled = false;
            txtProgressivo.Location = new Point(160, 76);
            txtProgressivo.MaxLength = 3;
            txtProgressivo.Name = "txtProgressivo";
            txtProgressivo.Size = new Size(58, 23);
            txtProgressivo.TabIndex = 11;
            txtProgressivo.TextAlign = HorizontalAlignment.Right;
            // 
            // lblProgressivo
            // 
            lblProgressivo.AutoSize = true;
            lblProgressivo.Location = new Point(70, 79);
            lblProgressivo.Name = "lblProgressivo";
            lblProgressivo.Size = new Size(84, 17);
            lblProgressivo.TabIndex = 10;
            lblProgressivo.Text = "Progressivo:";
            // 
            // cboTipoCartella
            // 
            cboTipoCartella.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoCartella.FormattingEnabled = true;
            cboTipoCartella.Location = new Point(575, 114);
            cboTipoCartella.Name = "cboTipoCartella";
            cboTipoCartella.Size = new Size(170, 25);
            cboTipoCartella.TabIndex = 9;
            cboTipoCartella.TextChanged += cboTipoCartella_TextChanged;
            // 
            // lblTipoCartella
            // 
            lblTipoCartella.AutoSize = true;
            lblTipoCartella.Location = new Point(531, 117);
            lblTipoCartella.Name = "lblTipoCartella";
            lblTipoCartella.Size = new Size(38, 17);
            lblTipoCartella.TabIndex = 8;
            lblTipoCartella.Text = "Tipo:";
            // 
            // btnCerca
            // 
            btnCerca.Image = Properties.Resources.cerca_24x24;
            btnCerca.Location = new Point(751, 35);
            btnCerca.Name = "btnCerca";
            btnCerca.Size = new Size(36, 31);
            btnCerca.TabIndex = 4;
            btnCerca.UseVisualStyleBackColor = true;
            btnCerca.Click += btnCerca_Click;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(btnConferma);
            panel2.Controls.Add(btnAnnulla);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 640);
            panel2.Name = "panel2";
            panel2.Size = new Size(1250, 60);
            panel2.TabIndex = 5;
            // 
            // btnConferma
            // 
            btnConferma.Dock = DockStyle.Right;
            btnConferma.FlatAppearance.BorderSize = 0;
            btnConferma.FlatStyle = FlatStyle.Flat;
            btnConferma.Location = new Point(1048, 0);
            btnConferma.Name = "btnConferma";
            btnConferma.Size = new Size(100, 58);
            btnConferma.TabIndex = 0;
            btnConferma.Text = "Conferma";
            btnConferma.UseVisualStyleBackColor = true;
            btnConferma.Click += btnConferma_Click;
            // 
            // btnAnnulla
            // 
            btnAnnulla.Dock = DockStyle.Right;
            btnAnnulla.FlatAppearance.BorderSize = 0;
            btnAnnulla.FlatStyle = FlatStyle.Flat;
            btnAnnulla.Location = new Point(1148, 0);
            btnAnnulla.Name = "btnAnnulla";
            btnAnnulla.Size = new Size(100, 58);
            btnAnnulla.TabIndex = 1;
            btnAnnulla.Text = "Annulla";
            btnAnnulla.UseVisualStyleBackColor = true;
            btnAnnulla.Click += btnAnnulla_Click;
            // 
            // GestioneCartella
            // 
            AcceptButton = btnConferma;
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnAnnulla;
            ClientSize = new Size(1250, 700);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "GestioneCartella";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestione Cartella";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblPercorso;
        private TextBox txtPercorso;
        private TextBox txtNome;
        private Label lblNome;
        private Panel panel1;
        private Button btnCerca;
        private Panel panel2;
        private Button btnAnnulla;
        private Button btnConferma;
        private ComboBox cboTipoCartella;
        private Label lblTipoCartella;
        private TextBox txtProgressivo;
        private Label lblProgressivo;
    }
}