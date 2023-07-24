using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkManager.CustomDialogBox.Linkage;
using WorkManager.Linkage;
using WorkManager.Properties;

namespace WorkManager.Funzioni
{
    public partial class OperaAttivita : Form
    {
        private int parteAbilitata;
        private string percorsoCliente;

        private bool linkageValorizzata;
        private int gridIndex;
        private string percorsoAttivita;

        public OperaAttivita()
        {
            InitializeComponent();
            PersonalizzaInizializzazione();
        }

        private void PersonalizzaInizializzazione()
        {
            //Titolo programma
            if (Globale.functionCall != null)
            {
                this.Text = Globale.functionCall.Titolo;
            }

            linkageValorizzata = false;

            parteAbilitata = 1;
            abilitaDisabilita();

            txtCliente.Text = string.Empty;
            cboAttivita.Items.Clear();
            cboAttivita.Enabled = false;

            if (!string.IsNullOrEmpty(LKOperaAttivita.cliente) &&
                !string.IsNullOrEmpty(LKOperaAttivita.percorsoCliente) &&
                !string.IsNullOrEmpty(LKOperaAttivita.attivita))
            {
                txtCliente.Text = LKOperaAttivita.cliente;
                percorsoCliente = LKOperaAttivita.percorsoCliente;

                TrovaAttivita(percorsoCliente);
                cboAttivita.Text = LKOperaAttivita.attivita;
                btnConferma_Click(null, null);

                linkageValorizzata = true;
            }

            gridIndex = 0;

            ImpostaTimer();
        }

        private void abilitaDisabilita()
        {
            switch (parteAbilitata)
            {
                case 1:
                    pnlPrimaParte.Enabled = true;
                    btnConferma.Enabled = true;
                    pnlSecondaParte.Enabled = false;
                    pnlSecondaParte.Visible = false;

                    gridContenuto.Rows.Clear();
                    break;
                case 2:
                    pnlPrimaParte.Enabled = false;
                    btnConferma.Enabled = false;
                    pnlSecondaParte.Enabled = true;
                    pnlSecondaParte.Visible = true;
                    break;
            }
        }

        private void btnCercaCliente_Click(object sender, EventArgs e)
        {
            //Valorizzazione linkage input
            LKFinFolder.ClearLinkage();
            LKFinFolder.mostraRoot = false;
            LKFinFolder.TipoCartella = ParametriCostanti<TipiCartella>.getName(TipiCartella.Cliente);

            //Chiamata programma
            if (Funzione.Apri("FinFolder", "WorkManager") == DialogResult.OK)
            {
                percorsoCliente = LKFinFolder.percorsoCartella;
                txtCliente.Text = LKFinFolder.nomeCartella;

                //Recupero le attività aperte per il cliente selezionato
                cboAttivita.Items.Clear();
                if (string.IsNullOrEmpty(txtCliente.Text))
                {
                    cboAttivita.Enabled = false;
                }
                else
                {
                    cboAttivita.Enabled = true;
                    TrovaAttivita(percorsoCliente);
                }
            }
        }

        private void TrovaAttivita(string cliente)
        {
            foreach (string dir in Directory.GetDirectories(cliente))
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                if (!di.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    JSONwsFolder jwsF = new JSONwsFolder(dir, false);
                    if (!jwsF.isNull() &&
                        (jwsF.getValue(ChiaviwsFolder.Tipo) == ParametriCostanti<TipiCartella>.getName(TipiCartella.Attivita)) &&
                        (jwsF.getValue(ChiaviwsFolder.Stato) == ParametriCostanti<StatiAttivita>.getNameWithId(StatiAttivita.Aperta)))
                    {
                        cboAttivita.Items.Add($"{Path.GetFileName(dir).Substring(0, 3)} - {Path.GetFileName(dir).Substring(4)}");
                    }
                }
            }
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            if (parteAbilitata == 1)
            {
                if (controllaDati())
                {
                    percorsoAttivita = $"{percorsoCliente}\\{cboAttivita.Text.Substring(0, 3)}_{cboAttivita.Text.Substring(6)}";
                    //Carico la griglia
                    TrovaElementi(percorsoAttivita);
                    if (gridContenuto.Rows.Count > 0) 
                    {
                        gridContenuto.Rows[gridIndex].Selected = true;
                    }

                    parteAbilitata = 2;
                    abilitaDisabilita();
                }
            }
        }

