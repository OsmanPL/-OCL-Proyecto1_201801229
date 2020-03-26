using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OCL_Proyecto1_201801229
{
    class MetodoSubconjuntos
    {
        List<Estado> transiciones = new List<Estado>();
        NodoExpresion ultimo = new NodoExpresion();
        List<NodoExpresion> listaNodo = new List<NodoExpresion>();
        List<Object> listaSimbolos = new List<object>();
        String name = "";
        int j = 0;
        public MetodoSubconjuntos()
        {

        }
        public void generarTabla(List<NodoExpresion> listaNodos, List<int> numeros, List<Object> simbolos, String nombre, NodoExpresion final, ListaCircularGaleria lg,  Galeria nuevoGaleria)
        {
            listaNodo = listaNodos;
            name = nombre;
            listaSimbolos = simbolos;
            ultimo = final;
            List<int> estadosCerradura = new List<int>();
            for (int i = 0; i < numeros.Count; i++)
            {
                NodoExpresion paraCerradura = buscarNodo(numeros.ElementAt(i));
                if (paraCerradura != null)
                {
                    cerradura(paraCerradura, estadosCerradura);
                }
            }
            mostrarCerradura(estadosCerradura);
            Estado nuevoEstado = new Estado();
            nuevoEstado.EstadoInicial = j;
            j++;
            nuevoEstado.Numeros = numeros;
            bool has = estadosCerradura.Any(x => x == ultimo.Id);
            if (has==true)
            {
                nuevoEstado.Aceptacion = true;
            }
            transiciones.Add(nuevoEstado);
            List<Transicion> trancisionesEstado = new List<Transicion>();
            for (int i = 0; i < listaSimbolos.Count; i++)
            {
                List<int> estadosMueve = new List<int>();
                for (int l = 0; l < estadosCerradura.Count; l++)
                {
                    NodoExpresion paraMove = buscarNodo(estadosCerradura.ElementAt(l));
                    if (paraMove!=null)
                    {
                        move(paraMove, listaSimbolos.ElementAt(i), estadosMueve);
                    }
                }
                if (estadosMueve.Count>0)
                {
                    bool sn = existeCerradura(estadosMueve);
                    if (sn)
                    {
                        int id = devolverId(estadosMueve);
                        Transicion nuevaTransicion = new Transicion();
                        nuevaTransicion.Estado = id;
                        nuevaTransicion.Simbolo = listaSimbolos.ElementAt(i).ToString();
                        trancisionesEstado.Add(nuevaTransicion);
                    }
                    else
                    {
                        Estado apuntar = new Estado();
                        apuntar.EstadoInicial = j;
                        j++;
                        apuntar.Numeros = estadosMueve;
                        transiciones.Add(apuntar);

                        Transicion nuevaTransicion = new Transicion();
                        nuevaTransicion.Estado = apuntar.EstadoInicial;
                        nuevaTransicion.Simbolo = listaSimbolos.ElementAt(i).ToString();
                        trancisionesEstado.Add(nuevaTransicion);
                        siguientes(estadosMueve, apuntar);
                    }
                }
            }
            nuevoEstado.Transiciones = trancisionesEstado;
            nuevoGaleria.Estados = transiciones;
            lg.insertar(nuevoGaleria);
        }
        public void siguientes(List<int> numeros, Estado nuevoEstado)
        {
            List<int> estadosCerradura = new List<int>();
            for (int i = 0; i < numeros.Count; i++)
            {
                NodoExpresion paraCerradura = buscarNodo(numeros.ElementAt(i));
                if (paraCerradura != null)
                {
                    cerradura(paraCerradura, estadosCerradura);
                }
            }
            mostrarCerradura(estadosCerradura);
            bool has = estadosCerradura.Any(x => x == ultimo.Id);
            if (has == true)
            {
                nuevoEstado.Aceptacion = true;
            }
            List<Transicion> trancisionesEstado = new List<Transicion>();
            for (int i = 0; i < listaSimbolos.Count; i++)
            {
                List<int> estadosMueve = new List<int>();
                for (int l = 0; l < estadosCerradura.Count; l++)
                {
                    NodoExpresion paraMove = buscarNodo(estadosCerradura.ElementAt(l));
                    if (paraMove != null)
                    {
                        move(paraMove, listaSimbolos.ElementAt(i), estadosMueve);
                    }
                }
                if (estadosMueve.Count > 0)
                {
                    bool sn = existeCerradura(estadosMueve);
                    if (sn)
                    {
                        int id = devolverId(estadosMueve);
                        Transicion nuevaTransicion = new Transicion();
                        nuevaTransicion.Estado = id;
                        nuevaTransicion.Simbolo = listaSimbolos.ElementAt(i).ToString();
                        trancisionesEstado.Add(nuevaTransicion);
                    }
                    else
                    {
                        Estado apuntar = new Estado();
                        apuntar.EstadoInicial = j;
                        j++;
                        apuntar.Numeros = estadosMueve;
                        transiciones.Add(apuntar);
                        Transicion nuevaTransicion = new Transicion();
                        nuevaTransicion.Estado = apuntar.EstadoInicial;
                        nuevaTransicion.Simbolo = listaSimbolos.ElementAt(i).ToString();
                        trancisionesEstado.Add(nuevaTransicion);
                        siguientes(estadosMueve, apuntar);
                    }
                }
            }
            nuevoEstado.Transiciones = trancisionesEstado;
        }
        public void cerradura(NodoExpresion inicio, List<int> estados)
        {
            estados.Add(inicio.Id);
            if (inicio.Izquierda!=null)
            {
                if (inicio.TransicionIzquierda.ToString() == "Ɛ")
                {
                    cerradura(inicio.Izquierda, estados);
                }
            }
            if (inicio.Derecha != null)
            {
                if (inicio.TransicionDerecha.ToString() == "Ɛ")
                {
                    cerradura(inicio.Derecha, estados);
                }
            }
        }
        public void move(NodoExpresion raiz, Object simbolo, List<int> estados)
        {
            if (raiz.Izquierda!=null)
            {
                if (raiz.TransicionIzquierda.ToString() == simbolo.ToString())
                {
                    estados.Add(raiz.Izquierda.Id);
                }
            }
            if (raiz.Derecha != null)
            {
                if (raiz.TransicionDerecha.ToString() == simbolo.ToString())
                {
                    estados.Add(raiz.Derecha.Id);
                }
            }
        }
        public NodoExpresion buscarNodo(int id)
        {
            NodoExpresion devolver = new NodoExpresion();
            for (int i = 0; i < listaNodo.Count; i++)
            {
                if (listaNodo.ElementAt(i).Id == id)
                {
                    devolver = listaNodo.ElementAt(i);
                }
            }
            return devolver;
        }

       
        public bool existeCerradura(List<int> estados)
        {
            bool existe = false;
            for (int i = 0; i < transiciones.Count; i++)
            {
                List<int> diferencia = transiciones.ElementAt(i).Numeros.Except(estados).ToList();
                if (diferencia.Count == 0)
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }
        public int devolverId(List<int> estados)
        {
            int id = 0;
            for (int i = 0; i < transiciones.Count; i++)
            {
                List<int> diferencia = transiciones.ElementAt(i).Numeros.Except(estados).ToList();
                if (diferencia.Count == 0)
                {
                    id = transiciones.ElementAt(i).EstadoInicial;
                    break;
                }
            }
            return id;
        }

        public void mostrarCerradura(List<int> estados)
        {
            String mensaje = "";
            for (int i = 0; i < estados.Count; i++)
            {
                mensaje += estados.ElementAt(i) + ", ";
            }
        }

        public void GraficarAFD()
        {
            String nombre = name + "_AFD";
            String grafica = "digraph "+nombre+" {\n overlap=false;\nrankdir=\u0022LR\u0022;\n";
            for (int i = 0; i < transiciones.Count; i++)
            {
                if (transiciones.ElementAt(i).Aceptacion==true)
                {
                    grafica += "node" + transiciones.ElementAt(i).EstadoInicial + " [shape = doublecircle, height=.1  label=\u0022" + transiciones.ElementAt(i).EstadoInicial + "\u0022]; \n";
                }
                else
                {
                    grafica += "node" + transiciones.ElementAt(i).EstadoInicial + " [shape = circle, height=.1 label=\u0022" + transiciones.ElementAt(i).EstadoInicial + "\u0022]; \n";
                }
            }
            for (int i = 0; i < transiciones.Count; i++)
            {
                int id = transiciones.ElementAt(i).EstadoInicial;
                if (transiciones.ElementAt(i).Transiciones != null)
                {
                    for (int l = 0; l < transiciones.ElementAt(i).Transiciones.Count; l++)
                    {
                        grafica += "node" + id + " -> node" + 
                            transiciones.ElementAt(i).Transiciones.ElementAt(l).Estado + 
                            " [label=\u0022" + transiciones.ElementAt(i).Transiciones.ElementAt(l).Simbolo.Replace('"', ' ').Trim()
                            + "\u0022]; \n";
                    }
                }
                
            }
            grafica += "}";
            Graficador gr = new Graficador();
            gr.graficar(grafica, nombre);
        }

    }
}
