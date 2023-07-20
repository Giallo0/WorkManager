using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkManager.Linkage;

namespace WorkManager.Funzioni
{
    public partial class ConsultaConfigurazioniCartelle : Form
    {
        private int parteAbilitata;
        private string percorsoCliente;
        private JSONwsFolder jwsF;

        private DataTable dt = new DataTable();

        public ConsultaConfigurazioniCartelle()
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

            txtCliente.Text = string.Empty;

            gridConfig.Rows.Clear();

            dt.Columns.Add("Attività", typeof(string));
            foreach (string col in Enum.GetNames(typeof(ChiaviwsFolder)))
            {
                if (col != ChiaviwsFolder.CntAtt.ToString())
                {
                    dt.Columns.Add(col, typeof(string));
                }
            }

            parteAbilitata = 1;
            abilitaDisabilita();
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
            }
        }

        private void abilitaDisabilita()
        {
            switch (parteAbilitata)
            {
                case 1:
                    jwsF = null;
                    pnlPrimaParte.Enabled = true;
                    pnlSecondaParte.Enabled = false;
                    break;
                case 2:
                    pnlPrimaParte.Enabled = false;
                    pnlSecondaParte.Enabled = true;
                    break;
            }
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            if (parteAbilitata == 1)
            {
                if (controllaDati())
                {
                    dt.Rows.Clear();
                    TrovaSottoCartelle(percorsoCliente);
                    gridConfig.DataSource = dt;

                    foreach (DataGridViewColumn col in gridConfig.Columns)
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }

                    if (gridConfig.Rows.Count > 0)
                    {
                        gridConfig.Rows[0].Selected = true;
                    }

                    ImpostaFiltro();

                    parteAbilitata = 2;
                    abilitaDisabilita();
                }
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
                    if (!jwsF.isNull())
                    {
                        object[] riga = new object[Enum.GetNames(typeof(ChiaviwsFolder)).Length];
                        riga[0] = Path.GetFileName(dir);                          //Attività

                        int cnt = 0;
                        foreach (ChiaviwsFolder key in Enum.GetValues(typeof(ChiaviwsFolder)))
                        {
                            if (key != ChiaviwsFolder.CntAtt)
                            {
                                cnt++;
                                if (!string.IsNullOrEmpty(jwsF.getValue(ChiaviwsFolder.DataCreazione)) && key == ChiaviwsFolder.DataCreazione)
                                {
                                    DateTime dataCrezione = DateTime.ParseExact(jwsF.getValue(ChiaviwsFolder.DataCreazione), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                                    riga[cnt] = dataCrezione.ToString("yyyy/MM/dd");
                                }
                                else if (!string.IsNullOrEmpty(jwsF.getValue(ChiaviwsFolder.OraCreazione)) && key == ChiaviwsFolder.OraCreazione)
                                {
                                    DateTime oraCreazione = DateTime.ParseExact(jwsF.getValue(ChiaviwsFolder.OraCreazione), "HHmmss", System.Globalization.CultureInfo.InvariantCulture);
                                    riga[cnt] = oraCreazione.ToString("HH:mm:ss");
                                }
                                else if (!string.IsNullOrEmpty(jwsF.getValue(ChiaviwsFolder.DataModifica)) && key == ChiaviwsFolder.DataModifica)
                                {
                                    DateTime dataModifica = DateTime.ParseExact(jwsF.getValue(ChiaviwsFolder.DataModifica), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                                    riga[cnt] = dataModifica.ToString("yyyy/MM/dd");
                                }
                                else if (!string.IsNullOrEmpty(jwsF.getValue(ChiaviwsFolder.OraModifica)) && key == ChiaviwsFolder.OraModifica)
                                {
                                    DateTime oraModifica = DateTime.ParseExact(jwsF.getValue(ChiaviwsFolder.OraModifica), "HHmmss", System.Globalization.CultureInfo.InvariantCulture);
                                    riga[cnt] = oraModifica.ToString("HH:mm:ss");
                                }
                                else
                                {
                                    riga[cnt] = jwsF.getValue(key) ?? string.Empty;
                                }
                            }
                        }
                        dt.Rows.Add(riga);
                    }
                    TrovaSottoCartelle(dir);
                }
            }
        }

        private void ImpostaFiltro()
        {
            dt.DefaultView.Sort = null;

            dt.DefaultView.Sort = $"{ChiaviwsFolder.Stato.ToString()} desc, {ChiaviwsFolder.Priorita.ToString()} desc, {ChiaviwsFolder.DataCreazione.ToString()}, {ChiaviwsFolder.OraCreazione.ToString()}";
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

        controllaDatiErr:
            return noerrori;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            if (parteAbilitata == 1)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                dt.Rows.Clear();
                parteAbilitata = 1;
                abilitaDisabilita();
            }
        }
    }
}
