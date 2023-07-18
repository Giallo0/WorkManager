using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkManager.Linkage;

namespace WorkManager.Funzioni
{
    public partial class CambiaStatoAttivita : Form
    {
        private int parteAbilitata;
        private string statoAttivita;
        private string percorsoCliente;

        public CambiaStatoAttivita()
        {
            InitializeComponent();
            PersonalizzaInizializzazione();
        }

        private void PersonalizzaInizializzazione()
        {
            int Y = 0;
            foreach (string stato in ParametriCostanti<StatiAttivita>.getNames())
            {
                Y += 30;
                RadioButton rbStato = new RadioButton();
                gbStati.Controls.Add(rbStato);

                rbStato.AutoSize = true;
                rbStato.Location = new Point(15, Y);
                rbStato.Name = $"rbStato{stato}";
                rbStato.Size = new Size(109, 21);
                rbStato.TabIndex = 0;
                rbStato.TabStop = true;
                rbStato.Text = stato;
                rbStato.UseVisualStyleBackColor = true;
                rbStato.CheckedChanged += rbStato_CheckedChanged;

                if(Y == 30)
                {
                    rbStato.Checked = true;
                }
            }

            parteAbilitata = 1;
            abilitaDisabilita();
        }

        private void abilitaDisabilita()
        {
            switch (parteAbilitata)
            {
                case 1:
                    pnlPrimaParte.Enabled = true;
                    pnlSecondaParte.Enabled = false;
                    break;
                case 2:
                    pnlPrimaParte.Enabled = false;
                    pnlSecondaParte.Enabled = true;
                    break;
            }
        }

        private void rbStato_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                statoAttivita = rb.Text;
            }
        }

        private void btnCercaCliente_Click(object sender, EventArgs e)
        {
            //Valorizzazione linkage input
            LKFinFolder.ClearLinkage();
            LKFinFolder.mostraRoot = false;
            LKFinFolder.TipoCartella = ParametriCostanti<TipiCartella>.getName(TipiCartella.Cliente);

            //Chiamata programma
            if (Funzione.Apri("FinFolder", "WorkManager") == DialogResult.OK)
            {
                percorsoCliente = LKFinFolder.percorsoCartella;
                txtCliente.Text = LKFinFolder.nomeCartella;

                //Recupero le attività aperte per il cliente selezionato
                cboAttivita.Items.Clear();
                if (string.IsNullOrEmpty(txtCliente.Text))
                {
                    cboAttivita.Enabled = false;
                }
                else
                {
                    cboAttivita.Enabled = true;
                    TrovaAttivita(percorsoCliente);
                }
            }
        }

        private void TrovaAttivita(string cliente)
        {
            foreach (string dir in Directory.GetDirectories(cliente))
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                if (!di.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    JSONwsFolder jwsF = new JSONwsFolder(dir, false);
                    if (!jwsF.isNull() &&
                        (jwsF.getValue(ChiaviwsFolder.Tipo) == ParametriCostanti<TipiCartella>.getName(TipiCartella.Attivita)) &&
                        (jwsF.getValue(ChiaviwsFolder.Stato) == ParametriCostanti<StatiAttivita>.getName(StatiAttivita.Aperta)))
                    {
                        cboAttivita.Items.Add($"{Path.GetFileName(dir).Substring(0, 3)} - {Path.GetFileName(dir).Substring(4)}");
                    }
                }
            }
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            if (parteAbilitata == 1)
            {
                if (controllaDati())
                {
                    //Recupero stato
                    //((RadioButton)gbStati.Controls[]).Checked = true;

                    parteAbilitata = 2;
                    abilitaDisabilita();
                }
            }
        }

        private bool controllaDati()
        {
            bool noerrori = true;

            if (string.IsNullOrEmpty(txtCliente.Text))
            {
                MessageBox.Show("Nessun cliente selezionato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                noerrori = false;
                goto controllaDatiErr;
            }

            if (string.IsNullOrEmpty(cboAttivita.Text))
            {
                MessageBox.Show("Nessuna attività selezionata", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                noerrori = false;
                goto controllaDatiErr;
            }

        controllaDatiErr:
            return noerrori;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            if (parteAbilitata == 1)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                parteAbilitata = 1;
                abilitaDisabilita();
            }
        }
    }
}
