namespace WorkManager.CustomDialogBox
{
    partial class GestioneFileAttivita
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
            pnlPulsanti = new Panel();
            btnAnnulla = new Button();
            btnConferma = new Button();
            pnlMain = new Panel();
            cboEstensione = new ComboBox();
            lblEstensione = new Label();
            txtNomeFile = new TextBox();
            lblNomeFile = new Label();
            pnlPulsanti.SuspendLayout();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPulsanti
            // 
            pnlPulsanti.Controls.Add(btnAnnulla);
            pnlPulsanti.Controls.Add(btnConferma);
            pnlPulsanti.Dock = DockStyle.Bottom;
            pnlPulsanti.Location = new Point(0, 181);
            pnlPulsanti.Name = "pnlPulsanti";
            pnlPulsanti.Size = new Size(325, 58);
            pnlPulsanti.TabIndex = 4;
            // 
            // btnAnnulla
            // 
            btnAnnulla.Location = new Point(178, 18);
            btnAnnulla.Name = "btnAnnulla";
            btnAnnulla.Size = new Size(114, 26);
            btnAnnulla.TabIndex = 1;
            btnAnnulla.Text = "Annulla";
            btnAnnulla.UseVisualStyleBackColor = true;
            btnAnnulla.Click += btnAnnulla_Click;
            // 
            // btnConferma
            // 
            btnConferma.Location = new Point(32, 18);
            btnConferma.Name = "btnConferma";
            btnConferma.Size = new Size(114, 26);
            btnConferma.TabIndex = 0;
            btnConferma.Text = "Conferma";
            btnConferma.UseVisualStyleBackColor = true;
            btnConferma.Click += btnConferma_Click;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(cboEstensione);
            pnlMain.Controls.Add(lblEstensione);
            pnlMain.Controls.Add(txtNomeFile);
            pnlMain.Controls.Add(lblNomeFile);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(325, 181);
            pnlMain.TabIndex = 5;
            // 
            // cboEstensione
            // 
            cboEstensione.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstensione.FormattingEnabled = true;
            cboEstensione.Location = new Point(14, 109);
            cboEstensione.Name = "cboEstensione";
            cboEstensione.Size = new Size(78, 25);
            cboEstensione.TabIndex = 3;
            // 
            // lblEstensione
            // 
            lblEstensione.AutoSize = true;
            lblEstensione.Location = new Point(14, 89);
            lblEstensione.Name = "lblEstensione";
            lblEstensione.Size = new Size(78, 17);
            lblEstensione.TabIndex = 2;
            lblEstensione.Text = "Estensione:";
            // 
            // txtNomeFile
            // 
            txtNomeFile.Location = new Point(14, 53);
            txtNomeFile.Name = "txtNomeFile";
            txtNomeFile.Size = new Size(297, 23);
            txtNomeFile.TabIndex = 1;
            // 
            // lblNomeFile
            // 
            lblNomeFile.AutoSize = true;
            lblNomeFile.Location = new Point(14, 33);
            lblNomeFile.Name = "lblNomeFile";
            lblNomeFile.Size = new Size(74, 17);
            lblNomeFile.TabIndex = 0;
            lblNomeFile.Text = "Nome file:";
            // 
            // GestioneFileAttivita
            // 
            AcceptButton = btnConferma;
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnAnnulla;
            ClientSize = new Size(325, 239);
            Controls.Add(pnlMain);
            Controls.Add(pnlPulsanti);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "GestioneFileAttivita";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestione File Attivita";
            pnlPulsanti.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlPulsanti;
        private Button btnAnnulla;
        private Button btnConferma;
        private Panel pnlMain;
        private TextBox txtNomeFile;
        private Label lblNomeFile;
        private ComboBox cboEstensione;
        private Label lblEstensione;
    }
}