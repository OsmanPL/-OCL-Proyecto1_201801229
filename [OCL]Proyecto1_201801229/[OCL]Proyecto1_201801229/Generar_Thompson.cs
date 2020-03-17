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
                generarAFN(nodos.ElementAt(j), 0);
                grafica += "}";
                Graficador gr = new Graficador();
                gr.graficar(grafica, nombreGrafica);

                nodos = new List<object>();
                j = 0;
                k = 0;
                grafica = "";
            }
        }

        public void generarAFN(Object nodo, int n)
        {

            if (nodo.ToString() == "|")
            {
                grafica += "node" + n + "; \n";
                k = n;
                generarOr(n);
            }
            else if (nodo.ToString() == ".")
            {
                k = n;
                generarConcatenacion(n);
            }
            else if (nodo.ToString() == "+")
            {
                grafica += "node" + n + "; \n";
                k = n;
                generarCerrduraPositiva(n);
            }
            else if (nodo.ToString() == "*")
            {
                grafica += "node" + n + "; \n";
                k = n;
                generarCerraduaKleene(n);
            }
            else if (nodo.ToString() == "?")
            {
                grafica += "node" + n + "; \n";
                k = n;
                generarInterrogacion(n);
            }
        }
        public void generarOr(int n)
        { 
            //Lado Izquierdo
            j++;

            int m = n + 1;
            int l = m + 1;
            Object nodo = nodos.ElementAt(j);
            
            if (nodo.ToString() == "|")
            {
                generarAFN(nodo, m);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == ".")
            {
                generarAFN(nodo, m);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "+")
            {
                generarAFN(nodo, m);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "*")
            {
                generarAFN(nodo, m);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "?")
            {
                generarAFN(nodo, m);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else
            {
                grafica += "node" + m + "; \n";
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022;\n]";
                grafica += "node" + l + "; \n";
                grafica += "node" + m + " -> node" + l + " [label=\u0022 "+nodo.ToString()+"\u0022];\n";
                k = l;
            }
            l = k;
            //Lado Derecho
            int d = k + 1;
            int r = d + 1;
            j++;
            nodo = nodos.ElementAt(j);

            if (nodo.ToString() == "|")
            {
                generarAFN(nodo, d);
                grafica += "node" + n + " -> node" + d + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == ".")
            {
                generarAFN(nodo, d);
                grafica += "node" + n + " -> node" + d + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "+")
            {
                generarAFN(nodo, d);
                grafica += "node" + n + " -> node" + d + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "*")
            {
                generarAFN(nodo, d);
                grafica += "node" + n + " -> node" + d + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "?")
            {
                generarAFN(nodo, d);
                grafica += "node" + n + " -> node" + d + " [label=\u0022Ɛ\u0022];\n";
            }
            else
            {
                grafica += "node" + d + "; \n";
                grafica += "node" + n + " -> node" + d + " [label=\u0022Ɛ\u0022];\n";
                grafica += "node" + r + "; \n";
                grafica += "node" + d + " -> node" + r + " [label=\u0022 " + nodo.ToString() + "\u0022];\n";
                k = r;
            }
            r = k;
            int u = k + 1;
            grafica += "node" + u + "; \n";
            grafica += "node" + l + " -> node" + u + " [label=\u0022Ɛ\u0022];\n";
            grafica += "node" + r + " -> node" + u + " [label=\u0022Ɛ\u0022];\n";
            k = u;
        }

        public void generarConcatenacion(int n)
        {
            //Lado Izquierdo
            j++;
            int m = n;
            int l = m + 1;
            Object nodo = nodos.ElementAt(j);
            Object transicion = new Object();

            if (nodo.ToString() == "|")
            {
                generarAFN(nodo, m);
            }
            else if (nodo.ToString() == ".")
            {
                generarAFN(nodo, m);
            }
            else if (nodo.ToString() == "+")
            {
                generarAFN(nodo, m);
            }
            else if (nodo.ToString() == "*")
            {
                generarAFN(nodo, m);
            }
            else if (nodo.ToString() == "?")
            {
                generarAFN(nodo, m);
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
                generarAFN(nodo, d);
            }
            else if (nodo.ToString() == ".")
            {
                generarAFN(nodo, d);
            }
            else if (nodo.ToString() == "+")
            {
                generarAFN(nodo, d);
            }
            else if (nodo.ToString() == "*")
            {
                generarAFN(nodo, d);
            }
            else if (nodo.ToString() == "?")
            {
                generarAFN(nodo, d);
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
                generarAFN(nodo, m);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == ".")
            {
                generarAFN(nodo, m);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "+")
            {
                generarAFN(nodo, m);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "*")
            {
                generarAFN(nodo, m);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "?")
            {
                generarAFN(nodo, m);
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
                generarAFN(nodo, m);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == ".")
            {
                generarAFN(nodo, m);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "+")
            {
                generarAFN(nodo, m);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "*")
            {
                generarAFN(nodo, m);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "?")
            {
                generarAFN(nodo, m);
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
                generarAFN(nodo, m);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == ".")
            {
                generarAFN(nodo, m);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "+")
            {
                generarAFN(nodo, m);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "*")
            {
                generarAFN(nodo, m);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "?")
            {
                generarAFN(nodo, m);
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
                generarAFN(nodo, l);
                grafica += "node" + m + " -> node" + l + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == ".")
            {
                generarAFN(nodo, l);
                grafica += "node" + m + " -> node" + l + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "+")
            {
                generarAFN(nodo, l);
                grafica += "node" + m + " -> node" + l + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "*")
            {
                generarAFN(nodo, l);
                grafica += "node" + m + " -> node" + l + " [label=\u0022Ɛ\u0022];\n";
            }
            else if (nodo.ToString() == "?")
            {
                generarAFN(nodo, l);
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
