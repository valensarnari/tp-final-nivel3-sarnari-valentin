using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class CategoriaController
    {
        public List<Categoria> ListarTodasLasCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                acceso.SetConsulta("Select Id, Descripcion from CATEGORIAS");
                acceso.EjecutarLectura();

                while (acceso.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)acceso.Lector["Id"];
                    aux.Descripcion = (string)acceso.Lector["Descripcion"];

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
        public List<Categoria> ListarTodasLasCategorias(bool x)
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                Categoria todas = new Categoria();
                todas.Descripcion = "Todas las categorías";
                lista.Add(todas);

                acceso.SetConsulta("Select Id, Descripcion from CATEGORIAS");
                acceso.EjecutarLectura();

                while (acceso.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)acceso.Lector["Id"];
                    aux.Descripcion = (string)acceso.Lector["Descripcion"];

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
    }
}
