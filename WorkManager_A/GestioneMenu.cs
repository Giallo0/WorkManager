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
using WorkManager_A.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WorkManager_A
{
    public partial class GestioneMenu : Form
    {
        private MenuJSON jMenu = new MenuJSON();

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

            cboBitmap.Items.Clear();
            cboBitmap.Items.Add(" - ");
            foreach (DictionaryEntry entry in Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true))
            {
                cboBitmap.Items.Add(entry.Key.ToString());
            }
            pnlEditClear();
        }

        private void riempiListMenu()
        {
            treeList.Nodes.Clear();
            foreach (ComponenteMenu function in jMenu.getElements())
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
        }

        private void cboBitmap_TextChanged(object sender, EventArgs e)
        {
            picBitmap.Image = (Image)Resources.ResourceManager.GetObject(cboBitmap.Text);
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            ComponenteMenu function = new ComponenteMenu();
            function.Titolo = txtTitolo.Text;
            function.Programma = txtProgramma.Text;
            function.Bitmap = cboBitmap.SelectedItem.ToString();

            if (int.Parse(lblIDValue.Text) == 0)
            {
                jMenu.add(function);
            }
            else
            {
                jMenu.edit(lblIDValue.Text, function);
            }
            pnlEditClear();
            riempiListMenu();
            pnlFunzioni.Enabled = true;
            pnlEdit.Enabled = false;
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

            pnlEditClear();
            lblIDValue.Text = "0";
        }

        private void treeList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            modificaFunzioneMenu((ComponenteMenu)e.Node.Tag);
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
            modificaFunzioneMenu((ComponenteMenu)treeList.SelectedNode.Tag);
        }

        private void modificaFunzioneMenu(ComponenteMenu function)
        {
            pnlEditClear();
            pnlFunzioni.Enabled = false;
            pnlEdit.Enabled = true;

            lblIDValue.Text = function.ID;
            txtTitolo.Text = function.Titolo;
            txtProgramma.Text = function.Programma;
            cboBitmap.Text = function.Bitmap;
        }

        private void eliminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Sicuro di voler eliminare la funzione dal menù?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                jMenu.remove((ComponenteMenu)treeList.SelectedNode.Tag);
                riempiListMenu();
            }
        }
    }
}
