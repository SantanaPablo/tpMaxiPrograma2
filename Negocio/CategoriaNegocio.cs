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
                    Categoria aux= new Categoria();
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
    }
}
