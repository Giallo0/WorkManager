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

        public static string[] getNames()
        {
            return Enum.GetNames(typeof(T));
        }
    }

    internal enum TipiCartella
    {
        Root, Cliente, Attivita
    }

    internal enum StatiAttivita
    {
        Aperta, Chiusa
    }

    internal enum PrioritaAttivita
    {
        Bassa = 0, Media, Alta
    }
}
