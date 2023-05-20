using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManager_A
{
    internal enum ChiaviwsFolder
    {
        Tipo, DataCreazione, OraCreazione
    }

    internal class ComponentiwsFolder
    {
        public string? Tipo { get; set; }
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

        public string getValue(string key)
        {
            return jnode[key].Value;
        }

        public void setValue(string key, string value)
        {
            jnode[key] = value;
        }

        public void salva()
        {
            File.SetAttributes(path, FileAttributes.Normal);
            File.WriteAllText(path, jnode.ToString(""));
            File.SetAttributes(path, FileAttributes.Hidden);
        }
    }
}
