using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OCL_Proyecto1_201801229
{
    class Probar_Lexemas
    {
        Galeria aux;
        List<Error> errores;

        internal List<Error> Errores { get => errores; set => errores = value; }

        public Probar_Lexemas()
        {
            errores = new List<Error>();
        }

        public String prueba(Galeria inicio, List<Lexema> lexemas, List<Conjunto> listaConjuntos)
        {
            String consola = "";
            aux = inicio;
            for (int i = 0; i < lexemas.Count; i++)
            {
                if (aux.Nombre == lexemas.ElementAt(i).Identificador)
                {
                    List<String> valores = new List<String>();
                    separar(valores, lexemas.ElementAt(i).ExpresionLexema);
                    Estado actual = aux.Estados.ElementAt(0);
                    int fila = 1;
                    int columna = 0;
                    String c;
                    bool correcto = false;
                    for (int l = 0; l < valores.Count; l++)
                    {
                        c = valores.ElementAt(l);
                        columna++;
                        bool vamosbien = false;
                        for (int k = 0; k < actual.Transiciones.Count; k++)
                        {
                            String conjunto = "";
                            for (int h = 0; h < listaConjuntos.Count; h++)
                            {
                                if (actual.Transiciones.ElementAt(k).Simbolo == listaConjuntos.ElementAt(h).Identificador)
                                {
                                    conjunto = listaConjuntos.ElementAt(h).Elementos;
                                    break;
                                }
                            }
                            if (conjunto == "")
                            {
                                if (c==actual.Transiciones.ElementAt(k).Simbolo)
                                {
                                    vamosbien = true;
                                    if (l == valores.Count)
                                    {
                                        if (actual.Aceptacion)
                                        {
                                            correcto = true;
                                        }
                                    }
                                    for (int m = 0; m < aux.Estados.Count; m++)
                                    {
                                        if (actual.Transiciones.ElementAt(k).Estado == aux.Estados.ElementAt(m).EstadoInicial)
                                        {
                                            actual = aux.Estados.ElementAt(m);
                                        }
                                    }
                                    break;
                                }
                            }
                            else {
                                if (conjunto.Contains("~"))
                                {
                                    String[] datos = conjunto.Split('~');
                                    String datomenor = datos[0];
                                    String datomayor = datos[1];
                                    int menor = String.Compare(c, datomenor, false);
                                    int mayor = String.Compare(c, datomayor, false);
                                    if (menor <= 0 && mayor >= 0)
                                    {
                                        vamosbien = true;
                                        if (l == valores.Count)
                                        {
                                            if (actual.Aceptacion)
                                            {
                                                correcto = true;
                                            }
                                        }
                                        break;
                                    }

                                    for (int m = 0; m < aux.Estados.Count; m++)
                                    {
                                        if (actual.Transiciones.ElementAt(k).Estado == aux.Estados.ElementAt(m).EstadoInicial)
                                        {
                                            actual = aux.Estados.ElementAt(m);
                                        }
                                    }
                                }
                                else
                                {
                                    String[] datos = conjunto.Split(',');
                                    for (int r = 0; r < datos.Length; r++)
                                    {
                                        if (c == datos[r])
                                        {
                                            vamosbien = true;
                                            if (l == valores.Count)
                                            {
                                                if (actual.Aceptacion)
                                                {
                                                    correcto = true;
                                                }
                                            }
                                            for (int m = 0; m < aux.Estados.Count; m++)
                                            {
                                                if (actual.Transiciones.ElementAt(k).Estado == aux.Estados.ElementAt(m).EstadoInicial)
                                                {
                                                    actual = aux.Estados.ElementAt(m);
                                                }
                                            }
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                        if (vamosbien)
                        {

                        }
                        else
                        {
                            agregarerror("",c,0,0,lexemas.ElementAt(i).Identificador);
                        }
                    }
                    if (correcto)
                    {
                        consola += lexemas.ElementAt(i).ExpresionLexema + " concuerda con "+ aux.Nombre + "\n";
                    }
                    else
                    {
                        consola += lexemas.ElementAt(i).ExpresionLexema + " no se acepta como valida para " + aux.Nombre+"\n";
                    }
                }
                else
                {
                    aux = aux.Siguiente;
                    i--;
                }
            }
            return consola;
        }
        public void agregarerror(String descripcion, String caracter,int fila, int columna, String nombre)
        {
            Error nuevo = new Error(descripcion, caracter, fila, columna, nombre);
            Errores.Add(nuevo);
        }
        public void separar(List<String> valores, String lexema)
        {
            Char c;
            String texto = lexema + " ";
            int estado = 0;
            String numero = "";
            for (int i = 0; i < texto.Length; i++)
            {
                c = texto[i];
                switch (estado)
                {
                    case 0:
                        if (Char.IsDigit(c))
                        {
                            numero += c;
                            estado = 1;
                        }
                        else
                        {
                            valores.Add(c.ToString());
                            estado = 0;
                        }
                        break;
                    case 1:
                        if (Char.IsDigit(c))
                        {
                            numero += c;
                            estado = 1;
                        }
                        else
                        {
                            valores.Add(numero);
                            numero = "";
                            i--;
                            estado = 0;
                        }
                        break;
                }
            }
        }
    }
}
