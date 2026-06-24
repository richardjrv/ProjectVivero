using Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess
{
    public static class DatoSensorDao
    {
        // =====================================================
        // GUARDAR UNA MEDICIÓN
        // =====================================================
        public static int Insertar(DatoSensor dato)
        {
            const string sql = @"
                INSERT INTO DatosSensores
                (
                    Temperatura,
                    HumedadAire,
                    HumedadSuelo,
                    FechaHora
                )
                VALUES
                (
                    @temperatura,
                    @humedadAire,
                    @humedadSuelo,
                    @fechaHora
                );";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            {
                using (SqlCommand comando =
                       new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(
                        "@temperatura",
                        SqlDbType.Float
                    ).Value = dato.Temperatura;

                    comando.Parameters.Add(
                        "@humedadAire",
                        SqlDbType.Float
                    ).Value = dato.HumedadAire;

                    comando.Parameters.Add(
                        "@humedadSuelo",
                        SqlDbType.Float
                    ).Value = dato.HumedadSuelo;

                    comando.Parameters.Add(
                        "@fechaHora",
                        SqlDbType.DateTime
                    ).Value = dato.FechaHora;

                    conexion.Open();

                    return comando.ExecuteNonQuery();
                }
            }
        }

        // =====================================================
        // OBTENER LA ÚLTIMA MEDICIÓN
        // =====================================================
        public static DatoSensor ObtenerUltima()
        {
            const string sql = @"
                SELECT TOP 1
                    IdDato,
                    Temperatura,
                    HumedadAire,
                    HumedadSuelo,
                    FechaHora
                FROM DatosSensores
                ORDER BY FechaHora DESC, IdDato DESC;";

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
                        if (!reader.Read())
                        {
                            return null;
                        }

                        return ConvertirDato(reader);
                    }
                }
            }
        }

        // =====================================================
        // LISTAR LAS ÚLTIMAS MEDICIONES
        // =====================================================
        public static List<DatoSensor> ListarUltimos(
            int cantidad)
        {
            List<DatoSensor> lista =
                new List<DatoSensor>();

            const string sql = @"
                SELECT TOP (@cantidad)
                    IdDato,
                    Temperatura,
                    HumedadAire,
                    HumedadSuelo,
                    FechaHora
                FROM DatosSensores
                ORDER BY FechaHora DESC, IdDato DESC;";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            {
                using (SqlCommand comando =
                       new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(
                        "@cantidad",
                        SqlDbType.Int
                    ).Value = cantidad;

                    conexion.Open();

                    using (SqlDataReader reader =
                           comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(
                                ConvertirDato(reader)
                            );
                        }
                    }
                }
            }

            return lista;
        }

        // =====================================================
        // LISTAR MEDICIONES ENTRE DOS FECHAS
        // PARA LAS GRÁFICAS
        // =====================================================
        public static List<DatoSensor> ListarPorRango(
            DateTime fechaInicio,
            DateTime fechaFin)
        {
            List<DatoSensor> lista =
                new List<DatoSensor>();

            const string sql = @"
                SELECT
                    IdDato,
                    Temperatura,
                    HumedadAire,
                    HumedadSuelo,
                    FechaHora
                FROM DatosSensores
                WHERE FechaHora >= @fechaInicio
                  AND FechaHora <= @fechaFin
                ORDER BY FechaHora ASC, IdDato ASC;";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            {
                using (SqlCommand comando =
                       new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(
                        "@fechaInicio",
                        SqlDbType.DateTime
                    ).Value = fechaInicio;

                    comando.Parameters.Add(
                        "@fechaFin",
                        SqlDbType.DateTime
                    ).Value = fechaFin;

                    conexion.Open();

                    using (SqlDataReader reader =
                           comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(
                                ConvertirDato(reader)
                            );
                        }
                    }
                }
            }

            return lista;
        }

        // =====================================================
        // CONVERTIR UNA FILA DE SQL EN DatoSensor
        // =====================================================
        private static DatoSensor ConvertirDato(
            SqlDataReader reader)
        {
            return new DatoSensor
            {
                IdDato =
                    Convert.ToInt32(
                        reader["IdDato"]
                    ),

                Temperatura =
                    Convert.ToDouble(
                        reader["Temperatura"]
                    ),

                HumedadAire =
                    Convert.ToDouble(
                        reader["HumedadAire"]
                    ),

                HumedadSuelo =
                    Convert.ToDouble(
                        reader["HumedadSuelo"]
                    ),

                FechaHora =
                    Convert.ToDateTime(
                        reader["FechaHora"]
                    )
            };
        }
    }
}