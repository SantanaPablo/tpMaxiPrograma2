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
    public partial class frmCategorias : Form
    {
        private List<Categoria> listaCategorias = new List<Categoria>();
        private Categoria categoria = new Categoria();
        private CategoriaNegocio negocio = new CategoriaNegocio();
        public frmCategorias()
        {
            InitializeComponent();
        }

        private void cargar()
        {

            try
            {
                listaCategorias = negocio.listarCategorias();
                dgvCategorias.DataSource = listaCategorias;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            cargar();
            dgvCategorias.RowHeadersVisible = false;
        }
    }
}
