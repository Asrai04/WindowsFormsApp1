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

        public MOTO(int X2, int Y2) 
        { 
            X = X2;
            Y = Y2;
        }

        public void destruirse()
        {
            X = 100000;
        }
        public void revivir()
        {
            X = 0;
        }
    }

}
