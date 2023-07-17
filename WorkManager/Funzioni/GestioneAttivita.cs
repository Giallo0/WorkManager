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

namespace WorkManager.Funzioni
{
    public partial class GestioneAttivita : Form
    {
        //Solo in modifica e in eliminazione, path di origine
        private string originPath;

        public GestioneAttivita()
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

            LKGestioneAttivita.DecodificaLinkageString(Globale.functionCall.Linkage);

            //Funzione
            if (string.IsNullOrEmpty(LKGestioneAttivita.funzione))
            {
                MessageBox.Show("Funzione in linkage non valorizzata", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                noerrori = false;
                goto ControllaLinkageErr;
            }
            else if (LKGestioneAttivita.funzione != "I" && LKGestioneAttivita.funzione != "G" && LKGestioneAttivita.funzione != "E")
            {
                MessageBox.Show($"Funzione in linkage '{LKGestioneAttivita.funzione}' non valida", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtProgressivo.Text = 0.ToString();
            txtNome.Text = string.Empty;

            //Riempio la combo con gli stati
            cboStato.Items.Clear();
            cboStato.Items.AddRange(ParametriCostanti<StatiAttivita>.getNames());

            //Riempio la combo con le priorita
            cboPriorita.Items.Clear();
            foreach(var p in ParametriCostanti<PrioritaAttivita>.getNames())
            {
                cboPriorita.Items.Add($"{(int)Enum.Parse<PrioritaAttivita>(p)} - {p}");
            }

            //Se sono in eliminazione disabilito il field Nome
            if (LKGestioneAttivita.funzione == "E")
            {
                txtNome.Enabled = false;
            }

            //Se la funzione è inserimento, imposto lo stato in Aperta
            //Se la funzione è inserimento, imposto la priorita in Bassa
            if (LKGestioneAttivita.funzione == "I")
            {
                cboStato.Text = ParametriCostanti<StatiAttivita>.getName(StatiAttivita.Aperta);
                cboPriorita.Text = ParametriCostanti<PrioritaAttivita>.getName(PrioritaAttivita.Bassa);
            }
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            if (controllaDati())
            {
                string folderPath = null;
                string stato = string.Empty;
                string priorita = string.Empty;

                //Il percorso della cartella sarà formato dal progressivo + il nome della cartella
                //Lo stato è valorizzato
                folderPath = $"{txtPercorso.Text}\\{txtProgressivo.Text.PadLeft(3, '0')}_{txtNome.Text}";
                stato = cboStato.Text;
                priorita = cboPriorita.Text;

                if (!string.IsNullOrEmpty(folderPath))
                {
                    JSONwsFolder jwsF;
                    switch (LKGestioneAttivita.funzione)
                    {
                        case "I":
                            Directory.CreateDirectory(folderPath);

                            jwsF = new JSONwsFolder(folderPath);
                            ComponentiwsFolder wsFolder = new ComponentiwsFolder();
                            wsFolder.Tipo = ParametriCostanti<TipiCartella>.getName(TipiCartella.Attivita);
                            wsFolder.DataCreazione = DateTime.Now.ToString("yyyyMMdd");
                            wsFolder.OraCreazione = DateTime.Now.ToString("HHmmss");
                            wsFolder.Stato = stato;
                            wsFolder.Priorita = priorita;
                            jwsF.newFolder(wsFolder);

                            JSONwsFolder jwsFC = new JSONwsFolder(txtPercorso.Text, false);
                            if (!jwsFC.isNull() && jwsFC.getValue(ChiaviwsFolder.Tipo) == ParametriCostanti<TipiCartella>.getName(TipiCartella.Cliente))
                            {
                                jwsFC.setValue(ChiaviwsFolder.CntAtt, txtProgressivo.Text);
                                jwsFC.salva();
                            }

                            MessageBox.Show($"L'attivita '{txtNome.Text}' è stata creata", "Nuova attivita", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtNome.Text = string.Empty;
                            calcolaProgressivo();
                            break;

                        case "G":
                            if (originPath != folderPath)
                            {
                                Directory.Move(originPath, folderPath);
                            }
                            jwsF = new JSONwsFolder(folderPath);
                            jwsF.setValue(ChiaviwsFolder.Priorita, priorita);
                            jwsF.setValue(ChiaviwsFolder.DataModifica, DateTime.Now.ToString("yyyyMMdd"));
                            jwsF.setValue(ChiaviwsFolder.OraModifica, DateTime.Now.ToString("HHmmss"));
                            jwsF.salva();

                            //Il percorso della cartella sarà formato dal progressivo + il nome della cartella
                            MessageBox.Show($"L'attivita '{txtNome.Text}' è stata modificata", "Modifica attivita", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtPercorso.Text = string.Empty;
                            txtNome.Text = string.Empty;
                            txtProgressivo.Text = 0.ToString();
                            cboStato.Text = string.Empty;
                            cboPriorita.Text = string.Empty;
                            
                            break;

                        case "E":
                            //Controllo se all'interno dell'attivita sono presenti dei file non nascosti
                            FileInfo[] files = new DirectoryInfo(originPath).GetFiles();
                            var filtered = files.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden));
                            if (filtered.Count() == 0)
                            {
                                if (MessageBox.Show($"Eliminare l'attivita '{txtNome.Text}'?", "Elimina attivita", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                {
                                    Directory.Delete(originPath, true);

                                    MessageBox.Show($"L'attivita '{txtNome.Text}' è stata eliminata", "Elimina attivita", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtNome.Text = string.Empty;
                                    txtPercorso.Text = string.Empty;
                                    txtProgressivo.Text = 0.ToString();
                                    cboStato.Text = string.Empty;
                                    cboPriorita.Text = string.Empty;
                                }
                            }
                            else
                            {
                                MessageBox.Show($"L'attivita '{txtNome.Text}' non può essere eliminata perché contiene dei file al suo interno", "Elimina attivita", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (LKGestioneAttivita.funzione.CompareTo("I") == 0 || LKGestioneAttivita.funzione.CompareTo("G") == 0)
            {
                if (Directory.Exists($"{txtPercorso.Text}\\{txtNome.Text}"))
                {
                    MessageBox.Show("Attivita già esistente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Focus();
                    noErrori = false;
                    goto controllaDatiErr;
                }
            }
            if (string.IsNullOrEmpty(cboStato.Text))
            {
                MessageBox.Show("Stato non valorizzato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboStato.Focus();
                noErrori = false;
                goto controllaDatiErr;
            }
            if (string.IsNullOrEmpty(cboPriorita.Text))
            {
                MessageBox.Show("Priorità non valorizzata", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboPriorita.Focus();
                noErrori = false;
                goto controllaDatiErr;
            }
        controllaDatiErr:
            return noErrori;
        }

        private void txtPercorso_TextChanged(object sender, EventArgs e)
        {
            switch (LKGestioneAttivita.funzione)
            {
                case "I":
                    calcolaProgressivo();
                    break;
                case "G":
                case "E":
                    recuperaStato();
                    recuperaPriorita();
                    break;
            }
        }

        private void calcolaProgressivo()
        {
            int cntAtt = 0;
            if (!string.IsNullOrEmpty(txtPercorso.Text))
            {
                JSONwsFolder jwsFC = new JSONwsFolder(txtPercorso.Text);
                if (!string.IsNullOrEmpty(jwsFC.getValue(ChiaviwsFolder.CntAtt)))
                {
                    cntAtt = int.Parse(jwsFC.getValue(ChiaviwsFolder.CntAtt));
                }
                else
                {
                    cntAtt = 0;
                }
                cntAtt += 1;
            }
            txtProgressivo.Text = cntAtt.ToString();
        }

        private void recuperaStato()
        {
            string stato = string.Empty;
            if (!string.IsNullOrEmpty(txtPercorso.Text))
            {
                JSONwsFolder jwsFC = new JSONwsFolder(originPath);
                if (!string.IsNullOrEmpty(jwsFC.getValue(ChiaviwsFolder.Stato)))
                {
                    stato = jwsFC.getValue(ChiaviwsFolder.Stato);
                }
            }
            cboStato.Text = stato;
        }

        private void recuperaPriorita()
        {
            string priorita = string.Empty;
            if (!string.IsNullOrEmpty(txtPercorso.Text))
            {
                JSONwsFolder jwsFC = new JSONwsFolder(originPath);
                if (!string.IsNullOrEmpty(jwsFC.getValue(ChiaviwsFolder.Priorita)))
                {
                    priorita = jwsFC.getValue(ChiaviwsFolder.Priorita);
                }
                else
                {
                    priorita = $"{(int)Enum.Parse<PrioritaAttivita>(ParametriCostanti<PrioritaAttivita>.getName(PrioritaAttivita.Bassa))} - {ParametriCostanti<PrioritaAttivita>.getName(PrioritaAttivita.Bassa)}";
                }
            }
            cboPriorita.Text = priorita;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCerca_Click(object sender, EventArgs e)
        {
            //Valorizzazione linkage input
            LKFinFolder.ClearLinkage();
            switch (LKGestioneAttivita.funzione)
            {
                case "I":
                    LKFinFolder.mostraRoot = false;
                    LKFinFolder.TipoCartella = ParametriCostanti<TipiCartella>.getName(TipiCartella.Cliente);
                    break;
                case "G":
                case "E":
                    LKFinFolder.mostraRoot = false;
                    LKFinFolder.TipoCartella = ParametriCostanti<TipiCartella>.getName(TipiCartella.Attivita);
                    break;
            }

            //Chiamata programma
            if (Funzione.Apri("FinFolder", "WorkManager") == DialogResult.OK)
            {
                //Valorizzazione con valori linkage output
                switch (LKGestioneAttivita.funzione)
                {
                    case "I":
                        txtPercorso.Text = LKFinFolder.percorsoCartella;
                        break;
                    case "G":
                    case "E":
                        originPath = LKFinFolder.percorsoCartella;
                        txtPercorso.Text = LKFinFolder.percorsoCartella.Remove(LKFinFolder.percorsoCartella.LastIndexOf('\\'));
                        string nomeCompleto = LKFinFolder.percorsoCartella.Remove(0, LKFinFolder.percorsoCartella.LastIndexOf('\\') + 1);
                        txtProgressivo.Text = int.Parse(nomeCompleto.Substring(0, 3)).ToString();
                        txtNome.Text = nomeCompleto.Substring(4);
                        recuperaStato();
                        recuperaPriorita();
                        break;
                }
            }
        }
    }
}
