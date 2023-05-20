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
            lblCartella = new Label();
            pnlPulsanti = new Panel();
            txtCartella = new TextBox();
            splitContainer1 = new SplitContainer();
            treeFullPath = new TreeView();
            lstContenuto = new ListView();
            pnlPulsanti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // btnConferma
            // 
            btnConferma.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConferma.Location = new Point(587, 42);
            btnConferma.Name = "btnConferma";
            btnConferma.Size = new Size(120, 23);
            btnConferma.TabIndex = 0;
            btnConferma.Text = "Seleziona cartella";
            btnConferma.UseVisualStyleBackColor = true;
            btnConferma.Click += btnConferma_Click;
            // 
            // btnAnnulla
            // 
            btnAnnulla.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAnnulla.Location = new Point(713, 42);
            btnAnnulla.Name = "btnAnnulla";
            btnAnnulla.Size = new Size(75, 23);
            btnAnnulla.TabIndex = 1;
            btnAnnulla.Text = "Annulla";
            btnAnnulla.UseVisualStyleBackColor = true;
            btnAnnulla.Click += btnAnnulla_Click;
            // 
            // lblCartella
            // 
            lblCartella.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCartella.AutoSize = true;
            lblCartella.Location = new Point(163, 16);
            lblCartella.Name = "lblCartella";
            lblCartella.Size = new Size(50, 15);
            lblCartella.TabIndex = 2;
            lblCartella.Text = "Cartella:";
            // 
            // pnlPulsanti
            // 
            pnlPulsanti.BorderStyle = BorderStyle.FixedSingle;
            pnlPulsanti.Controls.Add(txtCartella);
            pnlPulsanti.Controls.Add(lblCartella);
            pnlPulsanti.Controls.Add(btnConferma);
            pnlPulsanti.Controls.Add(btnAnnulla);
            pnlPulsanti.Dock = DockStyle.Bottom;
            pnlPulsanti.Location = new Point(0, 372);
            pnlPulsanti.Name = "pnlPulsanti";
            pnlPulsanti.Size = new Size(800, 78);
            pnlPulsanti.TabIndex = 0;
            // 
            // txtCartella
            // 
            txtCartella.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCartella.Enabled = false;
            txtCartella.Location = new Point(219, 13);
            txtCartella.Name = "txtCartella";
            txtCartella.Size = new Size(569, 23);
            txtCartella.TabIndex = 3;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeFullPath);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lstContenuto);
            splitContainer1.Size = new Size(800, 372);
            splitContainer1.SplitterDistance = 177;
            splitContainer1.TabIndex = 1;
            // 
            // treeFullPath
            // 
            treeFullPath.Dock = DockStyle.Fill;
            treeFullPath.Location = new Point(0, 0);
            treeFullPath.Name = "treeFullPath";
            treeFullPath.Size = new Size(177, 372);
            treeFullPath.TabIndex = 0;
            treeFullPath.NodeMouseClick += treeFullPath_NodeMouseClick;
            treeFullPath.NodeMouseDoubleClick += treeFullPath_NodeMouseDoubleClick;
            // 
            // lstContenuto
            // 
            lstContenuto.Dock = DockStyle.Fill;
            lstContenuto.Location = new Point(0, 0);
            lstContenuto.Name = "lstContenuto";
            lstContenuto.Size = new Size(619, 372);
            lstContenuto.TabIndex = 0;
            lstContenuto.UseCompatibleStateImageBehavior = false;
            lstContenuto.MouseClick += lstContenuto_MouseClick;
            lstContenuto.MouseDoubleClick += lstContenuto_MouseDoubleClick;
            // 
            // FinPath
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(pnlPulsanti);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FinPath";
            Text = "Cerca Percorso";
            pnlPulsanti.ResumeLayout(false);
            pnlPulsanti.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnConferma;
        private Button btnAnnulla;
        private Label lblCartella;
        private Panel pnlPulsanti;
        private TextBox txtCartella;
        private SplitContainer splitContainer1;
        private TreeView treeFullPath;
        private ListView lstContenuto;
    }
}