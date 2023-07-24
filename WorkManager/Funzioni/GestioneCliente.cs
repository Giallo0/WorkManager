using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkManager.Linkage;
using static WorkManager.TipiCartella;

namespace WorkManager.Funzioni
{
    public partial class GestioneCliente : Form
    {
        //Solo in modifica e in eliminazione, path di origine
        private string originPath;
        private string nome;

        public GestioneCliente()
        {
            if (ControllaLinkage())
            {
                InitializeComponent();
                PersonalizzaInizializzazione();
            }
            else
            {
                Load += (s, e) => Close();
                return;
            }
        }

        private bool ControllaLinkage()
        {
            bool noerrori = true;

            LKGestioneCliente.DecodificaLinkageString(Globale.functionCall.Linkage);

            //Funzione
            if (string.IsNullOrEmpty(LKGestioneCliente.funzione))
            {
                MessageBox.Show("Funzione in linkage non valorizzata", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                noerrori = false;
                goto ControllaLinkageErr;
            }
            else if (LKGestioneCliente.funzione != "I" && LKGestioneCliente.funzione != "G" && LKGestioneCliente.funzione != "E")
            {
                MessageBox.Show($"Funzione in linkage '{LKGestioneCliente.funzione}' non valida", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                noerrori = false;
                goto ControllaLinkageErr;
            }

        ControllaLinkageErr:
            return noerrori;
        }

        private void PersonalizzaInizializzazione()
        {
            originPath = string.Empty;

            //Titolo programma
            this.Text = Globale.functionCall.Titolo;

            //Inizializzo i field della screen
            txtPercorso.Text = string.Empty;
            txtNome.Text = string.Empty;
            nome = string.Empty;

            //Se sono in eliminazione disabilito il field Nome
            if (LKGestioneCliente.funzione == "E")
            {
                txtNome.Enabled = false;
            }
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            nome = string.Empty;
            nome = txtNome.Text.Replace(' ', '_');

            if (controllaDati())
            {
                string folderPath = null;
                string stato = string.Empty;

                //Il percorso della cartella sarà formato dal nome della cartella
                folderPath = $"{txtPercorso.Text}\\{nome}";

                if (!string.IsNullOrEmpty(folderPath))
                {
                    JSONwsFolder jwsF;
                    switch (LKGestioneCliente.funzione)
                    {
                        case "I":
                            Directory.CreateDirectory(folderPath);

                            jwsF = new JSONwsFolder(folderPath);
                            ComponentiwsFolder wsFolder = new ComponentiwsFolder();
                            wsFolder.Tipo = ParametriCostanti<TipiCartella>.getName(TipiCartella.Cliente);
                            wsFolder.DataCreazione = DateTime.Now.ToString("yyyyMMdd");
                            wsFolder.OraCreazione = DateTime.Now.ToString("HHmmss");
                            wsFolder.Stato = stato;
                            jwsF.newFolder(wsFolder);

                            MessageBox.Show($"Il cliente '{nome}' è stato creato", "Nuovo cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtNome.Text = string.Empty;
                            nome = string.Empty;
                            break;

                        case "G":
                            if (originPath != folderPath)
                            {
                                Directory.Move(originPath, folderPath);

                                jwsF = new JSONwsFolder(folderPath);
                                jwsF.setValue(ChiaviwsFolder.DataModifica, DateTime.Now.ToString("yyyyMMdd"));
                                jwsF.setValue(ChiaviwsFolder.OraModifica, DateTime.Now.ToString("HHmmss"));
                                jwsF.salva();

                                //Il percorso della cartella sarà formato dal nome della cartella
                                MessageBox.Show($"Il cliente '{originPath.Remove(0, originPath.LastIndexOf("\\") + 1)}' è stato rinominato in '{nome}'", "Modifica cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                txtPercorso.Text = string.Empty;
                                txtNome.Text = string.Empty;
                                nome = string.Empty;
                            }
                            break;

                        case "E":
                            //Controllo se all'interno della cartella sono presenti dei file non nascosti
                            FileInfo[] files = new DirectoryInfo(originPath).GetFiles();
                            var filtered = files.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden));
                            if (filtered.Count() == 0)
                            {
                                if (MessageBox.Show($"Eliminare il cliente '{nome}'?", "Elimina cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                {
                                    Directory.Delete(originPath, true);

                                    MessageBox.Show($"il cliente '{nome}' è stato eliminato", "Elimina cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtNome.Text = string.Empty;
                                    nome = string.Empty;
                                    txtPercorso.Text = string.Empty;
                                }
                            }
                            else
                            {
                                MessageBox.Show($"Il cliente '{nome}' non può essere eliminato perché contiene dei file al suo interno", "Elimina cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            break;
                    }
                }
                txtNome.Focus();
            }
        }

        private bool controllaDati()
        {
            bool noErrori = true;
            if (string.IsNullOrEmpty(txtPercorso.Text))
            {
                MessageBox.Show("Percorso non valorizzato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCerca.Focus();
                noErrori = false;
                goto controllaDatiErr;
            }
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Nome non valorizzato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                noErrori = false;
                goto controllaDatiErr;
            }
            if (LKGestioneCliente.funzione.CompareTo("I") == 0 || LKGestioneCliente.funzione.CompareTo("G") == 0)
            {
                if (Directory.Exists($"{txtPercorso.Text}\\{nome}"))
                {
                    MessageBox.Show("Cliente già esistente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Focus();
                    noErrori = false;
                    goto controllaDatiErr;
                }
            }
        controllaDatiErr:
            return noErrori;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCerca_Click(object sender, EventArgs e)
        {
            //Valorizzazione linkage input
            LKFinFolder.ClearLinkage();
            switch (LKGestioneCliente.funzione)
            {
                case "I":
                    LKFinFolder.mostraRoot = true;
                    LKFinFolder.TipoCartella = ParametriCostanti<TipiCartella>.getName(TipiCartella.Root);
                    break;
                case "G":
                case "E":
                    LKFinFolder.mostraRoot = false;
                    LKFinFolder.TipoCartella = ParametriCostanti<TipiCartella>.getName(TipiCartella.Cliente);
                    break;
            }

            //Chiamata programma
            if (Funzione.Apri("FinFolder", "WorkManager") == DialogResult.OK)
            {
                //Valorizzazione con valori linkage output
                switch (LKGestioneCliente.funzione)
                {
                    case "I":
                        txtPercorso.Text = LKFinFolder.percorsoCartella;
                        break;
                    case "G":
                    case "E":
                        originPath = LKFinFolder.percorsoCartella;
                        txtPercorso.Text = LKFinFolder.percorsoCartella.Remove(LKFinFolder.percorsoCartella.LastIndexOf('\\'));
                        string nomeCompleto = LKFinFolder.percorsoCartella.Remove(0, LKFinFolder.percorsoCartella.LastIndexOf('\\') + 1);
                        txtNome.Text = nomeCompleto;
                        break;
                }
            }
        }
    }
}
