namespace WorkManager.Funzioni
{
    partial class GestioneAttivita
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestioneAttivita));
            panel2 = new Panel();
            btnConferma = new Button();
            btnAnnulla = new Button();
            panel1 = new Panel();
            cboPriorita = new ComboBox();
            lblPriorita = new Label();
            cboStato = new ComboBox();
            lblStato = new Label();
            txtProgressivo = new TextBox();
            lblProgressivo = new Label();
            btnCerca = new Button();
            txtNome = new TextBox();
            lblPercorso = new Label();
            lblNome = new Label();
            txtPercorso = new TextBox();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
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
            panel2.TabIndex = 6;
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
            // panel1
            // 
            panel1.Controls.Add(cboPriorita);
            panel1.Controls.Add(lblPriorita);
            panel1.Controls.Add(cboStato);
            panel1.Controls.Add(lblStato);
            panel1.Controls.Add(txtProgressivo);
            panel1.Controls.Add(lblProgressivo);
            panel1.Controls.Add(btnCerca);
            panel1.Controls.Add(txtNome);
            panel1.Controls.Add(lblPercorso);
            panel1.Controls.Add(lblNome);
            panel1.Controls.Add(txtPercorso);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1250, 640);
            panel1.TabIndex = 7;
            // 
            // cboPriorita
            // 
            cboPriorita.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPriorita.FormattingEnabled = true;
            cboPriorita.Location = new Point(575, 120);
            cboPriorita.Name = "cboPriorita";
            cboPriorita.Size = new Size(170, 25);
            cboPriorita.TabIndex = 15;
            // 
            // lblPriorita
            // 
            lblPriorita.AutoSize = true;
            lblPriorita.Location = new Point(512, 123);
            lblPriorita.Name = "lblPriorita";
            lblPriorita.Size = new Size(57, 17);
            lblPriorita.TabIndex = 14;
            lblPriorita.Text = "Priorità:";
            // 
            // cboStato
            // 
            cboStato.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStato.Enabled = false;
            cboStato.FormattingEnabled = true;
            cboStato.Location = new Point(320, 117);
            cboStato.Name = "cboStato";
            cboStato.Size = new Size(170, 25);
            cboStato.TabIndex = 13;
            // 
            // lblStato
            // 
            lblStato.AutoSize = true;
            lblStato.Location = new Point(268, 120);
            lblStato.Name = "lblStato";
            lblStato.Size = new Size(46, 17);
            lblStato.TabIndex = 12;
            lblStato.Text = "Stato:";
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
            // btnCerca
            // 
            btnCerca.Image = Properties.Resources.cerca_24x24;
            btnCerca.Location = new Point(751, 34);
            btnCerca.Name = "btnCerca";
            btnCerca.Size = new Size(32, 32);
            btnCerca.TabIndex = 4;
            btnCerca.UseVisualStyleBackColor = true;
            btnCerca.Click += btnCerca_Click;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(320, 76);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(425, 23);
            txtNome.TabIndex = 2;
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
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(262, 79);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(52, 17);
            lblNome.TabIndex = 3;
            lblNome.Text = "Nome:";
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
            // GestioneAttivita
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
            Name = "GestioneAttivita";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestione Attivita";
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Button btnConferma;
        private Button btnAnnulla;
        private Panel panel1;
        private ComboBox cboStato;
        private Label lblStato;
        private TextBox txtProgressivo;
        private Label lblProgressivo;
        private Button btnCerca;
        private TextBox txtNome;
        private Label lblPercorso;
        private Label lblNome;
        private TextBox txtPercorso;
        private ComboBox cboPriorita;
        private Label lblPriorita;
    }
}