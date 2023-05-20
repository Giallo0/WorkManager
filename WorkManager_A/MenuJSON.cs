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
    internal class MenuJSON
    {
        private JSONNode? jnode;
        private string pathMenuJSON = "Configurazioni\\menuJSON.json";

        public MenuJSON(string pathMenuJSON)
        {
            this.pathMenuJSON = pathMenuJSON;
            newInstance();
        }

        public MenuJSON()
        {
            newInstance();
        }

        private void newInstance()
        {
            if (!File.Exists(pathMenuJSON))
            {
                Directory.CreateDirectory(pathMenuJSON.Remove(pathMenuJSON.LastIndexOf('\\')));
                File.Create(pathMenuJSON).Close();
                File.WriteAllText(pathMenuJSON, JSONNode.Parse("{ \"CntID\" : \"0\", \"Menu\" : [ ] }").ToString(""));
            }
            jnode = JSONNode.Parse(File.ReadAllText(pathMenuJSON));
        }

        public List<ComponenteMenu> getElements()
        {
            List<ComponenteMenu> elementi = new List<ComponenteMenu> ();
            if (jnode != null)
            {
                foreach (JSONNode nodo in jnode["Menu"].Childs)
                {
                    ComponenteMenu componente = new ComponenteMenu();
                    componente.ID = nodo[ChiaviMenu.ID];
                    componente.Titolo = nodo[ChiaviMenu.TITOLO];
                    componente.Programma = nodo[ChiaviMenu.PROGRAMMA];
                    componente.Bitmap = nodo[ChiaviMenu.BITMAP];
                    elementi.Add(componente);
                }
            }

            return elementi;
        }

        public void add(ComponenteMenu function)
        {
            int CntID = int.Parse(jnode["CntID"].Value);
            CntID += 1;

            JSONNode nodo = JSONNode.Parse("{ }");
            nodo[ChiaviMenu.ID] = CntID.ToString();
            nodo[ChiaviMenu.TITOLO] = function.Titolo;
            nodo[ChiaviMenu.PROGRAMMA] = function.Programma;
            nodo[ChiaviMenu.BITMAP] = function.Bitmap;
            jnode["Menu"].Add(nodo);

            jnode["CntID"] = CntID.ToString();
            salva();
        }

        public void edit(string ID, ComponenteMenu function)
        {
            if (jnode != null)
            {
                foreach (JSONNode nodo in jnode["Menu"].Childs)
                {
                    if (nodo[ChiaviMenu.ID].Value == ID)
                    {
                        nodo[ChiaviMenu.TITOLO] = function.Titolo;
                        nodo[ChiaviMenu.PROGRAMMA] = function.Programma;
                        nodo[ChiaviMenu.BITMAP] = function.Bitmap;
                        break;
                    }
                }
                salva();
            }
        }

        public void remove(ComponenteMenu function)
        {
            if (jnode != null)
            {
                for(int cnt = 0; cnt < jnode["Menu"].Count; cnt++)
                {
                    if (jnode["Menu"][cnt][ChiaviMenu.ID].Value == function.ID)
                    {
                        jnode["Menu"].Remove(cnt);
                        break;
                    }
                }
                salva();
            }
        }

        private void salva()
        {
            File.WriteAllText(pathMenuJSON, jnode.ToString(""));
        }
    }
}
