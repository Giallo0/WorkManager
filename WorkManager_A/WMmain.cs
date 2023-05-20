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

        private JSONwm jMenu = new JSONwm();

        public WMmain()
        {
            InitializeComponent();
            PersonalizzaInizializzazione();
        }

        private void PersonalizzaInizializzazione()
        {
            pnlListMenu.Controls.Clear();

            int locationY = 0;

            foreach (ComponentiMenu function in jMenu.getMenuElements())
            {
                Button btn = new Button();

                pnlListMenu.Controls.Add(btn);

                btn.BackColor = SystemColors.Control;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Image = (Image)Resources.ResourceManager.GetObject(function.Bitmap);
                btn.ImageAlign = ContentAlignment.MiddleLeft;
                btn.Location = new Point(0, locationY);
                btn.Name = function.Titolo;
                btn.Size = new Size(192, 60);
                btn.TabIndex = 0;
                btn.Text = function.Titolo;
                btn.Tag = function.Programma;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                btn.UseVisualStyleBackColor = false;
                btn.Click += btn_Click;

                locationY += 60;
            }
        }

        private void btn_Click(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                Button btn = (Button)sender;
                Funzione.Apri(btn.Tag.ToString());
            }
        }

        private void btnGestioneMenu_Click(object sender, EventArgs e)
        {
            Funzione.Apri(btnGestioneMenu.Tag.ToString(), "WorkManager_A");
        }

        private void btnRicaricaMenu_Click(object sender, EventArgs e)
        {
            jMenu = new JSONwm();
            PersonalizzaInizializzazione();
        }
    }
}