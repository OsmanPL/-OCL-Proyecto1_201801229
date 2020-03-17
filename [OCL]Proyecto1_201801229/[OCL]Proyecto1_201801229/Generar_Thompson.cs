﻿using System;
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
            String expresion = listaExpresiones.ElementAt(0).ExpresionRegular;

            int estado = 0;
            string lexema = "";
            Char c;
            grafica += "digraph nombreExpresion { \n";
            grafica += "node [shape = circle, height=.1] \n";
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
                            j++;
                        }
                        else if (c == '.')
                        {
                            nodos.Add(c);
                            j++;
                        }
                        else if (c == '+')
                        {
                            nodos.Add(c);
                            j++;
                        }
                        else if (c == '*')
                        {
                            nodos.Add(c);
                            j++;
                        }
                        else if (c == '?')
                        {
                            nodos.Add(c);
                            j++;
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
            gr.graficar(grafica);
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
                grafica += "node" + n + "; \n";
                k = n;
                generarConcatenacion(n);
            }
            else if (nodo.ToString() == "+")
            {
                generarOr(n);
            }
            else if (nodo.ToString() == "*")
            {
                generarOr(j);
            }
            else if (nodo.ToString() == "?")
            {
                generarOr(j);
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

            int u = k + 1;
            grafica += "node" + u + "; \n";
            grafica += "node" + l + " -> node" + u + " [label=\u0022Ɛ\u0022];\n";
            grafica += "node" + r + " -> node" + u + " [label=\u0022Ɛ\u0022];\n";

        }

        public void generarConcatenacion(int n)
        {

        }

        public void escribirArchivoDot()
        {

        }
    }

}
