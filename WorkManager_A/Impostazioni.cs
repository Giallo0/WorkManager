using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkManager_A.PanelImpostazioni;

namespace WorkManager_A
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
            treeMenu.Nodes.Add(nodo);

            TreeNode subNodo = new TreeNode();
            subNodo.Text = "Gestione Cartella";
            subNodo.Tag = "pGestioneCartella";
            nodo.Nodes.Add(subNodo);
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
                    case "pGestioneCartella":
                        pnlMain.Controls.Add(new pnlImpostazioniGestioneCartella());
                        break;
                }
            }
        }
    }
}
