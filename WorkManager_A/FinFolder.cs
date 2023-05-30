using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WorkManager_A.Linkage;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WorkManager_A
{
    public partial class FinFolder : Form
    {
        public FinFolder()
        {
            InitializeComponent();
            LKFinFolder.ClearLinkageOutput();
            PersonalizzaInizializzazione();
        }

        private void PersonalizzaInizializzazione()
        {
            if (LKFinFolder.mostraRoot == null)
            {
                LKFinFolder.mostraRoot = true;
            }

            //Riempi griglia
            gridCartelle.Rows.Clear();
            if (LKFinFolder.mostraRoot == true)
            {
                DataGridViewRow riga = new DataGridViewRow();
                riga.CreateCells(gridCartelle);
                riga.Cells[0].Value = Path.GetFileName(Globale.jwm.getValue(ChiaviRoot.Workspace.ToString()));
                riga.Cells[1].Value = "Root";
                riga.Cells[2].Value = Globale.jwm.getValue(ChiaviRoot.Workspace.ToString());
                gridCartelle.Rows.Add(riga);
            }
            TrovaSottoCartelle(Globale.jwm.getValue(ChiaviRoot.Workspace.ToString()));
        }

        private void TrovaSottoCartelle(string padre)
        {
            foreach (string dir in Directory.GetDirectories(padre))
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                if (!di.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    JSONwsFolder jwsF = new JSONwsFolder(dir);
                    if (LKFinFolder.limitaTipoCartella == string.Empty || LKFinFolder.limitaTipoCartella == jwsF.getValue(ChiaviwsFolder.Tipo.ToString()))
                    {
                        DataGridViewRow riga = new DataGridViewRow();
                        riga.CreateCells(gridCartelle);
                        riga.Cells[0].Value = Path.GetFileName(dir);
                        riga.Cells[1].Value = jwsF.getValue(ChiaviwsFolder.Tipo.ToString());
                        riga.Cells[2].Value = dir;
                        gridCartelle.Rows.Add(riga);
                    }
                    TrovaSottoCartelle(dir);
                }
            }
        }

        private void gridCartelle_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = gridCartelle.HitTest(e.X, e.Y).RowIndex;
            if (row > -1) 
            {
                btnConferma_Click(null, null);
            }
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            LKFinFolder.percorsoCartella = gridCartelle.CurrentRow.Cells["colPercorso"].Value.ToString();
            LKFinFolder.nomeCartella = gridCartelle.CurrentRow.Cells["colNome"].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
