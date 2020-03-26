using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OCL_Proyecto1_201801229
{
    class Error
    {
        private String nombreExp;
        private String descripcion;
        private String caracter;
        private int fila;
        private int columna;

        public string NombreExp { get => nombreExp; set => nombreExp = value; }

        public Error(String descripcion, String caracter, int fila, int columna, String nombreExp)
        {
            this.descripcion = descripcion;
            this.caracter = caracter;
            this.fila = fila;
            this.columna = columna;
            this.nombreExp = nombreExp;
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
