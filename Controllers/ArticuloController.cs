using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Controllers
{
    public class ArticuloController
    {
        public List<Articulo> ListarTodosLosArticulos()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                acceso.SetConsulta("Select A.Id, Codigo, Nombre, A.Descripcion, IdMarca, M.Descripcion as Marca, IdCategoria, C.Descripcion as Categoria, ImagenUrl, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id and A.IdCategoria = C.Id");
                acceso.EjecutarLectura();

                while (acceso.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)acceso.Lector["Id"];
                    aux.Codigo = (string)acceso.Lector["Codigo"];
                    aux.Nombre = (string)acceso.Lector["Nombre"];
                    aux.Descripcion = (string)acceso.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)acceso.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)acceso.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)acceso.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)acceso.Lector["Categoria"];

                    if (!(acceso.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)acceso.Lector["ImagenUrl"];

                    aux.Precio = (Decimal)acceso.Lector["Precio"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.CerrarConexion();
            }
        }
        public Articulo FiltrarPorId(string id)
        {
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                acceso.SetConsulta("Select A.Id, Codigo, Nombre, A.Descripcion, IdMarca, M.Descripcion as Marca, IdCategoria, C.Descripcion as Categoria, ImagenUrl, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id and A.IdCategoria = C.Id and A.Id = @id");
                acceso.SetParametro("@id", id);
                acceso.EjecutarLectura();

                if (acceso.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)acceso.Lector["Id"];
                    articulo.Codigo = (string)acceso.Lector["Codigo"];
                    articulo.Nombre = (string)acceso.Lector["Nombre"];
                    articulo.Descripcion = (string)acceso.Lector["Descripcion"];
                    articulo.Marca = new Marca();
                    articulo.Marca.Id = (int)acceso.Lector["IdMarca"];
                    articulo.Marca.Descripcion = (string)acceso.Lector["Marca"];
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Id = (int)acceso.Lector["IdCategoria"];
                    articulo.Categoria.Descripcion = (string)acceso.Lector["Categoria"];

                    if (!(acceso.Lector["ImagenUrl"] is DBNull))
                        articulo.ImagenUrl = (string)acceso.Lector["ImagenUrl"];

                    articulo.Precio = (Decimal)acceso.Lector["Precio"];

                    return articulo;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.CerrarConexion();
            }
        }
        public List<Articulo> FiltrarPorNombre(string nombre)
        {
            AccesoDatos acceso = new AccesoDatos();
            List<Articulo> listaArticulos = new List<Articulo>();

            try
            {
                string consulta = "Select A.Id, Codigo, Nombre, A.Descripcion, IdMarca, M.Descripcion as Marca, IdCategoria, C.Descripcion as Categoria, ImagenUrl, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id and A.IdCategoria = C.Id ";
                consulta += "and Nombre like '%" + nombre + "%'";
                
                acceso.SetConsulta(consulta);
                acceso.EjecutarLectura();

                while(acceso.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)acceso.Lector["Id"];
                    aux.Codigo = (string)acceso.Lector["Codigo"];
                    aux.Nombre = (string)acceso.Lector["Nombre"];
                    aux.Descripcion = (string)acceso.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)acceso.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)acceso.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)acceso.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)acceso.Lector["Categoria"];

                    if (!(acceso.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)acceso.Lector["ImagenUrl"];

                    aux.Precio = (Decimal)acceso.Lector["Precio"];

                    listaArticulos.Add(aux);
                }

                return listaArticulos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.CerrarConexion();
            }
        }
        public List<Articulo> Filtrar(string marca, string categoria, string precio, string precioTexto)
        {
            AccesoDatos acceso = new AccesoDatos();
            List<Articulo> listaArticulos = new List<Articulo>();

            try
            {
                string consulta = "Select A.Id, Codigo, Nombre, A.Descripcion, IdMarca, M.Descripcion as Marca, IdCategoria, C.Descripcion as Categoria, ImagenUrl, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id and A.IdCategoria = C.Id ";

                switch (marca)
                {
                    case "0":
                        consulta += "";
                        break;
                    default:
                        consulta += "and IdMarca = " + marca + " ";
                        break;
                }
                switch (categoria)
                {
                    case "0":
                        consulta += "";
                        break;
                    default:
                        consulta += "and IdCategoria = " + categoria + " ";
                        break;
                }
                switch (precio)
                {
                    case "Mayor a":
                        consulta += "and Precio > " + precioTexto + " ";
                        break;
                    case "Menor a":
                        consulta += "and Precio < " + precioTexto + " ";
                        break;
                    case "Igual a":
                        consulta += "and Precio = " + precioTexto + " ";
                        break;
                    default:
                        consulta += "";
                        break;
                }

                acceso.SetConsulta(consulta);
                acceso.EjecutarLectura();

                while (acceso.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)acceso.Lector["Id"];
                    aux.Codigo = (string)acceso.Lector["Codigo"];
                    aux.Nombre = (string)acceso.Lector["Nombre"];
                    aux.Descripcion = (string)acceso.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)acceso.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)acceso.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)acceso.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)acceso.Lector["Categoria"];

                    if (!(acceso.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)acceso.Lector["ImagenUrl"];

                    aux.Precio = (Decimal)acceso.Lector["Precio"];

                    listaArticulos.Add(aux);
                }

                return listaArticulos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.CerrarConexion();
            }
        }
        public void AgregarArticulo(Articulo art)
        {
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                acceso.SetConsulta("Insert into ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)");
                acceso.SetParametro("@Codigo", art.Codigo);
                acceso.SetParametro("@Nombre", art.Nombre);
                acceso.SetParametro("@Descripcion", art.Descripcion);
                acceso.SetParametro("@IdMarca", art.Marca.Id);
                acceso.SetParametro("@IdCategoria", art.Categoria.Id);
                acceso.SetParametro("@ImagenUrl", art.ImagenUrl);
                acceso.SetParametro("@Precio", art.Precio);
                acceso.EjecutarConsulta();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.CerrarConexion();
            }
        }
        public void ModificarArticulo(Articulo art)
        {
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                acceso.SetConsulta("update ARTICULOS set Codigo = @cod, Nombre = @nom, Descripcion = @desc, IdMarca = @idm, IdCategoria = @idc, ImagenUrl = @img, Precio = @prec where Id = @id");
                acceso.SetParametro("@cod", art.Codigo);
                acceso.SetParametro("@nom", art.Nombre);
                acceso.SetParametro("@desc", art.Descripcion);
                acceso.SetParametro("@idm", art.Marca.Id);
                acceso.SetParametro("@idc", art.Categoria.Id);
                acceso.SetParametro("@img", art.ImagenUrl);
                acceso.SetParametro("@prec", art.Precio);
                acceso.SetParametro("@id", art.Id);

                acceso.EjecutarConsulta();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.CerrarConexion();
            }
        }
        public void EliminarArticulo(int id)
        {
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                acceso.SetConsulta("Delete from ARTICULOS where Id = " + id);
                acceso.EjecutarConsulta();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.CerrarConexion();
            }
        }
    }
}
