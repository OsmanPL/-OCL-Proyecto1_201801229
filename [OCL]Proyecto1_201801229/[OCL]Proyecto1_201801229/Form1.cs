using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace _OCL_Proyecto1_201801229
{
    public partial class Form1 : Form
    {
        int c = 1;
        Pestaña nuevaPestaña = new Pestaña();
        Galeria inicio;
        Galeria final;
        List<Error> errores = new List<Error>();
        Galeria temporal;
        ListaCircularGaleria lg = new ListaCircularGaleria();
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
                DataTable dt = new DataTable();
                TablaTransiciones.DataSource = dt;
                TablaTransiciones.Update();
            String text = "";
            TabPage tp = tabControl1.SelectedTab;
            foreach (Control o in tp.Controls)
            {
                if (o is RichTextBox)
                {
                    text = o.Text;
                    RichTextBox r = (RichTextBox)o;
                    Analizador lexico = new Analizador();
                    lg.vaciarLista();
                    lexico.analizadorLexico(text, lg);
                        inicio = lg.InicioLista;
                        final = lg.FinalLista;
                        temporal = lg.FinalLista;
                    iniciarGaleria();
                        Probar_Lexemas pl = new Probar_Lexemas();
                        Consola.Text = pl.prueba(inicio,lexico.getListaLexemas(),lexico.getListaConjunto());
                        errores = pl.Errores;
                }
            }
            MessageBox.Show("Anlizado Correcamente");
        }
            catch (Exception ex)
             {
                 MessageBox.Show("Error: " + ex);
             }
}
        public void iniciarGaleria()
        {
            Galeria aux = temporal;
            String ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            String afn = ruta + "\\" + aux.Nombre + ".png ";
            String afd = ruta + "\\" + aux.Nombre + "_AFD.png ";
            mostrarImagen(afd, afn, aux.Nombre);
            DataTable dt = new DataTable();
            dt.Columns.Add("Estados");
            for (int i = 0; i < aux.Simbolos.Count; i++)
            {
                dt.Columns.Add(aux.Simbolos.ElementAt(i).ToString());
            }
            
             for (int i = 0; i < aux.Estados.Count; i++)
             {
                DataRow dr = dt.NewRow();
                String estado = "" + aux.Estados.ElementAt(i).EstadoInicial;
                if (aux.Estados.ElementAt(i).Aceptacion)
                {
                    estado += "*";
                }
                dr["Estados"] = estado;
                for (int j = 0; j < aux.Estados.ElementAt(i).Transiciones.Count; j++)
                {
                    dr[aux.Estados.ElementAt(i).Transiciones.ElementAt(j).Simbolo] = aux.Estados.ElementAt(i).Transiciones.ElementAt(j).Estado;
                }
                dt.Rows.Add(dr);
             }
            TablaTransiciones.DataSource = dt;
            TablaTransiciones.Update();
        }
        public void mostrarImagen(String afd, String afn, String nombre)
        {
            Expresion.Text = nombre;
            FileStream fs = new FileStream(afn, FileMode.Open, FileAccess.Read);
            
            AFN.Image = System.Drawing.Image.FromStream(fs);
            AFN.SizeMode = PictureBoxSizeMode.StretchImage;
            fs.Close();
            FileStream fs2 = new FileStream(afd, FileMode.Open, FileAccess.Read);
            AFD.Image = System.Drawing.Image.FromStream(fs2);
            AFD.SizeMode = PictureBoxSizeMode.StretchImage;
            fs.Close();
        }
        private void guardarTokensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Analizador lexico = new Analizador();
            lexico.Html_Tokens();
        }

        private void guardarErroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Analizador lexico = new Analizador();
            lexico.Html_Errores();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                temporal = temporal.Anterior;
                DataTable dt = new DataTable();
                TablaTransiciones.DataSource = dt;
                TablaTransiciones.Update();
                iniciarGaleria();
            }
            catch(Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                temporal = temporal.Siguiente;
                DataTable dt = new DataTable();
                TablaTransiciones.DataSource = dt;
                TablaTransiciones.Update();
                iniciarGaleria();
            }
            catch (Exception ex)
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void errorLexicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream(ruta + "\\ReporteErrores.pdf", FileMode.OpenOrCreate));
                

                doc.Open();
                Paragraph p = new Paragraph("Reporte Errores");
                p.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLUE);
                doc.Add(p);
                PdfPTable pt = new PdfPTable(2);
                pt.AddCell("Nombre De la Expresion");
                pt.AddCell("Caracter de Error");

                for (int i = 0; i < errores.Count; i++)
                {
                    pt.AddCell(errores.ElementAt(i).NombreExp);
                    pt.AddCell(errores.ElementAt(i).getCaracter());
                }
                doc.Add(pt);
                doc.Close();
                System.Diagnostics.Process.Start(ruta + "\\ReporteErrores.pdf");
            }
            catch (Exception ex)
            {

            }
        }
    }
}
