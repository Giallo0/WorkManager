namespace WorkManager_A
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
            pnlMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(196, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(604, 450);
            pnlMain.TabIndex = 1;
            // 
            // pnlMenu
            // 
            pnlMenu.Controls.Add(treeMenu);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(196, 450);
            pnlMenu.TabIndex = 0;
            // 
            // treeMenu
            // 
            treeMenu.Dock = DockStyle.Fill;
            treeMenu.Location = new Point(0, 0);
            treeMenu.Name = "treeMenu";
            treeMenu.Size = new Size(196, 450);
            treeMenu.TabIndex = 0;
            treeMenu.AfterSelect += treeMenu_AfterSelect;
            // 
            // Impostazioni
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlMain);
            Controls.Add(pnlMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Impostazioni";
            Text = "Impostazioni";
            pnlMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private Panel pnlMenu;
        private TreeView treeMenu;
    }
}