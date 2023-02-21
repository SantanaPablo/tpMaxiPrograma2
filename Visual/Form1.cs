using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Dominio;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;

namespace Visual
{
    public partial class frmContenedor : Form
    {
        private Form form;
        private OpenFileDialog imagen = null;
        private string imagePerfil = "\\Imagenes\\" + "imPerfil";
        
        public frmContenedor()
        {
            InitializeComponent();
        }

        private void ColorBotones()
        {   
            //Color rojo = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            //Color azul = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            if (form == form as frmArticulos)
            {
                btnArticulos.BackColor = Colores.rojo;
                btnMarcas.BackColor = Colores.azul;
                btnCategorias.BackColor = Colores.azul;
                btnPapelera.BackColor = Colores.azul;
            }
            else if (form == form as frmCategorias)
            {
                btnArticulos.BackColor = Colores.azul;
                btnMarcas.BackColor = Colores.azul;
                btnCategorias.BackColor = Colores.rojo;
                btnPapelera.BackColor = Colores.azul;
            }
            else if (form == form as frmMarcas)
            {
                btnArticulos.BackColor = Colores.azul;
                btnMarcas.BackColor = Colores.rojo;
                btnCategorias.BackColor = Colores.azul;
                btnPapelera.BackColor = Colores.azul;
            }

            else if (form == form as frmPapelera)
            {
                btnArticulos.BackColor = Colores.azul;
                btnMarcas.BackColor = Colores.azul;
                btnCategorias.BackColor = Colores.azul;
                btnPapelera.BackColor = Colores.rojo;
            }

            
        }
        private void frmPanel(object frmpanel)
        {
            if (this.pnlContenedor.Controls.Count > 0) this.pnlContenedor.Controls.RemoveAt(0);
            form= frmpanel as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.pnlContenedor.Controls.Add(form);
            this.pnlContenedor.Tag= form;
            form.Show();
        }
        private void btnArticulos_Click(object sender, EventArgs e)
        {
            if (form != form as frmArticulos)
            {
                frmPanel(new frmArticulos());
                ColorBotones();
            }
        }
        private void btnMarcas_Click(object sender, EventArgs e)
        {
            if (form != form as frmMarcas)
            {
                frmPanel(new frmMarcas());
                ColorBotones();
            }
        }
        private void btnCategorias_Click(object sender, EventArgs e)
        {
            if (form != form as frmCategorias)
            {
                frmPanel(new frmCategorias());
                ColorBotones();
            }
        }
        private void btnPapelera_Click(object sender, EventArgs e)
        {
            if (form != form as frmPapelera)
            {
                frmPanel(new frmPapelera());
                ColorBotones();
            }
        }
        private void frmContenedor_Load(object sender, EventArgs e)
        {
            frmPanel(new frmArticulos());
            ColorBotones();
            cargarImagen(imagePerfil);
            
        }
        private void cargarImagen(string imagen)
        {
            try
            {   
                pbxPerfil.Load(imagen);  
               
            }
            catch (Exception)
            {
                pbxPerfil.Load("https://cdn.xxl.thumbs.canstockphoto.com/your-logo-here-placeholder-symbol-vector-your-logo-here-placeholder-symbol-vector-illustration-drawing_csp88853596.jpg");
            }
        }
        private void btnCargarImgPerfil_Click(object sender, EventArgs e)
        {
            
            btnCargarImgPerfil.Visible = false;
            Directory.CreateDirectory("\\Imagenes\\");
            imagen = new OpenFileDialog();
            imagen.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif";
            if (imagen.ShowDialog() == DialogResult.OK)
            {
                cargarImagen("");
                File.Copy(imagen.FileName, imagePerfil, true);
                
            }

            cargarImagen(imagePerfil);
        }
        private void pbxPerfil_Click(object sender, EventArgs e)
        {
            btnCargarImgPerfil.Visible = true;
        }

        private void btnCargarImgPerfil_MouseLeave(object sender, EventArgs e)
        {
            btnCargarImgPerfil.Visible = false;
        }
    }
}
