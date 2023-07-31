using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Reflection.Metadata;
using WorkManager.Linkage;
using WorkManager.Properties;

namespace WorkManager
{
    public partial class WMmain : Form
    {
        /**
         * Nella finestra principale ci dovranno essere:
         * - la possibilità di accedere alle funzioni
         * - una griglia che elenca tutte le attività aperte in modo da poter accedere più rapidamente
         * - un elenco limitato di funzioni preferite, ovvero quelle utilizzate maggiormente, a scelta dell'utente
         * - un pulsante per la ricerca della funzione
         * - un pulsante per l'elenco totale delle funzioni
         * 
         * 
         * Le funzioni preferite saranno:
         * - nuova attività
         * - cambia stato attività
         * - gestione attività
         * 
         */
        private bool mnuClosePressed = false;
        private string chiusuraForm;


        private DataTable dt = new DataTable();

        public WMmain()
        {
            InitializeComponent();

            //Aggiungo la versione del programma nel titolo della finestra
            this.Text = $"{this.Text} - V{Settings.Default.Versione}";
            PersonalizzaInizializzazione();

            //Popolo la griglia con le attività aperte
            GeneraGrigliaAttivita();
        }

        private void PersonalizzaInizializzazione()
        {
            chiusuraForm = string.IsNullOrEmpty(Globale.jwm.getValue(ChiaviRoot.Chiusura)) ? "F" : Globale.jwm.getValue(ChiaviRoot.Chiusura);

            if (chiusuraForm == "F")
            {
                notifyPrgm.Visible = false;
            }
            else
            {
                notifyPrgm.Visible = true;
            }

            pnlListMenu.Controls.Clear();

            int locationY = 3;

            foreach (ComponentiMenu function in Globale.jwm.getMenuElements())
            {
                Button btn = new Button();

                pnlListMenu.Controls.Add(btn);

                btn.BackColor = SystemColors.Control;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Image = (Image)Resources.ResourceManager.GetObject(function.Bitmap);
                btn.ImageAlign = ContentAlignment.MiddleLeft;
                btn.Location = new Point(4, locationY);
                btn.Name = function.Titolo;
                btn.Size = new Size(218, 39);
                btn.TabIndex = 0;
                btn.Text = function.Titolo;
                btn.Tag = function;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                btn.UseVisualStyleBackColor = false;
                btn.Click += btn_Click;

                locationY += 45;
            }

            ImpostaTimer();
        }

        private void btn_Click(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                timerGridAttivita.Enabled = false;
                Button btn = (Button)sender;
                Globale.functionCall = (ComponentiMenu)btn.Tag;
                Funzione.Apri(((ComponentiMenu)btn.Tag).Programma.ToString());
                timerGridAttivita.Enabled = true;
            }
        }

        private void btnGestioneMenu_Click(object sender, EventArgs e)
        {
            timerGridAttivita.Enabled = false;
            Funzione.Apri(btnGestioneMenu.Tag.ToString(), "WorkManager");
            PersonalizzaInizializzazione();
        }

        private void btnImpostazioni_Click(object sender, EventArgs e)
        {
            timerGridAttivita.Enabled = false;
            Funzione.Apri(btnImpostazioni.Tag.ToString(), "WorkManager");
            PersonalizzaInizializzazione();
        }

