using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkManager_A.Linkage;

namespace WorkManager_A.PanelImpostazioni
{
    public partial class pnlImpostazioniGestioneCartella : Panel
    {
        private string programma = "GestioneCartella";
        private string parametro = string.Empty;
        private string valore = string.Empty;

        public pnlImpostazioniGestioneCartella()
        {
            InitializeComponent();
            InitializeComponentPersonalizzato();
        }

        public pnlImpostazioniGestioneCartella(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            InitializeComponentPersonalizzato();
        }

        // 
        // Definizione componenti panel
        // 
        private DataGridView gridGestioneCartella;
        private DataGridViewTextBoxColumn colParametro;
        private DataGridViewTextBoxColumn colValore;
        private DataGridViewTextBoxColumn colDescrizione;

        private void InitializeComponentPersonalizzato()
        {
            gridGestioneCartella = new DataGridView();
            colParametro = new DataGridViewTextBoxColumn();
            colValore = new DataGridViewTextBoxColumn();
            colDescrizione = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)gridGestioneCartella).BeginInit();
            SuspendLayout();
            // 
            // pnlOpzioniWorkspace
            // 
            Controls.Add(gridGestioneCartella);
            Dock = DockStyle.Fill;
            Location = new Point(0, 0);
            Padding = new Padding(20);
            Size = new Size(604, 450);
            // 
            // gridTipoCartella
            // 
            gridGestioneCartella.BackgroundColor = SystemColors.Control;
            gridGestioneCartella.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridGestioneCartella.Columns.AddRange(new DataGridViewColumn[] { colParametro, colValore, colDescrizione });
            gridGestioneCartella.Location = new Point(3, 3);
            gridGestioneCartella.Name = "gridGestioneCartella";
            gridGestioneCartella.RowTemplate.Height = 25;
            gridGestioneCartella.Size = new Size(595, 444);
            gridGestioneCartella.TabIndex = 0;
            gridGestioneCartella.MultiSelect = false;
            gridGestioneCartella.RowValidating += gridGestioneCartella_RowValidating;
            gridGestioneCartella.RowEnter += gridGestioneCartella_RowEnter;
            // 
            // colParametro
            // 
            colParametro.HeaderText = "Parametro";
            colParametro.Name = "colParametro";
            // 
            // colValore
            // 
            colValore.HeaderText = "Valore";
            colValore.Name = "colValore";
            // 
            // colDescrizione
            // 
            colDescrizione.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescrizione.HeaderText = "Descrizione";
            colDescrizione.Name = "colDescrizione";

            ((System.ComponentModel.ISupportInitialize)gridGestioneCartella).EndInit();
            ResumeLayout(false);


            gridGestioneCartella.Rows.Clear();
            foreach (ComponentiParametri param in Globale.jwm.getParametriElements(programma))
            {
                gridGestioneCartella.Rows.Add(param.Parametro, param.Valore, param.Descrizione);
            }
        }

        private void gridGestioneCartella_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            parametro = (gridGestioneCartella[0, e.RowIndex].Value ?? string.Empty).ToString();
            valore = (gridGestioneCartella[1, e.RowIndex].Value ?? string.Empty).ToString();
        }

        private void gridGestioneCartella_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if ((gridGestioneCartella[0, e.RowIndex].Value != null && string.IsNullOrEmpty(parametro)) || (!string.IsNullOrEmpty(parametro)))
            {
                if (controllaDati(e.RowIndex))
                {
                    ComponentiParametri function = new ComponentiParametri();
                    function.Programma = programma;
                    function.Parametro = gridGestioneCartella[0, e.RowIndex].Value.ToString();
                    function.Valore = gridGestioneCartella[1, e.RowIndex].Value.ToString();
                    function.Descrizione = (gridGestioneCartella[2, e.RowIndex].Value ?? string.Empty).ToString();

                    if (string.IsNullOrEmpty(parametro))
                    {
                        Globale.jwm.addParametri(function);
                    }
                    else
                    {
                        Globale.jwm.editParametri(parametro, function);
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
    }
}
