using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFamilia.Class
{
    class ConexionSql
    {
        public static SqlConnection conexion()
        {
            string servidor = "localhost";
            string bd = "Familia";
            string usuario = "user";
            string password = "123456";

            string cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id= " + usuario + "; Password=" + password + "";

            try
            {
                SqlConnection conexionBD = new SqlConnection(cadenaConexion);

                return conexionBD;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }
}
