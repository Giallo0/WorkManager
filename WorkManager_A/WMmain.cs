using WorkManager_A.Properties;

namespace WorkManager_A
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

        public WMmain()
        {
            InitializeComponent();
            PersonalizzaInizializzazione();
        }

        private void PersonalizzaInizializzazione()
        {
            chiusuraForm = string.IsNullOrEmpty(Globale.jwm.getValue(ChiaviRoot.Chiusura.ToString())) ? "F" : Globale.jwm.getValue(ChiaviRoot.Chiusura.ToString());

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
        }

        private void btn_Click(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                Button btn = (Button)sender;
                Globale.functionCall = (ComponentiMenu)btn.Tag;
                Funzione.Apri(((ComponentiMenu)btn.Tag).Programma.ToString());
            }
        }

        private void btnGestioneMenu_Click(object sender, EventArgs e)
        {
            Funzione.Apri(btnGestioneMenu.Tag.ToString(), "WorkManager_A");
            PersonalizzaInizializzazione();
        }

        private void btnImpostazioni_Click(object sender, EventArgs e)
        {
            Funzione.Apri(btnImpostazioni.Tag.ToString(), "WorkManager_A");
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
    }
}