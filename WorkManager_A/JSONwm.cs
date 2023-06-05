using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WorkManager_A
{
    internal enum ChiaviRoot
    {
        Workspace, CntID, Menu, Parametri, Chiusura
    }

    internal class ComponentiRoot
    {
        public string? Workspace { get; set; }

        public string? CntID { get; set; }

        public string? Chiusura { get; set; }
    }

    internal enum ChiaviMenu
    {
        ID, Titolo, Programma, Bitmap, Linkage
    }

    internal class ComponentiMenu
    {
        public string? ID { get; set; }

        public string? Titolo { get; set; }

        public string? Programma { get; set; }

        public string? Bitmap { get; set; }

        public string? Linkage { get; set; }
    }

    internal enum ChiaviParametri
    {
        Programma, Parametro, Valore, Descrizione
    }

    internal class ComponentiParametri
    {
        public string? Programma { get; set; }

        public string? Parametro { get; set; }

        public string? Valore { get; set; }

        public string? Descrizione { get; set; }
    }

    internal class JSONwm
    {
        private JSONNode? jnode;

        private string pathJSONwm = "Configurazione\\JSONwm.json";

        private string emptyTextJSON = "{ }";

        public JSONwm(string pathMenuJSON)
        {
            this.pathJSONwm = pathMenuJSON;
            newInstance();
        }

        public JSONwm()
        {
            if (Debugger.IsAttached || Path.GetFullPath(pathJSONwm).Contains("Debug"))
            {
                pathJSONwm = @"..\..\..\" + pathJSONwm;
            }
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
        
        public void salva()
        {
            File.WriteAllText(pathJSONwm, jnode.ToString(""));
        }

        //MENU
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
                componente.Linkage = nodo[ChiaviMenu.Linkage.ToString()];
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
            nodo[ChiaviMenu.Linkage.ToString()] = function.Linkage;
            jnode[ChiaviRoot.Menu.ToString()].Add(nodo);

            jnode[ChiaviRoot.CntID.ToString()] = CntID.ToString();
            salva();
        }

        public void addFunctionMenu(ComponentiMenu function, int posizione)
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
            nodo[ChiaviMenu.Linkage.ToString()] = function.Linkage;
            jnode[ChiaviRoot.Menu.ToString()].Add(nodo);

            jnode[ChiaviRoot.CntID.ToString()] = CntID.ToString();


            int posAttuale = jnode[ChiaviRoot.Menu.ToString()].Count - 1;
            while(posAttuale != posizione)
            {
                invertiOrdineMenu(posAttuale, posAttuale - 1);
                posAttuale -= 1;
            }

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
                    nodo[ChiaviMenu.Linkage.ToString()] = function.Linkage;
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

        public void invertiOrdineMenu(int posizioneElem, int posizioneTarget)
        {
            string appoggio = jnode[ChiaviRoot.Menu.ToString()][posizioneTarget].ToString();
            jnode[ChiaviRoot.Menu.ToString()][posizioneTarget] = jnode[ChiaviRoot.Menu.ToString()][posizioneElem];
            jnode[ChiaviRoot.Menu.ToString()][posizioneElem] = JSONNode.Parse(appoggio);
            salva();
        }

        //PARAMETRI
        public ComponentiParametri getParametro(string programma, string parametro)
        {
            ComponentiParametri componente = new ComponentiParametri();
            foreach (JSONNode nodo in jnode[ChiaviRoot.Parametri.ToString()].Childs)
            {
                string prog = nodo[ChiaviParametri.Programma.ToString()];
                string param = nodo[ChiaviParametri.Parametro.ToString()];
                if (prog == programma && param == parametro)
                {
                    componente.Programma = nodo[ChiaviParametri.Programma.ToString()];
                    componente.Parametro = nodo[ChiaviParametri.Parametro.ToString()];
                    componente.Valore = nodo[ChiaviParametri.Valore.ToString()];
                    componente.Descrizione = nodo[ChiaviParametri.Descrizione.ToString()];
                    break;
                }
            }
            return componente;
        }

        public List<ComponentiParametri> getParametriElements(string programma)
        {
            List<ComponentiParametri> elementi = new List<ComponentiParametri>();
            foreach (JSONNode nodo in jnode[ChiaviRoot.Parametri.ToString()].Childs)
            {
                string p = nodo[ChiaviParametri.Programma.ToString()];
                if (p == programma)
                {
                    ComponentiParametri componente = new ComponentiParametri();
                    componente.Programma = nodo[ChiaviParametri.Programma.ToString()];
                    componente.Parametro = nodo[ChiaviParametri.Parametro.ToString()];
                    componente.Valore = nodo[ChiaviParametri.Valore.ToString()];
                    componente.Descrizione = nodo[ChiaviParametri.Descrizione.ToString()];
                    elementi.Add(componente);
                }
            }
            return elementi;
        }

        public void addParametri(ComponentiParametri function)
        {
            JSONNode nodo = JSONNode.Parse("{ }");
            nodo[ChiaviParametri.Programma.ToString()] = function.Programma;
            nodo[ChiaviParametri.Parametro.ToString()] = function.Parametro;
            nodo[ChiaviParametri.Valore.ToString()] = function.Valore;
            nodo[ChiaviParametri.Descrizione.ToString()] = function.Descrizione;
            jnode[ChiaviRoot.Parametri.ToString()].Add(nodo);

            salva();
        }

        public void editParametri(string oldParametro, ComponentiParametri function)
        {
            foreach (JSONNode nodo in jnode[ChiaviRoot.Parametri.ToString()].Childs)
            {
                if ((nodo[ChiaviParametri.Programma.ToString()].Value == function.Programma) &&
                    (nodo[ChiaviParametri.Parametro.ToString()].Value == oldParametro))
                {
                    nodo[ChiaviParametri.Parametro.ToString()] = function.Parametro;
                    nodo[ChiaviParametri.Valore.ToString()] = function.Valore;
                    nodo[ChiaviParametri.Descrizione.ToString()] = function.Descrizione;
                    break;
                }
            }
            salva();
        }

        public void removeParametri(ComponentiParametri function)
        {
            for (int cnt = 0; cnt < jnode[ChiaviRoot.Parametri.ToString()].Count; cnt++)
            {
                if ((jnode[ChiaviRoot.Parametri.ToString()][cnt][ChiaviParametri.Programma.ToString()].Value == function.Programma) &&
                    (jnode[ChiaviRoot.Parametri.ToString()][cnt][ChiaviParametri.Parametro.ToString()].Value == function.Parametro))
                {
                    jnode[ChiaviRoot.Parametri.ToString()].Remove(cnt);
                    break;
                }
            }
            salva();
        }
    }
}
