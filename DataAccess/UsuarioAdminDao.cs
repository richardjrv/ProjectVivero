using Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess
{
    public static class UsuarioAdminDao
    {
        public static List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            const string sql = @"
                SELECT
                    U.idUsuario,
                    U.idRol,
                    U.nombreCompleto,
                    U.correo,
                    U.username,
                    U.estado,
                    R.nombreRol
                FROM USUARIO U
                INNER JOIN ROL R
                    ON U.idRol = R.idRol
                ORDER BY U.idUsuario DESC;";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            using (SqlCommand comando =
                   new SqlCommand(sql, conexion))
            {
                conexion.Open();

                using (SqlDataReader reader =
                       comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Usuario
                        {
                            IdUsuario =
                                Convert.ToInt32(
                                    reader["idUsuario"]
                                ),

                            IdRol =
                                Convert.ToInt32(
                                    reader["idRol"]
                                ),

                            NombreCompleto =
                                Convert.ToString(
                                    reader["nombreCompleto"]
                                ) ?? "",

                            Correo =
                                reader["correo"] == DBNull.Value
                                    ? ""
                                    : Convert.ToString(
                                        reader["correo"]
                                    ) ?? "",

                            Username =
                                Convert.ToString(
                                    reader["username"]
                                ) ?? "",

                            NombreRol =
                                Convert.ToString(
                                    reader["nombreRol"]
                                ) ?? "",

                            Estado =
                                Convert.ToString(
                                    reader["estado"]
                                ) ?? ""
                        });
                    }
                }
            }

            return lista;
        }

        public static bool ExisteUsuarioOCorreo(
            string username,
            string correo,
            int idUsuarioExcluir)
        {
            const string sql = @"
                SELECT COUNT(*)
                FROM USUARIO
                WHERE
                (
                    username = @username
                    OR
                    (
                        correo IS NOT NULL
                        AND correo = @correo
                    )
                )
                AND idUsuario <> @idUsuarioExcluir;";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            using (SqlCommand comando =
                   new SqlCommand(sql, conexion))
            {
                comando.Parameters.Add(
                    "@username",
                    SqlDbType.VarChar,
                    50
                ).Value = username.Trim();

                comando.Parameters.Add(
                    "@correo",
                    SqlDbType.VarChar,
                    150
                ).Value = correo.Trim();

                comando.Parameters.Add(
                    "@idUsuarioExcluir",
                    SqlDbType.Int
                ).Value = idUsuarioExcluir;

                conexion.Open();

                int cantidad =
                    Convert.ToInt32(
                        comando.ExecuteScalar()
                    );

                return cantidad > 0;
            }
        }

        public static int Insertar(Usuario usuario)
        {
            const string sql = @"
                INSERT INTO USUARIO
                (
                    idRol,
                    nombreCompleto,
                    username,
                    [password],
                    fechaCreacion,
                    estado,
                    correo
                )
                SELECT
                    R.idRol,
                    @nombreCompleto,
                    @username,
                    @password,
                    GETDATE(),
                    @estado,
                    @correo
                FROM ROL R
                WHERE R.nombreRol = @nombreRol;";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            using (SqlCommand comando =
                   new SqlCommand(sql, conexion))
            {
                AgregarParametros(
                    comando,
                    usuario,
                    incluirId: false,
                    incluirPassword: true
                );

                conexion.Open();

                return comando.ExecuteNonQuery();
            }
        }

        public static int Actualizar(Usuario usuario)
        {
            bool cambiarPassword =
                !string.IsNullOrWhiteSpace(
                    usuario.Password
                );

            string sql;

            if (cambiarPassword)
            {
                sql = @"
                    UPDATE U
                    SET
                        U.idRol = R.idRol,
                        U.nombreCompleto = @nombreCompleto,
                        U.username = @username,
                        U.[password] = @password,
                        U.estado = @estado,
                        U.correo = @correo
                    FROM USUARIO U
                    INNER JOIN ROL R
                        ON R.nombreRol = @nombreRol
                    WHERE U.idUsuario = @idUsuario;";
            }
            else
            {
                sql = @"
                    UPDATE U
                    SET
                        U.idRol = R.idRol,
                        U.nombreCompleto = @nombreCompleto,
                        U.username = @username,
                        U.estado = @estado,
                        U.correo = @correo
                    FROM USUARIO U
                    INNER JOIN ROL R
                        ON R.nombreRol = @nombreRol
                    WHERE U.idUsuario = @idUsuario;";
            }

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            using (SqlCommand comando =
                   new SqlCommand(sql, conexion))
            {
                AgregarParametros(
                    comando,
                    usuario,
                    incluirId: true,
                    incluirPassword: cambiarPassword
                );

                conexion.Open();

                return comando.ExecuteNonQuery();
            }
        }

        public static int Eliminar(int idUsuario)
        {
            const string sql = @"
                DELETE FROM USUARIO
                WHERE idUsuario = @idUsuario;";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            using (SqlCommand comando =
                   new SqlCommand(sql, conexion))
            {
                comando.Parameters.Add(
                    "@idUsuario",
                    SqlDbType.Int
                ).Value = idUsuario;

                conexion.Open();

                return comando.ExecuteNonQuery();
            }
        }

        private static void AgregarParametros(
            SqlCommand comando,
            Usuario usuario,
            bool incluirId,
            bool incluirPassword)
        {
            if (incluirId)
            {
                comando.Parameters.Add(
                    "@idUsuario",
                    SqlDbType.Int
                ).Value = usuario.IdUsuario;
            }

            comando.Parameters.Add(
                "@nombreCompleto",
                SqlDbType.VarChar,
                100
            ).Value = usuario.NombreCompleto.Trim();

            comando.Parameters.Add(
                "@username",
                SqlDbType.VarChar,
                50
            ).Value = usuario.Username.Trim();

            comando.Parameters.Add(
                "@correo",
                SqlDbType.VarChar,
                150
            ).Value =
                string.IsNullOrWhiteSpace(usuario.Correo)
                    ? DBNull.Value
                    : usuario.Correo.Trim();

            comando.Parameters.Add(
                "@estado",
                SqlDbType.VarChar,
                20
            ).Value = usuario.Estado.Trim();

            comando.Parameters.Add(
                "@nombreRol",
                SqlDbType.VarChar,
                50
            ).Value = usuario.NombreRol.Trim();

            if (incluirPassword)
            {
                comando.Parameters.Add(
                    "@password",
                    SqlDbType.VarChar,
                    255
                ).Value = usuario.Password;
            }
        }
    }
}
