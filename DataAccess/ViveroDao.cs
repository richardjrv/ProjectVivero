using Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess
{
    public static class ViveroDao
    {
        // =====================================================
        // LISTAR TODOS LOS VIVEROS
        // =====================================================
        public static List<Vivero> Listar()
        {
            List<Vivero> lista = new List<Vivero>();

            const string sql = @"
                SELECT
                    idVivero,
                    nombreVivero,
                    ubicacion,
                    tipoVivero,
                    fechaInstalacion,
                    descripcion
                FROM VIVERO
                ORDER BY idVivero DESC;";

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
                            Vivero vivero = new Vivero
                            {
                                IdVivero =
                                    Convert.ToInt32(
                                        reader["idVivero"]
                                    ),

                                NombreVivero =
                                    reader["nombreVivero"].ToString() ?? "",

                                Ubicacion =
                                    reader["ubicacion"].ToString() ?? "",

                                TipoVivero =
                                    reader["tipoVivero"].ToString() ?? "",

                                FechaInstalacion =
                                    Convert.ToDateTime(
                                        reader["fechaInstalacion"]
                                    ),

                                Descripcion =
                                    reader["descripcion"] == DBNull.Value
                                        ? ""
                                        : reader["descripcion"].ToString() ?? ""
                            };

                            lista.Add(vivero);
                        }
                    }
                }
            }

            return lista;
        }

        // =====================================================
        // INSERTAR
        // =====================================================
        public static int Insertar(Vivero vivero)
        {
            const string sql = @"
                INSERT INTO VIVERO
                (
                    nombreVivero,
                    ubicacion,
                    tipoVivero,
                    fechaInstalacion,
                    descripcion
                )
                VALUES
                (
                    @nombreVivero,
                    @ubicacion,
                    @tipoVivero,
                    @fechaInstalacion,
                    @descripcion
                );";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            {
                using (SqlCommand comando =
                       new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(
                        "@nombreVivero",
                        SqlDbType.VarChar,
                        100
                    ).Value = vivero.NombreVivero.Trim();

                    comando.Parameters.Add(
                        "@ubicacion",
                        SqlDbType.VarChar,
                        120
                    ).Value = vivero.Ubicacion.Trim();

                    comando.Parameters.Add(
                        "@tipoVivero",
                        SqlDbType.VarChar,
                        50
                    ).Value = vivero.TipoVivero.Trim();

                    comando.Parameters.Add(
                        "@fechaInstalacion",
                        SqlDbType.DateTime
                    ).Value = vivero.FechaInstalacion;

                    comando.Parameters.Add(
                        "@descripcion",
                        SqlDbType.VarChar,
                        255
                    ).Value =
                        string.IsNullOrWhiteSpace(vivero.Descripcion)
                            ? DBNull.Value
                            : vivero.Descripcion.Trim();

                    conexion.Open();

                    return comando.ExecuteNonQuery();
                }
            }
        }

        // =====================================================
        // ACTUALIZAR
        // =====================================================
        public static int Actualizar(Vivero vivero)
        {
            const string sql = @"
                UPDATE VIVERO
                SET
                    nombreVivero = @nombreVivero,
                    ubicacion = @ubicacion,
                    tipoVivero = @tipoVivero,
                    fechaInstalacion = @fechaInstalacion,
                    descripcion = @descripcion
                WHERE idVivero = @idVivero;";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            {
                using (SqlCommand comando =
                       new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(
                        "@idVivero",
                        SqlDbType.Int
                    ).Value = vivero.IdVivero;

                    comando.Parameters.Add(
                        "@nombreVivero",
                        SqlDbType.VarChar,
                        100
                    ).Value = vivero.NombreVivero.Trim();

                    comando.Parameters.Add(
                        "@ubicacion",
                        SqlDbType.VarChar,
                        120
                    ).Value = vivero.Ubicacion.Trim();

                    comando.Parameters.Add(
                        "@tipoVivero",
                        SqlDbType.VarChar,
                        50
                    ).Value = vivero.TipoVivero.Trim();

                    comando.Parameters.Add(
                        "@fechaInstalacion",
                        SqlDbType.DateTime
                    ).Value = vivero.FechaInstalacion;

                    comando.Parameters.Add(
                        "@descripcion",
                        SqlDbType.VarChar,
                        255
                    ).Value =
                        string.IsNullOrWhiteSpace(vivero.Descripcion)
                            ? DBNull.Value
                            : vivero.Descripcion.Trim();

                    conexion.Open();

                    return comando.ExecuteNonQuery();
                }
            }
        }

        // =====================================================
        // ELIMINAR
        // =====================================================
        public static int Eliminar(int idVivero)
        {
            const string sql = @"
                DELETE FROM VIVERO
                WHERE idVivero = @idVivero;";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            {
                using (SqlCommand comando =
                       new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(
                        "@idVivero",
                        SqlDbType.Int
                    ).Value = idVivero;

                    conexion.Open();

                    return comando.ExecuteNonQuery();
                }
            }
        }
    }
}