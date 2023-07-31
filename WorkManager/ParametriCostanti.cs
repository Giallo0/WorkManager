using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManager
{
    internal class ParametriCostanti<T> where T : Enum
    {
        public static string getName(T val)
        {
            return val.ToString();
        }

        public static string getNameWithId(T val)
        {
            return $"{(int)Enum.Parse(typeof(T), val.ToString())} - {val.ToString()}";
        }

        public static string[] getNames()
        {
            return Enum.GetNames(typeof(T));
        }

        public static string[] getNamesWithId()
        {
            string[] names = new string[ParametriCostanti<T>.getNames().Length];

            int cnt = -1;
            foreach (var p in ParametriCostanti<T>.getNames())
            {
                cnt++;
                names[cnt] = $"{(int)Enum.Parse(typeof(T), p)} - {p}";
            }

            return names;
        }
    }

    internal enum TipiCartella
    {
        Root, Cliente, Attivita
    }

    internal enum StatiAttivita
    {
        Aperta = 1, Da_Rilasciare, Annullata = 9, Chiusa = 0
    }

    internal enum PrioritaAttivita
    {
        Bassa = 0, Media, Alta
    }

    internal enum EstensioniFile
    {
        txt, docx, sql
    }
}
