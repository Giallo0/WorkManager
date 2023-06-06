using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkManager
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            //Text = $"Work Manager - v{Properties.Settings.Default.Versione}";
        }

        private void btnCercaPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPath.Text))
            {
                if (Directory.Exists(txtPath.Text))
                {
                    Globale.jwm.setValue(ChiaviRoot.Workspace.ToString(), txtPath.Text);
                    Globale.jwm.salva();
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Il percorso selezionato non è valido o inesistente", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Nessun percorso selezionato", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
