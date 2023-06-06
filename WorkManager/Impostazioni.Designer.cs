namespace WorkManager
{
    partial class Impostazioni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Impostazioni));
            pnlMain = new Panel();
            pnlMenu = new Panel();
            treeMenu = new TreeView();
            pnlButton = new Panel();
            btnEsci = new Button();
            pnlMenu.SuspendLayout();
            pnlButton.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(200, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1050, 700);
            pnlMain.TabIndex = 1;
            // 
            // pnlMenu
            // 
            pnlMenu.Controls.Add(treeMenu);
            pnlMenu.Controls.Add(pnlButton);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(200, 700);
            pnlMenu.TabIndex = 0;
            // 
            // treeMenu
            // 
            treeMenu.Dock = DockStyle.Fill;
            treeMenu.Location = new Point(0, 0);
            treeMenu.Name = "treeMenu";
            treeMenu.Size = new Size(200, 650);
            treeMenu.TabIndex = 0;
            treeMenu.AfterSelect += treeMenu_AfterSelect;
            // 
            // pnlButton
            // 
            pnlButton.BorderStyle = BorderStyle.FixedSingle;
            pnlButton.Controls.Add(btnEsci);
            pnlButton.Dock = DockStyle.Bottom;
            pnlButton.Location = new Point(0, 650);
            pnlButton.Name = "pnlButton";
            pnlButton.Size = new Size(200, 50);
            pnlButton.TabIndex = 0;
            // 
            // btnEsci
            // 
            btnEsci.Dock = DockStyle.Fill;
            btnEsci.FlatAppearance.BorderSize = 0;
            btnEsci.FlatStyle = FlatStyle.Flat;
            btnEsci.Location = new Point(0, 0);
            btnEsci.Name = "btnEsci";
            btnEsci.Size = new Size(198, 48);
            btnEsci.TabIndex = 0;
            btnEsci.Text = "Esci";
            btnEsci.UseVisualStyleBackColor = true;
            btnEsci.Click += btnEsci_Click;
            // 
            // Impostazioni
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 700);
            Controls.Add(pnlMain);
            Controls.Add(pnlMenu);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Impostazioni";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Impostazioni";
            pnlMenu.ResumeLayout(false);
            pnlButton.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private Panel pnlMenu;
        private TreeView treeMenu;
        private Panel pnlButton;
        private Button btnEsci;
    }
}