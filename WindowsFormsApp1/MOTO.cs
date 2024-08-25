using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class MOTO
    {

        public int X {  get; set; }
        public int Y { get; set; }

        public MOTO() 
        { 
            X = 0;
            Y = 0;
        }

        public void destruirse()
        {
            X = 10000;
        }
    }

}
