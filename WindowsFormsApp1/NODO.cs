using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    internal class NODO
    {
        private MOTO DATA;
        private NODO next;

        public NODO(MOTO DATAS)
        {
            this.next = null;
            this.DATA = DATAS;
        }

        public MOTO optenerData()
        {
            return DATA;
        }

        public void setData(MOTO data2)
        {
            this.DATA = data2;
        }

        public NODO getNext()
        {
            return this.next;
        }

        public void establecerNext(NODO nod)
        {
            this.next = nod;
        }

    }
}
