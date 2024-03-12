using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class AccesoDatos
    {
        // atributos y propiedades
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        // constructor y metodos
        public AccesoDatos()
        {
            try
            {
                conexion = new SqlConnection("server =.\\SQLEXPRESS; database = CATALOGO_WEB_DB; integrated security = true");
                comando = new SqlCommand();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void SetConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void SetParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void SetProcedimiento(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }

        public void EjecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EjecutarConsulta()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int EjecutarScalar()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                return int.Parse(comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }
    }
}
