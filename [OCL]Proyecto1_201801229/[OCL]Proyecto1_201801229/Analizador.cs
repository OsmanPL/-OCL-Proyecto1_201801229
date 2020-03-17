using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


using System.Windows.Forms;

namespace _OCL_Proyecto1_201801229
{

    class Analizador
    {
        ArrayList tokens;
        static private List<Token> listaTokens;
        private String retornar;
        public int estadoT;
        String anterior = "";
        String ant = "";

        //errores tokens
        static private List<Errores> listaErrores;

        //Listas de Conjuntos, expresiones y lexemas
        static private List<Conjunto> listaConjuntos;
        static private List<Expresion> listaExpresiones;
        static private List<Lexema> listaLexemas;

        bool conjunto = false;
        bool expresion = false;
        String idconj = "", idexp = "", idlexema = "", exp="", conj="", lex="";
        public Analizador()
        {
            listaTokens = new List<Token>();
            tokens = new ArrayList();
            listaErrores = new List<Errores>();
            listaConjuntos = new List<Conjunto>();
            listaExpresiones = new List<Expresion>();
            listaLexemas = new List<Lexema>();

            //Palabras Reservadas
            tokens.Add("CONJ");
            // ~ hola
        }

        public void Token(String lexema, String idToken, int fila, int columna, int indice)
        {
            Token tok = new Token(lexema, idToken, fila, columna, indice);
            listaTokens.Add(tok);
        }

        public void Error(String descripcion, String caracter, int fila, int columna)
        {

            Errores error = new Errores(descripcion, caracter, fila, columna);
            listaErrores.Add(error);
        }

