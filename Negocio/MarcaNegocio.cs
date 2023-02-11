using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaNegocio
    {

        public List<Marca> listarMarcas()
        {
            List<Marca> listaMarcas = new List<Marca>();
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                acceso.SetearConsulta("select Id, Descripcion from MARCAS");
                acceso.EjecutarLectura();

                while (acceso.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.id = (int)acceso.Lector["Id"];
                    aux.descripcion = (string)acceso.Lector["Descripcion"];

                    listaMarcas.Add(aux);

                }

                return listaMarcas;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally { acceso.CerrarConexion(); }
        }
    }
}
