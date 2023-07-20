using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManager
{
    internal class BonificaCartelle
    {
        private int counter = 0;

        public BonificaCartelle() 
        {
            string paramEsegui = Globale.jwm.getParametro("BONIFICA", "EseguiBonifica").Valore ?? string.Empty;
            if (paramEsegui == "S")
            {
                counter = 0;
                counter = EseguiBonifica();
                MessageBox.Show($"Bonifica terminata. Sono stati bonificati {counter} attività.", "Bonifica cartelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Parametro bonifica dei dati spento. Nessuna bonifica è stata eseguita.", "Bonifica cartelle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int EseguiBonifica()
        {
            //BonificaTipoCartella(Globale.jwm.getValue(ChiaviRoot.Workspace));
            //BonificaStatoPrioritaAttivita(Globale.jwm.getValue(ChiaviRoot.Workspace));
            //BonificaStatoChiuso(Globale.jwm.getValue(ChiaviRoot.Workspace));
            //return BonificaPriorita(Globale.jwm.getValue(ChiaviRoot.Workspace));
            return BonificaStati(Globale.jwm.getValue(ChiaviRoot.Workspace));
        }

        private void BonificaTipoCartella(string padre)
        {
            foreach (string dir in Directory.GetDirectories(padre))
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                if (!di.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    JSONwsFolder jwsF = new JSONwsFolder(dir, false);
                    if (!jwsF.isNull() && jwsF.getValue(ChiaviwsFolder.Tipo) == "Attività")
                    {
                        jwsF.setValue(ChiaviwsFolder.Tipo, ParametriCostanti<TipiCartella>.getName(TipiCartella.Attivita));
                        jwsF.salva();
                    }
                    BonificaTipoCartella(dir);
                }
            }
        }

        private void BonificaStatoPrioritaAttivita(string padre)
        {
            foreach (string dir in Directory.GetDirectories(padre))
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                if (!di.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    JSONwsFolder jwsF = new JSONwsFolder(dir, false);
                    if (!jwsF.isNull() && jwsF.getValue(ChiaviwsFolder.Tipo) == ParametriCostanti<TipiCartella>.getName(TipiCartella.Attivita) &&
                        string.IsNullOrEmpty(jwsF.getValue(ChiaviwsFolder.Stato)))
                    {
                        jwsF.setValue(ChiaviwsFolder.Stato, ParametriCostanti<StatiAttivita>.getName(StatiAttivita.Aperta));
                        jwsF.salva();
                    }
                    if (!jwsF.isNull() && jwsF.getValue(ChiaviwsFolder.Tipo) == ParametriCostanti<TipiCartella>.getName(TipiCartella.Attivita) &&
                        string.IsNullOrEmpty(jwsF.getValue(ChiaviwsFolder.Priorita)))
                    {
                        jwsF.setValue(ChiaviwsFolder.Priorita, ParametriCostanti<PrioritaAttivita>.getName(PrioritaAttivita.Bassa));
                        jwsF.salva();
                    }
                    BonificaStatoPrioritaAttivita(dir);
                }
            }
        }

        private void BonificaStatoChiuso(string padre)
        {
            foreach (string dir in Directory.GetDirectories(padre))
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                if (!di.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    JSONwsFolder jwsF = new JSONwsFolder(dir, false);
                    if (!jwsF.isNull() && jwsF.getValue(ChiaviwsFolder.Tipo) == ParametriCostanti<TipiCartella>.getName(TipiCartella.Attivita) &&
                        jwsF.getValue(ChiaviwsFolder.Stato) == ParametriCostanti<StatiAttivita>.getName(StatiAttivita.Aperta))
                    {
                        jwsF.setValue(ChiaviwsFolder.Stato, ParametriCostanti<StatiAttivita>.getName(StatiAttivita.Chiusa));
                        jwsF.salva();
                    }
                    BonificaStatoChiuso(dir);
                }
            }
        }

        private int BonificaPriorita(string padre)
        {
            foreach (string dir in Directory.GetDirectories(padre))
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                if (!di.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    JSONwsFolder jwsF = new JSONwsFolder(dir, false);
                    
                    if (!jwsF.isNull() && ParametriCostanti<PrioritaAttivita>.getNames().Contains(jwsF.getValue(ChiaviwsFolder.Priorita)))
                    {
                        jwsF.setValue(ChiaviwsFolder.Priorita, ParametriCostanti<PrioritaAttivita>.getNameWithId(
                            (PrioritaAttivita)Enum.Parse(typeof(PrioritaAttivita), jwsF.getValue(ChiaviwsFolder.Priorita))));
                        jwsF.salva();
                        counter++;
                    }else if(!jwsF.isNull() && !ParametriCostanti<PrioritaAttivita>.getNames().Contains(jwsF.getValue(ChiaviwsFolder.Priorita)))
                    {
                        jwsF.setValue(ChiaviwsFolder.Priorita, ParametriCostanti<PrioritaAttivita>.getNameWithId(PrioritaAttivita.Bassa));
                        jwsF.salva();
                        counter++;
                    }
                    BonificaPriorita(dir);
                }
            }
            return counter;
        }

        private int BonificaStati(string padre)
        {
            foreach (string dir in Directory.GetDirectories(padre))
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                if (!di.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    JSONwsFolder jwsF = new JSONwsFolder(dir, false);
                    if (!jwsF.isNull() && jwsF.getValue(ChiaviwsFolder.Tipo) == TipiCartella.Attivita.ToString())
                    {
                        if (ParametriCostanti<StatiAttivita>.getNames().Contains(jwsF.getValue(ChiaviwsFolder.Stato)))
                        {
                            jwsF.setValue(ChiaviwsFolder.Stato, ParametriCostanti<StatiAttivita>.getNameWithId(
                                (StatiAttivita)Enum.Parse(typeof(StatiAttivita), jwsF.getValue(ChiaviwsFolder.Stato))));
                            jwsF.salva();
                            counter++;
                        }
                        else if (!ParametriCostanti<StatiAttivita>.getNames().Contains(jwsF.getValue(ChiaviwsFolder.Stato)))
                        {
                            jwsF.setValue(ChiaviwsFolder.Stato, ParametriCostanti<StatiAttivita>.getNameWithId(StatiAttivita.Aperta));
                            jwsF.salva();
                            counter++;
                        }
                    }
                    BonificaStati(dir);
                }
            }

            return counter;
        }
    }
}
