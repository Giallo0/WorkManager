namespace WorkManager_A.Funzioni
{
    partial class GestioneCartella
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
            lblPercorso = new Label();
            txtPercorso = new TextBox();
            txtNome = new TextBox();
            lblNome = new Label();
            panel1 = new Panel();
            txtData = new TextBox();
            lblData = new Label();
            btnCerca = new Button();
            panel2 = new Panel();
            btnHome = new Button();
            btnConferma = new Button();
            btnAnnulla = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
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
            // txtPercorso
            // 
            txtPercorso.Enabled = false;
            txtPercorso.Location = new Point(158, 39);
            txtPercorso.Name = "txtPercorso";
            txtPercorso.Size = new Size(587, 23);
            txtPercorso.TabIndex = 1;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(158, 76);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(587, 23);
            txtNome.TabIndex = 2;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(102, 79);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(52, 17);
            lblNome.TabIndex = 3;
            lblNome.Text = "Nome:";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtData);
            panel1.Controls.Add(lblData);
            panel1.Controls.Add(btnCerca);
            panel1.Controls.Add(txtNome);
            panel1.Controls.Add(lblPercorso);
            panel1.Controls.Add(lblNome);
            panel1.Controls.Add(txtPercorso);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(914, 435);
            panel1.TabIndex = 4;
            // 
            // txtData
            // 
            txtData.Enabled = false;
            txtData.Location = new Point(160, 114);
            txtData.Name = "txtData";
            txtData.Size = new Size(100, 23);
            txtData.TabIndex = 7;
            // 
            // lblData
            // 
            lblData.AutoSize = true;
            lblData.Location = new Point(109, 117);
            lblData.Name = "lblData";
            lblData.Size = new Size(45, 17);
            lblData.TabIndex = 5;
            lblData.Text = "Data:";
            // 
            // btnCerca
            // 
            btnCerca.Image = Properties.Resources.cerca_24x24;
            btnCerca.Location = new Point(751, 30);
            btnCerca.Name = "btnCerca";
            btnCerca.Size = new Size(40, 40);
            btnCerca.TabIndex = 4;
            btnCerca.UseVisualStyleBackColor = true;
            btnCerca.Click += btnCerca_Click;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(btnHome);
            panel2.Controls.Add(btnConferma);
            panel2.Controls.Add(btnAnnulla);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 435);
            panel2.Name = "panel2";
            panel2.Size = new Size(914, 75);
            panel2.TabIndex = 5;
            // 
            // btnHome
            // 
            btnHome.Dock = DockStyle.Left;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Image = Properties.Resources.home_24x24;
            btnHome.Location = new Point(0, 0);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(100, 73);
            btnHome.TabIndex = 2;
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // btnConferma
            // 
            btnConferma.Dock = DockStyle.Right;
            btnConferma.FlatAppearance.BorderSize = 0;
            btnConferma.FlatStyle = FlatStyle.Flat;
            btnConferma.Location = new Point(712, 0);
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
            btnAnnulla.Location = new Point(812, 0);
            btnAnnulla.Name = "btnAnnulla";
            btnAnnulla.Size = new Size(100, 73);
            btnAnnulla.TabIndex = 1;
            btnAnnulla.Text = "Annulla";
            btnAnnulla.UseVisualStyleBackColor = true;
            btnAnnulla.Click += btnAnnulla_Click;
            // 
            // GestioneCartella
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 510);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "GestioneCartella";
            Text = "Gestione Cartella";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblPercorso;
        private TextBox txtPercorso;
        private TextBox txtNome;
        private Label lblNome;
        private Panel panel1;
        private Button btnCerca;
        private Panel panel2;
        private Button btnAnnulla;
        private Button btnConferma;
        private Button btnHome;
        private Label lblData;
        private TextBox txtData;
    }
}