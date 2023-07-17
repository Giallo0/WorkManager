using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkManager.PanelImpostazioni
{
    public partial class pnlImpostazioniParametri : UserControl
    {
        private string parametro = string.Empty;
        private string valore = string.Empty;

        public pnlImpostazioniParametri()
        {
            InitializeComponent();
            InitializeComponentPersonalizzato();
        }

        private void InitializeComponentPersonalizzato()
        {
            cboGruppo.Items.Clear();
            cboGruppo.Items.AddRange(Globale.jwm.getGruppiParametri().ToArray());
            if (cboGruppo.Items.Count > 0)
            {
                cboGruppo.SelectedIndex = 0;
            }
            cboGruppo_TextChanged(null, null);
        }

        private void eliminaRigaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComponentiParametri param = new ComponentiParametri();
            param.Gruppo = cboGruppo.Text;
            param.Parametro = parametro;
            Globale.jwm.removeParametri(param);
            gridGestioneCartella.Rows.RemoveAt(gridGestioneCartella.CurrentRow.Index);
        }

        private void gridGestioneCartella_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if ((gridGestioneCartella[0, e.RowIndex].Value != null && string.IsNullOrEmpty(parametro)) || (!string.IsNullOrEmpty(parametro)))
            {
                if (controllaDati(e.RowIndex))
                {
                    ComponentiParametri param = new ComponentiParametri();
                    param.Gruppo = cboGruppo.Text;
                    param.Parametro = gridGestioneCartella[0, e.RowIndex].Value.ToString();
                    param.Valore = gridGestioneCartella[1, e.RowIndex].Value.ToString();
                    param.Descrizione = (gridGestioneCartella[2, e.RowIndex].Value ?? string.Empty).ToString();

                    if (string.IsNullOrEmpty(parametro))
                    {
                        Globale.jwm.addParametri(param);
                    }
                    else
                    {
                        Globale.jwm.editParametri(parametro, param);
                    }
                }
            }
        }

        private bool controllaDati(int index)
        {
            bool noErrori = true;
            string gridParametro = (gridGestioneCartella[0, index].Value ?? string.Empty).ToString();
            if (string.IsNullOrEmpty(gridParametro))
            {
                MessageBox.Show("Il parametro deve essere valorizzato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gridGestioneCartella[0, index].Value = parametro;
                noErrori = false;
                goto controllaDatiErr;
            }
            string gridValore = (gridGestioneCartella[1, index].Value ?? string.Empty).ToString();
            if (string.IsNullOrEmpty(gridValore))
            {
                MessageBox.Show("Il valore del parametro deve essere valorizzato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gridGestioneCartella[1, index].Value = valore;
                noErrori = false;
                goto controllaDatiErr;
            }

        controllaDatiErr:
            return noErrori;
        }

        private void gridGestioneCartella_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            parametro = (gridGestioneCartella[0, e.RowIndex].Value ?? string.Empty).ToString();
            valore = (gridGestioneCartella[1, e.RowIndex].Value ?? string.Empty).ToString();
        }

        private void gridGestioneCartella_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int col = gridGestioneCartella.HitTest(e.X, e.Y).ColumnIndex;
                int row = gridGestioneCartella.HitTest(e.X, e.Y).RowIndex;
                if (col >= 0 && row >= 0)
                {
                    gridGestioneCartella[col, row].Selected = true;
                    if (!gridGestioneCartella.CurrentRow.IsNewRow)
                    {
                        mnuGridGestioneCartella.Show(gridGestioneCartella, e.Location);
                    }
                }
            }
        }

        private void cboGruppo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboGruppo.Text))
            {
                gridGestioneCartella.Enabled = true;
                gridGestioneCartella.Rows.Clear();
                foreach (ComponentiParametri param in Globale.jwm.getParametriElements(cboGruppo.Text))
                {
                    gridGestioneCartella.Rows.Add(param.Parametro, param.Valore, param.Descrizione);
                }
            }
            else
            {
                gridGestioneCartella.Enabled = false;
            }
        }
    }
}
