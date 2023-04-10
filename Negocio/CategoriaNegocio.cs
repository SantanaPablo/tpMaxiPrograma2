using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listarCategorias()
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                acceso.SetearConsulta("select Id, Descripcion from CATEGORIAS");
                acceso.EjecutarLectura();

                while (acceso.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.id = (int)acceso.Lector["Id"];
                    aux.descripcion = (string)acceso.Lector["Descripcion"];

                    listaCategorias.Add(aux);

                }

                return listaCategorias;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally { acceso.CerrarConexion(); }
        }

        public void AgregarCategoria(Categoria nueva)
        {
            AccesoDatos accesodatos = new AccesoDatos();

            try
            {
                accesodatos.SetearConsulta("Insert into CATEGORIAS (Descripcion) VALUES (@Descripcion)");
                accesodatos.SetearParametro("@Descripcion", nueva.descripcion);
                accesodatos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally
            {
                accesodatos.CerrarConexion();
            }
        }

        public void eliminarDefinitivo(int id)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.SetearConsulta("delete from Categorias where Id = @Id delete from ARTICULOS where IdCategoria = @Id");
                accesoDatos.SetearParametro("@Id", id);
                accesoDatos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally { accesoDatos.CerrarConexion(); }
        }
    }
}
