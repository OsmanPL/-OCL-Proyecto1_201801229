using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OCL_Proyecto1_201801229
{
    class Expresion
    {
        private String identificador;
        private String expresionRegular;

        public Expresion()
        {

        }

        public Expresion(String identificador, String expresionRegular)
        {
            this.identificador = identificador;
            this.expresionRegular = expresionRegular;
        }

        public string Identificador { get => identificador; set => identificador = value; }

        public string ExpresionRegular { get => expresionRegular; set => expresionRegular = value; }
    }
}
