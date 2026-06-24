using Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess
{
    public static class ActuadorControlDao
    {
        public static List<ActuadorControl> Listar()
        {
            List<ActuadorControl> lista =
                new List<ActuadorControl>();

            const string sql = @"
                SELECT
                    A.idActuador,
                    A.idVivero,
                    V.nombreVivero,
                    A.nombreActuador,
                    A.tipoActuador,
                    A.modoControl,
                    A.estadoDeseado,
                    A.estadoActual,
                    A.fechaActualizacion,
                    A.estadoRegistro
                FROM CONTROL_ACTUADOR A
                INNER JOIN VIVERO V
                    ON A.idVivero = V.idVivero
                ORDER BY A.idActuador;";

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
                        lista.Add(
                            Convertir(reader)
                        );
                    }
                }
            }

            return lista;
        }

        public static ActuadorControl ObtenerPorId(
            int idActuador)
        {
            const string sql = @"
                SELECT
                    A.idActuador,
                    A.idVivero,
                    V.nombreVivero,
                    A.nombreActuador,
                    A.tipoActuador,
                    A.modoControl,
                    A.estadoDeseado,
                    A.estadoActual,
                    A.fechaActualizacion,
                    A.estadoRegistro
                FROM CONTROL_ACTUADOR A
                INNER JOIN VIVERO V
                    ON A.idVivero = V.idVivero
                WHERE A.idActuador = @idActuador;";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            using (SqlCommand comando =
                   new SqlCommand(sql, conexion))
            {
                comando.Parameters.Add(
                    "@idActuador",
                    SqlDbType.Int
                ).Value = idActuador;

                conexion.Open();

                using (SqlDataReader reader =
                       comando.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    return Convertir(reader);
                }
            }
        }

        public static int Insertar(
            ActuadorControl actuador)
        {
            const string sql = @"
                INSERT INTO CONTROL_ACTUADOR
                (
                    idVivero,
                    nombreActuador,
                    tipoActuador,
                    modoControl,
                    estadoDeseado,
                    estadoActual,
                    fechaActualizacion,
                    estadoRegistro
                )
                VALUES
                (
                    @idVivero,
                    @nombreActuador,
                    @tipoActuador,
                    @modoControl,
                    @estadoDeseado,
                    @estadoActual,
                    GETDATE(),
                    @estadoRegistro
                );";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            using (SqlCommand comando =
                   new SqlCommand(sql, conexion))
            {
                AgregarParametros(
                    comando,
                    actuador,
                    incluirId: false
                );

                conexion.Open();

                return comando.ExecuteNonQuery();
            }
        }

        public static int Actualizar(
            ActuadorControl actuador)
        {
            const string sql = @"
                UPDATE CONTROL_ACTUADOR
                SET
                    idVivero = @idVivero,
                    nombreActuador = @nombreActuador,
                    tipoActuador = @tipoActuador,
                    modoControl = @modoControl,
                    estadoDeseado = @estadoDeseado,
                    estadoRegistro = @estadoRegistro,
                    fechaActualizacion = GETDATE()
                WHERE idActuador = @idActuador;";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            using (SqlCommand comando =
                   new SqlCommand(sql, conexion))
            {
                AgregarParametros(
                    comando,
                    actuador,
                    incluirId: true
                );

                conexion.Open();

                return comando.ExecuteNonQuery();
            }
        }

        public static int ActualizarComando(
            int idActuador,
            string modoControl,
            bool estadoDeseado)
        {
            const string sql = @"
                UPDATE CONTROL_ACTUADOR
                SET
                    modoControl = @modoControl,
                    estadoDeseado = @estadoDeseado,
                    fechaActualizacion = GETDATE()
                WHERE idActuador = @idActuador
                  AND estadoRegistro = 'Activo';";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            using (SqlCommand comando =
                   new SqlCommand(sql, conexion))
            {
                comando.Parameters.Add(
                    "@idActuador",
                    SqlDbType.Int
                ).Value = idActuador;

                comando.Parameters.Add(
                    "@modoControl",
                    SqlDbType.VarChar,
                    20
                ).Value = modoControl;

                comando.Parameters.Add(
                    "@estadoDeseado",
                    SqlDbType.Bit
                ).Value = estadoDeseado;

                conexion.Open();

                return comando.ExecuteNonQuery();
            }
        }

        public static int ActualizarEstadoActual(
            int idActuador,
            bool estadoActual)
        {
            const string sql = @"
                UPDATE CONTROL_ACTUADOR
                SET
                    estadoActual = @estadoActual,
                    fechaActualizacion = GETDATE()
                WHERE idActuador = @idActuador;";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            using (SqlCommand comando =
                   new SqlCommand(sql, conexion))
            {
                comando.Parameters.Add(
                    "@idActuador",
                    SqlDbType.Int
                ).Value = idActuador;

                comando.Parameters.Add(
                    "@estadoActual",
                    SqlDbType.Bit
                ).Value = estadoActual;

                conexion.Open();

                return comando.ExecuteNonQuery();
            }
        }

        public static int Eliminar(int idActuador)
        {
            const string sql = @"
                DELETE FROM CONTROL_ACTUADOR
                WHERE idActuador = @idActuador;";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            using (SqlCommand comando =
                   new SqlCommand(sql, conexion))
            {
                comando.Parameters.Add(
                    "@idActuador",
                    SqlDbType.Int
                ).Value = idActuador;

                conexion.Open();

                return comando.ExecuteNonQuery();
            }
        }

        private static void AgregarParametros(
            SqlCommand comando,
            ActuadorControl actuador,
            bool incluirId)
        {
            if (incluirId)
            {
                comando.Parameters.Add(
                    "@idActuador",
                    SqlDbType.Int
                ).Value = actuador.IdActuador;
            }

            comando.Parameters.Add(
                "@idVivero",
                SqlDbType.Int
            ).Value = actuador.IdVivero;

            comando.Parameters.Add(
                "@nombreActuador",
                SqlDbType.VarChar,
                100
            ).Value = actuador.NombreActuador.Trim();

            comando.Parameters.Add(
                "@tipoActuador",
                SqlDbType.VarChar,
                50
            ).Value = actuador.TipoActuador.Trim();

            comando.Parameters.Add(
                "@modoControl",
                SqlDbType.VarChar,
                20
            ).Value = actuador.ModoControl.Trim();

            comando.Parameters.Add(
                "@estadoDeseado",
                SqlDbType.Bit
            ).Value = actuador.EstadoDeseado;

            comando.Parameters.Add(
                "@estadoActual",
                SqlDbType.Bit
            ).Value = actuador.EstadoActual;

            comando.Parameters.Add(
                "@estadoRegistro",
                SqlDbType.VarChar,
                20
            ).Value = actuador.EstadoRegistro.Trim();
        }

        private static ActuadorControl Convertir(
            SqlDataReader reader)
        {
            return new ActuadorControl
            {
                IdActuador =
                    Convert.ToInt32(
                        reader["idActuador"]
                    ),

                IdVivero =
                    Convert.ToInt32(
                        reader["idVivero"]
                    ),

                NombreVivero =
                    Convert.ToString(
                        reader["nombreVivero"]
                    ) ?? "",

                NombreActuador =
                    Convert.ToString(
                        reader["nombreActuador"]
                    ) ?? "",

                TipoActuador =
                    Convert.ToString(
                        reader["tipoActuador"]
                    ) ?? "",

                ModoControl =
                    Convert.ToString(
                        reader["modoControl"]
                    ) ?? "Automatico",

                EstadoDeseado =
                    Convert.ToBoolean(
                        reader["estadoDeseado"]
                    ),

                EstadoActual =
                    Convert.ToBoolean(
                        reader["estadoActual"]
                    ),

                FechaActualizacion =
                    Convert.ToDateTime(
                        reader["fechaActualizacion"]
                    ),

                EstadoRegistro =
                    Convert.ToString(
                        reader["estadoRegistro"]
                    ) ?? "Activo"
            };
        }
    }
}
