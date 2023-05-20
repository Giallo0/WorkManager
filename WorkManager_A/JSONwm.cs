using SimpleJSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WorkManager_A
{
    internal enum ChiaviRoot
    {
        Workspace, CntID, Menu
    }

    internal class ComponentiRoot
    {
        public string? Workspace { get; set; }

        public string? CntID { get; set; }
    }

    internal enum ChiaviMenu
    {
        ID, Titolo, Programma, Bitmap
    }

    internal class ComponentiMenu
    {
        public string? ID { get; set; }

        public string? Titolo { get; set; }

        public string? Programma { get; set; }

        public string? Bitmap { get; set; }
    }

    internal class JSONwm
    {
        private JSONNode? jnode;
        private string pathJSONwm = "Configurazioni\\JSONwm.json";

        private string emptyTextJSON = "{ }";

        public JSONwm(string pathMenuJSON)
        {
            this.pathJSONwm = pathMenuJSON;
            newInstance();
        }

        public JSONwm()
        {
            newInstance();
        }

        private void newInstance()
        {
            if (!File.Exists(pathJSONwm) || string.IsNullOrEmpty(File.ReadAllText(pathJSONwm)))
            {
                Directory.CreateDirectory(pathJSONwm.Remove(pathJSONwm.LastIndexOf('\\')));
                File.Create(pathJSONwm).Close();
                
                JSONNode emptyJSON = JSONNode.Parse(emptyTextJSON);
                foreach(var comp in Enum.GetValues(typeof(ChiaviRoot))) 
                {
                    string key = comp.ToString();
                    emptyJSON.Add(key, string.Empty);
                }
                File.WriteAllText(pathJSONwm, emptyJSON.ToString(""));
            }
            jnode = JSONNode.Parse(File.ReadAllText(pathJSONwm));
        }

        public string getValue(string key)
        {
            return jnode[key].Value;
        }

        public void setValue(string key, string value) 
        {
            jnode[key] = value;
        }

        public List<ComponentiMenu> getMenuElements()
        {
            List<ComponentiMenu> elementi = new List<ComponentiMenu> ();
            foreach (JSONNode nodo in jnode[ChiaviRoot.Menu.ToString()].Childs)
            {
                ComponentiMenu componente = new ComponentiMenu();
                componente.ID = nodo[ChiaviMenu.ID.ToString()];
                componente.Titolo = nodo[ChiaviMenu.Titolo.ToString()];
                componente.Programma = nodo[ChiaviMenu.Programma.ToString()];
                componente.Bitmap = nodo[ChiaviMenu.Bitmap.ToString()];
                elementi.Add(componente);
            }

            return elementi;
        }

        public void addFunctionMenu(ComponentiMenu function)
        {
            int CntID = 0;
            if (!string.IsNullOrEmpty(jnode[ChiaviRoot.CntID.ToString()].Value))
            {
                CntID = int.Parse(jnode[ChiaviRoot.CntID.ToString()].Value);
            }
            
            CntID += 1;

            JSONNode nodo = JSONNode.Parse("{ }");
            nodo[ChiaviMenu.ID.ToString()] = CntID.ToString();
            nodo[ChiaviMenu.Titolo.ToString()] = function.Titolo;
            nodo[ChiaviMenu.Programma.ToString()] = function.Programma;
            nodo[ChiaviMenu.Bitmap.ToString()] = function.Bitmap;
            jnode[ChiaviRoot.Menu.ToString()].Add(nodo);

            jnode[ChiaviRoot.CntID.ToString()] = CntID.ToString();
            salva();
        }

        public void editFunctionMenu(string ID, ComponentiMenu function)
        {
            foreach (JSONNode nodo in jnode[ChiaviRoot.Menu.ToString()].Childs)
            {
                if (nodo[ChiaviMenu.ID.ToString()].Value == ID)
                {
                    nodo[ChiaviMenu.Titolo.ToString()] = function.Titolo;
                    nodo[ChiaviMenu.Programma.ToString()] = function.Programma;
                    nodo[ChiaviMenu.Bitmap.ToString()] = function.Bitmap;
                    break;
                }
            }
            salva();
        }

        public void removeFunctionMenu(ComponentiMenu function)
        {
            for (int cnt = 0; cnt < jnode[ChiaviRoot.Menu.ToString()].Count; cnt++)
            {
                if (jnode[ChiaviRoot.Menu.ToString()][cnt][ChiaviMenu.ID.ToString()].Value == function.ID)
                {
                    jnode[ChiaviRoot.Menu.ToString()].Remove(cnt);
                    break;
                }
            }
            salva();
        }

        public void salva()
        {
            File.WriteAllText(pathJSONwm, jnode.ToString(""));
        }
    }
}
