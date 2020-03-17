using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OCL_Proyecto1_201801229
{
    class Graficador
    {
        String ruta;
        StringBuilder grafica;
        public Graficador()
        {
            ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }
        private void generarDot(String rdot, String rpng)
        {
            System.IO.File.WriteAllText(rdot, grafica.ToString());
            String comandoDot = "dot.exe -Tpng " + rdot + " -o " + rpng + " ";
            var comando = String.Format(comandoDot);
            var procesoStart = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
            var procedimiento = new System.Diagnostics.Process();
            procedimiento.StartInfo = procesoStart;
            procedimiento.Start();
            procedimiento.WaitForExit();

        }

        public void graficar(String texto)
        {
            grafica = new StringBuilder();
            String rdot = ruta + "\\imagen.dot";
            String rpng = ruta + "\\imagen.png ";
            grafica.Append(texto);
            this.generarDot(rdot, rpng);
        }
    }
}
