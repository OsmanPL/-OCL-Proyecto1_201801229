using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OCL_Proyecto1_201801229
{
    class Estado
    {
        private int estadoInicial;
        private List<Transicion> transiciones;
        private List<int> numeros;
        private bool aceptacion;
        public Estado()
        {

        }
        public List<int> Numeros { get => numeros; set => numeros = value; }
        public int EstadoInicial { get => estadoInicial; set => estadoInicial = value; }
        public bool Aceptacion { get => aceptacion; set => aceptacion = value; }
        internal List<Transicion> Transiciones { get => transiciones; set => transiciones = value; }
    }
}
