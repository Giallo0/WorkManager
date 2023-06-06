using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManager
{
    internal class Funzione
    {
        public static DialogResult Apri(string funcName, string nameSpace = "WorkManager.Funzioni")
        {
            DialogResult result = DialogResult.None;
            try
            {
                Type? type = Type.GetType($"{nameSpace}.{funcName}");
                if (type != null) 
                {
                    var instanza = Activator.CreateInstance(type) as Form;
                    if (instanza != null)
                    {
                        result = instanza.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show($"Nessun programma impostato per la funzione '{Globale.functionCall.Titolo}'", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
    }
}
