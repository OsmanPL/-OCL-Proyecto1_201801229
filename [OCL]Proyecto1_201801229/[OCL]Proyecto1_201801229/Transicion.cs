using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OCL_Proyecto1_201801229
{
    class Transicion
    {
        private String estado;
        private String simbolo;

        public Transicion()
        {

        }

        public string Estado { get => estado; set => estado = value; }
        public string Simbolo { get => simbolo; set => simbolo = value; }
    }
}
