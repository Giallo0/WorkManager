namespace WorkManager_A
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            btnConferma = new Button();
            btnAnnulla = new Button();
            txtPath = new TextBox();
            lblPath = new Label();
            btnCercaPath = new Button();
            SuspendLayout();
            // 
            // btnConferma
            // 
            btnConferma.Location = new Point(147, 76);
            btnConferma.Name = "btnConferma";
            btnConferma.Size = new Size(75, 23);
            btnConferma.TabIndex = 0;
            btnConferma.Text = "Conferma";
            btnConferma.UseVisualStyleBackColor = true;
            btnConferma.Click += btnConferma_Click;
            // 
            // btnAnnulla
            // 
            btnAnnulla.Location = new Point(264, 76);
            btnAnnulla.Name = "btnAnnulla";
            btnAnnulla.Size = new Size(75, 23);
            btnAnnulla.TabIndex = 1;
            btnAnnulla.Text = "Annulla";
            btnAnnulla.UseVisualStyleBackColor = true;
            btnAnnulla.Click += btnAnnulla_Click;
            // 
            // txtPath
            // 
            txtPath.Location = new Point(12, 27);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(426, 23);
            txtPath.TabIndex = 2;
            // 
            // lblPath
            // 
            lblPath.AutoSize = true;
            lblPath.Location = new Point(12, 9);
            lblPath.Name = "lblPath";
            lblPath.Size = new Size(115, 15);
            lblPath.TabIndex = 3;
            lblPath.Text = "Percorso workspace:";
            // 
            // btnCercaPath
            // 
            btnCercaPath.Image = Properties.Resources.cartella;
            btnCercaPath.Location = new Point(444, 27);
            btnCercaPath.Name = "btnCercaPath";
            btnCercaPath.Size = new Size(28, 23);
            btnCercaPath.TabIndex = 4;
            btnCercaPath.UseVisualStyleBackColor = true;
            btnCercaPath.Click += btnCercaPath_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 111);
            Controls.Add(btnCercaPath);
            Controls.Add(lblPath);
            Controls.Add(txtPath);
            Controls.Add(btnAnnulla);
            Controls.Add(btnConferma);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            Text = "WorkManager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConferma;
        private Button btnAnnulla;
        private TextBox txtPath;
        private Label lblPath;
        private Button btnCercaPath;
    }
}