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
                txbAgregar.Text = "";
                setearColumnas();

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

        private void setearColumnas()
        {
            try
            {
                dgvMarcas.Columns["id"].Width = 50;
                dgvMarcas.Columns["Descripcion"].Width = 150;
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int cont = 0;
                if (txbAgregar.Text != "")
                {
                    DialogResult respuesta = MessageBox.Show("¿Agregar marca " + txbAgregar.Text + "?", "Agregando marca...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvMarcas.Rows)
                        {
                            if (txbAgregar.Text.ToUpper() == row.Cells["Descripcion"].Value.ToString().ToUpper())
                            {
                                cont++;
                            }


                        }
                        if (cont == 0)
                        {
                            marca.descripcion = txbAgregar.Text;
                            negocio.AgregarMarca(marca);
                            MessageBox.Show($"Marca {marca.descripcion} agregada");
                            cargar();

                        }
                        else
                        {
                            MessageBox.Show("La Marca ya existe");
                            cont = 0;
                        }

                    }
                }
                else MessageBox.Show("Escribir marca para agregar");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
