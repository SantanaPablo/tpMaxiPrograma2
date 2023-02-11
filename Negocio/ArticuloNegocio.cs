using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> listarArticulos() 
        {
            List<Articulo> listaArticulos = new List<Articulo>();
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                acceso.SetearConsulta("select A.Id, Codigo, Nombre,A.Descripcion, ImagenUrl, Precio, M.Descripcion Marca, IdMarca, C.Descripcion Categoria, IdCategoria from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id and A.IdCategoria = C.Id and Precio > 0");
                acceso.EjecutarLectura();

                while (acceso.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)acceso.Lector["Id"];
                    aux.codigo = (string)acceso.Lector["Codigo"];
                    aux.nombre = (string)acceso.Lector["Nombre"];
                    aux.descripcion = (string)acceso.Lector["Descripcion"];
                    aux.imagenUrl = (string)acceso.Lector["ImagenUrl"];
                    decimal precio = (decimal)acceso.Lector["Precio"];
                    aux.precio = Math.Round(precio, 2);
                    aux.marca = new Marca();
                    aux.marca.descripcion = (string)acceso.Lector["Marca"];
                    aux.marca.id = (int)acceso.Lector["IdMarca"];
                    aux.categoria = new Categoria();
                    aux.categoria.descripcion = (string)acceso.Lector["Categoria"];
                    aux.categoria.id = (int)acceso.Lector["IdCategoria"];

                    listaArticulos.Add(aux);
                }

                return listaArticulos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally { acceso.CerrarConexion();}
        }
        public void AgregarArticulo(Articulo nuevo)

        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.SetearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)");
                //accesoDatos.SetearParametro("@Id", nuevo.id);
                accesoDatos.SetearParametro("@Codigo", nuevo.codigo);
                accesoDatos.SetearParametro("@Nombre", nuevo.nombre);
                accesoDatos.SetearParametro("@Descripcion", nuevo.descripcion);
                accesoDatos.SetearParametro("@IdMarca", nuevo.marca.id);
                accesoDatos.SetearParametro("@IdCategoria", nuevo.categoria.id);
                accesoDatos.SetearParametro("@ImagenUrl", nuevo.imagenUrl);
                accesoDatos.SetearParametro("@Precio", nuevo.precio);
                accesoDatos.EjecutarAccion();
              



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.CerrarConexion();
            }
        }

        public void ModificarArticulo(Articulo viejo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.SetearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, ImagenUrl = @ImagenUrl, Precio = @Precio where Id=@Id");
                accesoDatos.SetearParametro("@Id", viejo.id);
                accesoDatos.SetearParametro("@Codigo", viejo.codigo);
                accesoDatos.SetearParametro("@Nombre", viejo.nombre);
                accesoDatos.SetearParametro("@Descripcion", viejo.descripcion);
                accesoDatos.SetearParametro("@IdMarca", viejo.marca.id);
                accesoDatos.SetearParametro("@IdCategoria", viejo.categoria.id);
                accesoDatos.SetearParametro("@ImagenUrl", viejo.imagenUrl);
                accesoDatos.SetearParametro("@Precio", viejo.precio);

                accesoDatos.EjecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex ;
            }
            finally { accesoDatos.CerrarConexion(); }

        }

        public void ReciclarArticulo(Articulo aPapelera)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.SetearConsulta("update ARTICULOS set Precio = -@Precio where Id=@Id");
                accesoDatos.SetearParametro("@Id", aPapelera.id);
                accesoDatos.SetearParametro("@Precio", aPapelera.precio);

                accesoDatos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally { accesoDatos.CerrarConexion(); }
        }

        public List<Articulo> listaPapelera()
        {
            List<Articulo> listaArticulos = new List<Articulo>();
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                acceso.SetearConsulta("select A.Id, Codigo, Nombre,A.Descripcion, ImagenUrl, Precio, M.Descripcion Marca, IdMarca, C.Descripcion Categoria, IdCategoria from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id and A.IdCategoria = C.Id and Precio < 0");
                acceso.EjecutarLectura();

                while (acceso.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)acceso.Lector["Id"];
                    aux.codigo = (string)acceso.Lector["Codigo"];
                    aux.nombre = (string)acceso.Lector["Nombre"];
                    aux.descripcion = (string)acceso.Lector["Descripcion"];
                    aux.imagenUrl = (string)acceso.Lector["ImagenUrl"];
                    decimal precio = (decimal)acceso.Lector["Precio"];
                    aux.precio = Math.Round(precio, 2);
                    aux.marca = new Marca();
                    aux.marca.descripcion = (string)acceso.Lector["Marca"];
                    aux.marca.id = (int)acceso.Lector["IdMarca"];
                    aux.categoria = new Categoria();
                    aux.categoria.descripcion = (string)acceso.Lector["Categoria"];
                    aux.categoria.id = (int)acceso.Lector["IdCategoria"];

                    listaArticulos.Add(aux);
                }

                return listaArticulos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally { acceso.CerrarConexion(); }
        }

        public void eliminarDefinitivo(int id) 
        {
            AccesoDatos accesoDatos= new AccesoDatos();
            try
            {
                accesoDatos.SetearConsulta("delete from ARTICULOS where Id = @Id");
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
