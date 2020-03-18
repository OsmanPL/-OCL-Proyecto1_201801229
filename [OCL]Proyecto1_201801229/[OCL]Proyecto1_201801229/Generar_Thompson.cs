using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OCL_Proyecto1_201801229
{
    class Generar_Thompson
    {

        NodoExpresion raiz = new NodoExpresion();

        List<Object> nodos = new List<object>();
        int j = 0;
        int k = 0;
        NodoExpresion ultimo = new NodoExpresion();
        String grafica = "";
        public Generar_Thompson()
        {

        }

        public void separarNodos(List<Expresion> listaExpresiones)
        {
            for (int h = 0; h < listaExpresiones.Count; h++)
            {
                String expresion = listaExpresiones.ElementAt(h).ExpresionRegular;
                String nombreGrafica = listaExpresiones.ElementAt(h).Identificador;
                int estado = 0;
                string lexema = "";
                Char c;
                grafica += "digraph "+ nombreGrafica+" { \n";
                grafica += "rankdir = \u0022LR\u0022; \n";
                grafica += "node [shape = circle, height=.1]; \n";
                expresion = expresion + " ";
                for (int i = 0; i < expresion.Length; i++)
                {
                    c = expresion[i];
                    switch (estado)
                    {
                        case 0:
                            if (c == '|')
                            {
                                nodos.Add(c);
                            }
                            else if (c == '.')
                            {
                                nodos.Add(c);
                            }
                            else if (c == '+')
                            {
                                nodos.Add(c);
                            }
                            else if (c == '*')
                            {
                                nodos.Add(c);
                            }
                            else if (c == '?')
                            {
                                nodos.Add(c);
                            }
                            else if (c == '{')
                            {
                                estado = 1;
                            }
                            else if (c == '\u0022')
                            {
                                lexema += c;
                                estado = 2;
                            }
                            break;
                        case 1:
                            if (c == '}')
                            {
                                nodos.Add(lexema);
                                lexema = "";
                                estado = 0;
                            }
                            else
                            {
                                lexema += c;
                            }
                            break;
                        case 2:
                            if (c == '\u0022')
                            {
                                lexema += c;
                                nodos.Add(lexema);
                                lexema = "";
                                estado = 0;
                            }
                            else
                            {
                                lexema += c;
                            }
                            break;
                    }
                }
                j = 0;
                Object nodo = nodos.ElementAt(j);
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, 0,nuevo);
                raiz = nuevo;
                grafica += "}";
                Graficador gr = new Graficador();
                gr.graficar(grafica, nombreGrafica);

                nodos = new List<object>();
                j = 0;
                k = 0;
                grafica = "";
            }
        }

        public void generarAFN(Object nodo, int n, NodoExpresion nodoexp)
        {

            if (nodo.ToString() == "|")
            {
                grafica += "node" + n + "; \n";
                k = n;
                ultimo = nodoexp;
                generarOr(n, nodoexp);
            }
            else if (nodo.ToString() == ".")
            {
                k = n;
                ultimo = nodoexp;
                generarConcatenacion(n);
            }
            else if (nodo.ToString() == "+")
            {
                grafica += "node" + n + "; \n";
                k = n;
                ultimo = nodoexp;
                generarCerrduraPositiva(n);
            }
            else if (nodo.ToString() == "*")
            {
                grafica += "node" + n + "; \n";
                k = n;
                ultimo = nodoexp;
                generarCerraduaKleene(n);
            }
            else if (nodo.ToString() == "?")
            {
                grafica += "node" + n + "; \n";
                k = n;
                ultimo = nodoexp;
                generarInterrogacion(n);
            }
        }
        public void generarOr(int n, NodoExpresion nodoexp)
        { 
            //Lado Izquierdo
            j++;

            int m = n + 1;
            int l = m + 1;
            Object nodo = nodos.ElementAt(j);

            NodoExpresion nuevo = new NodoExpresion();
            NodoExpresion nuevo2 = new NodoExpresion();
            if (nodo.ToString() == "|")
            {
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
                nuevo.Id = m;
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;
            }
            else if (nodo.ToString() == ".")
            {
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
                nuevo.Id = m;
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;
            }
            else if (nodo.ToString() == "+")
            {
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
                nuevo.Id = m;
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;
            }
            else if (nodo.ToString() == "*")
            {
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
                nuevo.Id = m;
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;
            }
            else if (nodo.ToString() == "?")
            {
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
                nuevo.Id = m;
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;
            }
            else
            {
                grafica += "node" + m + "; \n";
                nuevo.Id = m;
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022;\n]";
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;
                grafica += "node" + l + "; \n";
                nuevo2.Id = l;
                grafica += "node" + m + " -> node" + l + " [label=\u0022 "+nodo.ToString()+"\u0022];\n";
                nuevo.TransicionIzquierda = nodo.ToString();
                nuevo.Izquierda = nuevo2;
                k = l;
                ultimo = nuevo2;
            }
            l = k;
            NodoExpresion izuierdo = ultimo;
            //Lado Derecho
            int d = k + 1;
            int r = d + 1;
            j++;
            nodo = nodos.ElementAt(j);

            NodoExpresion nuevo3 = new NodoExpresion();

            NodoExpresion nuevo4 = new NodoExpresion();
            if (nodo.ToString() == "|")
            {
                
                
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + d + " [label=\u0022Ɛ\u0022];\n";
                nuevo3.Id = d;
                nodoexp.TransicionDerecha = "Ɛ";
                nodoexp.Derecha = nuevo3;

            }
            else if (nodo.ToString() == ".")
            {


                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + d + " [label=\u0022Ɛ\u0022];\n";
                nuevo3.Id = d;
                nodoexp.TransicionDerecha = "Ɛ";
                nodoexp.Derecha = nuevo3;

            }
            else if (nodo.ToString() == "+")
            {


                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + d + " [label=\u0022Ɛ\u0022];\n";
                nuevo3.Id = d;
                nodoexp.TransicionDerecha = "Ɛ";
                nodoexp.Derecha = nuevo3;

            }
            else if (nodo.ToString() == "*")
            {
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + d + " [label=\u0022Ɛ\u0022];\n";
                nuevo3.Id = d;
                nodoexp.TransicionDerecha = "Ɛ";
                nodoexp.Derecha = nuevo3;

            }
            else if (nodo.ToString() == "?")
            {
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + d + " [label=\u0022Ɛ\u0022];\n";
                nuevo3.Id = d;
                nodoexp.TransicionDerecha = "Ɛ";
                nodoexp.Derecha = nuevo3;

            }
            else
            {
                grafica += "node" + d + "; \n";
                nuevo3.Id = d;
                grafica += "node" + n + " -> node" + d + " [label=\u0022Ɛ\u0022];\n";
                nodoexp.TransicionDerecha = "Ɛ";
                nodoexp.Derecha = nuevo3;
                grafica += "node" + r + "; \n";
                nuevo4.Id = r;
                grafica += "node" + d + " -> node" + r + " [label=\u0022 " + nodo.ToString() + "\u0022];\n";
                nuevo3.TransicionIzquierda = nodo.ToString();
                nuevo3.Izquierda = nuevo4;
                k = r;
                ultimo = nuevo4;

            }
            r = k;
            NodoExpresion derecha = ultimo;
            int u = k + 1;
            NodoExpresion nodo5 = new NodoExpresion();
            grafica += "node" + u + "; \n";
            nodo5.Id = u;
            grafica += "node" + l + " -> node" + u + " [label=\u0022Ɛ\u0022];\n";
            izuierdo.TransicionIzquierda = "Ɛ";
            izuierdo.Izquierda = nodo5;
            grafica += "node" + r + " -> node" + u + " [label=\u0022Ɛ\u0022];\n";
            derecha.TransicionDerecha = "Ɛ";
            derecha.Derecha = nodo5;
            k = u;
            ultimo = nodo5;
        }

        public void generarConcatenacion(int n)
        {
            //Lado Izquierdo
            j++;
            int m = n;
            int l = m + 1;
            Object nodo = nodos.ElementAt(j);

            if (nodo.ToString() == "|")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
            }
            else if (nodo.ToString() == ".")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
            }
            else if (nodo.ToString() == "+")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
            }
            else if (nodo.ToString() == "*")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
            }
            else if (nodo.ToString() == "?")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
            }
            else
            {
                m = k;
                l = k + 1;
                grafica += "node" + m + "; \n";
                grafica += "node" + l + "; \n";
                grafica += "node" + m + " -> node" + l + " [label=\u0022 " + nodo.ToString() + "\u0022];\n";
                k = l;
            }


            //Lado Derecho
            j++;
            int d = k;
            int r = d + 1;
            nodo = nodos.ElementAt(j);

            if (nodo.ToString() == "|")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
            }
            else if (nodo.ToString() == ".")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
            }
            else if (nodo.ToString() == "+")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
            }
            else if (nodo.ToString() == "*")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
            }
            else if (nodo.ToString() == "?")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
            }
            else
            {
                d = k;
                r = k + 1;
                grafica += "node" + r + "; \n";
                grafica += "node" + d + " -> node" + r + " [label=\u0022 " + nodo.ToString() + "\u0022];\n";
                k = r;
            }
        }
        public void generarInterrogacion(int n)
        {
            //Lado Izquierdo
            j++;

            int m = n + 1;
            int l = m + 1;
            Object nodo = nodos.ElementAt(j);

            if (nodo.ToString() == "|")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == ".")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "+")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "*")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "?")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else
            {
                grafica += "node" + m + "; \n";
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022;\n]";
                grafica += "node" + l + "; \n";
                grafica += "node" + m + " -> node" + l + " [label=\u0022 " + nodo.ToString() + "\u0022];\n";
                k = l;
            }
            l = k;
            //Lado Derecho
            int d = k + 1;
            int r = d + 1;

            grafica += "node" + d + "; \n";
            grafica += "node" + n + " -> node" + d + " [label=\u0022Ɛ\u0022];\n";
            grafica += "node" + r + "; \n";
            grafica += "node" + d + " -> node" + r + " [label=\u0022Ɛ\u0022];\n";
            k = r;

            int u = k + 1;
            grafica += "node" + u + "; \n";
            grafica += "node" + l + " -> node" + u + " [label=\u0022Ɛ\u0022];\n";
            grafica += "node" + r + " -> node" + u + " [label=\u0022Ɛ\u0022];\n";
            k = u;
        }

        public void generarCerraduaKleene(int n)
        {
            j++;
            int m = k + 1;
            int l = m + 1;
            Object nodo = nodos.ElementAt(j);

            if (nodo.ToString() == "|")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == ".")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "+")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "*")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "?")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else
            {
                grafica += "node" + m + "; \n";
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022;\n]";
                grafica += "node" + l + "; \n";
                grafica += "node" + m + " -> node" + l + " [label=\u0022 " + nodo.ToString() + "\u0022];\n";
                k = l;
            }
            l = k;
            int p = k + 1;
            grafica += "node" + l + " -> node" + m + " [label=\u0022Ɛ\u0022;\n]";
            grafica += "node" + p + "; \n";
            grafica += "node" + l + " -> node" + p + " [label=\u0022Ɛ\u0022;\n]";
            grafica += "node" + n + " -> node" + p + " [label=\u0022Ɛ\u0022;\n]";
            k = p;
        }
        public void generarCerrduraPositiva(int n)
        {
            
            j++;
            int t = j;
            int m = k + 1;
            Object nodo = nodos.ElementAt(j);

            if (nodo.ToString() == "|")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == ".")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "+")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "*")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "?")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else
            {
                grafica += "node" + n + " -> node" + m + " [label=\u0022 " + nodo.ToString() + "\u0022];\n";
                k = m;
            }
            m = k;
            int l = k + 1;
            int r = l + 1;
            j = t;
            if (nodo.ToString() == "|")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, l, nuevo);
                grafica += "node" + m + " -> node" + l + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == ".")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, l, nuevo);
                grafica += "node" + m + " -> node" + l + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "+")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, l, nuevo);
                grafica += "node" + m + " -> node" + l + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "*")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, l, nuevo);
                grafica += "node" + m + " -> node" + l + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "?")
            {
                NodoExpresion nuevo = new NodoExpresion();
                nuevo.Id = j;
                
                generarAFN(nodo, l, nuevo);
                grafica += "node" + m + " -> node" + l + " [label=\u0022Ɛ\u0022];\n";
            }
            else
            {
                grafica += "node" + l + "; \n";
                grafica += "node" + m + " -> node" + l + " [label=\u0022Ɛ\u0022;\n]";
                grafica += "node" + r + "; \n";
                grafica += "node" + l + " -> node" + r + " [label=\u0022 " + nodo.ToString() + "\u0022];\n";
                k = r;
            }
            r = k;
            int p = k + 1;
            grafica += "node" + r + " -> node" + l + " [label=\u0022Ɛ\u0022;\n]";
            grafica += "node" + p + "; \n";
            grafica += "node" + r + " -> node" + p + " [label=\u0022Ɛ\u0022;\n]";
            grafica += "node" + m + " -> node" + p + " [label=\u0022Ɛ\u0022;\n]";
            k = p;
        }

        public void escribirArchivoDot()
        {

        }
    }

}
