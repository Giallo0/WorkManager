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
        private List<string> elencoClienti = new List<string>();
        private DataTable dt = new DataTable();

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
            dt.Columns.Add("Progressivo", typeof(string)).ColumnMapping = MappingType.Hidden;
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("Tipo", typeof(string));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Percorso", typeof(string));

            if (LKFinFolder.mostraRoot == true)
            {
                dt.Rows.Add(new object[] {
                    string.Empty,                                                               //Progressivo
                    Path.GetFileName(Globale.jwm.getValue(ChiaviRoot.Workspace.ToString())),    //Nome
                    "Root",                                                                     //Tipo
                    string.Empty,                                                               //Cliente
                    Globale.jwm.getValue(ChiaviRoot.Workspace.ToString())                       //Percorso
                });
            }
            TrovaSottoCartelle(Globale.jwm.getValue(ChiaviRoot.Workspace.ToString()));
            gridCartelle.DataSource = dt;

            gridCartelle.Columns["Nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridCartelle.Columns["Percorso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //Riempi combo Clienti
            cboCliente.Items.Clear();
            cboCliente.Items.Add("Tutti");
            cboCliente.Items.AddRange(elencoClienti.ToArray());
            cboCliente.SelectedIndex = 0;

            //Riempi combo Tipi
            cboTipo.Items.Clear();
            cboTipo.Items.Add("Tutti");
            cboTipo.Items.Add("Root");
            string[] tipiCartella = Globale.jwm.getParametro("GestioneCartella", "TipoCartella").Valore.ToString().Split(';') ?? new string[0];
            cboTipo.Items.AddRange(tipiCartella);
            cboTipo.Items.Remove("ND");
            cboTipo.SelectedIndex = 0;

            if (!string.IsNullOrEmpty(LKFinFolder.limitaTipoCartella))
            {
                cboTipo.SelectedItem = LKFinFolder.limitaTipoCartella;
                cboTipo.Enabled = false;
            }
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
                        if (jwsF.getValue(ChiaviwsFolder.Tipo.ToString()) == "Attività")
                        {
                            dt.Rows.Add(new object[] {
                                Path.GetFileName(dir).Substring(0, 3),          //Progressivo
                                Path.GetFileName(dir).Substring(4),             //Nome
                                jwsF.getValue(ChiaviwsFolder.Tipo.ToString()),  //Tipo
                                Directory.GetParent(dir).Name,                  //Cliente
                                dir                                             //Percorso
                            });
                            if (!elencoClienti.Contains(Directory.GetParent(dir).Name))
                            {
                                elencoClienti.Add(Directory.GetParent(dir).Name);
                            }
                        }
                        else
                        {
                            dt.Rows.Add(new object[] {
                                string.Empty,                                   //Progressivo
                                Path.GetFileName(dir),                          //Nome
                                jwsF.getValue(ChiaviwsFolder.Tipo.ToString()),  //Tipo
                                Path.GetFileName(dir),                          //Cliente
                                dir                                             //Percorso
                            });
                        }
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
            LKFinFolder.percorsoCartella = gridCartelle.CurrentRow.Cells["Percorso"].Value.ToString();
            LKFinFolder.nomeCartella = gridCartelle.CurrentRow.Cells["Nome"].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cboCliente_TextChanged(object sender, EventArgs e)
        {
            impostaFiltro();
        }

        private void cboTipo_TextChanged(object sender, EventArgs e)
        {
            if (cboTipo.Text == "Cliente" || cboTipo.Text == "Root")
            {
                cboCliente.SelectedIndex = 0;
                cboCliente.Enabled = false;

                chbProgDec.Checked = false;
                chbProgDec.Enabled = false;
            }
            else
            {
                cboCliente.Enabled = true;
                chbProgDec.Enabled = true;
            }
            impostaFiltro();
        }

        private void chbProgDec_CheckedChanged(object sender, EventArgs e)
        {
            impostaFiltro();
        }

        private void impostaFiltro()
        {
            dt.DefaultView.RowFilter = null;
            dt.DefaultView.Sort = null;

            if (cboTipo.Text != "Tutti")
            {
                if (string.IsNullOrEmpty(dt.DefaultView.RowFilter))
                {
                    dt.DefaultView.RowFilter = string.Format($"Tipo = '{cboTipo.Text}'");
                }
                else
                {
                    dt.DefaultView.RowFilter += string.Format($" and Tipo = '{cboTipo.Text}'");
                }
            }

            if (cboCliente.Text != "Tutti")
            {
                if (string.IsNullOrEmpty(dt.DefaultView.RowFilter))
                {
                    dt.DefaultView.RowFilter = string.Format($"Cliente = '{cboCliente.Text}'");
                }
                else
                {
                    dt.DefaultView.RowFilter += string.Format($" and Cliente = '{cboCliente.Text}'");
                }
            }

            if (chbProgDec.Checked)
            {
                dt.DefaultView.Sort = "Tipo DESC, Cliente ASC, Progressivo DESC, Nome ASC";
            }
            else
            {
                dt.DefaultView.Sort = "Tipo DESC, Cliente ASC, Progressivo ASC, Nome ASC";
            }
        }
    }
}