        public void analizadorLexico(String codigo)
        {
            int estado = 0;
            int columna = 0;
            int fila = 1;
            string lexema = "";
            Char c;
            codigo = codigo + " ";
            for (int i = 0; i < codigo.Length; i++)
            {
                c = codigo[i];
                columna++;
                switch (estado)
                {
                    case 0:
                        if (Char.IsLetter(c))
                        {
                            lexema += c;
                            estado = 1;
                        }
                        else if (c=='-')
                        {
                            lexema += c;
                            Token(lexema, "Guion", fila, columna, i - lexema.Length);
                            lexema = "";
                            estado = 2;
                        }
                        else if (c==';')
                        {
                            lexema += c;
                            Token(lexema, "Punto y Coma", fila, columna, i - lexema.Length);
                            lexema = "";
                            estado = 0;
                            conjunto = false;
                            expresion = false;
                            idconj = "";
                            idexp = "";
                            idlexema = "";
                            exp = "";
                            conj = ""; 
                            lex = "";
                        }
                        else if (c == ' ')
                        {
                            columna++;
                            estado = 0;
                        }
                        else if (c == '\n')
                        {
                            fila++;
                            estado = 0;
                            columna = 0;
                        }
                        else if (c == ':')
                        {
                            lexema += c;
                            Token(lexema, "Dos Puntos", fila, columna, i - lexema.Length);
                            lexema = "";
                            estado = 0;
                        }
                        else if (c == '\u0022')
                        {
                            lexema += c;
                            Token(lexema, "Comillas", fila, columna, i - lexema.Length);
                            lexema = "";
                            estado = 4;
                        }
                        else if (c == '/')
                        {
                            lexema += c;
                            estado = 5;
                        }
                        else if (c == '<')
                        {
                            lexema += c;
                            estado = 7;
                        }
                        else
                        {
                            lexema += c;
                            Error("Caracter Desconocido", lexema, fila, columna);
                            lexema = "";
                            estado = 0;
                        }
                        break;
                    case 1:
                        if (Char.IsLetterOrDigit(c))
                        {
                            lexema += c;
                            estado = 1;
                        }
                        else
                        {
                            Boolean reser = false;
                            reser = palabraReservada(lexema);
                            if (reser)
                            {
                                Token(lexema, "Palabra Reservada", fila, columna, i - lexema.Length);
                            }
                            else
                            {

                                Token(lexema, "Identificador", fila, columna, i - lexema.Length);
                            }
                            estado = 0;
                            i--;
                            columna--;
                            lexema = "";
                        }
                        break;
                    case 2:
                        if (c == '>')
                        {
                            lexema += c;
                            Token(lexema, "Mayor que", fila, columna, i - lexema.Length);
                            lexema = "";
                            estado = 3;
                        }
                        else
                        {
                            estado = 0;
                        }
                        break;
                    case 3:
                        if (c == ';')
                        {
                            if (conjunto == true)
                            {
                                conj = lexema;
                                Conjunto nuevoConjunto = new Conjunto(idconj, conj);
                                listaConjuntos.Add(nuevoConjunto);
                                Token(lexema, "Conjunto " + idconj, fila, columna, i - lexema.Length);
                            }
                            else if (conjunto == false)
                            {
                                exp = lexema;
                                Expresion nuevaExpresion = new Expresion(idexp, exp);
                                listaExpresiones.Add(nuevaExpresion);
                                Token(lexema, "Expresion Regular " + idexp, fila, columna, i - lexema.Length);
                            }

                            lexema = "";
                            estado = 0;
                            columna--;
                            i--;
                        }
                        else
                        {
                            lexema += c;
                        }
                        break;
                    case 4:
                        if (c == '\u0022')
                        {
                            if (conjunto == false)
                            {
                                lex = lexema;
                                Lexema nuevoLexema = new Lexema(idlexema, lex);
                                listaLexemas.Add(nuevoLexema);
                                Token(lexema, "Lexema - " + idlexema, fila, columna, i - lexema.Length);
                                lexema = "";
                            }
                            lexema += c;
                            Token(lexema, "Comillas", fila, columna, i - lexema.Length);
                            lexema = "";
                            estado = 0;
                        }
                        else
                        {
                            lexema += c;
                        }
                        break;
                    case 5:
                        if (c == '/')
                        {
                            lexema += c;
                            estado = 6;
                        }
                        else
                        {
                            lexema += c;
                            Error("Caracter Desconocido", lexema, fila, columna);
                            lexema = "";
                            estado = 0;
                        }
                        break;
                    case 6:
                        if (c == '\n')
                        {
                            Token(lexema, "Comentario Simple", fila, columna, i - lexema.Length);
                            lexema = "";
                            estado = 0;
                        }
                        else
                        {
                            lexema += c;
                        }
                        break;
                    case 7:
                        if (c == '!')
                        {
                            lexema += c;
                            Token(lexema, "Abrir Comentario Multilinea", fila, columna, i - lexema.Length);
                            lexema = "";
                            estado = 8;
                        }
                        else
                        {
                            lexema += c;
                            Error("Caracter Desconocido", lexema, fila, columna);
                            lexema = "";
                            estado = 0;
                        }
                        break;
                    case 8:
                        if (c == '!')
                        {
                            Token(lexema, "Comentario Multilinea", fila, columna, i - lexema.Length);
                            lexema = "";
                            lexema += c;
                            estado = 9;
                        }
                        else
                        {
                            lexema += c;
                        }
                        break;
                    case 9:
                        if (c == '>')
                        {
                            lexema += c;
                            Token(lexema, "Cerrar Comentario Multilinea", fila, columna, i - lexema.Length);
                            lexema = "";
                            estado = 0;
                        }
                        else
                        {
                            lexema += c;
                            Error("Caracter Desconocido", lexema, fila, columna);
                            lexema = "";
                            estado = 0;
                        }
                        break;
                }
            }
            if (listaErrores.Count==0)
            {
                Generar_Thompson gt = new Generar_Thompson();
                gt.separarNodos(listaExpresiones);
            }
            else
            {
                MessageBox.Show("Existen Errores Lexicos");
            }
        }
     
