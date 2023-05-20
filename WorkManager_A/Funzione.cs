using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManager_A
{
    internal class Funzione
    {
        public static DialogResult Apri(string funcName, string nameSpace = "WorkManager_A.Funzioni")
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
                    MessageBox.Show($"Nessuna funzione presente con nome '{funcName}'", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
