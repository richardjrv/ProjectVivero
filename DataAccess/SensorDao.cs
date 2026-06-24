using System;
using Entidades;
using Microsoft.Data.SqlClient;

namespace DataAccess
{
    public static class SensorDao
    {
        public static int Insertar(Entidades.Sensor sensor)
        {
            if (sensor == null)
            {
                throw new ArgumentNullException(nameof(sensor));
            }

            const string sql = @"
                INSERT INTO Sensores
                (
                    Temperatura,
                    HumedadAmbiente,
                    HumedadSuelo,
                    Fecha
                )
                VALUES
                (
                    @temperatura,
                    @humedadAmbiente,
                    @humedadSuelo,
                    @fecha
                );";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            {
                using (SqlCommand comando =
                       new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@temperatura",
                        sensor.Temperatura
                    );

                    comando.Parameters.AddWithValue(
                        "@humedadAmbiente",
                        sensor.HumedadAmbiente
                    );

                    comando.Parameters.AddWithValue(
                        "@humedadSuelo",
                        sensor.HumedadSuelo
                    );

                    comando.Parameters.AddWithValue(
                        "@fecha",
                        DateTime.Now
                    );

                    conexion.Open();

                    return comando.ExecuteNonQuery();
                }
            }
        }
    }
}