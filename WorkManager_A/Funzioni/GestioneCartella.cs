using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkManager_A.Linkage;

namespace WorkManager_A.Funzioni
{
    public partial class GestioneCartella : Form
    {
        private bool noerrori = true;

        //Solo in modifica
        private string oldPath;

        public GestioneCartella()
        {
            ControllaLinkage();
            if (noerrori)
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

        private void ControllaLinkage()
        {
            noerrori = true;

            LKGestioneCartella.DecodificaLinkageString(Globale.functionCall.Linkage);

            //Funzione
            switch (LKGestioneCartella.funzione)
            {
                case "I":
                case "G":
                case "E":
                    break;
                case " ":
                    MessageBox.Show("Funzione in linkage non valorizzata", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    noerrori = false;
                    break;
                default:
                    MessageBox.Show($"Funzione in linkage '{LKGestioneCartella.funzione}' non valida", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    noerrori = false;
                    break;
            }
        }

        private void PersonalizzaInizializzazione()
        {
            //Titolo programma
            this.Text = Globale.functionCall.Titolo;

            //Inizializzo i field della screen
            txtPercorso.Text = string.Empty;
            txtProgressivo.Text = 0.ToString();
            txtNome.Text = string.Empty;

            //Riempio la combo con i tipi cartella
            cboTipoCartella.Items.Clear();
            string[] tipiCartella = Globale.jwm.getParametro("GestioneCartella", "TipoCartella").Valore.ToString().Split(';') ?? new string[0];
            cboTipoCartella.Items.AddRange(tipiCartella);
            cboTipoCartella.Items.Remove("ND");

            if (LKGestioneCartella.funzione == "G")
            {
                oldPath = string.Empty;
            }
            else if (LKGestioneCartella.funzione == "E")
            {
                oldPath = string.Empty;
                txtNome.Enabled = false;
            }

            //Se la funzione è abilitata a gestire un solo tipo cartella, lo blocco
            if (LKGestioneCartella.TipoCartella != "ND")
            {
                cboTipoCartella.Text = LKGestioneCartella.TipoCartella;
                cboTipoCartella.Enabled = false;
            }
            else
            {
                cboTipoCartella.SelectedIndex = 0;
            }
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            if (controllaDati())
            {
                string folderPath;
                if (cboTipoCartella.Text == "Attività")
                {
                    folderPath = $"{txtPercorso.Text}\\{txtProgressivo.Text.PadLeft(3, '0')}_{txtNome.Text}";
                }
                else
                {
                    folderPath = $"{txtPercorso.Text}\\{txtNome.Text}";
                }
                JSONwsFolder jwsF;

                switch (LKGestioneCartella.funzione)
                {
                    case "I":
                        Directory.CreateDirectory(folderPath);

                        jwsF = new JSONwsFolder(folderPath);
                        ComponentiwsFolder wsFolder = new ComponentiwsFolder();
                        wsFolder.Tipo = cboTipoCartella.Text;
                        wsFolder.DataCreazione = DateTime.Now.ToString("yyyyMMdd");
                        wsFolder.OraCreazione = DateTime.Now.ToString("HHmmss");
                        jwsF.newFolder(wsFolder);

                        JSONwsFolder jwsFC = new JSONwsFolder(txtPercorso.Text);
                        jwsFC.setValue(ChiaviwsFolder.CntAtt.ToString(), txtProgressivo.Text);
                        jwsFC.salva();

                        MessageBox.Show($"La cartella {txtNome.Text} è stata creata", "Nuova cartella", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNome.Text = string.Empty;
                        calcolaProgressivo();
                        break;
                    case "G":
                        Directory.Move(oldPath, folderPath);

                        jwsF = new JSONwsFolder(folderPath);
                        jwsF.setValue(ChiaviwsFolder.DataModifica.ToString(), DateTime.Now.ToString("yyyyMMdd"));
                        jwsF.setValue(ChiaviwsFolder.OraModifica.ToString(), DateTime.Now.ToString("HHmmss"));
                        jwsF.salva();

                        MessageBox.Show($"La cartella '{oldPath.Remove(0, oldPath.LastIndexOf("\\") + 1).Substring(4)}' è stata rinominata in '{txtNome.Text}'", "Modifica cartella", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPercorso.Text = string.Empty;
                        txtNome.Text = string.Empty;
                        txtProgressivo.Text = "0";
                        break;
                    case "E":
                        DirectoryInfo directoryInfo = new DirectoryInfo(oldPath);
                        FileInfo[] files = directoryInfo.GetFiles();
                        var filtered = files.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden));
                        if (filtered.Count() == 0)
                        {
                            if (MessageBox.Show($"Eliminare la cartella '{txtNome.Text}'?", "Elimina cartella", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                Directory.Delete(oldPath, true);
                                MessageBox.Show($"La cartella {txtNome.Text} è stata eliminata", "Elimina cartella", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtNome.Text = string.Empty;
                                txtPercorso.Text = string.Empty;
                                txtProgressivo.Text = "0";
                            }
                        }
                        else
                        {
                            MessageBox.Show($"La cartella {txtNome.Text} non può essere eliminata perché contiene dei file al suo interno", "Elimina cartella", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
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
            if (LKGestioneCartella.funzione.CompareTo("I") == 0 || LKGestioneCartella.funzione.CompareTo("G") == 0)
            {
                if (Directory.Exists($"{txtPercorso.Text}\\{txtNome.Text}"))
                {
                    MessageBox.Show("Cartella già esistente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Focus();
                    noErrori = false;
                    goto controllaDatiErr;
                }
            }
            if (string.IsNullOrEmpty(cboTipoCartella.Text))
            {
                MessageBox.Show("Tipo cartella non valorizzato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboTipoCartella.Focus();
                noErrori = false;
                goto controllaDatiErr;
            }
        controllaDatiErr:
            return noErrori;
        }

        private void cboTipoCartella_TextChanged(object sender, EventArgs e)
        {
            txtPercorso.Text = string.Empty;
            //Se il tipo cartella che verrà generato è Cliente, non mostro il progressivo
            if (cboTipoCartella.Text == "Cliente")
            {
                lblProgressivo.Visible = false;
                txtProgressivo.Visible = false;
            }
            else
            {
                lblProgressivo.Visible = true;
                txtProgressivo.Visible = true;

                calcolaProgressivo();
            }
        }

        private void txtPercorso_TextChanged(object sender, EventArgs e)
        {
            switch (LKGestioneCartella.funzione)
            {
                case "I":
                    calcolaProgressivo();
                    break;
                case "G":
                case "E":
                    break;
            }
        }

        private void calcolaProgressivo()
        {
            int cntAtt = 0;
            if (!string.IsNullOrEmpty(txtPercorso.Text) && cboTipoCartella.Text == "Attività")
            {
                JSONwsFolder jwsFC = new JSONwsFolder(txtPercorso.Text);
                if (!string.IsNullOrEmpty(jwsFC.getValue(ChiaviwsFolder.CntAtt.ToString())))
                {
                    cntAtt = int.Parse(jwsFC.getValue(ChiaviwsFolder.CntAtt.ToString()));
                }
                else
                {
                    cntAtt = 0;
                }
                cntAtt += 1;
            }
            txtProgressivo.Text = cntAtt.ToString();
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCerca_Click(object sender, EventArgs e)
        {
            //Valorizzazione linkage input
            LKFinFolder.ClearLinkage();
            switch (LKGestioneCartella.funzione)
            {
                case "I":
                    if (cboTipoCartella.Text == "Cliente")
                    {
                        LKFinFolder.mostraRoot = true;
                        LKFinFolder.limitaTipoCartella = "Root";
                    }
                    else if (cboTipoCartella.Text == "Attività")
                    {
                        LKFinFolder.mostraRoot = false;
                        LKFinFolder.limitaTipoCartella = "Cliente";
                    }
                    break;
                case "G":
                case "E":
                    LKFinFolder.mostraRoot = false;
                    LKFinFolder.limitaTipoCartella = cboTipoCartella.Text;
                    break;
            }

            //Chiamata programma
            if (Funzione.Apri("FinFolder", "WorkManager_A") == DialogResult.OK)
            {
                //Valorizzazione con valori linkage output
                switch (LKGestioneCartella.funzione)
                {
                    case "I":
                        txtPercorso.Text = LKFinFolder.percorsoCartella;
                        break;
                    case "G":
                    case "E":
                        oldPath = LKFinFolder.percorsoCartella;
                        txtPercorso.Text = LKFinFolder.percorsoCartella.Remove(LKFinFolder.percorsoCartella.LastIndexOf('\\'));
                        string nomeCompleto = LKFinFolder.percorsoCartella.Remove(0, LKFinFolder.percorsoCartella.LastIndexOf('\\') + 1);
                        if (cboTipoCartella.Text == "Cliente")
                        {
                            txtProgressivo.Text = "0";
                            txtNome.Text = nomeCompleto;
                        }
                        else
                        {
                            txtProgressivo.Text = int.Parse(nomeCompleto.Substring(0, 3)).ToString();
                            txtNome.Text = nomeCompleto.Substring(4);
                        }
                        break;
                }
            }
        }
    }
}
