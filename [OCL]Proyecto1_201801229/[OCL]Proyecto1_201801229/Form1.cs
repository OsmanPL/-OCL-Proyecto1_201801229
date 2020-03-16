using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _OCL_Proyecto1_201801229
{
    public partial class Form1 : Form
    {
        int c = 1;
        Pestaña nuevaPestaña = new Pestaña();

        public Form1()
        {
            InitializeComponent();
        }

        private void generarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nuevaPestaña.agregar(tabControl1, c);
            c++;
        }

        private void analizarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog pf = new OpenFileDialog();
                pf.DefaultExt = "*.er";
                pf.Filter = "ER Files|*.er";
                if (pf.ShowDialog() == DialogResult.OK && pf.FileName.Length > 0)
                {
                    TabPage tp = tabControl1.SelectedTab;
                    foreach (Control o in tp.Controls)
                    {
                        if (o is RichTextBox)
                        {
                            RichTextBox r = (RichTextBox)o;
                            r.LoadFile(pf.FileName, RichTextBoxStreamType.PlainText);
                            tp.Text = pf.SafeFileName;
                            MessageBox.Show("Achivo .er cargado correctamente");
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Achivo .er no se cargo");
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sv = new SaveFileDialog();
                StreamWriter sw = null;
                sv.Filter = "ER (*.er)|*er";
                sv.CheckPathExists = true;
                sv.Title = "Guardar como";
                sv.FileName = ".er";

                TabPage tp = tabControl1.SelectedTab;
                foreach (Control o in tp.Controls)
                {
                    if (o is RichTextBox)
                    {
                        if (sv.ShowDialog(this) == DialogResult.OK)
                        {
                            RichTextBox r = (RichTextBox)o;
                            r.SaveFile(sv.FileName, RichTextBoxStreamType.PlainText);
                            tabControl1.TabPages.RemoveAt(tabControl1.TabPages.IndexOf(tp));
                            MessageBox.Show("Archivo .er guardado correctamente");
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Archivo .er no se guardo");
            }
        }

        private void iniciarAnalisisLexicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            String text = "";
            TabPage tp = tabControl1.SelectedTab;
            foreach (Control o in tp.Controls)
            {
                if (o is RichTextBox)
                {
                    text = o.Text;
                    RichTextBox r = (RichTextBox)o;
                    Analizador lexico = new Analizador();
                    lexico.analizadorLexico(text);
                    lexico.generarReportes();

                }
            }
            MessageBox.Show("Anlizado Correcamente");
        }
            catch (Exception ex)
             {
                 MessageBox.Show("Error: " + ex);
             }
}
    }
}
