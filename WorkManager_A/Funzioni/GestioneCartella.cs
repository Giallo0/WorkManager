using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkManager_A.Linkage;

namespace WorkManager_A.Funzioni
{
    public partial class GestioneCartella : Form
    {
        private bool noerrori = true;

        //Solo in modifica
        private string oldPath;

        public GestioneCartella()
        {
            ControllaLinkage();
            if (noerrori)
            {
                InitializeComponent();
                PersonalizzaInizializzazione();
            }
            else
            {
                Load += (s, e) => Close();
                return;
            }
        }

        private void ControllaLinkage()
        {
            noerrori = true;

            LKGestioneCartella.DecodificaLinkageString(Globale.functionCall.Linkage);

            //Funzione
            switch (LKGestioneCartella.funzione)
            {
                case "I":
                case "G":
                case "E":
                    break;
                case " ":
                    MessageBox.Show("Funzione in linkage non valorizzata", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    noerrori = false;
                    break;
                default:
                    MessageBox.Show($"Funzione in linkage '{LKGestioneCartella.funzione}' non valida", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    noerrori = false;
                    break;
            }
        }

        private void PersonalizzaInizializzazione()
        {
            //Titolo programma
            this.Text = Globale.functionCall.Titolo;

            txtPercorso.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");





            if (LKGestioneCartella.funzione == "G")
            {
                oldPath = string.Empty;
            }
            else if (LKGestioneCartella.funzione == "E")
            {
                oldPath = string.Empty;
                txtNome.Enabled = false;
            }
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            if (controllaDati())
            {
                string folderPath = $"{txtPercorso.Text}\\{txtNome.Text}";
                JSONwsFolder wsFolder;

                switch (LKGestioneCartella.funzione)
                {
                    case "I":
                        Directory.CreateDirectory(folderPath);

                        wsFolder = new JSONwsFolder(folderPath);
                        wsFolder.setValue(ChiaviwsFolder.Tipo.ToString(), "Cliente");
                        wsFolder.setValue(ChiaviwsFolder.DataCreazione.ToString(), DateTime.Now.ToString("yyyyMMdd"));
                        wsFolder.setValue(ChiaviwsFolder.OraCreazione.ToString(), DateTime.Now.ToString("HHmmss"));
                        wsFolder.salva();

                        MessageBox.Show($"La cartella {txtNome.Text} è stata creata", "Nuova cartella", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNome.Text = string.Empty;
                        break;
                    case "G":
                        Directory.Move(oldPath, folderPath);

                        wsFolder = new JSONwsFolder(folderPath);
                        wsFolder.setValue(ChiaviwsFolder.DataModifica.ToString(), DateTime.Now.ToString("yyyyMMdd"));
                        wsFolder.setValue(ChiaviwsFolder.OraModifica.ToString(), DateTime.Now.ToString("HHmmss"));
                        wsFolder.salva();

                        MessageBox.Show($"La cartella '{oldPath.Remove(0, oldPath.LastIndexOf("\\") + 1)}' è stata rinominata in '{txtNome.Text}'", "Modifica cartella", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNome.Text = string.Empty;
                        break;
                    case "E":
                        DirectoryInfo directoryInfo = new DirectoryInfo(oldPath);
                        FileInfo[] files = directoryInfo.GetFiles();
                        var filtered = files.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden));
                        if (filtered.Count() == 0)
                        {
                            if (MessageBox.Show($"Eliminare la cartella '{txtNome.Text}'?", "Elimina cartella", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                Directory.Delete(oldPath, true);
                                MessageBox.Show($"La cartella {txtNome.Text} è stata eliminata", "Elimina cartella", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtNome.Text = string.Empty;
                                txtPercorso.Text = string.Empty;
                            }
                        }
                        else
                        {
                            MessageBox.Show($"La cartella {txtNome.Text} non può essere eliminata perché contiene dei file al suo interno", "Elimina cartella", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                }
                txtNome.Focus();
            }
        }

        private bool controllaDati()
        {
            bool noErrori = true;
            if (string.IsNullOrEmpty(txtPercorso.Text))
            {
                MessageBox.Show("Percorso non valorizzato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCerca.Focus();
                noErrori = false;
                goto controllaDatiErr;
            }
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Nome non valorizzato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                noErrori = false;
                goto controllaDatiErr;
            }
            if (LKGestioneCartella.funzione.CompareTo("I") == 0 || LKGestioneCartella.funzione.CompareTo("G") == 0)
            {
                if (Directory.Exists($"{txtPercorso.Text}\\{txtNome.Text}"))
                {
                    MessageBox.Show("Cartella già esistente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Focus();
                    noErrori = false;
                    goto controllaDatiErr;
                }
            }
        controllaDatiErr:
            return noErrori;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCerca_Click(object sender, EventArgs e)
        {
            if (Funzione.Apri("FinFolder", "WorkManager_A") == DialogResult.OK)
            {
                switch (LKGestioneCartella.funzione)
                {
                    case "I":
                        txtPercorso.Text = Globale.percorsoCartella;
                        break;
                    case "G":
                    case "E":
                        oldPath = Globale.percorsoCartella;
                        txtPercorso.Text = Globale.percorsoCartella.Remove(Globale.percorsoCartella.LastIndexOf('\\'));
                        txtNome.Text = Globale.percorsoCartella.Remove(0, Globale.percorsoCartella.LastIndexOf('\\') + 1);
                        break;
                }
            }
        }
    }
}
