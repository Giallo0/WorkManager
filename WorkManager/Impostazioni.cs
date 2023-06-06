using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkManager.PanelImpostazioni;

namespace WorkManager
{
    public partial class Impostazioni : Form
    {
        public Impostazioni()
        {
            InitializeComponent();

            treeMenu.Nodes.Clear();
            TreeNode nodo = new TreeNode();
            nodo.Text = "Workspace";
            nodo.Tag = "Workspace";
            treeMenu.Nodes.Add(nodo);

            nodo = new TreeNode();
            nodo.Text = "Parametri";
            nodo.Tag = "Parametri";
            treeMenu.Nodes.Add(nodo);

            nodo = new TreeNode();
            nodo.Text = "Opzioni";
            nodo.Tag = "Opzioni";
            treeMenu.Nodes.Add(nodo);
        }

        private void treeMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeMenu.SelectedNode != null)
            {
                pnlMain.Controls.Clear();
                switch (treeMenu.SelectedNode.Tag)
                {
                    case "Workspace":
                        pnlMain.Controls.Add(new pnlImpostazioniWorkspace());
                        break;
                    case "Parametri":
                        pnlMain.Controls.Add(new pnlImpostazioniParametri());
                        break;
                    case "Opzioni":
                        pnlMain.Controls.Add(new pnlImpostazioniOpzioni());
                        break;
                }
            }
        }

        private void btnEsci_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
