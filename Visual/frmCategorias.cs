using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                dgvCategorias.Columns["id"].Width= 50;
                dgvCategorias.Columns["descripcion"].Width = 150;

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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int cont = 0;
                if (txbAgregar.Text != "")
                {
                    DialogResult respuesta = MessageBox.Show("¿Agregar Categoría " + txbAgregar.Text + "?", "Agregando Categoría...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvCategorias.Rows)
                        {
                            if (txbAgregar.Text.ToUpper() == row.Cells["Descripcion"].Value.ToString().ToUpper())
                            {
                                cont++;
                            }


                        }
                        if (cont == 0)
                        {
                            categoria.descripcion = txbAgregar.Text;
                            negocio.AgregarCategoria(categoria);
                            MessageBox.Show($"Categoría {categoria.descripcion} agregada");
                            cargar();

                        }
                        else
                        {
                            MessageBox.Show("La Categoría ya existe");
                            cont = 0;
                        }

                    }
                }
                else MessageBox.Show("Escribir Categoría para agregar");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