        private bool controllaDati()
        {
            bool noerrori = true;

            if (string.IsNullOrEmpty(txtCliente.Text))
            {
                MessageBox.Show("Nessun cliente selezionato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                noerrori = false;
                goto controllaDatiErr;
            }

            if (string.IsNullOrEmpty(cboAttivita.Text))
            {
                MessageBox.Show("Nessuna attività selezionata", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                noerrori = false;
                goto controllaDatiErr;
            }

        controllaDatiErr:
            return noerrori;
        }

        private void TrovaElementi(string cartella)
        {
            foreach (string file in Directory.GetFiles(cartella))
            {
                FileInfo fi = new FileInfo(file);
                if (!fi.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    gridContenuto.Rows.Add(new object[]
                    {
                        Path.GetFileName(file).Substring(0, Path.GetFileName(file).LastIndexOf('.')),
                        Path.GetExtension(file).Substring(1),
                        "File",
                        file
                    });
                }
            }

            foreach (string dir in Directory.GetDirectories(cartella))
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                if (!di.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    gridContenuto.Rows.Add(new object[]
                    {
                        Path.GetFileName(dir),
                        " ",
                        "Cartella",
                        dir
                    });
                }
                TrovaElementi(dir);
            }
        }

        private void AggiornaGriglia()
        {
            gridContenuto.Rows.Clear();
            TrovaElementi(percorsoAttivita);

            if (gridContenuto.Rows.Count >= gridIndex)
            {
                gridContenuto.Rows[gridIndex].Selected = true;
            }
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            if (parteAbilitata == 1)
            {
                timerAttivita.Stop();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                timerAttivita.Stop();
                if (linkageValorizzata)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    parteAbilitata = 1;
                    abilitaDisabilita();
                }
            }
        }

