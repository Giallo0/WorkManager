namespace WorkManager.CustomDialogBox
{
    partial class GestioneCartellaAttivita
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
            pnlMain = new Panel();
            txtNomeCartella = new TextBox();
            lblNomeCartella = new Label();
            pnlPulsanti = new Panel();
            btnAnnulla = new Button();
            btnConferma = new Button();
            pnlMain.SuspendLayout();
            pnlPulsanti.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(txtNomeCartella);
            pnlMain.Controls.Add(lblNomeCartella);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(325, 181);
            pnlMain.TabIndex = 2;
            // 
            // txtNomeCartella
            // 
            txtNomeCartella.Location = new Point(14, 68);
            txtNomeCartella.Name = "txtNomeCartella";
            txtNomeCartella.Size = new Size(297, 23);
            txtNomeCartella.TabIndex = 1;
            // 
            // lblNomeCartella
            // 
            lblNomeCartella.AutoSize = true;
            lblNomeCartella.Location = new Point(14, 45);
            lblNomeCartella.Name = "lblNomeCartella";
            lblNomeCartella.Size = new Size(105, 17);
            lblNomeCartella.TabIndex = 0;
            lblNomeCartella.Text = "Nome cartella:";
            // 
            // pnlPulsanti
            // 
            pnlPulsanti.Controls.Add(btnAnnulla);
            pnlPulsanti.Controls.Add(btnConferma);
            pnlPulsanti.Dock = DockStyle.Bottom;
            pnlPulsanti.Location = new Point(0, 181);
            pnlPulsanti.Name = "pnlPulsanti";
            pnlPulsanti.Size = new Size(325, 58);
            pnlPulsanti.TabIndex = 3;
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
            // AggiungiCartella
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(325, 239);
            Controls.Add(pnlMain);
            Controls.Add(pnlPulsanti);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AggiungiCartella";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Aggiungi_cartella";
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            pnlPulsanti.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private TextBox txtNomeCartella;
        private Label lblNomeCartella;
        private Panel pnlPulsanti;
        private Button btnAnnulla;
        private Button btnConferma;
    }
}