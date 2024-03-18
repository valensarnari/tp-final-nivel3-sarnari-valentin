using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Controllers
{
    public class FavoritoController
    {
        public List<Favorito> ListarFavoritosPorUser(string id)
        {
			AccesoDatos acceso = new AccesoDatos();
			List<Favorito> listaFavoritos = new List<Favorito>();

			try
			{
				acceso.SetConsulta("Select Id, IdUser, IdArticulo from FAVORITOS where idUser = " + id);
				acceso.EjecutarLectura();

				while(acceso.Lector.Read())
				{
					Favorito favorito = new Favorito();

					favorito.Id = (int)acceso.Lector["Id"];
					favorito.IdUser = (int)acceso.Lector["IdUser"];
					favorito.IdArticulo = (int)acceso.Lector["IdArticulo"];

					listaFavoritos.Add(favorito);
				}

				return listaFavoritos;
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
		public bool EsFavorito(Articulo articulo, User user)
		{
			AccesoDatos acceso = new AccesoDatos();

			try
			{
				acceso.SetConsulta("Select Id, IdUser, IdArticulo from FAVORITOS where IdUser = @IdUser and IdArticulo = @IdArt");
				acceso.SetParametro("@IdUser", user != null ? user.Id : (object)DBNull.Value);
				acceso.SetParametro("@IdArt", articulo.Id);
				acceso.EjecutarLectura();

				if (acceso.Lector.Read())
					return true;

				return false;
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
        public void AgregarFavorito(Articulo articulo, User user)
		{
			AccesoDatos acceso = new AccesoDatos();

			try
			{
				acceso.SetConsulta("Insert into FAVORITOS(IdUser, IdArticulo) values(@IdUser, @IdArt)");
                acceso.SetParametro("@IdUser", user != null ? user.Id : (object)DBNull.Value);
                acceso.SetParametro("@IdArt", articulo.Id);
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
		public void QuitarFavorito(Articulo articulo, User user)
		{
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                acceso.SetConsulta("Delete from FAVORITOS where IdUser = @IdUser and IdArticulo = @IdArt");
                acceso.SetParametro("@IdUser", user.Id);
                acceso.SetParametro("@IdArt", articulo.Id);
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
