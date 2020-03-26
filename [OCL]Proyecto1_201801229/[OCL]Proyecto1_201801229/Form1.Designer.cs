namespace _OCL_Proyecto1_201801229
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarAnalisisLexicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarTokensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarErroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorLexicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.AFN = new System.Windows.Forms.PictureBox();
            this.AFD = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TablaTransiciones = new System.Windows.Forms.DataGridView();
            this.Expresion = new System.Windows.Forms.Label();
            this.Consola = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AFN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AFD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablaTransiciones)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.analizarToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.generarToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // generarToolStripMenuItem
            // 
            this.generarToolStripMenuItem.Name = "generarToolStripMenuItem";
            this.generarToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.generarToolStripMenuItem.Text = "Agregar Pestaña";
            this.generarToolStripMenuItem.Click += new System.EventHandler(this.generarToolStripMenuItem_Click);
            // 
            // analizarToolStripMenuItem
            // 
            this.analizarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarAnalisisLexicoToolStripMenuItem,
            this.guardarTokensToolStripMenuItem,
            this.guardarErroresToolStripMenuItem});
            this.analizarToolStripMenuItem.Name = "analizarToolStripMenuItem";
            this.analizarToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.analizarToolStripMenuItem.Text = "Herramientas";
            this.analizarToolStripMenuItem.Click += new System.EventHandler(this.analizarToolStripMenuItem_Click);
            // 
            // iniciarAnalisisLexicoToolStripMenuItem
            // 
            this.iniciarAnalisisLexicoToolStripMenuItem.Name = "iniciarAnalisisLexicoToolStripMenuItem";
            this.iniciarAnalisisLexicoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.iniciarAnalisisLexicoToolStripMenuItem.Text = "Cargar Thompson";
            this.iniciarAnalisisLexicoToolStripMenuItem.Click += new System.EventHandler(this.iniciarAnalisisLexicoToolStripMenuItem_Click);
            // 
            // guardarTokensToolStripMenuItem
            // 
            this.guardarTokensToolStripMenuItem.Name = "guardarTokensToolStripMenuItem";
            this.guardarTokensToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.guardarTokensToolStripMenuItem.Text = "Guardar Tokens";
            this.guardarTokensToolStripMenuItem.Click += new System.EventHandler(this.guardarTokensToolStripMenuItem_Click);
            // 
            // guardarErroresToolStripMenuItem
            // 
            this.guardarErroresToolStripMenuItem.Name = "guardarErroresToolStripMenuItem";
            this.guardarErroresToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.guardarErroresToolStripMenuItem.Text = "Guardar Errores";
            this.guardarErroresToolStripMenuItem.Click += new System.EventHandler(this.guardarErroresToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.errorLexicoToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // errorLexicoToolStripMenuItem
            // 
            this.errorLexicoToolStripMenuItem.Name = "errorLexicoToolStripMenuItem";
            this.errorLexicoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.errorLexicoToolStripMenuItem.Text = "Error Lexico";
            this.errorLexicoToolStripMenuItem.Click += new System.EventHandler(this.errorLexicoToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(481, 243);
            this.tabControl1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(771, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Anterior";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1098, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Siguiente";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AFN
            // 
            this.AFN.Location = new System.Drawing.Point(632, 58);
            this.AFN.Name = "AFN";
            this.AFN.Size = new System.Drawing.Size(710, 214);
            this.AFN.TabIndex = 5;
            this.AFN.TabStop = false;
            // 
            // AFD
            // 
            this.AFD.Location = new System.Drawing.Point(632, 278);
            this.AFD.Name = "AFD";
            this.AFD.Size = new System.Drawing.Size(710, 214);
            this.AFD.TabIndex = 6;
            this.AFD.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(541, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "Automata Finito\r\n No Determinista";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(485, 363);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Automata Finito Determinista";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(514, 588);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tabla de Transiciones";
            // 
            // TablaTransiciones
            // 
            this.TablaTransiciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaTransiciones.Location = new System.Drawing.Point(632, 523);
            this.TablaTransiciones.Name = "TablaTransiciones";
            this.TablaTransiciones.Size = new System.Drawing.Size(710, 214);
            this.TablaTransiciones.TabIndex = 11;
            // 
            // Expresion
            // 
            this.Expresion.AutoSize = true;
            this.Expresion.Location = new System.Drawing.Point(909, 32);
            this.Expresion.Name = "Expresion";
            this.Expresion.Size = new System.Drawing.Size(133, 13);
            this.Expresion.TabIndex = 12;
            this.Expresion.Text = "Nombre Expresion Regular";
            this.Expresion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Consola
            // 
            this.Consola.Enabled = false;
            this.Consola.Location = new System.Drawing.Point(12, 305);
            this.Consola.Name = "Consola";
            this.Consola.Size = new System.Drawing.Size(467, 419);
            this.Consola.TabIndex = 13;
            this.Consola.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(207, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Consola";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Consola);
            this.Controls.Add(this.Expresion);
            this.Controls.Add(this.TablaTransiciones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AFD);
            this.Controls.Add(this.AFN);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AFN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AFD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablaTransiciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarAnalisisLexicoToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem guardarTokensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarErroresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorLexicoToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox AFN;
        private System.Windows.Forms.PictureBox AFD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView TablaTransiciones;
        private System.Windows.Forms.Label Expresion;
        private System.Windows.Forms.RichTextBox Consola;
        private System.Windows.Forms.Label label5;
    }
}

