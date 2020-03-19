using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OCL_Proyecto1_201801229
{
    class MetodoSubconjuntos
    {
        List<Estado> transiciones = new List<Estado>();
        List<int> estados = new List<int>();
        public void generarTabla(NodoExpresion raiz)
        {
            cerradura(raiz);
        }
        public void cerradura(NodoExpresion raiz)
        {
            if (raiz.Izquierda != null)
            {
                if (raiz.TransicionIzquierda.ToString() == "Ɛ")
                {
                    
                }
            }
        }
        public void move(Estado nuevo, Object simbolo)
        {

        }
    }
}
