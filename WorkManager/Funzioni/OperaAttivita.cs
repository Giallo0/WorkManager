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
using WorkManager.Properties;

namespace WorkManager.Funzioni
{
    public partial class OperaAttivita : Form
    {
        private int parteAbilitata;
        private string percorsoCliente;

        private bool linkageValorizzata;

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

            if (!string.IsNullOrEmpty(LKOperaAttivita.cliente) && !string.IsNullOrEmpty(LKOperaAttivita.attivita))
            {
                txtCliente.Text = LKOperaAttivita.cliente;
                percorsoCliente = LKOperaAttivita.percorsoCliente;
                
                TrovaAttivita(percorsoCliente);
                cboAttivita.Text = LKOperaAttivita.attivita;
                btnConferma_Click(null, null);

                linkageValorizzata = true;
            }
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
                        (jwsF.getValue(ChiaviwsFolder.Stato) == ParametriCostanti<StatiAttivita>.getName(StatiAttivita.Aperta)))
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
                    //Carico la griglia
                    TrovaElementi($"{percorsoCliente}\\{cboAttivita.Text.Substring(0, 3)}_{cboAttivita.Text.Substring(6)}");

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
                        "Cartella",
                        dir
                    });
                }
                TrovaElementi(dir);
            }
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            if (parteAbilitata == 1)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
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

        private Label lblNomeCartella;
        private TextBox txtNomeCartella;
        private Button btnConfermaAddCartella;
        private Button btnAnnullaAddCartella;

        private void btnAddCartella_Click(object sender, EventArgs e)
        {
            Form addCartellaForm = new Form();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperaAttivita));
            lblNomeCartella = new Label();
            txtNomeCartella = new TextBox();
            btnConfermaAddCartella = new Button();
            btnAnnullaAddCartella = new Button();
            addCartellaForm.SuspendLayout();
            // 
            // lblNomeCartella
            // 
            lblNomeCartella.AutoSize = true;
            lblNomeCartella.Location = new Point(10, 10);
            lblNomeCartella.Name = "lblNomeCartella";
            lblNomeCartella.Size = new Size(58, 17);
            lblNomeCartella.TabIndex = 0;
            lblNomeCartella.Text = "Nome:";
            // 
            // txtNomeCartella
            // 
            txtNomeCartella.Location = new Point(70, 8);
            txtNomeCartella.Name = "txtNomeCartella";
            txtNomeCartella.Size = new Size(125, 23);
            txtNomeCartella.TabIndex = 1;
            // 
            // btnAnnulla
            // 
            btnAnnullaAddCartella.Location = new Point(10, 40);
            btnAnnullaAddCartella.Name = "btnAnnullaAddCartella";
            btnAnnullaAddCartella.Size = new Size(85, 24);
            btnAnnullaAddCartella.TabIndex = 3;
            btnAnnullaAddCartella.Text = "Annulla";
            btnAnnullaAddCartella.UseVisualStyleBackColor = true;
            btnAnnullaAddCartella.Click += btnAnnullaAddCartella_Click;
            // 
            // btnConfermaAddCartella
            // 
            btnConfermaAddCartella.Location = new Point(101, 400000000);
            btnConfermaAddCartella.Name = "btnConfermaAddCartella";
            btnConfermaAddCartella.Size = new Size(85, 24);
            btnConfermaAddCartella.TabIndex = 2;
            btnConfermaAddCartella.Text = "Conferma";
            btnConfermaAddCartella.UseVisualStyleBackColor = true;
            btnConfermaAddCartella.Click += btnConfermaAddCartella_Click;

            addCartellaForm.Controls.Add(lblNomeCartella);
            addCartellaForm.Controls.Add(txtNomeCartella);
            addCartellaForm.Controls.Add(btnAnnullaAddCartella);
            addCartellaForm.Controls.Add(btnConfermaAddCartella);
            addCartellaForm.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            addCartellaForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            addCartellaForm.Icon = (Icon)resources.GetObject("$this.Icon");
            addCartellaForm.MaximizeBox = false;
            addCartellaForm.Name = "addCartellaForm";
            addCartellaForm.StartPosition = FormStartPosition.CenterScreen;
            addCartellaForm.Text = "Aggiungi cartella";
            addCartellaForm.ResumeLayout(false);
            addCartellaForm.ShowDialog();
        }

        private void btnAnnullaAddCartella_Click(object sender, EventArgs e)
        {

        }

        private void btnConfermaAddCartella_Click(object sender, EventArgs e)
        {

        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {

        }

        private void btnRinomina_Click(object sender, EventArgs e)
        {

        }

        private void btnRimuovi_Click(object sender, EventArgs e)
        {

        }

        private void btnCambiaStato_Click(object sender, EventArgs e)
        {

        }
    }
}
