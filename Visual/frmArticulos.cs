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
        private Articulo articuloaux;
        private ArticuloNegocio negocio = new ArticuloNegocio();
        private List<Articulo> listaBuscar = new List<Articulo>();


        public frmArticulos()
        {
            InitializeComponent();
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            cargar();
            setearColumnas();
        }
        private void cargar()
        {

            try
            {
                listaArticulos = negocio.listarArticulos();
                dgvArticulos.DataSource = listaArticulos;
                cargarLabels();
                cargarImagen(articulo.imagenUrl);
                chkBusqAvanzada.Checked = false;
                txbBuscar.Text = "";
                if (listaArticulos.Count != 0)
                {
                    btnEliminar.Enabled = true;
                    btnModificar.Enabled = true;
                }

                else if (listaArticulos.Count == 0)
                {
                    btnEliminar.Enabled = false;
                    btnModificar.Enabled = false;
                    cargarImagen("");
                }

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

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                cargarLabels();
                cargarImagen(articulo.imagenUrl);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        //Botones
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                cargarImagen("");
                frmAltaArticulo nuevo = new frmAltaArticulo();
                nuevo.Text = "Alta Artículo";
                nuevo.ShowDialog();
                cargar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                cargarImagen("");
                articulo = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                articuloaux = new Articulo();
                articuloaux.nombre = articulo.nombre;
                frmAltaArticulo modificar = new frmAltaArticulo(articulo);
                modificar.Text= "Modificando";
                modificar.ShowDialog();
                cargar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }

        private void dgvArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnModificar_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                articulo = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                DialogResult respuesta = MessageBox.Show("¿Reciclar?", "Reciclar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    negocio.ReciclarArticulo(articulo);
                    cargar();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            
        }

        ///////////////////////////////////////////////////////////////       

        //Búsquedas
        private void txbBuscar_TextChanged(object sender, EventArgs e)
        {
            
            string busqueda = txbBuscar.Text;
            try
            {
                if (chkBusqAvanzada.Checked == false || cboFiltro.Text == "")
                {
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

                else
                {
                    bool isNumeric = int.TryParse(txbBuscar.Text, out _);
                    string criterio = cboFiltro.Text;
                    switch (criterio)
                    {
                        case "Comienza con":
                            listaBuscar = listaArticulos.FindAll(x => x.codigo.ToUpper().StartsWith(busqueda.ToUpper()) || x.nombre.ToUpper().StartsWith(busqueda.ToUpper()) || x.descripcion.ToUpper().StartsWith(busqueda.ToUpper()));

                            break;
                        case "Termina con":
                            listaBuscar = listaArticulos.FindAll(x => x.codigo.ToUpper().EndsWith(busqueda.ToUpper()) || x.nombre.ToUpper().EndsWith(busqueda.ToUpper()) || x.descripcion.ToUpper().EndsWith(busqueda.ToUpper()));
                            break;
                        case "Precio Mayor a":

                            if (isNumeric) { listaBuscar = listaArticulos.FindAll(x => x.precio > int.Parse(busqueda)); }
                            else
                            {
                                txbBuscar.Text = "0";
                                MessageBox.Show("Solo Números para buscar por precio");
                                listaBuscar = listaArticulos.FindAll(x => x.precio > int.Parse("0"));

                            }

                            break;

                        case "Precio Menor a":

                            if (isNumeric)
                            {
                                if (txbBuscar.Text == "") { txbBuscar.Text = "0"; }
                                listaBuscar = listaArticulos.FindAll(x => x.precio < int.Parse(busqueda));

                            }
                            else
                            {
                                txbBuscar.Text = "0";
                                MessageBox.Show("Solo Números para buscar por precio");
                                listaBuscar = listaArticulos.FindAll(x => x.precio < int.Parse("0"));
                            }
                            break;
                        case "Precio Igual a":
                            if (isNumeric) { listaBuscar = listaArticulos.FindAll(x => x.precio == int.Parse(busqueda)); }
                            else
                            {
                                txbBuscar.Text = "0";
                                MessageBox.Show("Solo Números para buscar por precio");
                                listaBuscar = listaArticulos.FindAll(x => x.precio == int.Parse("0"));
                            }
                            break;



                    }

                    dgvArticulos.DataSource = listaBuscar;


                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void chkBusqAvanzada_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkBusqAvanzada.Checked)
                {
                    cboFiltro.Enabled = true;
                    cboFiltro.Items.Add("Comienza con");
                    cboFiltro.Items.Add("Termina con");
                    //cboFiltro.Items.Add("Contiene");
                    cboFiltro.Items.Add("Precio Mayor a");
                    cboFiltro.Items.Add("Precio Menor a");
                    cboFiltro.Items.Add("Precio Igual a");
                }
                else
                {
                    cboFiltro.Items.Clear();
                    cboFiltro.Text = "";
                    cboFiltro.Enabled = false;
                    txbBuscar.Text = "";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }

        private void cboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string busqueda = txbBuscar.Text;
            string criterio = cboFiltro.Text;

            try
            {
                bool isNumeric = int.TryParse(txbBuscar.Text, out _);
                switch (criterio)
                {
                    case "Comienza con":
                        listaBuscar = listaArticulos.FindAll(x => x.codigo.ToUpper().StartsWith(busqueda.ToUpper()) || x.nombre.ToUpper().StartsWith(busqueda.ToUpper()) || x.descripcion.ToUpper().StartsWith(busqueda.ToUpper()));

                        break;
                    case "Termina con":
                        listaBuscar = listaArticulos.FindAll(x => x.codigo.ToUpper().EndsWith(busqueda.ToUpper()) || x.nombre.ToUpper().EndsWith(busqueda.ToUpper()) || x.descripcion.ToUpper().EndsWith(busqueda.ToUpper()));
                        break;
                    case "Precio Mayor a":
                        
                        if (isNumeric) { listaBuscar = listaArticulos.FindAll(x => x.precio > int.Parse(busqueda)); }
                        else 
                        { 
                            txbBuscar.Text = "0";
                            //MessageBox.Show("Solo Números para buscar por precio"); 
                            listaBuscar = listaArticulos.FindAll(x => x.precio > int.Parse("0"));
                            
                        }

                            break;
                        
                    case "Precio Menor a":
                        
                        if (isNumeric) 
                        {
                            if (txbBuscar.Text == "") { txbBuscar.Text = "0"; }
                            listaBuscar = listaArticulos.FindAll(x => x.precio < int.Parse(busqueda));
                            
                        }
                        else 
                        {
                            txbBuscar.Text = "0";
                            //MessageBox.Show("Solo Números para buscar por precio");
                            listaBuscar = listaArticulos.FindAll(x => x.precio < int.Parse("0"));
                        }
                        break;
                    case "Precio Igual a":
                        if (isNumeric) { listaBuscar = listaArticulos.FindAll(x => x.precio == int.Parse(busqueda)); }
                        else 
                        {
                            txbBuscar.Text = "0";
                            //MessageBox.Show("Solo Números para buscar por precio");
                            listaBuscar = listaArticulos.FindAll(x => x.precio == int.Parse("0"));
                        }
                        break;

                    //default:
                    //    listaBuscar = listaArticulos.FindAll(x => x.codigo.ToUpper().Contains(busqueda.ToUpper()) || x.nombre.ToUpper().Contains(busqueda.ToUpper()) || x.descripcion.ToUpper().Contains(busqueda.ToUpper()));
                    //    break;

                }
               
                dgvArticulos.DataSource = listaBuscar;

            }
            catch (Exception ex )
            {

                throw ex;
            }
        }

        

        //////////////////////////////////////////////////////////////////
    }
}
