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
    public partial class frmMarcas : Form

    {

        private List<Marca> listaMarcas = new List<Marca>();
        private Marca marca = new Marca();
        private MarcaNegocio negocio = new MarcaNegocio();
        

        public frmMarcas()
        {
            InitializeComponent();
        }

        private void cargar()
        {

            try
            {
                listaMarcas = negocio.listarMarcas();
                dgvMarcas.DataSource = listaMarcas;
                dgvMarcas.RowHeadersVisible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmMarcas_Load(object sender, EventArgs e)
        {
            cargar();
        }
    }
}
