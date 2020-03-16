using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace _OCL_Proyecto1_201801229
{
    class Pestaña
    {
        List<RichTextBox> ltxt = new List<RichTextBox>();
        public void agregar(TabControl tb, int c)
        {
            TabPage tp = new TabPage("Pestaña" + c);
            RichTextBox txt = new RichTextBox();
            txt.Size = new Size(472, 216);
            tp.Controls.Add(txt);
            tb.TabPages.Add(tp);
            tb.SelectedTab = tp;

        }
        public void eliminar(TabControl tb)
        {
            TabPage tp = tb.SelectedTab;
            tb.TabPages.Remove(tp);
        }


    }
}
