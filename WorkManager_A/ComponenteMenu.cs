using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManager_A
{
    internal class ComponenteMenu
    {
        public string? ID { get; set; }

        public string? Titolo { get; set; }

        public string? Programma { get; set; }

        public string? Bitmap { get; set; }
    }

    internal class ChiaviMenu
    {
        public const string ID = "ID";
        public const string TITOLO = "Titolo";
        public const string PROGRAMMA = "Programma";
        public const string BITMAP = "Bitmap";
    }
}
