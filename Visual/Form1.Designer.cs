namespace Visual
{
    partial class frmContenedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContenedor));
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnPapelera = new System.Windows.Forms.Button();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.btnMarcas = new System.Windows.Forms.Button();
            this.btnArticulos = new System.Windows.Forms.Button();
            this.pnlTopMenu = new System.Windows.Forms.Panel();
            this.btnCargarImgPerfil = new System.Windows.Forms.Button();
            this.pbxPerfil = new System.Windows.Forms.PictureBox();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.pnlTopMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPerfil)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.pnlMenu.Controls.Add(this.btnPapelera);
            this.pnlMenu.Controls.Add(this.btnCategorias);
            this.pnlMenu.Controls.Add(this.btnMarcas);
            this.pnlMenu.Controls.Add(this.btnArticulos);
            this.pnlMenu.Controls.Add(this.pnlTopMenu);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(220, 611);
            this.pnlMenu.TabIndex = 1;
            // 
            // btnPapelera
            // 
            this.btnPapelera.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPapelera.FlatAppearance.BorderSize = 0;
            this.btnPapelera.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPapelera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPapelera.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPapelera.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPapelera.Image = global::Visual.Properties.Resources.papelera;
            this.btnPapelera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPapelera.Location = new System.Drawing.Point(0, 280);
            this.btnPapelera.Name = "btnPapelera";
            this.btnPapelera.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPapelera.Size = new System.Drawing.Size(220, 60);
            this.btnPapelera.TabIndex = 5;
            this.btnPapelera.Text = "Papelera de Reciclaje";
            this.btnPapelera.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPapelera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPapelera.UseVisualStyleBackColor = true;
            this.btnPapelera.Click += new System.EventHandler(this.btnPapelera_Click);
            // 
            // btnCategorias
            // 
            this.btnCategorias.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategorias.FlatAppearance.BorderSize = 0;
            this.btnCategorias.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorias.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategorias.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCategorias.Image = global::Visual.Properties.Resources.categorias;
            this.btnCategorias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorias.Location = new System.Drawing.Point(0, 220);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCategorias.Size = new System.Drawing.Size(220, 60);
            this.btnCategorias.TabIndex = 4;
            this.btnCategorias.Text = "Categorías";
            this.btnCategorias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategorias.UseVisualStyleBackColor = true;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // btnMarcas
            // 
            this.btnMarcas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMarcas.FlatAppearance.BorderSize = 0;
            this.btnMarcas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMarcas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarcas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarcas.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMarcas.Image = ((System.Drawing.Image)(resources.GetObject("btnMarcas.Image")));
            this.btnMarcas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMarcas.Location = new System.Drawing.Point(0, 160);
            this.btnMarcas.Name = "btnMarcas";
            this.btnMarcas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMarcas.Size = new System.Drawing.Size(220, 60);
            this.btnMarcas.TabIndex = 2;
            this.btnMarcas.Text = "Marcas";
            this.btnMarcas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMarcas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMarcas.UseVisualStyleBackColor = true;
            this.btnMarcas.Click += new System.EventHandler(this.btnMarcas_Click);
            // 
            // btnArticulos
            // 
            this.btnArticulos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnArticulos.FlatAppearance.BorderSize = 0;
            this.btnArticulos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnArticulos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArticulos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArticulos.ForeColor = System.Drawing.SystemColors.Control;
            this.btnArticulos.Image = global::Visual.Properties.Resources.articulos;
            this.btnArticulos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArticulos.Location = new System.Drawing.Point(0, 100);
            this.btnArticulos.Name = "btnArticulos";
            this.btnArticulos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnArticulos.Size = new System.Drawing.Size(220, 60);
            this.btnArticulos.TabIndex = 3;
            this.btnArticulos.Text = "Artículos";
            this.btnArticulos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArticulos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnArticulos.UseVisualStyleBackColor = true;
            this.btnArticulos.Click += new System.EventHandler(this.btnArticulos_Click);
            // 
            // pnlTopMenu
            // 
            this.pnlTopMenu.Controls.Add(this.btnCargarImgPerfil);
            this.pnlTopMenu.Controls.Add(this.pbxPerfil);
            this.pnlTopMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlTopMenu.Name = "pnlTopMenu";
            this.pnlTopMenu.Size = new System.Drawing.Size(220, 100);
            this.pnlTopMenu.TabIndex = 2;
            // 
            // btnCargarImgPerfil
            // 
            this.btnCargarImgPerfil.Location = new System.Drawing.Point(139, 74);
            this.btnCargarImgPerfil.Name = "btnCargarImgPerfil";
            this.btnCargarImgPerfil.Size = new System.Drawing.Size(75, 23);
            this.btnCargarImgPerfil.TabIndex = 0;
            this.btnCargarImgPerfil.Text = "Cambiar Imagen";
            this.btnCargarImgPerfil.UseVisualStyleBackColor = true;
            this.btnCargarImgPerfil.Visible = false;
            this.btnCargarImgPerfil.Click += new System.EventHandler(this.btnCargarImgPerfil_Click);
            // 
            // pbxPerfil
            // 
            this.pbxPerfil.Location = new System.Drawing.Point(55, 0);
            this.pbxPerfil.Name = "pbxPerfil";
            this.pbxPerfil.Size = new System.Drawing.Size(100, 100);
            this.pbxPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxPerfil.TabIndex = 0;
            this.pbxPerfil.TabStop = false;
            this.pbxPerfil.Click += new System.EventHandler(this.pbxPerfil_Click);
            this.pbxPerfil.MouseLeave += new System.EventHandler(this.pbxPerfil_MouseLeave);
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(220, 0);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(580, 611);
            this.pnlContenedor.TabIndex = 2;
            // 
            // frmContenedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 611);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlMenu);
            this.Name = "frmContenedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmContenedor_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlTopMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPerfil)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlTopMenu;
        private System.Windows.Forms.Button btnMarcas;
        private System.Windows.Forms.Button btnArticulos;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Button btnPapelera;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.PictureBox pbxPerfil;
        private System.Windows.Forms.Button btnCargarImgPerfil;
    }
}

