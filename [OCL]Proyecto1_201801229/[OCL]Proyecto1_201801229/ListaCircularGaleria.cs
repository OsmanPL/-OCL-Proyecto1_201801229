using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OCL_Proyecto1_201801229
{
    class ListaCircularGaleria
    {
        public ListaCircularGaleria()
        {

        }
        private Galeria inicioLista;
        private Galeria finalLista;

        internal Galeria InicioLista { get => inicioLista; set => inicioLista = value; }
        internal Galeria FinalLista { get => finalLista; set => finalLista = value; }

        public void insertar(Galeria nuevo)
        {
            if (listavacia())
            {
                InicioLista = nuevo;
                FinalLista = nuevo;
                InicioLista.Siguiente = FinalLista;
                InicioLista.Anterior = FinalLista;
                FinalLista.Siguiente = InicioLista;
                FinalLista.Anterior = InicioLista;
            }
            else
            {
                nuevo.Siguiente = InicioLista;
                nuevo.Anterior = FinalLista;
                InicioLista.Anterior = nuevo;
                FinalLista.Siguiente = nuevo;
                FinalLista = nuevo;
            }
        }
        public bool listavacia()
        {
            if (InicioLista!=null && FinalLista != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void vaciarLista()
        {
            if (InicioLista != null && FinalLista != null)
            {
                InicioLista = null;
                FinalLista = null;
            }
        }
    }
}
