using DataAccess;
using Entidades;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public static class SensorCatalogoLogic
    {
        public static List<SensorCatalogo> Listar()
        {
            return SensorCatalogoDao.Listar();
        }

        public static bool Insertar(
            SensorCatalogo sensor)
        {
            Validar(sensor);

            sensor.IdSensor = 0;

            return SensorCatalogoDao.Insertar(sensor) > 0;
        }

        public static bool Actualizar(
            SensorCatalogo sensor)
        {
            if (sensor == null)
            {
                throw new Exception(
                    "Los datos del sensor son obligatorios."
                );
            }

            if (sensor.IdSensor <= 0)
            {
                throw new Exception(
                    "Seleccione un sensor para editar."
                );
            }

            Validar(sensor);

            return SensorCatalogoDao.Actualizar(sensor) > 0;
        }

        public static bool Eliminar(int idSensor)
        {
            if (idSensor <= 0)
            {
                throw new Exception(
                    "Seleccione un sensor para eliminar."
                );
            }

            return SensorCatalogoDao.Eliminar(idSensor) > 0;
        }

        private static void Validar(
            SensorCatalogo sensor)
        {
            if (sensor == null)
            {
                throw new Exception(
                    "Los datos del sensor son obligatorios."
                );
            }

            if (sensor.IdVivero <= 0)
            {
                throw new Exception(
                    "Seleccione el vivero del sensor."
                );
            }

            if (string.IsNullOrWhiteSpace(
                    sensor.NombreSensor))
            {
                throw new Exception(
                    "Ingrese el nombre del sensor."
                );
            }

            if (sensor.NombreSensor.Trim().Length > 100)
            {
                throw new Exception(
                    "El nombre del sensor no puede superar " +
                    "los 100 caracteres."
                );
            }

            if (string.IsNullOrWhiteSpace(
                    sensor.TipoSensor))
            {
                throw new Exception(
                    "Seleccione el tipo del sensor."
                );
            }

            if (sensor.TipoSensor.Trim().Length > 50)
            {
                throw new Exception(
                    "El tipo del sensor no puede superar " +
                    "los 50 caracteres."
                );
            }

            if (string.IsNullOrWhiteSpace(
                    sensor.EstadoSensor))
            {
                sensor.EstadoSensor = "Activo";
            }

            if (sensor.EstadoSensor.Trim().Length > 20)
            {
                throw new Exception(
                    "El estado del sensor no puede superar " +
                    "los 20 caracteres."
                );
            }
        }
    }
}
