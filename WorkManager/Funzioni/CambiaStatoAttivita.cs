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
        private string percorsoCliente;
        private string percorsoAtt;
        private JSONwsFolder jwsF;

        public CambiaStatoAttivita()
        {
            InitializeComponent();
            PersonalizzaInizializzazione();
        }

        private void PersonalizzaInizializzazione()
        {
            //Titolo programma
            if (Globale.functionCall != null)
            {
                this.Text = Globale.functionCall.Titolo;
            }

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
                rbStato.Text = ParametriCostanti<StatiAttivita>.getNameWithId((StatiAttivita)Enum.Parse(typeof(StatiAttivita), stato));
                rbStato.UseVisualStyleBackColor = true;

                if (Y == 30)
                {
                    rbStato.Checked = true;
                }
            }

            parteAbilitata = 1;
            abilitaDisabilita();

            txtCliente.Text = string.Empty;
            cboAttivita.Items.Clear();
            cboAttivita.Enabled = false;            
        }

        private void abilitaDisabilita()
        {
            switch (parteAbilitata)
            {
                case 1:
                    jwsF = null;
                    pnlPrimaParte.Enabled = true;
                    pnlSecondaParte.Enabled = false;
                    break;
                case 2:
                    pnlPrimaParte.Enabled = false;
                    pnlSecondaParte.Enabled = true;
                    break;
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
                        (jwsF.getValue(ChiaviwsFolder.Tipo) == ParametriCostanti<TipiCartella>.getName(TipiCartella.Attivita)))
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
                    percorsoAtt = $"{percorsoCliente}\\{cboAttivita.Text.Substring(0, 3)}_{cboAttivita.Text.Substring(6)}";
                    
                    jwsF = new JSONwsFolder(percorsoAtt);
                    if(!string.IsNullOrEmpty(jwsF.getValue(ChiaviwsFolder.Stato)) &&
                        ParametriCostanti<StatiAttivita>.getNamesWithId().Contains(jwsF.getValue(ChiaviwsFolder.Stato)))
                    {
                        foreach(RadioButton rbStato in gbStati.Controls)
                        {
                            if (rbStato.Text == jwsF.getValue(ChiaviwsFolder.Stato)) 
                            {
                                rbStato.Checked = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        ((RadioButton)gbStati.Controls[ParametriCostanti<StatiAttivita>.getName(StatiAttivita.Aperta)]).Checked = true;
                    }

                    parteAbilitata = 2;
                    abilitaDisabilita();
                }
            }
            else
            {
                LK_CambiaStatoAttivita.ClearLinkage();
                LK_CambiaStatoAttivita.percorsoCliente = percorsoCliente;
                LK_CambiaStatoAttivita.attivita = $"{cboAttivita.Text.Substring(0, 3)}_{cboAttivita.Text.Substring(6)}";

                foreach (RadioButton rbStato in gbStati.Controls )
                {
                    if (rbStato.Checked)
                    {
                        LK_CambiaStatoAttivita.stato = rbStato.Text;
                    }
                }
                Funzione.Apri("_CambiaStatoAttivita");
                if (!LK_CambiaStatoAttivita.erroriElab)
                {
                    parteAbilitata = 1;
                    abilitaDisabilita();
                }
                LK_CambiaStatoAttivita.ClearLinkage();
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
