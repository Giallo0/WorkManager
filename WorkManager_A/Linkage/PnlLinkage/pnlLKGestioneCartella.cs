using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManager_A.Linkage.PnlLinkage
{
    public partial class pnlLKGestioneCartella : Panel
    {
        public pnlLKGestioneCartella()
        {
            InitializeComponent();
            InitializeComponentPersonalizzato();
        }

        public pnlLKGestioneCartella(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            InitializeComponentPersonalizzato();
        }

        private Panel pnlLinkage;
        private GroupBox gbFunzione;
        private RadioButton rbInserimento;
        private RadioButton rbEliminazione;
        private RadioButton rbModifica;
        private Button btnConferma;
        private Button btnAnnulla;
        private Panel pnlButton;

        private void InitializeComponentPersonalizzato()
        {
            rbInserimento = new RadioButton();
            rbModifica = new RadioButton();
            rbEliminazione = new RadioButton();
            gbFunzione = new GroupBox();
            gbFunzione.SuspendLayout();
            SuspendLayout();
            //
            // pnlLKGestioneCartella
            //
            Controls.Add(gbFunzione);
            Dock = DockStyle.Fill;
            Location = new Point(0, 0);
            Size = new Size(800, 450);
            // 
            // rbInserimento
            // 
            rbInserimento.AutoSize = true;
            rbInserimento.Location = new Point(6, 22);
            rbInserimento.Name = "rbInserimento";
            rbInserimento.Size = new Size(88, 19);
            rbInserimento.TabIndex = 0;
            rbInserimento.TabStop = true;
            rbInserimento.Text = "Inserimento";
            rbInserimento.UseVisualStyleBackColor = true;
            rbInserimento.CheckedChanged += rbInserimento_CheckedChanged;
            // 
            // rbModifica
            // 
            rbModifica.AutoSize = true;
            rbModifica.Location = new Point(6, 47);
            rbModifica.Name = "rbModifica";
            rbModifica.Size = new Size(72, 19);
            rbModifica.TabIndex = 1;
            rbModifica.TabStop = true;
            rbModifica.Text = "Modifica";
            rbModifica.UseVisualStyleBackColor = true;
            rbModifica.CheckedChanged += rbModifica_CheckedChanged;
            // 
            // rbEliminazione
            // 
            rbEliminazione.AutoSize = true;
            rbEliminazione.Location = new Point(6, 72);
            rbEliminazione.Name = "rbEliminazione";
            rbEliminazione.Size = new Size(92, 19);
            rbEliminazione.TabIndex = 2;
            rbEliminazione.TabStop = true;
            rbEliminazione.Text = "Eliminazione";
            rbEliminazione.UseVisualStyleBackColor = true;
            rbEliminazione.CheckedChanged += rbEliminazione_CheckedChanged;
            // 
            // gbFunzione
            // 
            gbFunzione.Controls.Add(rbInserimento);
            gbFunzione.Controls.Add(rbEliminazione);
            gbFunzione.Controls.Add(rbModifica);
            gbFunzione.Location = new Point(12, 12);
            gbFunzione.Name = "gbFunzione";
            gbFunzione.Size = new Size(200, 100);
            gbFunzione.TabIndex = 3;
            gbFunzione.TabStop = false;
            gbFunzione.Text = "Funzione";

            gbFunzione.ResumeLayout(false);
            gbFunzione.PerformLayout();
            ResumeLayout(false);

            ImpostaLinkage();
        }

        private void ImpostaLinkage()
        {
            LKGestioneCartella.ClearLinkage();
            if (!string.IsNullOrEmpty(LKGestioneLinkage.linkage))
            {
                LKGestioneCartella.DecodificaLinkageString(LKGestioneLinkage.linkage);
            }

            switch (LKGestioneCartella.funzione)
            {
                case 'I':
                    rbInserimento.Checked = true;
                    break;
                case 'G':
                    rbModifica.Checked = true;
                    break;
                case 'E':
                    rbEliminazione.Checked = true;
                    break;
                default:
                    rbInserimento.Checked = true;
                    break;
            }
        }

        private void rbInserimento_CheckedChanged(object sender, EventArgs e)
        {
            LKGestioneCartella.funzione = 'I';
        }

        private void rbModifica_CheckedChanged(object sender, EventArgs e)
        {
            LKGestioneCartella.funzione = 'G';
        }

        private void rbEliminazione_CheckedChanged(object sender, EventArgs e)
        {
            LKGestioneCartella.funzione = 'E';
        }
    }
}