        public bool palabraReservada(String palabra)
        {
            if (palabra=="CONJ")
            {
                conjunto = true;
                return true;
            }
            else
            {
                if (conjunto == true)
                {
                    idconj = palabra;
                }
                else if (conjunto == false)
                {
                    idexp = palabra;
                    idlexema = palabra;
                }
                return false;
            }
        }
       
        public void generarReportes()
        {
            Html_Tokens();
            Html_Errores();
        }
        public void Html_Errores()
        {

            String Contenido_html;
            Contenido_html = "<html>" +
            "<body>" +
            "<h1 align='center'>ERRORES ENCONTRADOS</h1></br>" +
            "<table cellpadding='10' border = '1' align='center'>" +
            "<tr>" +
            "<td><strong>No." +
            "</strong></td>" +

            "<td><strong>Descripcion" +
            "</strong></td>" +

            "<td><strong>Error" +
            "</strong></td>" +

            "<td><strong>Fila" +
            "</strong></td>" +

            "<td><strong>Columna" +
            "</strong></td>" +

            "</tr>";

            String Cad_tokens = "";
            String tempo_tokens;

            for (int i = 0; i < listaErrores.Count; i++)
            {
                Errores sen_pos = listaErrores.ElementAt(i);

                tempo_tokens = "";
                tempo_tokens = "<tr>" +
                "<td><strong>" + (i + 1).ToString() +
                "</strong></td>" +

                "<td>" + sen_pos.getDescripcion() +
                "</td>" +

                "<td>" + sen_pos.getCaracter() +
                "</td>" +

                "<td>" + sen_pos.getFila() +
                "</td>" +

                "<td>" + sen_pos.getColumna() +
                "</td>" +

                "</tr>";
                Cad_tokens = Cad_tokens + tempo_tokens;

            }

            Contenido_html = Contenido_html + Cad_tokens +
            "</table>" +
            "</body>" +
            "</html>";

            File.WriteAllText("Reporte de Errores.html", Contenido_html);
            System.Diagnostics.Process.Start("Reporte de Errores.html");


        }

        public void Html_Tokens()
        {

            String Contenido_html;
            Contenido_html = "<html>" +
            "<body>" +
            "<h1 align='center'>LISTADOS DE TOKENS</h1></br>" +
            "<table cellpadding='10' border = '1' align='center'>" +
            "<tr>" +
            "<td><strong>No." +
            "</strong></td>" +

            "<td><strong>Lexema" +
            "</strong></td>" +

           "<td><strong>Fila" +
            "</strong></td>" +

            "<td><strong>Columna" +
            "</strong></td>" +

             "<td><strong>Token" +
            "</strong></td>" +

            "</tr>";

            String Cad_tokens = "";
            String tempo_tokens;

            for (int i = 0; i < listaTokens.Count; i++)
            {
                Token sen_pos = listaTokens.ElementAt(i);

                tempo_tokens = "";
                tempo_tokens = "<tr>" +
                "<td><strong>" + (i + 1).ToString() +
                "</strong></td>" +

                "<td>" + sen_pos.getLexema() +
                "</td>" +

                "<td>" + sen_pos.getFila() +
                "</td>" +

                "<td>" + sen_pos.getColumna() +
                "</td>" +

                "<td>" + sen_pos.getIdToken() +
                "</td>" +

                "</tr>";
                Cad_tokens = Cad_tokens + tempo_tokens;

            }

            Contenido_html = Contenido_html + Cad_tokens +
            "</table>" +
            "</body>" +
            "</html>";
            File.WriteAllText("Reporte de Tokens.html", Contenido_html);
            System.Diagnostics.Process.Start("Reporte de Tokens.html");


        }
        public String getRetornar()
        {
            return this.retornar;
        }

        public List<Token> getListaTokens()
        {
            return listaTokens;
        }
        public List<Errores> getListaErroes()
        {
            return listaErrores;
        }

    }
}
