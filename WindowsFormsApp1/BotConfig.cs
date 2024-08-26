using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class BotConfig
    {
        public int Ancho { get; set; }
        public int Largo { get; set; }

        public string Direcciones;

        public BotConfig()
        {
            Ancho = 10;
            Largo = 10;
            Direcciones = "izquierda";
        }

    }
}
