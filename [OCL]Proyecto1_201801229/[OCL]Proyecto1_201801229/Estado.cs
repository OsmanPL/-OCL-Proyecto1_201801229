using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OCL_Proyecto1_201801229
{
    class Estado
    {
        private String estadoInicial;
        private List<Transicion> transiciones;

        public Estado()
        {

        }
        public string EstadoInicial { get => estadoInicial; set => estadoInicial = value; }
        internal List<Transicion> Transiciones { get => transiciones; set => transiciones = value; }
    }
}
