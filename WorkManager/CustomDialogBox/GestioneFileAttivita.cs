using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkManager.CustomDialogBox.Linkage;

namespace WorkManager.CustomDialogBox
{
    public partial class GestioneFileAttivita : Form
    {
        private string funzione;
        private string percorso;
        private string oldNomeFile;
        private string nomeCompleto;

        public GestioneFileAttivita()
        {
            InitializeComponent();
            PersonalizzaInizializzazione();
        }

        private void PersonalizzaInizializzazione()
        {
            //Popolo la combo estensioni
            cboEstensione.Items.Clear();
            cboEstensione.Items.AddRange(ParametriCostanti<EstensioniFile>.getNames());
            cboEstensione.Text = ParametriCostanti<EstensioniFile>.getName(EstensioniFile.txt);

            //Controllo linkage
            if (string.IsNullOrEmpty(LKGestioneFileAttivita.funzione))
            {
                MessageBox.Show("Funzione in linkage non valorizzata", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChiusuraForzata();
            }
            else if (LKGestioneFileAttivita.funzione != "I" &&
                LKGestioneFileAttivita.funzione != "M" &&
                LKGestioneFileAttivita.funzione != "C")
            {
                MessageBox.Show($"Funzione in linkage '{LKGestioneFileAttivita.funzione}' non valida", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChiusuraForzata();
            }
            else
            {
                funzione = LKGestioneFileAttivita.funzione;
            }
            if (string.IsNullOrEmpty(LKGestioneFileAttivita.percorso))
            {
                MessageBox.Show("Percorso in linkage non valorizzato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChiusuraForzata();
            }
            else
            {
                if (funzione == "I")
                {
                    percorso = LKGestioneFileAttivita.percorso;
                }
                else
                {
                    percorso = Directory.GetParent(LKGestioneFileAttivita.percorso).FullName;
                }
            }

            //Se sono in modifica o cancellazione valorizzo il nome del file e me lo salvo in una variabile old
            if (funzione == "M" || funzione == "C")
            {
                oldNomeFile = Path.GetFileName(LKGestioneFileAttivita.percorso);
                txtNomeFile.Text = Path.GetFileNameWithoutExtension(LKGestioneFileAttivita.percorso);
                cboEstensione.Text = Path.GetExtension(LKGestioneFileAttivita.percorso).Substring(1);
            }

            //Se sono in cancellazione disabilito il campo nome file
            if (funzione == "M")
            {
                cboEstensione.Enabled = false;
            }
            else if (funzione == "C")
            {
                txtNomeFile.Enabled = false;
                cboEstensione.Enabled = false;
            }
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            if (ControllaDati())
            {
                nomeCompleto = $"{txtNomeFile.Text}.{cboEstensione.Text}";
                switch (funzione)
                {
                    case "I":
                        File.Create($"{percorso}\\{nomeCompleto}").Close();
                        MessageBox.Show($"File '{nomeCompleto}' creato con successo", "Nuovo file", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        break;
                    case "M":
                        File.Move($"{percorso}\\{oldNomeFile}", $"{percorso}\\{nomeCompleto}");
                        MessageBox.Show($"File '{nomeCompleto}' rinominato con successo", "Nuovo file", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        break;
                    case "C":
                        File.Delete($"{percorso}\\{nomeCompleto}");
                        MessageBox.Show($"File '{nomeCompleto}' cancellato con successo", "Cancella file", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        break;
                }
            }
        }

        private bool ControllaDati()
        {
            bool noErrori = true;

            if (string.IsNullOrEmpty(txtNomeFile.Text))
            {
                MessageBox.Show("Nome file non valorizzato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                noErrori = false;
                goto ControllaDatiErr;
            }
            if (string.IsNullOrEmpty(cboEstensione.Text))
            {
                MessageBox.Show("Estensione file non valorizzato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                noErrori = false;
                goto ControllaDatiErr;
            }
            if (funzione == "I" || funzione == "M")
            {
                if (File.Exists($"{percorso}\\{txtNomeFile.Text}.{cboEstensione.Text}"))
                {
                    MessageBox.Show("File già esistente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNomeFile.Focus();
                    noErrori = false;
                    goto ControllaDatiErr;
                }
            }

        ControllaDatiErr:
            return noErrori;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void ChiusuraForzata()
        {
            this.DialogResult = DialogResult.No;
            Load += (s, e) => Close();
            return;
        }
    }
}
