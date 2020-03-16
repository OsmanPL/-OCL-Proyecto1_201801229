using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OCL_Proyecto1_201801229
{
    class Lexema
    {
        private String identificador;
        private String expresionLexema;

        public Lexema()
        {

        }

        public Lexema(String identificador, String expresionLexema)
        {
            this.identificador = identificador;
            this.expresionLexema = expresionLexema;
        }

        public string Identificador { get => identificador; set => identificador = value; }

        public string ExpresionLexema { get => expresionLexema; set => expresionLexema = value; }
    }
}
