namespace WorkManager_A
{
    partial class GestioneLinkage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestioneLinkage));
            pnlLinkage = new Panel();
            pnlButton = new Panel();
            btnConferma = new Button();
            btnAnnulla = new Button();
            pnlButton.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLinkage
            // 
            pnlLinkage.Dock = DockStyle.Fill;
            pnlLinkage.Location = new Point(0, 0);
            pnlLinkage.Name = "pnlLinkage";
            pnlLinkage.Size = new Size(1250, 640);
            pnlLinkage.TabIndex = 0;
            // 
            // pnlButton
            // 
            pnlButton.BorderStyle = BorderStyle.FixedSingle;
            pnlButton.Controls.Add(btnConferma);
            pnlButton.Controls.Add(btnAnnulla);
            pnlButton.Dock = DockStyle.Bottom;
            pnlButton.Location = new Point(0, 640);
            pnlButton.Name = "pnlButton";
            pnlButton.Size = new Size(1250, 60);
            pnlButton.TabIndex = 1;
            // 
            // btnConferma
            // 
            btnConferma.Dock = DockStyle.Right;
            btnConferma.FlatAppearance.BorderSize = 0;
            btnConferma.FlatStyle = FlatStyle.Flat;
            btnConferma.Location = new Point(1076, 0);
            btnConferma.Name = "btnConferma";
            btnConferma.Size = new Size(86, 58);
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
            btnAnnulla.Location = new Point(1162, 0);
            btnAnnulla.Name = "btnAnnulla";
            btnAnnulla.Size = new Size(86, 58);
            btnAnnulla.TabIndex = 1;
            btnAnnulla.Text = "Annulla";
            btnAnnulla.UseVisualStyleBackColor = true;
            btnAnnulla.Click += btnAnnulla_Click;
            // 
            // GestioneLinkage
            // 
            AcceptButton = btnConferma;
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnAnnulla;
            ClientSize = new Size(1250, 700);
            Controls.Add(pnlLinkage);
            Controls.Add(pnlButton);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "GestioneLinkage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GestioneLinkage";
            pnlButton.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLinkage;
        private Panel pnlButton;
        private Button btnConferma;
        private Button btnAnnulla;
    }
}