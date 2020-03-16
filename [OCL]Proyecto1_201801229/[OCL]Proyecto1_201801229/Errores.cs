using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OCL_Proyecto1_201801229
{
    class Errores
    {
        private String descripcion;
        private String caracter;
        private int fila;
        private int columna;
        public Errores(String descripcion, String caracter, int fila, int columna)
        {
            this.descripcion = descripcion;
            this.caracter = caracter;
            this.fila = fila;
            this.columna = columna;
        }
        public String getDescripcion()
        {
            return this.descripcion;
        }
        public String getCaracter()
        {
            return this.caracter;
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
