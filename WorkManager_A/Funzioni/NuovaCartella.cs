using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkManager_A.Funzioni
{
    public partial class NuovaCartella : Form
    {
        public NuovaCartella()
        {
            InitializeComponent();
            PersonalizzaInizializzazione();
        }

        private void PersonalizzaInizializzazione()
        {
            this.Text = Globale.functionCallName;

            txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            if (controllaDati())
            {
                string folderPath = $"{txtPercorso.Text}\\{txtNome.Text}";
                Directory.CreateDirectory(folderPath);

                JSONwsFolder wsFolder = new JSONwsFolder(folderPath);
                wsFolder.setValue(ChiaviwsFolder.Tipo.ToString(), "Cliente");
                wsFolder.setValue(ChiaviwsFolder.DataCreazione.ToString(), DateTime.Now.ToString("yyyyMMdd"));
                wsFolder.setValue(ChiaviwsFolder.OraCreazione.ToString(), DateTime.Now.ToString("HHmmss"));
                wsFolder.salva();

                MessageBox.Show($"La cartella {txtNome.Text} è stata creata", "Nuova cartella", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNome.Text = string.Empty;
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
            if (Directory.Exists($"{txtPercorso.Text}\\{txtNome.Text}"))
            {
                MessageBox.Show("Cartella già esistente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                noErrori = false;
                goto controllaDatiErr;
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
                txtPercorso.Text = Globale.percorsoCartella;
            }
        }
    }
}
