using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;
using static System.Net.Mime.MediaTypeNames;

namespace Visual
{
    public partial class frmArticulos : Form
    {

        private List<Articulo> listaArticulos = new List<Articulo>();
        private Articulo articulo = new Articulo();
        private ArticuloNegocio negocio = new ArticuloNegocio();
        

        public frmArticulos()
        {
            InitializeComponent();
        }

        private void cargar()
        {

            try
            {
                listaArticulos = negocio.listarArticulos();
                if (listaArticulos.Count != dgvArticulos.RowCount) { dgvArticulos.DataSource = listaArticulos; }
                cargarLabels();
                cargarImagen(articulo.imagenUrl);
                chkBusqAvanzada.Checked = false;
                txbBuscar.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void setearColumnas()
        {
            try
            {
                dgvArticulos.Columns["id"].Visible = false;
                dgvArticulos.Columns["ImagenUrl"].Visible = false;
                dgvArticulos.Columns["Codigo"].Width = 50;
                dgvArticulos.Columns["Descripcion"].Visible = false;
                dgvArticulos.RowHeadersVisible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
           
        }
        private void cargarLabels()
        {
            try
            {
                if (dgvArticulos.CurrentRow != null) { articulo = (Articulo)dgvArticulos.CurrentRow.DataBoundItem; }
                lblDescripcion.Text = $"Descripción: {articulo.descripcion}";
                lblCodigo.Text = $"Código: {articulo.codigo}";
                lblNombre.Text = $"Modelo: {articulo.nombre}";
                lblMarca.Text = $"Marca: {articulo.marca}";
                lblPrecio.Text = $"$ {articulo.precio}";
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (Exception)
            {
                pbxArticulo.Load("https://static.vecteezy.com/system/resources/thumbnails/002/718/799/small/sad-emoji-face-classic-line-style-icon-free-vector.jpg");
            }
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            
            cargar();
            if (listaArticulos.Count != 0) 
            { 
                setearColumnas();
                btnEliminar.Enabled= true;
                btnModificar.Enabled= true;
            }

            else if (listaArticulos.Count == 0)
            {
                btnEliminar.Enabled= false;
                btnModificar.Enabled= false;
            }






        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            cargarLabels();
            cargarImagen(articulo.imagenUrl);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaArticulo nuevo = new frmAltaArticulo();
            nuevo.ShowDialog();
            cargar();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
            cargarImagen("");
            articulo = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmAltaArticulo modificar = new frmAltaArticulo(articulo);
            modificar.ShowDialog();
            cargar();
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            articulo = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            DialogResult respuesta = MessageBox.Show("¿Reciclar?", "Reciclar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                negocio.ReciclarArticulo(articulo);
                cargar();
            }
        }

        private void txbBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaBuscar;
            string busqueda = txbBuscar.Text;

            if (busqueda.Length >= 3)
            {
                listaBuscar = listaArticulos.FindAll(x => x.codigo.ToUpper().Contains(busqueda.ToUpper()) || x.nombre.ToUpper().Contains(busqueda.ToUpper()) || x.descripcion.ToUpper().Contains(busqueda.ToUpper()));
            }
            else
            {
                listaBuscar = listaArticulos;
            }

            if (listaBuscar.Count == 0) 
            { 
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
            }

            else 
            {
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
            }

            dgvArticulos.DataSource = listaBuscar;
        }

        private void chkBusqAvanzada_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBusqAvanzada.Checked)
            {
                cboFiltro.Items.Add("Comienza con ");
                cboFiltro.Items.Add("Termina con ");
                cboFiltro.Items.Add("Contiene ");
                cboFiltro.Items.Add("Precio Mayor a");
                cboFiltro.Items.Add("Precio Menor a");
                cboFiltro.Items.Add("Precio igual a");
            }
            else { cboFiltro.Items.Clear(); cboFiltro.Text = ""; }



        }
    }
}
