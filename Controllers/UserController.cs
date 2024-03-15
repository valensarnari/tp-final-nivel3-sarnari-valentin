using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Controllers
{
    public class UserController
    {
        public User Login(User user)
        {
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                acceso.SetConsulta("Select Id, email, pass, nombre, apellido, urlImagenPerfil, admin from USERS where email = @email and pass = @pass");
                acceso.SetParametro("@email", user.Email);
                acceso.SetParametro("@pass", user.Pass);
                acceso.EjecutarLectura();

                if (acceso.Lector.Read())
                {
                    user.Id = (int)acceso.Lector["Id"];
                    if (!(acceso.Lector["nombre"] is DBNull))
                        user.Nombre = (string)acceso.Lector["nombre"];
                    if (!(acceso.Lector["apellido"] is DBNull))
                        user.Apellido = (string)acceso.Lector["apellido"];
                    if (!(acceso.Lector["urlImagenPerfil"] is DBNull))
                        user.UrlImagenPerfil = (string)acceso.Lector["urlImagenPerfil"];
                    user.Admin = (bool)acceso.Lector["admin"];

                    return user;
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
        public void Signup(User user)
        {
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                acceso.SetConsulta("Insert into USERS(email, pass) values(@email, @pass)");
                acceso.SetParametro("@email", user.Email);
                acceso.SetParametro("@pass", user.Pass);
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
