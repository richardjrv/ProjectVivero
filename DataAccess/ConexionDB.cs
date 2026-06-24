using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace DataAccess
{
    public class ConexionDB
    {
        public static readonly string cadenaConexion =
            @"Data Source=.\SQLDEVELOPER;
              Initial Catalog=Project;
              Integrated Security=True;
              TrustServerCertificate=True;";

        // SELECT
        public static DataTable getQuery(
            string sql,
            List<SqlParameter> parametros = null)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conexion =
                   new SqlConnection(cadenaConexion))
            {
                using (SqlCommand comando =
                       new SqlCommand(sql, conexion))
                {
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(
                            parametros.ToArray()
                        );
                    }

                    using (SqlDataAdapter adaptador =
                           new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }

            return tabla;
        }
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }

        public static bool ProbarConexion(out string mensaje)
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();

                    mensaje =
                        "Conexión correcta con la base de datos Project.";

                    return true;
                }
            }
            catch (Exception ex)
            {
                mensaje =
                    "No se pudo conectar con SQL Server.\n\n" +
                    ex.Message;

                return false;
            }
        }

        // INSERT, UPDATE Y DELETE
        public static int execQuery(
            string sql,
            List<SqlParameter> parametros = null)
        {
            using (SqlConnection conexion =
                   new SqlConnection(cadenaConexion))
            {
                using (SqlCommand comando =
                       new SqlCommand(sql, conexion))
                {
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(
                            parametros.ToArray()
                        );
                    }

                    conexion.Open();

                    return comando.ExecuteNonQuery();
                }
            }
        }
    }
}