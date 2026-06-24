using DataAccess;
using Entidades;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public static class DatoSensorLogic
    {
        // =====================================================
        // GUARDAR MEDICIÓN
        // =====================================================
        public static bool Guardar(DatoSensor dato)
        {
            Validar(dato);

            if (dato.FechaHora == DateTime.MinValue)
            {
                dato.FechaHora = DateTime.Now;
            }

            return DatoSensorDao.Insertar(dato) > 0;
        }

        // También puede llamarse Insertar.
        public static bool Insertar(DatoSensor dato)
        {
            return Guardar(dato);
        }

        // =====================================================
        // OBTENER LA ÚLTIMA MEDICIÓN
        // =====================================================
        public static DatoSensor ObtenerUltima()
        {
            return DatoSensorDao.ObtenerUltima();
        }

        // =====================================================
        // LISTAR LAS ÚLTIMAS MEDICIONES
        // =====================================================
        public static List<DatoSensor> ListarUltimos(
            int cantidad = 100)
        {
            if (cantidad <= 0)
            {
                cantidad = 100;
            }

            if (cantidad > 1000)
            {
                cantidad = 1000;
            }

            return DatoSensorDao.ListarUltimos(
                cantidad
            );
        }

        // =====================================================
        // LISTAR POR RANGO PARA LAS GRÁFICAS
        // =====================================================
        public static List<DatoSensor> ListarPorRango(
            DateTime fechaInicio,
            DateTime fechaFin)
        {
            if (fechaInicio > fechaFin)
            {
                throw new Exception(
                    "La fecha inicial no puede ser posterior " +
                    "a la fecha final."
                );
            }

            return DatoSensorDao.ListarPorRango(
                fechaInicio,
                fechaFin
            );
        }

        // =====================================================
        // VALIDAR MEDICIÓN
        // =====================================================
        private static void Validar(DatoSensor dato)
        {
            if (dato == null)
            {
                throw new Exception(
                    "Los datos de la medición son obligatorios."
                );
            }

            if (double.IsNaN(dato.Temperatura) ||
                double.IsInfinity(dato.Temperatura))
            {
                throw new Exception(
                    "La temperatura no es válida."
                );
            }

            if (double.IsNaN(dato.HumedadAire) ||
                double.IsInfinity(dato.HumedadAire))
            {
                throw new Exception(
                    "La humedad del aire no es válida."
                );
            }

            if (double.IsNaN(dato.HumedadSuelo) ||
                double.IsInfinity(dato.HumedadSuelo))
            {
                throw new Exception(
                    "La humedad del suelo no es válida."
                );
            }

            if (dato.HumedadAire < 0 ||
                dato.HumedadAire > 100)
            {
                throw new Exception(
                    "La humedad del aire debe estar " +
                    "entre 0 y 100%."
                );
            }

            if (dato.HumedadSuelo < 0 ||
                dato.HumedadSuelo > 100)
            {
                throw new Exception(
                    "La humedad del suelo debe estar " +
                    "entre 0 y 100%."
                );
            }
        }
    }
}