        private void btnEsci_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void apriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openProgram();
        }

        private void chiudiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnuClosePressed = true;
            this.Close();
        }

        private void btnBonifica_Click(object sender, EventArgs e)
        {
            Funzione.Apri(btnBonifica.Tag.ToString(), "WorkManager");
        }

        private void notifyPrgm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            openProgram();
        }

        private void WMmain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Se 'B' la chiusura è gestita dall'icona nella barra delle applicazioni
            // Se spazio o 'F' la chiusura è gestita dal form
            if (chiusuraForm == "B" && !mnuClosePressed)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                e.Cancel = true;
            }
        }

        private void openProgram()
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void GeneraGrigliaAttivita()
        {
            gridAttivitaAperte.Rows.Clear();

            dt.Columns.Add("Attivita", typeof(string));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Stato", typeof(string));
            dt.Columns.Add("Priorita", typeof(string));
            dt.Columns.Add("Data", typeof(string));
            dt.Columns.Add("Ora", typeof(string));
            dt.Columns.Add("Progressivo", typeof(string));
            dt.Columns.Add("Percorso", typeof(string));

            AggiornaGrigliaAttivita();
        }

        private void AggiornaGrigliaAttivita()
        {
            dt.Rows.Clear();

            TrovaSottoCartelle(Globale.jwm.getValue(ChiaviRoot.Workspace));
            gridAttivitaAperte.DataSource = dt;

            gridAttivitaAperte.Columns["Attivita"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridAttivitaAperte.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridAttivitaAperte.Columns["Stato"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridAttivitaAperte.Columns["Priorita"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridAttivitaAperte.Columns["Data"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridAttivitaAperte.Columns["Ora"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridAttivitaAperte.Columns["Progressivo"].MinimumWidth = 2;
            gridAttivitaAperte.Columns["Progressivo"].Width = 0;
            gridAttivitaAperte.Columns["Percorso"].MinimumWidth = 2;
            gridAttivitaAperte.Columns["Percorso"].Width = 0;

            foreach (DataGridViewColumn column in gridAttivitaAperte.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            ImpostaFiltro();

            if (gridAttivitaAperte.Rows.Count > 0)
            {
                gridAttivitaAperte.Rows[0].Selected = true;
            }
        }

        private void TrovaSottoCartelle(string padre)
        {
            foreach (string dir in Directory.GetDirectories(padre))
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                if (!di.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    JSONwsFolder jwsF = new JSONwsFolder(dir, false);
                    if (!jwsF.isNull() && jwsF.getValue(ChiaviwsFolder.Tipo) == ParametriCostanti<TipiCartella>.getName(TipiCartella.Attivita) &&
                        jwsF.getValue(ChiaviwsFolder.Stato) != ParametriCostanti<StatiAttivita>.getNameWithId(StatiAttivita.Chiusa) &&
                        jwsF.getValue(ChiaviwsFolder.Stato) != ParametriCostanti<StatiAttivita>.getNameWithId(StatiAttivita.Annullata))
                    {
                        DateTime data = DateTime.ParseExact(jwsF.getValue(ChiaviwsFolder.DataCreazione), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                        DateTime ora = DateTime.ParseExact(jwsF.getValue(ChiaviwsFolder.OraCreazione), "HHmmss", System.Globalization.CultureInfo.InvariantCulture);

                        dt.Rows.Add(new object[] {
                            Path.GetFileName(dir).Substring(4),             //Nome
                            Directory.GetParent(dir).Name,                  //Cliente
                            jwsF.getValue(ChiaviwsFolder.Stato),            //Stato
                            jwsF.getValue(ChiaviwsFolder.Priorita),         //Priorita
                            data.ToString("yyyy/MM/dd"),                    //Data creazione
                            ora.ToString("HH:mm:ss"),                       //Ora creazione
                            Path.GetFileName(dir).Substring(0, 3),          //Progressivo
                            Directory.GetParent(dir)                        //Percorso cliente
                        });
                    }
                    TrovaSottoCartelle(dir);
                }
            }
        }

        private void ImpostaFiltro()
        {
            dt.DefaultView.Sort = null;

            dt.DefaultView.Sort = "Stato, Priorita desc, Data, Ora, Cliente, Progressivo";
        }

        private void btnAggiornaGriglia_Click(object sender, EventArgs e)
        {
            AggiornaGrigliaAttivita();
        }

        private void gridAttivitaAperte_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = gridAttivitaAperte.HitTest(e.X, e.Y).RowIndex;
            if (row > -1)
            {
                LKOperaAttivita.ClearLinkage();
                LKOperaAttivita.cliente = gridAttivitaAperte.CurrentRow.Cells["Cliente"].Value.ToString();
                LKOperaAttivita.percorsoCliente = gridAttivitaAperte.CurrentRow.Cells["Percorso"].Value.ToString();
                LKOperaAttivita.attivita = $"{gridAttivitaAperte.CurrentRow.Cells["Progressivo"].Value.ToString()} - {gridAttivitaAperte.CurrentRow.Cells["Attivita"].Value.ToString()}";
                Funzione.Apri("OperaAttivita");
                LKOperaAttivita.ClearLinkage();
                AggiornaGrigliaAttivita();
            }
        }

        private void ImpostaTimer()
        {
            //Imposto il timer
            string timerAbilitato = Globale.jwm.getParametro("TIMER_MENU", "TimerAttivo").Valore ?? "N";
            if (timerAbilitato == "S")
            {
                //Imposto l'intervallo di aggiornamento
                if (string.IsNullOrEmpty(Globale.jwm.getParametro("TIMER_MENU", "TempoAggiorna").Valore))
                {
                    timerGridAttivita.Interval = 45000; //1 minuto in millisecondi
                }
                else
                {
                    timerGridAttivita.Interval = int.Parse(Globale.jwm.getParametro("TIMER_MENU", "TempoAggiorna").Valore);
                }

                timerGridAttivita.Enabled = true;
            }
            else
            {
                timerGridAttivita.Enabled = false;
            }
        }

        private void timerGridAttivita_Tick(object sender, EventArgs e)
        {
            AggiornaGrigliaAttivita();
        }
    }
}