using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OCL_Proyecto1_201801229
{
    class NodoExpresion
    {
        private int id;
        private Object transicionDerecha;
        private Object transicionIzquierda;
        private NodoExpresion izquierda;
        private NodoExpresion derecha;

        public NodoExpresion()
        {

        }

        public int Id { get => id; set => id = value; }
        public object TransicionDerecha { get => transicionDerecha; set => transicionDerecha = value; }
        public object TransicionIzquierda { get => transicionIzquierda; set => transicionIzquierda = value; }
        internal NodoExpresion Izquierda { get => izquierda; set => izquierda = value; }
        internal NodoExpresion Derecha { get => derecha; set => derecha = value; }
    }
}
