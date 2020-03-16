using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OCL_Proyecto1_201801229
{
    class Token
    {
        private String lexema;
        private String idToken;
        private int fila;
        private int columna;
        private int indice;
        public Token(String lexema, String idToken, int fila, int columna, int indice)
        {

            this.lexema = lexema;
            this.idToken = idToken;
            this.fila = fila;
            this.columna = columna;
            this.indice = indice;
        }

        public int getIndice()
        {
            return this.indice;
        }
        public String getLexema()
        {
            return this.lexema;
        }
        public String getIdToken()
        {
            return this.idToken;
        }
        public int getFila()
        {
            return this.fila;
        }
        public int getColumna()
        {
            return this.columna;
        }
    }
}
