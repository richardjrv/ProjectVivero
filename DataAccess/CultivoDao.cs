using Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess
{
    public static class CultivoDao
    {
        // =====================================================
        // LISTAR CULTIVOS
        // =====================================================
        public static List<Cultivo> Listar()
        {
            List<Cultivo> lista = new List<Cultivo>();

            const string sql = @"
                SELECT
                    C.idCultivo,
                    C.idVivero,
                    C.nombreCultivo,
                    C.fechaSiembra,
                    C.fechaEstimadaCosecha,
                    C.fechaCosecha,
                    C.estado,
                    C.variedad,
                    C.etapa,
                    C.descripcion,
                    V.nombreVivero
                FROM CULTIVO C
                INNER JOIN VIVERO V
                    ON C.idVivero = V.idVivero
                ORDER BY C.idCultivo DESC;";

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
                            Cultivo cultivo = new Cultivo
                            {
                                IdCultivo =
                                    Convert.ToInt32(
                                        reader["idCultivo"]
                                    ),

                                IdVivero =
                                    Convert.ToInt32(
                                        reader["idVivero"]
                                    ),

                                NombreVivero =
                                    reader["nombreVivero"]
                                        .ToString() ?? "",

                                NombreCultivo =
                                    reader["nombreCultivo"]
                                        .ToString() ?? "",

                                FechaSiembra =
                                    LeerFechaNullable(
                                        reader,
                                        "fechaSiembra"
                                    ),

                                FechaEstimadaCosecha =
                                    LeerFechaNullable(
                                        reader,
                                        "fechaEstimadaCosecha"
                                    ),

                                FechaCosecha =
                                    LeerFechaNullable(
                                        reader,
                                        "fechaCosecha"
                                    ),

                                Estado =
                                    reader["estado"]
                                        .ToString() ?? "",

                                Variedad =
                                    reader["variedad"] == DBNull.Value
                                        ? ""
                                        : reader["variedad"]
                                            .ToString() ?? "",

                                Etapa =
                                    reader["etapa"] == DBNull.Value
                                        ? ""
                                        : reader["etapa"]
                                            .ToString() ?? "",

                                Descripcion =
                                    reader["descripcion"] == DBNull.Value
                                        ? ""
                                        : reader["descripcion"]
                                            .ToString() ?? ""
                            };

                            lista.Add(cultivo);
                        }
                    }
                }
            }

            return lista;
        }

        // =====================================================
        // INSERTAR CULTIVO
        // =====================================================
        public static int Insertar(Cultivo cultivo)
        {
            const string sql = @"
                INSERT INTO CULTIVO
                (
                    idVivero,
                    nombreCultivo,
                    fechaSiembra,
                    fechaEstimadaCosecha,
                    fechaCosecha,
                    estado,
                    variedad,
                    etapa,
                    descripcion
                )
                VALUES
                (
                    @idVivero,
                    @nombreCultivo,
                    @fechaSiembra,
                    @fechaEstimadaCosecha,
                    @fechaCosecha,
                    @estado,
                    @variedad,
                    @etapa,
                    @descripcion
                );";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            {
                using (SqlCommand comando =
                       new SqlCommand(sql, conexion))
                {
                    AgregarParametros(
                        comando,
                        cultivo,
                        incluirId: false
                    );

                    conexion.Open();

                    return comando.ExecuteNonQuery();
                }
            }
        }

        // =====================================================
        // ACTUALIZAR CULTIVO
        // =====================================================
        public static int Actualizar(Cultivo cultivo)
        {
            const string sql = @"
                UPDATE CULTIVO
                SET
                    idVivero = @idVivero,
                    nombreCultivo = @nombreCultivo,
                    fechaSiembra = @fechaSiembra,
                    fechaEstimadaCosecha =
                        @fechaEstimadaCosecha,
                    fechaCosecha = @fechaCosecha,
                    estado = @estado,
                    variedad = @variedad,
                    etapa = @etapa,
                    descripcion = @descripcion
                WHERE idCultivo = @idCultivo;";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            {
                using (SqlCommand comando =
                       new SqlCommand(sql, conexion))
                {
                    AgregarParametros(
                        comando,
                        cultivo,
                        incluirId: true
                    );

                    conexion.Open();

                    return comando.ExecuteNonQuery();
                }
            }
        }

        // =====================================================
        // ELIMINAR CULTIVO
        // =====================================================
        public static int Eliminar(int idCultivo)
        {
            const string sql = @"
                DELETE FROM CULTIVO
                WHERE idCultivo = @idCultivo;";

            using (SqlConnection conexion =
                   ConexionDB.ObtenerConexion())
            {
                using (SqlCommand comando =
                       new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(
                        "@idCultivo",
                        SqlDbType.Int
                    ).Value = idCultivo;

                    conexion.Open();

                    return comando.ExecuteNonQuery();
                }
            }
        }

        // =====================================================
        // PARÁMETROS PARA INSERTAR Y ACTUALIZAR
        // =====================================================
        private static void AgregarParametros(
            SqlCommand comando,
            Cultivo cultivo,
            bool incluirId)
        {
            if (incluirId)
            {
                comando.Parameters.Add(
                    "@idCultivo",
                    SqlDbType.Int
                ).Value = cultivo.IdCultivo;
            }

            comando.Parameters.Add(
                "@idVivero",
                SqlDbType.Int
            ).Value = cultivo.IdVivero;

            comando.Parameters.Add(
                "@nombreCultivo",
                SqlDbType.VarChar,
                100
            ).Value = cultivo.NombreCultivo.Trim();

            comando.Parameters.Add(
                "@fechaSiembra",
                SqlDbType.DateTime
            ).Value =
                cultivo.FechaSiembra.HasValue
                    ? (object)cultivo.FechaSiembra.Value
                    : DBNull.Value;

            comando.Parameters.Add(
                "@fechaEstimadaCosecha",
                SqlDbType.Date
            ).Value =
                cultivo.FechaEstimadaCosecha.HasValue
                    ? (object)cultivo
                        .FechaEstimadaCosecha.Value.Date
                    : DBNull.Value;

            comando.Parameters.Add(
                "@fechaCosecha",
                SqlDbType.Date
            ).Value =
                cultivo.FechaCosecha.HasValue
                    ? (object)cultivo.FechaCosecha.Value.Date
                    : DBNull.Value;

            comando.Parameters.Add(
                "@estado",
                SqlDbType.VarChar,
                20
            ).Value = cultivo.Estado.Trim();

            comando.Parameters.Add(
                "@variedad",
                SqlDbType.VarChar,
                100
            ).Value =
                string.IsNullOrWhiteSpace(cultivo.Variedad)
                    ? DBNull.Value
                    : cultivo.Variedad.Trim();

            comando.Parameters.Add(
                "@etapa",
                SqlDbType.VarChar,
                50
            ).Value = cultivo.Etapa.Trim();

            comando.Parameters.Add(
                "@descripcion",
                SqlDbType.VarChar,
                255
            ).Value =
                string.IsNullOrWhiteSpace(
                    cultivo.Descripcion
                )
                    ? DBNull.Value
                    : cultivo.Descripcion.Trim();
        }

        // =====================================================
        // LEER FECHAS QUE PUEDEN SER NULL
        // =====================================================
        private static DateTime? LeerFechaNullable(
            SqlDataReader reader,
            string nombreColumna)
        {
            if (reader[nombreColumna] == DBNull.Value)
            {
                return null;
            }

            return Convert.ToDateTime(
                reader[nombreColumna]
            );
        }
    }
}