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
            btnConferma.Location = new Point(168, 86);
            btnConferma.Name = "btnConferma";
            btnConferma.Size = new Size(86, 26);
            btnConferma.TabIndex = 0;
            btnConferma.Text = "Conferma";
            btnConferma.UseVisualStyleBackColor = true;
            btnConferma.Click += btnConferma_Click;
            // 
            // btnAnnulla
            // 
            btnAnnulla.Location = new Point(302, 86);
            btnAnnulla.Name = "btnAnnulla";
            btnAnnulla.Size = new Size(86, 26);
            btnAnnulla.TabIndex = 1;
            btnAnnulla.Text = "Annulla";
            btnAnnulla.UseVisualStyleBackColor = true;
            btnAnnulla.Click += btnAnnulla_Click;
            // 
            // txtPath
            // 
            txtPath.Location = new Point(14, 31);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(486, 23);
            txtPath.TabIndex = 2;
            // 
            // lblPath
            // 
            lblPath.AutoSize = true;
            lblPath.Location = new Point(14, 10);
            lblPath.Name = "lblPath";
            lblPath.Size = new Size(142, 17);
            lblPath.TabIndex = 3;
            lblPath.Text = "Percorso workspace:";
            // 
            // btnCercaPath
            // 
            btnCercaPath.Image = Properties.Resources.cerca_24x24;
            btnCercaPath.Location = new Point(506, 27);
            btnCercaPath.Name = "btnCercaPath";
            btnCercaPath.Size = new Size(32, 31);
            btnCercaPath.TabIndex = 4;
            btnCercaPath.UseVisualStyleBackColor = true;
            btnCercaPath.Click += btnCercaPath_Click;
            // 
            // Login
            // 
            AcceptButton = btnConferma;
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnAnnulla;
            ClientSize = new Size(553, 126);
            Controls.Add(btnCercaPath);
            Controls.Add(lblPath);
            Controls.Add(txtPath);
            Controls.Add(btnAnnulla);
            Controls.Add(btnConferma);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
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