using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkManager_A.Linkage;
using WorkManager_A.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WorkManager_A
{
    public partial class GestioneMenu : Form
    {
        private string linkageFunction;
        private int posizioneElementoNew;

        public GestioneMenu()
        {
            InitializeComponent();
            PersonalizzaInizializzazione();
        }

        private void PersonalizzaInizializzazione()
        {
            pnlFunzioni.Enabled = true;
            pnlEdit.Enabled = false;

            riempiListMenu();
            LKGestioneLinkage.ClearLinkage();

            cboBitmap.Items.Clear();
            cboBitmap.Items.Add(" - ");
            foreach (DictionaryEntry entry in Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true))
            {
                string name = entry.Key.ToString();
                if (name.Contains('_') && name.Substring(name.LastIndexOf('_') + 1) == "24x24")
                {
                    cboBitmap.Items.Add(name);
                }
            }
            pnlEditClear();
        }

        private void riempiListMenu()
        {
            treeList.Nodes.Clear();
            foreach (ComponentiMenu function in Globale.jwm.getMenuElements())
            {
                TreeNode nodo = new TreeNode(function.Titolo);
                nodo.Tag = function;
                treeList.Nodes.Add(nodo);
            }
        }

        private void pnlEditClear()
        {
            lblIDValue.Text = string.Empty;
            txtTitolo.Text = string.Empty;
            txtProgramma.Text = string.Empty;
            cboBitmap.SelectedItem = " - ";
            linkageFunction = string.Empty;
        }

        private void cboBitmap_TextChanged(object sender, EventArgs e)
        {
            picBitmap.Image = (Image)Resources.ResourceManager.GetObject(cboBitmap.Text);
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            if (controllaDati())
            {
                ComponentiMenu function = new ComponentiMenu();
                function.Titolo = txtTitolo.Text;
                function.Programma = txtProgramma.Text;
                function.Bitmap = cboBitmap.SelectedItem.ToString();
                function.Linkage = LKGestioneLinkage.linkage;

                if (int.Parse(lblIDValue.Text) == 0)
                {
                    if (posizioneElementoNew > 0)
                    {
                        Globale.jwm.addFunctionMenu(function, posizioneElementoNew);
                    }
                    else
                    {
                        Globale.jwm.addFunctionMenu(function);
                    }
                }
                else
                {
                    Globale.jwm.editFunctionMenu(lblIDValue.Text, function);
                }
                pnlEditClear();
                riempiListMenu();
                pnlFunzioni.Enabled = true;
                pnlEdit.Enabled = false;
                posizioneElementoNew = 0;
            }
        }

        private bool controllaDati()
        {
            bool noErrori = true;
            if (string.IsNullOrEmpty(txtTitolo.Text))
            {
                MessageBox.Show("Titolo non valorizzato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTitolo.Focus();
                noErrori = false;
                goto controllaDatiErr;
            }
            if (string.IsNullOrEmpty(txtProgramma.Text))
            {
                MessageBox.Show("Programma non valorizzato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProgramma.Focus();
                noErrori = false;
                goto controllaDatiErr;
            }
            if (Type.GetType($"WorkManager_A.Linkage.LK{txtProgramma.Text}") != null && string.IsNullOrEmpty(LKGestioneLinkage.linkage))
            {
                MessageBox.Show("Linkage non valorizzata", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnLinkage.Focus();
                noErrori = false;
                goto controllaDatiErr;
            }

        controllaDatiErr:
            return noErrori;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            pnlEditClear();
            pnlFunzioni.Enabled = true;
            pnlEdit.Enabled = false;
        }

        private void btnEsci_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnNuovaFunzione_Click(object sender, EventArgs e)
        {
            pnlFunzioni.Enabled = false;
            pnlEdit.Enabled = true;
            btnLinkage.Enabled = false;

            pnlEditClear();
            lblIDValue.Text = "0";
        }

        private void treeList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            modificaFunzioneMenu((ComponentiMenu)e.Node.Tag);
        }

        private void treeList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeList.SelectedNode = e.Node;
                treeListMenu.Show(treeList, e.Location);
            }
        }

        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modificaFunzioneMenu((ComponentiMenu)treeList.SelectedNode.Tag);
        }

        private void modificaFunzioneMenu(ComponentiMenu function)
        {
            pnlEditClear();
            pnlFunzioni.Enabled = false;
            pnlEdit.Enabled = true;

            lblIDValue.Text = function.ID;
            txtTitolo.Text = function.Titolo;
            txtProgramma.Text = function.Programma;
            cboBitmap.Text = function.Bitmap;
            linkageFunction = function.Linkage;
        }

        private void eliminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Sicuro di voler eliminare la funzione dal menù?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                Globale.jwm.removeFunctionMenu((ComponentiMenu)treeList.SelectedNode.Tag);
                riempiListMenu();
            }
        }

        private void txtProgramma_TextChanged(object sender, EventArgs e)
        {
            btnLinkage.Enabled = false;
            if (Type.GetType($"WorkManager_A.Linkage.LK{txtProgramma.Text}") != null)
            {
                btnLinkage.Enabled = true;
            }
        }

        private void btnLinkage_Click(object sender, EventArgs e)
        {
            LKGestioneLinkage.ClearLinkage();
            LKGestioneLinkage.nomePgm = txtProgramma.Text;
            LKGestioneLinkage.linkage = linkageFunction;
            Funzione.Apri("GestioneLinkage", "WorkManager_A");
            linkageFunction = LKGestioneLinkage.linkage;
        }

        private void spostaSuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeList.SelectedNode.Index > 0)
            {
                Globale.jwm.invertiOrdineMenu(treeList.SelectedNode.Index, treeList.SelectedNode.Index - 1);
                riempiListMenu();
            }
        }

        private void spostaGiùToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeList.GetNodeCount(false) - 1 > treeList.SelectedNode.Index)
            {
                Globale.jwm.invertiOrdineMenu(treeList.SelectedNode.Index, treeList.SelectedNode.Index + 1);
                riempiListMenu();
            }
        }

        private void nuovaFunzioneSuccessivaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            posizioneElementoNew = treeList.SelectedNode.Index + 1;

            pnlFunzioni.Enabled = false;
            pnlEdit.Enabled = true;
            btnLinkage.Enabled = false;

            pnlEditClear();
            lblIDValue.Text = "0";
        }
    }
}
