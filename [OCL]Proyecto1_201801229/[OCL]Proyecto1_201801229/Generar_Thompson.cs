using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OCL_Proyecto1_201801229
{
    class Generar_Thompson
    {

        NodoExpresion raiz = new NodoExpresion();
        List<Object> simbolos = new List<object>();
        List<Object> nodos = new List<object>();
        List<NodoExpresion> listaNodos = new List<NodoExpresion>();
        int j = 0;
        int k = 0;
        NodoExpresion ultimo = new NodoExpresion();
        String grafica = "";
        public Generar_Thompson()
        {

        }

        public void separarNodos(List<Expresion> listaExpresiones, ListaCircularGaleria lg)
        {
            for (int h = 0; h < listaExpresiones.Count; h++)
            {
                String expresion = listaExpresiones.ElementAt(h).ExpresionRegular;
                String nombreGrafica = listaExpresiones.ElementAt(h).Identificador;
                int estado = 0;
                string lexema = "";
                Char c;
                grafica += "digraph " + nombreGrafica + " { \n";
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
                listaNodos.Add(nuevo);
                generarAFN(nodo, 0, nuevo);
                raiz = nuevo;
                grafica += "}";
                Graficador gr = new Graficador();
                gr.graficar(grafica, nombreGrafica);
                MetodoSubconjuntos ms = new MetodoSubconjuntos();
                List<int> numeros = new List<int>();
                numeros.Add(0);
                Galeria nuevoGaleria = new Galeria();
                nuevoGaleria.Nombre = nombreGrafica;
                nuevoGaleria.Simbolos = simbolos;
                ms.generarTabla(listaNodos,numeros,simbolos, nombreGrafica, ultimo, lg, nuevoGaleria);
                ms.GraficarAFD();
                nodos = new List<object>();
                listaNodos = new List<NodoExpresion>();
                simbolos = new List<object>();
                j = 0;
                k = 0;
                grafica = "";
                
            }
        }

        public void generarAFN(Object nodo, int n, NodoExpresion nodoexp)
        {

            
            if (nodo.ToString() == "|")
            {
                grafica += "node" + n + "[label=\u0022"+n+"\u0022]; \n";
                k = n;
                ultimo = nodoexp;
                generarOr(n, nodoexp);
            }
            else if (nodo.ToString() == ".")
            {
                k = n;
                ultimo = nodoexp;
                generarConcatenacion(n, nodoexp);
            }
            else if (nodo.ToString() == "+")
            {
                grafica += "node" + n + "[label=\u0022" + n + "\u0022]; \n";
                k = n;
                ultimo = nodoexp;
                generarCerrduraPositiva(n, nodoexp);
            }
            else if (nodo.ToString() == "*")
            {
                grafica += "node" + n + "[label=\u0022" + n + "\u0022]; \n";
                k = n;
                ultimo = nodoexp;
                generarCerraduaKleene(n, nodoexp);
            }
            else if (nodo.ToString() == "?")
            {
                grafica += "node" + n + "[label=\u0022" + n + "\u0022]; \n";
                k = n;
                ultimo = nodoexp;
                generarInterrogacion(n, nodoexp);
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
                listaNodos.Add(nuevo);
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
                nuevo.Id = m;
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;
            }
            else if (nodo.ToString() == ".")
            {
                listaNodos.Add(nuevo);
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
                nuevo.Id = m;
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;
            }
            else if (nodo.ToString() == "+")
            {
                listaNodos.Add(nuevo);
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
                nuevo.Id = m;
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;
            }
            else if (nodo.ToString() == "*")
            {
                listaNodos.Add(nuevo);
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
                nuevo.Id = m;
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;
            }
            else if (nodo.ToString() == "?")
            {
                listaNodos.Add(nuevo);
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
                nuevo.Id = m;
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;
            }
            else
            {
                revisarSimboloExistente(nodo);

                listaNodos.Add(nuevo);
                listaNodos.Add(nuevo2);
                grafica += "node" + m + "[label=\u0022" + m + "\u0022]; \n";
                nuevo.Id = m;
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022;\n]";
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;
                grafica += "node" + l + "[label=\u0022" + l + "\u0022]; \n";
                nuevo2.Id = l;
                grafica += "node" + m + " -> node" + l + " [label=\u0022 " + nodo.ToString().Replace('"', ' ').Trim() + "\u0022];\n";
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

                listaNodos.Add(nuevo3);
                generarAFN(nodo, d, nuevo3);
                grafica += "node" + n + " -> node" + d + " [label=\u0022Ɛ\u0022];\n";
                nuevo3.Id = d;
                nodoexp.TransicionDerecha = "Ɛ";
                nodoexp.Derecha = nuevo3;

            }
            else if (nodo.ToString() == ".")
            {

                listaNodos.Add(nuevo3);

                generarAFN(nodo, d, nuevo3);
                grafica += "node" + n + " -> node" + d + " [label=\u0022Ɛ\u0022];\n";
                nuevo3.Id = d;
                nodoexp.TransicionDerecha = "Ɛ";
                nodoexp.Derecha = nuevo3;

            }
            else if (nodo.ToString() == "+")
            {

                listaNodos.Add(nuevo3);

                generarAFN(nodo, d, nuevo3);
                grafica += "node" + n + " -> node" + d + " [label=\u0022Ɛ\u0022];\n";
                nuevo3.Id = d;
                nodoexp.TransicionDerecha = "Ɛ";
                nodoexp.Derecha = nuevo3;

            }
            else if (nodo.ToString() == "*")
            {
                listaNodos.Add(nuevo3);
                generarAFN(nodo, d, nuevo3);
                grafica += "node" + n + " -> node" + d + " [label=\u0022Ɛ\u0022];\n";
                nuevo3.Id = d;
                nodoexp.TransicionDerecha = "Ɛ";
                nodoexp.Derecha = nuevo3;

            }
            else if (nodo.ToString() == "?")
            {
                listaNodos.Add(nuevo3);
                generarAFN(nodo, d, nuevo3);
                grafica += "node" + n + " -> node" + d + " [label=\u0022Ɛ\u0022];\n";
                nuevo3.Id = d;
                nodoexp.TransicionDerecha = "Ɛ";
                nodoexp.Derecha = nuevo3;

            }
            else
            {
                revisarSimboloExistente(nodo);
                listaNodos.Add(nuevo3);
                listaNodos.Add(nuevo4);
                grafica += "node" + d + "[label=\u0022" + d + "\u0022]; \n";
                nuevo3.Id = d;
                grafica += "node" + n + " -> node" + d + " [label=\u0022Ɛ\u0022];\n";
                nodoexp.TransicionDerecha = "Ɛ";
                nodoexp.Derecha = nuevo3;
                grafica += "node" + r + "[label=\u0022" + r + "\u0022]; \n";
                nuevo4.Id = r;
                grafica += "node" + d + " -> node" + r + " [label=\u0022 " + nodo.ToString().Replace('"', ' ').Trim() + "\u0022];\n";
                nuevo3.TransicionIzquierda = nodo.ToString();
                nuevo3.Izquierda = nuevo4;
                k = r;
                ultimo = nuevo4;

            }
            r = k;
            NodoExpresion derecha = ultimo;

            int u = k + 1;
            NodoExpresion nodo5 = new NodoExpresion();
            listaNodos.Add(nodo5);
            grafica += "node" + u + "[label=\u0022" + u + "\u0022]; \n";
            nodo5.Id = u;
            grafica += "node" + l + " -> node" + u + " [label=\u0022Ɛ\u0022];\n";
            izuierdo.TransicionIzquierda = "Ɛ";
            izuierdo.Izquierda = nodo5;
            grafica += "node" + r + " -> node" + u + " [label=\u0022Ɛ\u0022];\n";
            derecha.TransicionIzquierda = "Ɛ";
            derecha.Izquierda = nodo5;
            k = u;
            ultimo = nodo5;
        }

        public void generarConcatenacion(int n, NodoExpresion nodoexp)
        {
            //Lado Izquierdo
            j++;
            int m = n;
            int l = m + 1;
            Object nodo = nodos.ElementAt(j);
            NodoExpresion nuevo = nodoexp;
            
            if (nodo.ToString() == "|")
            {

                generarAFN(nodo, m, nuevo);
            }
            else if (nodo.ToString() == ".")
            {

                generarAFN(nodo, m, nuevo);
            }
            else if (nodo.ToString() == "+")
            {

                generarAFN(nodo, m, nuevo);
            }
            else if (nodo.ToString() == "*")
            {
                generarAFN(nodo, m, nuevo);
            }
            else if (nodo.ToString() == "?")
            {

                generarAFN(nodo, m, nuevo);
            }
            else
            {

                revisarSimboloExistente(nodo);
                m = k;
                l = k + 1;
                grafica += "node" + m + "[label=\u0022" + m + "\u0022]; \n";
                grafica += "node" + l + "[label=\u0022" + l + "\u0022]; \n";
                NodoExpresion nuevo2 = new NodoExpresion();
                listaNodos.Add(nuevo2);
                nuevo2.Id = l;
                grafica += "node" + m + " -> node" + l + " [label=\u0022 " + nodo.ToString().Replace('"', ' ').Trim() + "\u0022];\n";
                nuevo.TransicionIzquierda = nodo.ToString();
                nuevo.Izquierda = nuevo2;
                k = l;
                ultimo = nuevo2;
            }


            //Lado Derecho
            j++;
            int d = k;
            int r = d + 1;
            nodo = nodos.ElementAt(j);
            NodoExpresion nuevou = ultimo;
            if (nodo.ToString() == "|")
            {

                generarAFN(nodo, d, nuevou);
            }
            else if (nodo.ToString() == ".")
            {

                generarAFN(nodo, d, nuevou);
            }
            else if (nodo.ToString() == "+")
            {
                generarAFN(nodo, d, nuevou);
            }
            else if (nodo.ToString() == "*")
            {
                generarAFN(nodo, d, nuevou);
            }
            else if (nodo.ToString() == "?")
            {

                generarAFN(nodo, d, nuevou);
            }
            else
            {
                revisarSimboloExistente(nodo);
                d = k;
                NodoExpresion nuevo3 = ultimo;
                r = k + 1;
                NodoExpresion nuevo4 = new NodoExpresion();
                listaNodos.Add(nuevo4);
                nuevo4.Id = r;
                grafica += "node" + r + "[label=\u0022" + r + "\u0022]; \n";
                grafica += "node" + d + " -> node" + r + " [label=\u0022 " + nodo.ToString().Replace('"', ' ').Trim() + "\u0022];\n";
                nuevo3.TransicionIzquierda = nodo.ToString();
                nuevo3.Izquierda = nuevo4;
                k = r;
                ultimo = nuevo4;
            }
        }
        public void generarInterrogacion(int n, NodoExpresion nodoexp)
        {
            //Lado Izquierdo
            j++;

            int m = n + 1;
            int l = m + 1;
            Object nodo = nodos.ElementAt(j);

            NodoExpresion nuevo = new NodoExpresion();
            nuevo.Id = m;
            if (nodo.ToString() == "|")
            {
                listaNodos.Add(nuevo);
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;

            }
            else if (nodo.ToString() == ".")
            {

                listaNodos.Add(nuevo);
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;
            }
            else if (nodo.ToString() == "+")
            {

                listaNodos.Add(nuevo);
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;
            }
            else if (nodo.ToString() == "*")
            {

                listaNodos.Add(nuevo);
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;
            }
            else if (nodo.ToString() == "?")
            {

                listaNodos.Add(nuevo);
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;
            }
            else
            {
                revisarSimboloExistente(nodo);
                grafica += "node" + m + "[label=\u0022" + m + "\u0022]; \n";
                listaNodos.Add(nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;
                grafica += "node" + l + "[label=\u0022" + l + "\u0022]; \n";
                NodoExpresion nuevo2 = new NodoExpresion();
                listaNodos.Add(nuevo2);
                nuevo2.Id = l;
                grafica += "node" + m + " -> node" + l + " [label=\u0022 " + nodo.ToString().Replace('"', ' ').Trim() + "\u0022];\n";
                nuevo.TransicionIzquierda = nodo.ToString();
                nuevo.Izquierda = nuevo2;
                k = l;
                ultimo = nuevo2;
            }
            l = k;
            NodoExpresion izquierda = ultimo;
            //Lado Derecho
            int d = k + 1;
            int r = d + 1;

            grafica += "node" + d + "[label=\u0022" + d + "\u0022]; \n";
            NodoExpresion nuevo3 = new NodoExpresion();
            listaNodos.Add(nuevo3);
            nuevo3.Id = d;
            grafica += "node" + n + " -> node" + d + " [label=\u0022Ɛ\u0022];\n";
            nodoexp.TransicionDerecha = "Ɛ";
            nodoexp.Derecha = nuevo3;
            grafica += "node" + r + "[label=\u0022" + r + "\u0022]; \n";
            NodoExpresion nuevo4 = new NodoExpresion();
            listaNodos.Add(nuevo4);
            nuevo4.Id = r;
            grafica += "node" + d + " -> node" + r + " [label=\u0022Ɛ\u0022];\n";
            nuevo3.TransicionIzquierda = "Ɛ";
            nuevo3.Izquierda = nuevo4;
            k = r;

            int u = k + 1;
            grafica += "node" + u + "[label=\u0022" + u + "\u0022]; \n";
            NodoExpresion nuevo5 = new NodoExpresion();
            listaNodos.Add(nuevo5);
            nuevo5.Id = u;
            grafica += "node" + l + " -> node" + u + " [label=\u0022Ɛ\u0022];\n";
            izquierda.TransicionIzquierda = "Ɛ";
            izquierda.Izquierda = nuevo5;
            grafica += "node" + r + " -> node" + u + " [label=\u0022Ɛ\u0022];\n";
            nuevo4.TransicionIzquierda = "Ɛ";
            nuevo4.Izquierda = nuevo5;
            k = u;
            ultimo = nuevo5;
        }

        public void generarCerraduaKleene(int n, NodoExpresion nodoexp)
        {
            j++;
            int m = k + 1;
            int l = m + 1;
            Object nodo = nodos.ElementAt(j);

            NodoExpresion nuevo = new NodoExpresion();
            nuevo.Id = m;

            if (nodo.ToString() == "|")
            {
                listaNodos.Add(nuevo);
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;
            }
            else if (nodo.ToString() == ".")
            {
                listaNodos.Add(nuevo);
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;
            }
            else if (nodo.ToString() == "+")
            {
                listaNodos.Add(nuevo);
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;
            }
            else if (nodo.ToString() == "*")
            {
                listaNodos.Add(nuevo);
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;
            }
            else if (nodo.ToString() == "?")
            {
                listaNodos.Add(nuevo);
                generarAFN(nodo, m, nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022];\n";
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;
            }
            else
            {
                revisarSimboloExistente(nodo);
                grafica += "node" + m + "[label=\u0022" + m + "\u0022]; \n";
                listaNodos.Add(nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022Ɛ\u0022;\n]";
                nodoexp.TransicionIzquierda = "Ɛ";
                nodoexp.Izquierda = nuevo;
                grafica += "node" + l + "[label=\u0022" + l + "\u0022]; \n";
                NodoExpresion nuevo2 = new NodoExpresion();
                listaNodos.Add(nuevo2);
                nuevo2.Id = l;
                grafica += "node" + m + " -> node" + l + " [label=\u0022 " + nodo.ToString().Replace('"', ' ').Trim() + "\u0022];\n";
                nuevo.TransicionIzquierda = nodo.ToString();
                nuevo.Izquierda = nuevo2;
                k = l;
                ultimo = nuevo2;
            }
            l = k;
            NodoExpresion izquierda = ultimo;
            int p = k + 1;
            grafica += "node" + l + " -> node" + m + " [label=\u0022Ɛ\u0022;\n]";
            izquierda.TransicionIzquierda = "Ɛ";
            izquierda.Izquierda = nuevo;
            grafica += "node" + p + "[label=\u0022" + p + "\u0022]; \n";
            NodoExpresion nuevo3 = new NodoExpresion();
            listaNodos.Add(nuevo3);
            nuevo3.Id = p;
            grafica += "node" + l + " -> node" + p + " [label=\u0022Ɛ\u0022;\n]";
            izquierda.TransicionDerecha = "Ɛ";
            izquierda.Derecha = nuevo3;
            grafica += "node" + n + " -> node" + p + " [label=\u0022Ɛ\u0022;\n]";
            nodoexp.TransicionDerecha = "Ɛ";
            nodoexp.Derecha = nuevo3;
            k = p;
            ultimo = nuevo3;
        }
        public void generarCerrduraPositiva(int n, NodoExpresion nodoexp)
        {

            j++;
            int t = j;
            int m = n + 1;
            Object nodo = nodos.ElementAt(j);

            NodoExpresion nuevo = new NodoExpresion();
            nuevo.Id = m;
            if (nodo.ToString() == "|")
            {
                listaNodos.Add(nuevo);
                generarAFN(nodo, m, nuevo);
            }
            else if (nodo.ToString() == ".")
            {
                listaNodos.Add(nuevo);
                generarAFN(nodo, m, nuevo);
            }
            else if (nodo.ToString() == "+")
            {
                listaNodos.Add(nuevo);
                generarAFN(nodo, m, nuevo);
            }
            else if (nodo.ToString() == "*")
            {
                listaNodos.Add(nuevo);
                generarAFN(nodo, m, nuevo);
            }
            else if (nodo.ToString() == "?")
            {
                listaNodos.Add(nuevo);
                generarAFN(nodo, m, nuevo);
            }
            else
            {
                revisarSimboloExistente(nodo);
                grafica += "node" + m + "[label=\u0022" + m + "\u0022];\n";
                listaNodos.Add(nuevo);
                grafica += "node" + n + " -> node" + m + " [label=\u0022 " + nodo.ToString().Replace('"', ' ').Trim() + "\u0022];\n";
                nodoexp.TransicionIzquierda = nodo.ToString();
                nodoexp.Izquierda = nuevo;
                k = m;
                ultimo = nuevo;
            }
            int z = k;
            NodoExpresion izquierda = ultimo;
            int l = z + 1;
            int r = l + 1;
            j = t;
            NodoExpresion nuevo2 = new NodoExpresion();
            nuevo2.Id = l;
            nodo = nodos.ElementAt(j);
            if (nodo.ToString() == "|")
            {
                listaNodos.Add(nuevo2);
                generarAFN(nodo, l, nuevo2);
                grafica += "node" + z + " -> node" + l + " [label=\u0022Ɛ\u0022];\n";
                izquierda.TransicionIzquierda = "Ɛ";
                izquierda.Izquierda = nuevo2;
            }
            else if (nodo.ToString() == ".")
            {

                listaNodos.Add(nuevo2);
                generarAFN(nodo, l, nuevo2);
                grafica += "node" + z + " -> node" + l + " [label=\u0022Ɛ\u0022];\n";
                izquierda.TransicionIzquierda = "Ɛ";
                izquierda.Izquierda = nuevo2;
            }
            else if (nodo.ToString() == "+")
            {
                listaNodos.Add(nuevo2);
                generarAFN(nodo, l, nuevo2);
                grafica += "node" + z + " -> node" + l + " [label=\u0022Ɛ\u0022];\n";
                izquierda.TransicionIzquierda = "Ɛ";
                izquierda.Izquierda = nuevo2;
            }
            else if (nodo.ToString() == "*")
            {
                listaNodos.Add(nuevo2);
                generarAFN(nodo, l, nuevo2);
                grafica += "node" + z + " -> node" + l + " [label=\u0022Ɛ\u0022];\n";
                izquierda.TransicionIzquierda = "Ɛ";
                izquierda.Izquierda = nuevo2;
            }
            else if (nodo.ToString() == "?")
            {
                listaNodos.Add(nuevo2);
                generarAFN(nodo, l, nuevo2);
                grafica += "node" + z + " -> node" + l + " [label=\u0022Ɛ\u0022];\n";
                izquierda.TransicionIzquierda = "Ɛ";
                izquierda.Izquierda = nuevo2;
            }
            else
            {
                revisarSimboloExistente(nodo);
                grafica += "node" + l + "[label=\u0022" + l + "\u0022]; \n";
                listaNodos.Add(nuevo2);
                grafica += "node" + z + " -> node" + l + " [label=\u0022Ɛ\u0022];\n";
                izquierda.TransicionIzquierda = "Ɛ";
                izquierda.Izquierda = nuevo2;
                grafica += "node" + r + "[label=\u0022" + r + "\u0022]; \n";
                NodoExpresion nuevo3 = new NodoExpresion();
                nuevo3.Id = r;
                listaNodos.Add(nuevo3);
                grafica += "node" + l + " -> node" + r + " [label=\u0022 " + nodo.ToString().Replace('"', ' ').Trim() + "\u0022];\n";
                nuevo2.TransicionIzquierda = nodo.ToString();
                nuevo2.Izquierda = nuevo3;
                k = r;
                ultimo = nuevo3;
            }
            int rr = k;
            NodoExpresion derecha = ultimo;
            int p = k + 1;
            grafica += "node" + rr + " -> node" + l + " [label=\u0022Ɛ\u0022];\n";
            derecha.TransicionIzquierda = "Ɛ";
            derecha.Izquierda = nuevo2;
            grafica += "node" + p + "[label=\u0022" + p + "\u0022]; \n";
            NodoExpresion nuevo4 = new NodoExpresion();
            nuevo4.Id = p;
            listaNodos.Add(nuevo4);
            grafica += "node" + rr + " -> node" + p + " [label=\u0022Ɛ\u0022];\n";
            derecha.TransicionDerecha = "Ɛ";
            derecha.Derecha = nuevo4;
            grafica += "node" + z + " -> node" + p + " [label=\u0022Ɛ\u0022];\n";
            izquierda.TransicionDerecha = "Ɛ";
            izquierda.Derecha = nuevo4;
            k = p;
            ultimo = nuevo4;
        }
        public void revisarSimboloExistente(Object simbolo)
        {
            bool agregar = true;
            for (int i = 0; i < simbolos.Count; i++)
            {
                if (simbolos.ElementAt(i).ToString() == simbolo.ToString())
                {
                    agregar = false;
                }
            }
            if (agregar)
            {
                simbolos.Add(simbolo);
            }
        }
    }
}
