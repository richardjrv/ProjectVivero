using DataAccess;
using Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccess
{
    public static class SensorCatalogoDao
    {
        // =====================================================
        // LISTAR SENSORES
        // =====================================================
        public static List<SensorCatalogo> Listar()
        {
            List<SensorCatalogo> lista =
                new List<SensorCatalogo>();

            const string sql = @"
                SELECT
                    S.idSensor,
                    S.idVivero,
                    S.nombreSensor,
                    S.tipoSensor,
                    S.fechaInstalacion,
                    S.estadoSensor,
                    V.nombreVivero
                FROM SENSOR S
                INNER JOIN VIVERO V
                    ON S.idVivero = V.idVivero
                ORDER BY S.idSensor DESC;";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            {
                using (SqlCommand comando =
                       new SqlCommand(sql, conexion))
                {
                    conexion.Open();

                    using (SqlDataReader reader =
                           comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SensorCatalogo sensor =
                                new SensorCatalogo
                                {
                                    IdSensor =
                                        Convert.ToInt32(
                                            reader["idSensor"]
                                        ),

                                    IdVivero =
                                        Convert.ToInt32(
                                            reader["idVivero"]
                                        ),

                                    NombreVivero =
                                        Convert.ToString(
                                            reader["nombreVivero"]
                                        ) ?? "",

                                    NombreSensor =
                                        Convert.ToString(
                                            reader["nombreSensor"]
                                        ) ?? "",

                                    TipoSensor =
                                        Convert.ToString(
                                            reader["tipoSensor"]
                                        ) ?? "",

                                    FechaInstalacion =
                                        reader["fechaInstalacion"]
                                            == DBNull.Value
                                                ? null
                                                : Convert.ToDateTime(
                                                    reader[
                                                        "fechaInstalacion"
                                                    ]
                                                ),

                                    EstadoSensor =
                                        Convert.ToString(
                                            reader["estadoSensor"]
                                        ) ?? ""
                                };

                            lista.Add(sensor);
                        }
                    }
                }
            }

            return lista;
        }

        // =====================================================
        // INSERTAR SENSOR
        // =====================================================
        public static int Insertar(
            SensorCatalogo sensor)
        {
            const string sql = @"
                INSERT INTO SENSOR
                (
                    idVivero,
                    nombreSensor,
                    tipoSensor,
                    fechaInstalacion,
                    estadoSensor
                )
                VALUES
                (
                    @idVivero,
                    @nombreSensor,
                    @tipoSensor,
                    @fechaInstalacion,
                    @estadoSensor
                );";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            {
                using (SqlCommand comando =
                       new SqlCommand(sql, conexion))
                {
                    AgregarParametros(
                        comando,
                        sensor,
                        incluirId: false
                    );

                    conexion.Open();

                    return comando.ExecuteNonQuery();
                }
            }
        }

        // =====================================================
        // ACTUALIZAR SENSOR
        // =====================================================
        public static int Actualizar(
            SensorCatalogo sensor)
        {
            const string sql = @"
                UPDATE SENSOR
                SET
                    idVivero = @idVivero,
                    nombreSensor = @nombreSensor,
                    tipoSensor = @tipoSensor,
                    fechaInstalacion = @fechaInstalacion,
                    estadoSensor = @estadoSensor
                WHERE idSensor = @idSensor;";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            {
                using (SqlCommand comando =
                       new SqlCommand(sql, conexion))
                {
                    AgregarParametros(
                        comando,
                        sensor,
                        incluirId: true
                    );

                    conexion.Open();

                    return comando.ExecuteNonQuery();
                }
            }
        }

        // =====================================================
        // ELIMINAR SENSOR
        // =====================================================
        public static int Eliminar(int idSensor)
        {
            const string sql = @"
                DELETE FROM SENSOR
                WHERE idSensor = @idSensor;";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            {
                using (SqlCommand comando =
                       new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(
                        "@idSensor",
                        SqlDbType.Int
                    ).Value = idSensor;

                    conexion.Open();

                    return comando.ExecuteNonQuery();
                }
            }
        }

        // =====================================================
        // PARÁMETROS
        // =====================================================
        private static void AgregarParametros(
            SqlCommand comando,
            SensorCatalogo sensor,
            bool incluirId)
        {
            if (incluirId)
            {
                comando.Parameters.Add(
                    "@idSensor",
                    SqlDbType.Int
                ).Value = sensor.IdSensor;
            }

            comando.Parameters.Add(
                "@idVivero",
                SqlDbType.Int
            ).Value = sensor.IdVivero;

            comando.Parameters.Add(
                "@nombreSensor",
                SqlDbType.VarChar,
                100
            ).Value = sensor.NombreSensor.Trim();

            comando.Parameters.Add(
                "@tipoSensor",
                SqlDbType.VarChar,
                50
            ).Value = sensor.TipoSensor.Trim();

            comando.Parameters.Add(
                "@fechaInstalacion",
                SqlDbType.DateTime
            ).Value =
                sensor.FechaInstalacion.HasValue
                    ? (object)sensor.FechaInstalacion.Value
                    : DBNull.Value;

            comando.Parameters.Add(
                "@estadoSensor",
                SqlDbType.VarChar,
                20
            ).Value = sensor.EstadoSensor.Trim();
        }
    }
}