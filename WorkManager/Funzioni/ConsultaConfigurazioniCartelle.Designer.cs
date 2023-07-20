namespace WorkManager.Funzioni
{
    partial class ConsultaConfigurazioniCartelle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaConfigurazioniCartelle));
            pnlPrimaParte = new Panel();
            txtCliente = new TextBox();
            btnCercaCliente = new Button();
            lblCliente = new Label();
            pnlPulsanti = new Panel();
            btnConferma = new Button();
            btnAnnulla = new Button();
            pnlSecondaParte = new Panel();
            gridConfig = new DataGridView();
            pnlPrimaParte.SuspendLayout();
            pnlPulsanti.SuspendLayout();
            pnlSecondaParte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridConfig).BeginInit();
            SuspendLayout();
            // 
            // pnlPrimaParte
            // 
            pnlPrimaParte.Controls.Add(txtCliente);
            pnlPrimaParte.Controls.Add(btnCercaCliente);
            pnlPrimaParte.Controls.Add(lblCliente);
            pnlPrimaParte.Dock = DockStyle.Top;
            pnlPrimaParte.Location = new Point(0, 0);
            pnlPrimaParte.Name = "pnlPrimaParte";
            pnlPrimaParte.Size = new Size(1250, 50);
            pnlPrimaParte.TabIndex = 7;
            // 
            // txtCliente
            // 
            txtCliente.Enabled = false;
            txtCliente.Location = new Point(76, 12);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(125, 23);
            txtCliente.TabIndex = 4;
            // 
            // btnCercaCliente
            // 
            btnCercaCliente.Image = Properties.Resources.cerca_24x24;
            btnCercaCliente.Location = new Point(207, 7);
            btnCercaCliente.Name = "btnCercaCliente";
            btnCercaCliente.Size = new Size(32, 32);
            btnCercaCliente.TabIndex = 3;
            btnCercaCliente.UseVisualStyleBackColor = true;
            btnCercaCliente.Click += btnCercaCliente_Click;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(12, 15);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(58, 17);
            lblCliente.TabIndex = 2;
            lblCliente.Text = "Cliente:";
            // 
            // pnlPulsanti
            // 
            pnlPulsanti.BorderStyle = BorderStyle.FixedSingle;
            pnlPulsanti.Controls.Add(btnConferma);
            pnlPulsanti.Controls.Add(btnAnnulla);
            pnlPulsanti.Dock = DockStyle.Bottom;
            pnlPulsanti.Location = new Point(0, 650);
            pnlPulsanti.Name = "pnlPulsanti";
            pnlPulsanti.Size = new Size(1250, 50);
            pnlPulsanti.TabIndex = 8;
            // 
            // btnConferma
            // 
            btnConferma.Dock = DockStyle.Right;
            btnConferma.FlatAppearance.BorderSize = 0;
            btnConferma.FlatStyle = FlatStyle.Flat;
            btnConferma.Location = new Point(1068, 0);
            btnConferma.Name = "btnConferma";
            btnConferma.Size = new Size(90, 48);
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
            btnAnnulla.Location = new Point(1158, 0);
            btnAnnulla.Name = "btnAnnulla";
            btnAnnulla.Size = new Size(90, 48);
            btnAnnulla.TabIndex = 1;
            btnAnnulla.Text = "Annulla";
            btnAnnulla.UseVisualStyleBackColor = true;
            btnAnnulla.Click += btnAnnulla_Click;
            // 
            // pnlSecondaParte
            // 
            pnlSecondaParte.Controls.Add(gridConfig);
            pnlSecondaParte.Dock = DockStyle.Fill;
            pnlSecondaParte.Location = new Point(0, 50);
            pnlSecondaParte.Name = "pnlSecondaParte";
            pnlSecondaParte.Size = new Size(1250, 600);
            pnlSecondaParte.TabIndex = 9;
            // 
            // gridConfig
            // 
            gridConfig.AllowUserToAddRows = false;
            gridConfig.AllowUserToDeleteRows = false;
            gridConfig.AllowUserToResizeRows = false;
            gridConfig.BackgroundColor = SystemColors.ButtonFace;
            gridConfig.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridConfig.Dock = DockStyle.Fill;
            gridConfig.Location = new Point(0, 0);
            gridConfig.MultiSelect = false;
            gridConfig.Name = "gridConfig";
            gridConfig.ReadOnly = true;
            gridConfig.RowTemplate.Height = 25;
            gridConfig.Size = new Size(1250, 600);
            gridConfig.TabIndex = 0;
            // 
            // ConsultaConfigurazioniCartelle
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 700);
            Controls.Add(pnlSecondaParte);
            Controls.Add(pnlPulsanti);
            Controls.Add(pnlPrimaParte);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ConsultaConfigurazioniCartelle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ConsultaConfigurazioniCartelle";
            pnlPrimaParte.ResumeLayout(false);
            pnlPrimaParte.PerformLayout();
            pnlPulsanti.ResumeLayout(false);
            pnlSecondaParte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridConfig).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlPrimaParte;
        private TextBox txtCliente;
        private Button btnCercaCliente;
        private Label lblCliente;
        private Panel pnlPulsanti;
        private Button btnConferma;
        private Button btnAnnulla;
        private Panel pnlSecondaParte;
        private DataGridView gridConfig;
    }
}