namespace WorkManager_A
{
    partial class GestioneMenu
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
            components = new System.ComponentModel.Container();
            pnlFunzioni = new Panel();
            pnlList = new Panel();
            treeList = new TreeView();
            pnlPuls = new Panel();
            btnNuovaFunzione = new Button();
            btnEsci = new Button();
            treeListMenu = new ContextMenuStrip(components);
            modificaToolStripMenuItem = new ToolStripMenuItem();
            eliminaToolStripMenuItem = new ToolStripMenuItem();
            pnlEdit = new Panel();
            pnlItemEdit = new Panel();
            lblID = new Label();
            lblIDValue = new Label();
            lblTitolo = new Label();
            lblProgramma = new Label();
            picBitmap = new PictureBox();
            lblBitmap = new Label();
            cboBitmap = new ComboBox();
            txtTitolo = new TextBox();
            txtProgramma = new TextBox();
            pnlPulsEdit = new Panel();
            btnConferma = new Button();
            btnAnnulla = new Button();
            pnlFunzioni.SuspendLayout();
            pnlList.SuspendLayout();
            pnlPuls.SuspendLayout();
            treeListMenu.SuspendLayout();
            pnlEdit.SuspendLayout();
            pnlItemEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBitmap).BeginInit();
            pnlPulsEdit.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFunzioni
            // 
            pnlFunzioni.Controls.Add(pnlList);
            pnlFunzioni.Controls.Add(pnlPuls);
            pnlFunzioni.Dock = DockStyle.Left;
            pnlFunzioni.Location = new Point(0, 0);
            pnlFunzioni.Name = "pnlFunzioni";
            pnlFunzioni.Size = new Size(229, 510);
            pnlFunzioni.TabIndex = 0;
            // 
            // pnlList
            // 
            pnlList.Controls.Add(treeList);
            pnlList.Dock = DockStyle.Fill;
            pnlList.Location = new Point(0, 0);
            pnlList.Name = "pnlList";
            pnlList.Padding = new Padding(6);
            pnlList.Size = new Size(229, 441);
            pnlList.TabIndex = 1;
            // 
            // treeList
            // 
            treeList.Dock = DockStyle.Fill;
            treeList.Location = new Point(6, 6);
            treeList.Name = "treeList";
            treeList.Size = new Size(217, 429);
            treeList.TabIndex = 0;
            treeList.NodeMouseClick += treeList_NodeMouseClick;
            treeList.NodeMouseDoubleClick += treeList_NodeMouseDoubleClick;
            // 
            // pnlPuls
            // 
            pnlPuls.BorderStyle = BorderStyle.FixedSingle;
            pnlPuls.Controls.Add(btnNuovaFunzione);
            pnlPuls.Controls.Add(btnEsci);
            pnlPuls.Dock = DockStyle.Bottom;
            pnlPuls.Location = new Point(0, 441);
            pnlPuls.Name = "pnlPuls";
            pnlPuls.Padding = new Padding(2);
            pnlPuls.Size = new Size(229, 69);
            pnlPuls.TabIndex = 0;
            // 
            // btnNuovaFunzione
            // 
            btnNuovaFunzione.Dock = DockStyle.Top;
            btnNuovaFunzione.FlatStyle = FlatStyle.Flat;
            btnNuovaFunzione.Location = new Point(2, 2);
            btnNuovaFunzione.Name = "btnNuovaFunzione";
            btnNuovaFunzione.Size = new Size(223, 30);
            btnNuovaFunzione.TabIndex = 3;
            btnNuovaFunzione.Text = "Nuova Funzione";
            btnNuovaFunzione.UseVisualStyleBackColor = true;
            btnNuovaFunzione.Click += btnNuovaFunzione_Click;
            // 
            // btnEsci
            // 
            btnEsci.Dock = DockStyle.Bottom;
            btnEsci.FlatStyle = FlatStyle.Flat;
            btnEsci.Location = new Point(2, 35);
            btnEsci.Name = "btnEsci";
            btnEsci.Size = new Size(223, 30);
            btnEsci.TabIndex = 2;
            btnEsci.Text = "Esci";
            btnEsci.UseVisualStyleBackColor = true;
            btnEsci.Click += btnEsci_Click;
            // 
            // treeListMenu
            // 
            treeListMenu.Items.AddRange(new ToolStripItem[] { modificaToolStripMenuItem, eliminaToolStripMenuItem });
            treeListMenu.Name = "treeListMenu";
            treeListMenu.Size = new Size(122, 48);
            // 
            // modificaToolStripMenuItem
            // 
            modificaToolStripMenuItem.Name = "modificaToolStripMenuItem";
            modificaToolStripMenuItem.Size = new Size(121, 22);
            modificaToolStripMenuItem.Text = "Modifica";
            modificaToolStripMenuItem.Click += modificaToolStripMenuItem_Click;
            // 
            // eliminaToolStripMenuItem
            // 
            eliminaToolStripMenuItem.Name = "eliminaToolStripMenuItem";
            eliminaToolStripMenuItem.Size = new Size(121, 22);
            eliminaToolStripMenuItem.Text = "Elimina";
            eliminaToolStripMenuItem.Click += eliminaToolStripMenuItem_Click;
            // 
            // pnlEdit
            // 
            pnlEdit.Controls.Add(pnlItemEdit);
            pnlEdit.Controls.Add(pnlPulsEdit);
            pnlEdit.Dock = DockStyle.Fill;
            pnlEdit.Location = new Point(229, 0);
            pnlEdit.Name = "pnlEdit";
            pnlEdit.Size = new Size(685, 510);
            pnlEdit.TabIndex = 1;
            // 
            // pnlItemEdit
            // 
            pnlItemEdit.Controls.Add(lblID);
            pnlItemEdit.Controls.Add(lblIDValue);
            pnlItemEdit.Controls.Add(lblTitolo);
            pnlItemEdit.Controls.Add(lblProgramma);
            pnlItemEdit.Controls.Add(picBitmap);
            pnlItemEdit.Controls.Add(lblBitmap);
            pnlItemEdit.Controls.Add(cboBitmap);
            pnlItemEdit.Controls.Add(txtTitolo);
            pnlItemEdit.Controls.Add(txtProgramma);
            pnlItemEdit.Dock = DockStyle.Fill;
            pnlItemEdit.Location = new Point(0, 0);
            pnlItemEdit.Name = "pnlItemEdit";
            pnlItemEdit.Size = new Size(685, 435);
            pnlItemEdit.TabIndex = 11;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(93, 27);
            lblID.Name = "lblID";
            lblID.Size = new Size(25, 17);
            lblID.TabIndex = 9;
            lblID.Text = "ID:";
            // 
            // lblIDValue
            // 
            lblIDValue.AutoSize = true;
            lblIDValue.Location = new Point(124, 27);
            lblIDValue.Name = "lblIDValue";
            lblIDValue.Size = new Size(0, 17);
            lblIDValue.TabIndex = 10;
            // 
            // lblTitolo
            // 
            lblTitolo.AutoSize = true;
            lblTitolo.Location = new Point(72, 68);
            lblTitolo.Name = "lblTitolo";
            lblTitolo.Size = new Size(46, 17);
            lblTitolo.TabIndex = 2;
            lblTitolo.Text = "Titolo:";
            // 
            // lblProgramma
            // 
            lblProgramma.AutoSize = true;
            lblProgramma.Location = new Point(34, 114);
            lblProgramma.Name = "lblProgramma";
            lblProgramma.Size = new Size(90, 17);
            lblProgramma.TabIndex = 3;
            lblProgramma.Text = "Programma:";
            // 
            // picBitmap
            // 
            picBitmap.Location = new Point(399, 152);
            picBitmap.Name = "picBitmap";
            picBitmap.Size = new Size(24, 24);
            picBitmap.SizeMode = PictureBoxSizeMode.AutoSize;
            picBitmap.TabIndex = 8;
            picBitmap.TabStop = false;
            // 
            // lblBitmap
            // 
            lblBitmap.AutoSize = true;
            lblBitmap.Location = new Point(63, 156);
            lblBitmap.Name = "lblBitmap";
            lblBitmap.Size = new Size(58, 17);
            lblBitmap.TabIndex = 4;
            lblBitmap.Text = "Bitmap:";
            // 
            // cboBitmap
            // 
            cboBitmap.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBitmap.FormattingEnabled = true;
            cboBitmap.Location = new Point(124, 152);
            cboBitmap.Name = "cboBitmap";
            cboBitmap.Size = new Size(269, 25);
            cboBitmap.TabIndex = 7;
            cboBitmap.TextChanged += cboBitmap_TextChanged;
            // 
            // txtTitolo
            // 
            txtTitolo.Location = new Point(124, 65);
            txtTitolo.Name = "txtTitolo";
            txtTitolo.Size = new Size(269, 23);
            txtTitolo.TabIndex = 5;
            // 
            // txtProgramma
            // 
            txtProgramma.Location = new Point(124, 110);
            txtProgramma.Name = "txtProgramma";
            txtProgramma.Size = new Size(269, 23);
            txtProgramma.TabIndex = 6;
            // 
            // pnlPulsEdit
            // 
            pnlPulsEdit.BorderStyle = BorderStyle.FixedSingle;
            pnlPulsEdit.Controls.Add(btnConferma);
            pnlPulsEdit.Controls.Add(btnAnnulla);
            pnlPulsEdit.Dock = DockStyle.Bottom;
            pnlPulsEdit.Location = new Point(0, 435);
            pnlPulsEdit.Name = "pnlPulsEdit";
            pnlPulsEdit.Size = new Size(685, 75);
            pnlPulsEdit.TabIndex = 2;
            // 
            // btnConferma
            // 
            btnConferma.Dock = DockStyle.Right;
            btnConferma.FlatAppearance.BorderSize = 0;
            btnConferma.FlatStyle = FlatStyle.Flat;
            btnConferma.Location = new Point(483, 0);
            btnConferma.Name = "btnConferma";
            btnConferma.Size = new Size(100, 73);
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
            btnAnnulla.Location = new Point(583, 0);
            btnAnnulla.Name = "btnAnnulla";
            btnAnnulla.Size = new Size(100, 73);
            btnAnnulla.TabIndex = 1;
            btnAnnulla.Text = "Annulla";
            btnAnnulla.UseVisualStyleBackColor = true;
            btnAnnulla.Click += btnAnnulla_Click;
            // 
            // GestioneMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 510);
            Controls.Add(pnlEdit);
            Controls.Add(pnlFunzioni);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "GestioneMenu";
            Text = "GestioneMenu";
            pnlFunzioni.ResumeLayout(false);
            pnlList.ResumeLayout(false);
            pnlPuls.ResumeLayout(false);
            treeListMenu.ResumeLayout(false);
            pnlEdit.ResumeLayout(false);
            pnlItemEdit.ResumeLayout(false);
            pnlItemEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBitmap).EndInit();
            pnlPulsEdit.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFunzioni;
        private Panel pnlEdit;
        private PictureBox picBitmap;
        private ComboBox cboBitmap;
        private TextBox txtProgramma;
        private TextBox txtTitolo;
        private Label lblBitmap;
        private Label lblProgramma;
        private Label lblTitolo;
        private Button btnAnnulla;
        private Button btnConferma;
        private Label lblIDValue;
        private Label lblID;
        private Panel pnlPuls;
        private Button btnEsci;
        private Panel pnlPulsEdit;
        private Panel pnlList;
        private Panel pnlItemEdit;
        private Button btnNuovaFunzione;
        private TreeView treeList;
        private ContextMenuStrip treeListMenu;
        private ToolStripMenuItem modificaToolStripMenuItem;
        private ToolStripMenuItem eliminaToolStripMenuItem;
    }
}