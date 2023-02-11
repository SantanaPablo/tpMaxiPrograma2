using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual
{
    public partial class frmPapelera : Form
    {
        private List<Articulo> listaArticulos = new List<Articulo>();
        private Articulo articulo = new Articulo();
        private ArticuloNegocio negocio = new ArticuloNegocio();
        public frmPapelera()
        {
            InitializeComponent();
        }

        private void cargar()
        {

            try
            {
                listaArticulos = negocio.listaPapelera();
                dgvPapelera.DataSource = listaArticulos;
                if (dgvPapelera.CurrentRow != null) { articulo = (Articulo)dgvPapelera.CurrentRow.DataBoundItem; }


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
                dgvPapelera.Columns["id"].Visible = false;
                dgvPapelera.Columns["ImagenUrl"].Visible = false;
                dgvPapelera.Columns["Codigo"].Width = 50;
                dgvPapelera.Columns["Descripcion"].Visible = false;
                dgvPapelera.RowHeadersVisible = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void frmPapelera_Load(object sender, EventArgs e)
        {
            cargar();
            setearColumnas();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            articulo = (Articulo)dgvPapelera.CurrentRow.DataBoundItem;
            DialogResult respuesta = MessageBox.Show("¿Restaurar?", "Restaurar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                negocio.ReciclarArticulo(articulo);
                //Restaura el artículo con el mismo metódo, negativo por negativo
                //Con otra base de datos, usaría el campo Activo 0-1
                cargar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            articulo = (Articulo)dgvPapelera.CurrentRow.DataBoundItem;
            DialogResult respuesta = MessageBox.Show("¿Eliminar definitivamente?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                negocio.eliminarDefinitivo(articulo.id);
                cargar();
            }

        }
    }
}
