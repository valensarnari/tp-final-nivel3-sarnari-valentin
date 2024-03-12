using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class MarcaController
    {
        public List<Marca> ListarTodasLasMarcas()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                acceso.SetConsulta("Select Id, Descripcion from MARCAS");
                acceso.EjecutarLectura();

                while (acceso.Lector.Read())
                {
                    Marca aux = new Marca();
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
