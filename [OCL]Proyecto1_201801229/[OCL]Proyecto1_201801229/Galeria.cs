using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OCL_Proyecto1_201801229
{
    class Galeria
    {
        private String nombre;
        private List<Estado> estados;
        private List<Object> simbolos;
        private Galeria siguiente;
        private Galeria anterior;
        public Galeria()
        {

        }
        public string Nombre { get => nombre; set => nombre = value; }
        public List<object> Simbolos { get => simbolos; set => simbolos = value; }
        internal List<Estado> Estados { get => estados; set => estados = value; }
        internal Galeria Siguiente { get => siguiente; set => siguiente = value; }
        internal Galeria Anterior { get => anterior; set => anterior = value; }
    }
}
