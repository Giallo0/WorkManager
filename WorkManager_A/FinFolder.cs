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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WorkManager_A
{
    public partial class FinFolder : Form
    {
        public FinFolder()
        {
            InitializeComponent();
            Globale.percorsoCartella = String.Empty;
            Globale.titoloCartella = String.Empty;
            PersonalizzaInizializzazione();
        }

        private void PersonalizzaInizializzazione()
        {
            // Text => Nome della cartella
            // Tag => Percorso della cartella

            treeFullPath.Nodes.Clear();
            TreeNode root = new TreeNode();

            //Aggiungo come root la cartella del workspace
            root.Text = Path.GetFileName(Globale.jwm.getValue(ChiaviRoot.Workspace.ToString()));
            root.Tag = Globale.jwm.getValue(ChiaviRoot.Workspace.ToString());
            treeFullPath.Nodes.Add(root);
            TrovaSottoCartelle(root);

            ImageList imageList = new ImageList();
            imageList.Images.Add(Properties.Resources.cartella_16x16);
            imageList.ImageSize = new Size(16, 16);
            root.TreeView.ImageList = imageList;

            root.Expand();
        }

        private void TrovaSottoCartelle(TreeNode parent)
        {
            foreach (string dir in Directory.GetDirectories(parent.Tag.ToString()))
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                if (!di.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    TreeNode nodo = new TreeNode();
                    nodo.Text = Path.GetFileName(dir);
                    nodo.Tag = dir;
                    parent.Nodes.Add(nodo);
                    TrovaSottoCartelle(nodo);
                }
            }
        }

        private void treeFullPath_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            txtCartella.Text = e.Node.Tag.ToString();

            lstContenuto.Items.Clear();
            ImageList imageList = new ImageList();
            /*
            //Per ogni cartella e file aggiungo l'icona associata alla lista di immagini
            foreach (string dir in Directory.GetDirectories(txtCartella.Text))
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                if (!di.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    imageList.Images.Add(Properties.Resources.cartella_32x32);
                }

            }
            */
            foreach (string file in Directory.GetFiles(txtCartella.Text))
            {
                FileInfo fi = new FileInfo(file);
                if (!fi.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    imageList.Images.Add(Properties.Resources.file_32x32);
                }
            }

            //Gestisco le proprietà dell'immagine e l'associo alla list view
            lstContenuto.View = View.LargeIcon;
            imageList.ImageSize = new Size(32, 32);
            lstContenuto.LargeImageList = imageList;

            //Inserisco gli oggetti all'interno della lista con le rispettive icone
            int j = 0;
            /*
            foreach (string dir in Directory.GetDirectories(txtCartella.Text))
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                if (!di.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = j++;
                    item.Text = dir.Remove(0, dir.LastIndexOf("\\") + 1);
                    item.Tag = dir;
                    lstContenuto.Items.Add(item);
                }

            }
            */
            foreach (string file in Directory.GetFiles(txtCartella.Text))
            {
                FileInfo fi = new FileInfo(file);
                if (!fi.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = j++;
                    item.Text = file.Substring(file.LastIndexOf("\\") + 1);
                    lstContenuto.Items.Add(item);
                }
            }
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            Globale.percorsoCartella = txtCartella.Text;
            Globale.titoloCartella = txtCartella.Text.Remove(0, txtCartella.Text.LastIndexOf("\\") + 1);
            this.DialogResult = DialogResult.OK;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void treeFullPath_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            txtCartella.Text = e.Node.Tag.ToString();
            btnConferma_Click(null, null);
        }

        private void lstContenuto_MouseClick(object sender, MouseEventArgs e)
        {
            /*
            if (lstContenuto.SelectedItems.Count > 0)
            {
                ListViewItem item = lstContenuto.SelectedItems[0];
                if (item.Bounds.Contains(e.Location))
                {
                    if (item.Tag != null)
                    {
                        txtCartella.Text = item.Tag.ToString();
                    }
                    else
                    {
                        txtCartella.Text = String.Empty;
                    }
                }
            }
            */
        }

        private void lstContenuto_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            /*
            if (lstContenuto.SelectedItems.Count > 0)
            {
                ListViewItem item = lstContenuto.SelectedItems[0];
                if (item.Bounds.Contains(e.Location))
                {
                    if (item.Tag != null)
                    {
                        txtCartella.Text = item.Tag.ToString();
                        btnConferma_Click(null, null);
                    }
                    else
                    {
                        txtCartella.Text = String.Empty;
                    }
                }
            }
            */
        }
    }
}