        private void btnApriAttivita_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", percorsoAttivita);
        }

        private void btnAddCartella_Click(object sender, EventArgs e)
        {
            LKGestioneCartellaAttivita.funzione = "I";
            LKGestioneCartellaAttivita.percorso = percorsoAttivita;
            Funzione.Apri("GestioneCartellaAttivita", "WorkManager.CustomDialogBox");

            AggiornaGriglia();
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            LKGestioneFileAttivita.funzione = "I";
            LKGestioneFileAttivita.percorso = percorsoAttivita;
            Funzione.Apri("GestioneFileAttivita", "WorkManager.CustomDialogBox");

            AggiornaGriglia();
        }

        private void btnChiudiAttivita_Click(object sender, EventArgs e)
        {
            LK_CambiaStatoAttivita.ClearLinkage();
            LK_CambiaStatoAttivita.percorsoCliente = percorsoCliente;
            LK_CambiaStatoAttivita.attivita = $"{cboAttivita.Text.Substring(0, 3)}_{cboAttivita.Text.Substring(6)}";
            LK_CambiaStatoAttivita.stato = ParametriCostanti<StatiAttivita>.getNameWithId(StatiAttivita.Chiusa);
            Funzione.Apri("_CambiaStatoAttivita");

            if (!LK_CambiaStatoAttivita.erroriElab)
            {
                if (linkageValorizzata)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    parteAbilitata = 1;
                    abilitaDisabilita();

                    AggiornaGriglia();
                }
            }
            LK_CambiaStatoAttivita.ClearLinkage();
        }

        private void gridContenuto_MouseClick(object sender, MouseEventArgs e)
        {
            int col = gridContenuto.HitTest(e.X, e.Y).ColumnIndex;
            int row = gridContenuto.HitTest(e.X, e.Y).RowIndex;
            if (col >= 0 && row >= 0)
            {
                if (gridContenuto.CurrentRow != null)
                {
                    gridIndex = gridContenuto.CurrentRow.Index;
                }

                if (e.Button == MouseButtons.Right)
                {
                    gridContenuto[col, row].Selected = true;
                    if (!gridContenuto.CurrentRow.IsNewRow)
                    {
                        mnuGridContenuto.Show(gridContenuto, e.Location);
                    }
                }
            }
        }

        private void gridContenuto_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = gridContenuto.HitTest(e.X, e.Y).RowIndex;
            if (row > -1)
            {
                btnApri_Click(null, null);
            }
        }

        private void btnApri_Click(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.Arguments = gridContenuto[3, gridContenuto.CurrentRow.Index].Value.ToString();

            if (gridContenuto[2, gridContenuto.CurrentRow.Index].Value.ToString() == "File" &&
                gridContenuto[1, gridContenuto.CurrentRow.Index].Value.ToString() == ParametriCostanti<EstensioniFile>.getName(EstensioniFile.txt))
            {
                proc.StartInfo.FileName = "C:\\Program Files\\Notepad++\\notepad++.exe";
            }
            else
            {
                proc.StartInfo.FileName = "explorer.exe";
            }

            proc.Start();
        }

        private void btnRinomina_Click(object sender, EventArgs e)
        {
            if (gridContenuto[2, gridContenuto.CurrentRow.Index].Value.ToString() == "File")
            {
                LKGestioneFileAttivita.funzione = "M";
                LKGestioneFileAttivita.percorso = gridContenuto[3, gridContenuto.CurrentRow.Index].Value.ToString();
                Funzione.Apri("GestioneFileAttivita", "WorkManager.CustomDialogBox");

                AggiornaGriglia();
            }
            else if (gridContenuto[2, gridContenuto.CurrentRow.Index].Value.ToString() == "Cartella")
            {
                LKGestioneCartellaAttivita.funzione = "M";
                LKGestioneCartellaAttivita.percorso = gridContenuto[3, gridContenuto.CurrentRow.Index].Value.ToString();
                Funzione.Apri("GestioneCartellaAttivita", "WorkManager.CustomDialogBox");

                AggiornaGriglia();
            }
        }

        private void btnCancella_Click(object sender, EventArgs e)
        {
            if (gridContenuto[2, gridContenuto.CurrentRow.Index].Value.ToString() == "File")
            {
                LKGestioneFileAttivita.funzione = "C";
                LKGestioneFileAttivita.percorso = gridContenuto[3, gridContenuto.CurrentRow.Index].Value.ToString();
                Funzione.Apri("GestioneFileAttivita", "WorkManager.CustomDialogBox");

                AggiornaGriglia();
            }
            else if (gridContenuto[2, gridContenuto.CurrentRow.Index].Value.ToString() == "Cartella")
            {
                LKGestioneCartellaAttivita.funzione = "C";
                LKGestioneCartellaAttivita.percorso = gridContenuto[3, gridContenuto.CurrentRow.Index].Value.ToString();
                Funzione.Apri("GestioneCartellaAttivita", "WorkManager.CustomDialogBox");

                AggiornaGriglia();
            }
        }

        private void ImpostaTimer()
        {
            //Imposto il timer
            string timerAbilitato = Globale.jwm.getParametro("TIMER_ATTIVITA", "TimerAttivo").Valore ?? "N";
            if (timerAbilitato == "S")
            {
                //Imposto l'intervallo di aggiornamento
                if (string.IsNullOrEmpty(Globale.jwm.getParametro("TIMER_ATTIVITA", "TempoAggiorna").Valore))
                {
                    timerAttivita.Interval = 45000; //1 minuto in millisecondi
                }
                else
                {
                    timerAttivita.Interval = int.Parse(Globale.jwm.getParametro("TIMER_ATTIVITA", "TempoAggiorna").Valore);
                }

                timerAttivita.Enabled = true;
            }
            else
            {
                timerAttivita.Enabled = false;
            }
        }

        private void timerAttivita_Tick(object sender, EventArgs e)
        {
            AggiornaGriglia();
        }
    }
}
