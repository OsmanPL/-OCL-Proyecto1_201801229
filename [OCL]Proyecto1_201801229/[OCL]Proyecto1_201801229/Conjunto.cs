using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OCL_Proyecto1_201801229
{
    class Conjunto
    {
        private String identificador;
        private String elementos;

        public Conjunto()
        {

        }

        public Conjunto(String identificador, String elementos)
        {
            this.identificador = identificador;
            this.elementos = elementos;
        }

        public string Identificador { get => identificador; set => identificador = value; }

        public string Elementos { get => elementos; set => elementos = value; }
    }
}
