using DataAccess;
using Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessLogic
{
    public class UsuarioLogic
    {
        // =====================================================
        // BUSCAR USUARIO PARA INICIAR SESIÓN
        // =====================================================
        public static Usuario getUsuarioPorUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return null;
            }

            string sql = @"
                SELECT TOP 1
                    U.idUsuario,
                    U.nombreCompleto,
                    U.[password],
                    R.nombreRol
                FROM USUARIO U
                INNER JOIN ROL R
                    ON U.idRol = R.idRol
                WHERE U.username = @username
                  AND U.estado = 'Activo';
            ";

            List<SqlParameter> parametros =
                new List<SqlParameter>()
                {
                    new SqlParameter(
                        "@username",
                        username.Trim()
                    )
                };

            DataTable tabla =
                ConexionDB.getQuery(
                    sql,
                    parametros
                );

            if (tabla == null || tabla.Rows.Count == 0)
            {
                return null;
            }

            DataRow fila = tabla.Rows[0];

            Usuario usuario = new Usuario();

            usuario.IdUsuario =
                Convert.ToInt32(fila["idUsuario"]);

            usuario.NombreCompleto =
                fila["nombreCompleto"].ToString();

            usuario.Password =
                fila["password"].ToString();

            usuario.NombreRol =
                fila["nombreRol"].ToString();

            return usuario;
        }

        // =====================================================
        // REGISTRAR NUEVO USUARIO
        // =====================================================
        public static bool InsertarNuevoUsuario(
            string nombre,
            string correo,
            string username,
            string password,
            string rol)
        {
            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(rol))
            {
                return false;
            }

            string sql = @"
                INSERT INTO USUARIO
                (
                    idRol,
                    nombreCompleto,
                    correo,
                    username,
                    [password],
                    estado
                )
                SELECT
                    R.idRol,
                    @nombre,
                    @correo,
                    @username,
                    @password,
                    'Activo'
                FROM ROL R
                WHERE R.nombreRol = @rol
                  AND NOT EXISTS
                  (
                      SELECT 1
                      FROM USUARIO
                      WHERE username = @username
                         OR correo = @correo
                  );
            ";

            List<SqlParameter> parametros =
                new List<SqlParameter>()
                {
                    new SqlParameter(
                        "@nombre",
                        nombre.Trim()
                    ),

                    new SqlParameter(
                        "@correo",
                        correo.Trim()
                    ),

                    new SqlParameter(
                        "@username",
                        username.Trim()
                    ),

                    new SqlParameter(
                        "@password",
                        password
                    ),

                    new SqlParameter(
                        "@rol",
                        rol.Trim()
                    )
                };

            try
            {
                int filasAfectadas =
                    DataAccess.ConexionDB.execQuery(
                        sql,
                        parametros
                    );

                return filasAfectadas > 0;
            }
            catch (SqlException ex)
                when (ex.Number == 2601 ||
                      ex.Number == 2627)
            {
                // El correo o el usuario ya están registrados.
                return false;
            }
        }

        // =====================================================
        // COMPROBAR SI YA EXISTE EL USUARIO O CORREO
        // =====================================================

        public static bool ExisteUsuarioOCorreo(
        string username,
        string correo)
        {
            string sql = @"
        SELECT COUNT(*)
        FROM USUARIO
        WHERE username = @username
           OR correo = @correo;
    ";

            List<SqlParameter> parametros =
                new List<SqlParameter>()
                {
            new SqlParameter(
                "@username",
                username.Trim()
            ),

            new SqlParameter(
                "@correo",
                correo.Trim()
            )
                };

            DataTable tabla =
                ConexionDB.getQuery(
                    sql,
                    parametros
                );

            if (tabla == null || tabla.Rows.Count == 0)
            {
                return false;
            }

            int cantidad =
                Convert.ToInt32(tabla.Rows[0][0]);

            return cantidad > 0;
        }
    }
    
}