using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    internal class LinkList
    {
        private NODO HEAD;
        private int SIZE;

        public LinkList()
        {
            this.HEAD = null;
            this.SIZE = 0;
        }

        public bool EstaVacia()
        {
            return this.HEAD == null;
        }

        public int size()
        {
            return this.SIZE;
        }

        public void insertarDato(MOTO data)
        {
            NODO newNode = new NODO(data);
            newNode.establecerNext(this.HEAD);
            this.HEAD = newNode;
            this.SIZE++;
        }

        public void borrarDato()
        {
            if (this.HEAD == null)
            {
                ;
            }
            else
            {
                this.HEAD = this.HEAD.getNext();
            }
        }
        public NODO displayList()
        {
            NODO current = this.HEAD;
            while (current != null)
            {
                return this.HEAD;
                current = current.getNext();
            }
            return current;
        }

    }
}
