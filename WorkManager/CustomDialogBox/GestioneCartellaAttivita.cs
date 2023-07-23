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
using WorkManager.Linkage;

namespace WorkManager.CustomDialogBox
{
    public partial class GestioneCartellaAttivita : Form
    {
        private string funzione;
        private string percorso;
        private string oldNomeCartella;

        public GestioneCartellaAttivita()
        {
            InitializeComponent();
            PersonalizzaInizializzazione();
        }

        private void PersonalizzaInizializzazione()
        {
            //Controllo linkage
            if (string.IsNullOrEmpty(LKGestioneCartellaAttivita.funzione))
            {
                MessageBox.Show("Funzione in linkage non valorizzata", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChiusuraForzata();
            }
            else if (LKGestioneCartellaAttivita.funzione != "I" &&
                LKGestioneCartellaAttivita.funzione != "M" &&
                LKGestioneCartellaAttivita.funzione != "C")
            {
                MessageBox.Show($"Funzione in linkage '{LKGestioneCartellaAttivita.funzione}' non valida", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChiusuraForzata();
            }
            else
            {
                funzione = LKGestioneCartellaAttivita.funzione;
            }
            if (string.IsNullOrEmpty(LKGestioneCartellaAttivita.percorso))
            {
                MessageBox.Show("Percorso in linkage non valorizzato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChiusuraForzata();
            }
            else
            {
                if (funzione == "I")
                {
                    percorso = LKGestioneCartellaAttivita.percorso;
                }
                else
                {
                    percorso = Directory.GetParent(LKGestioneCartellaAttivita.percorso).FullName;
                }
            }

            //Se sono in modifica o cancellazione valorizzo il nome della cartella e me lo salvo in una variabile old
            if (funzione == "M" || funzione == "C")
            {
                oldNomeCartella = Path.GetFileName(LKGestioneCartellaAttivita.percorso);
                txtNomeCartella.Text = Path.GetFileName(LKGestioneCartellaAttivita.percorso);
            }

            //Se sono in cancellazione disabilito il campo nome cartella
            if (funzione == "C")
            {
                txtNomeCartella.Enabled = false;
            }
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            if (ControllaDati())
            {
                switch (funzione)
                {
                    case "I":
                        Directory.CreateDirectory($"{percorso}\\{txtNomeCartella.Text}");
                        MessageBox.Show($"Cartella '{txtNomeCartella.Text}' creata con successo", "Nuova cartella", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        break;
                    case "M":
                        Directory.Move($"{percorso}\\{oldNomeCartella}", $"{percorso}\\{txtNomeCartella.Text}");
                        MessageBox.Show($"Cartella '{txtNomeCartella.Text}' rinominata con successo", "Modifica cartella", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        break;
                    case "C":
                        Directory.Delete($"{percorso}\\{txtNomeCartella.Text}");
                        MessageBox.Show($"Cartella '{txtNomeCartella.Text}' cancellata con successo", "Cancella cartella", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        break;
                }
            }
        }

        private bool ControllaDati()
        {
            bool noErrori = true;

            if (string.IsNullOrEmpty(txtNomeCartella.Text))
            {
                MessageBox.Show("Nome cartella non valorizzato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                noErrori = false;
                goto ControllaDatiErr;
            }
            if (funzione == "I" || funzione == "M")
            {
                if (Directory.Exists($"{percorso}\\{txtNomeCartella.Text}"))
                {
                    MessageBox.Show("Cartella già esistente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNomeCartella.Focus();
                    noErrori = false;
                    goto ControllaDatiErr;
                }
            }
            if (funzione == "C")
            {
                //Controllo se all'interno dell'attivita sono presenti dei file non nascosti
                FileInfo[] files = new DirectoryInfo($"{percorso}\\{txtNomeCartella.Text}").GetFiles();
                var filtered = files.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden));
                if (filtered.Count() > 0)
                {
                    MessageBox.Show("Impossibile cancellare la cartella perché contiene dei file al suo interno", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
