using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Configuracion
    {
        public static int Ancho {  get; set; }
        public static int Largo { get; set; }

        public static string Direcciones;

        public Configuracion() 
        { 
            Ancho = 10;
            Largo = 10;
            Direcciones = "left";
        }

    }
}
