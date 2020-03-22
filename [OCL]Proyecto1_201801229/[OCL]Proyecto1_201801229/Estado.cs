using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OCL_Proyecto1_201801229
{
    class Estado
    {
        private Object estadoInicial;
        private List<Transicion> transiciones;
        private List<int> numeros; 

        public Estado()
        {

        }
        public object EstadoInicial1 { get => estadoInicial; set => estadoInicial = value; }
        public List<int> Numeros { get => numeros; set => numeros = value; }
        internal List<Transicion> Transiciones { get => transiciones; set => transiciones = value; }
    }
}
