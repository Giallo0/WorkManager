using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManager
{
    internal enum ChiaviwsFolder
    {
        Tipo, DataCreazione, OraCreazione, DataModifica, OraModifica, CntAtt, Stato, Priorita
    }

    internal class ComponentiwsFolder
    {
        public string? Tipo { get; set; }

        public string? DataCreazione { get; set; }

        public string? OraCreazione { get; set; }

        public string? DataModifica { get; set; }

        public string? OraModifica { get; set;}

        public string? CntAtt { get; set; }

        public string? Stato { get; set; }

        public string? Priorita { get; set; }
    }

    internal class JSONwsFolder
    {
        private JSONNode? jnode;
        private string path;
        private string emptyTextJSON = "{ }";

        public JSONwsFolder(string folderPath)
        {
            path = folderPath + "\\wsFolder.json";
            newInstance();
        }

        public JSONwsFolder(string folderPath, bool createJSON) 
        {
            path = folderPath + "\\wsFolder.json";
            if (createJSON) newInstance(); else newInstanceOpen();
        }

        private void newInstance()
        {
            if (!File.Exists(path) || string.IsNullOrEmpty(File.ReadAllText(path)))
            {
                File.Create(path).Close();

                JSONNode emptyJSON = JSONNode.Parse(emptyTextJSON);
                foreach (var comp in Enum.GetValues(typeof(ChiaviwsFolder)))
                {
                    string key = comp.ToString();
                    emptyJSON.Add(key, string.Empty);
                }
                File.WriteAllText(path, emptyJSON.ToString(""));
                File.SetAttributes(path, FileAttributes.Hidden);
            }
            jnode = JSONNode.Parse(File.ReadAllText(path));
        }

        private void newInstanceOpen()
        {
            if (File.Exists(path) && !string.IsNullOrEmpty(File.ReadAllText(path)))
            {
                jnode = JSONNode.Parse(File.ReadAllText(path));
            }
            else
            {
                jnode = null;
            }
        }

        public string getValue(ChiaviwsFolder key)
        {
            return jnode[key.ToString()].Value;
        }

        public void setValue(ChiaviwsFolder key, string value)
        {
            jnode[key.ToString()] = value;
        }

        public void salva()
        {
            File.SetAttributes(path, FileAttributes.Normal);
            File.WriteAllText(path, jnode.ToString(""));
            File.SetAttributes(path, FileAttributes.Hidden);
        }

        public bool isNull()
        {
            return jnode == null ? true : false;
        }

        public void newFolder(ComponentiwsFolder fold)
        {
            setValue(ChiaviwsFolder.Tipo, fold.Tipo);
            setValue(ChiaviwsFolder.DataCreazione, fold.DataCreazione);
            setValue(ChiaviwsFolder.OraCreazione, fold.OraCreazione);
            setValue(ChiaviwsFolder.Stato, fold.Stato);
            setValue(ChiaviwsFolder.Priorita, fold.Priorita);
            salva();
        }
    }
}
