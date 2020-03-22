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
        List<int> cerraduras = new List<int>();
        List<List<int>> mueves = new List<List<int>>();
        List<Estado> temporal = new List<Estado>();
        int j = 0;
        NodoExpresion arbol;
        public MetodoSubconjuntos()
        {

        }
        public void generarTabla(NodoExpresion raiz,int numeros, List<Object> simbolos)
        {

        }
        public void siguientes(NodoExpresion raiz, List<int> numeros, List<Object> simbolos)
        {

        }
        public void cerradura(NodoExpresion inicio)
        {
            estados.Add(inicio.Id);
            if (inicio.Izquierda != null)
            {
                if (inicio.TransicionIzquierda.ToString() == "Ɛ")
                {
                    cerradura(inicio.Izquierda);
                }
            }
            if (inicio.Derecha != null)
            {
                if (inicio.TransicionDerecha.ToString() == "Ɛ")
                {
                    cerradura(inicio.Derecha);
                }
            }
        }
        public void move(NodoExpresion raiz, Object simbolo)
        {

        }
        public NodoExpresion buscarNodo(NodoExpresion raiz, int id)
        {
            NodoExpresion retornar = raiz;
            NodoExpresion devolver = new NodoExpresion();
            if (retornar.Id == id)
            {
                devolver = retornar;
            }
            else
            {
                if (retornar.Izquierda != null)
                {
                    devolver = buscarNodo(retornar.Izquierda, id);
                }
                if (retornar.Derecha != null)
                {
                    devolver = buscarNodo(retornar.Derecha, id);
                }
            }
            return devolver;
        }
    }
}
