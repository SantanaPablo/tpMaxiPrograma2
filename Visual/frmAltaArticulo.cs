using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual
{
    public partial class frmAltaArticulo : Form
    {   
        private Articulo articulo = null;
        private OpenFileDialog imagen = null;
        string imagenAntigua;

        
        public frmAltaArticulo()
        {
            InitializeComponent();
        }
        public frmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {      
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio= new CategoriaNegocio();  
            try
            {
                cboMarca.DataSource = marcaNegocio.listarMarcas();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";
                cboCategoria.DataSource =  categoriaNegocio.listarCategorias();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";
                

                if (articulo != null)
                {
                    txbCodigo.Text = articulo.codigo;
                    txbNombre.Text = articulo.nombre;
                    txbDescripcion.Text = articulo.nombre;
                    txbImagenUrl.Text = articulo.imagenUrl;
                    nudPrecio.Value = articulo.precio;
                    cboMarca.SelectedValue= articulo.marca.id;
                    cboCategoria.SelectedValue = articulo.categoria.id;
                    if (File.Exists(articulo.imagenUrl)) { imagenAntigua = articulo.imagenUrl; }
                    cargarImagen(articulo.imagenUrl);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                
                if (articulo== null)articulo = new Articulo();

                articulo.codigo = txbCodigo.Text;
                articulo.nombre = txbNombre.Text;
                articulo.descripcion = txbDescripcion.Text;
                articulo.precio = nudPrecio.Value;
                articulo.imagenUrl = txbImagenUrl.Text;
               
                
                articulo.marca = (Marca)cboMarca.SelectedItem;
                articulo.categoria = (Categoria)cboCategoria.SelectedItem;

                if (txbCodigo.Text == "" || txbNombre.Text == "") { MessageBox.Show("Faltan completar campos obligatorios"); }

                else if (articulo.id != 0)
                {
                    
                    articuloNegocio.ModificarArticulo(articulo);
                    cargarImagen("");
                    if (articulo.imagenUrl != imagenAntigua && File.Exists(imagenAntigua)) 
                    {
                        MessageBox.Show($"Artículo: Modificado");
                        File.Delete(imagenAntigua);
                        
                    }
                    this.Close();
                }
                else
                {
                    
                    articuloNegocio.AgregarArticulo(articulo);
                    
                    this.Close();


                }

                
            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally {
                
               
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (imagen != null) 
            {
                File.Delete("\\Imagenes\\" + imagen.SafeFileName);
            }
            this.Close();
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxArticulo.Load("https://static.vecteezy.com/system/resources/thumbnails/002/718/799/small/sad-emoji-face-classic-line-style-icon-free-vector.jpg");
            }
        }
        private void btnCargarImagen_Click(object sender, EventArgs e)
        {   
            imagen = new OpenFileDialog();
            imagen.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif";
            
            if (imagen.ShowDialog() == DialogResult.OK)
            {
                
                cargarImagen(imagen.FileName);
                File.Copy(imagen.FileName, "\\Imagenes\\" + imagen.SafeFileName, true);
                txbImagenUrl.Text = "\\Imagenes\\" + imagen.SafeFileName;
            }
            else imagen = null;
            

        }

        private void guardarImagen()
        {
            try
            {             
                  File.Copy("\\Imagenes\\" + imagen.SafeFileName, "\\Imagenes\\" + $"{articulo.id}imagen", true);     
                  
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
