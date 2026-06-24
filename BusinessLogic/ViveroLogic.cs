using DataAccess;
using Entidades;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public static class ViveroLogic
    {
        public static List<Vivero> Listar()
        {
            return ViveroDao.Listar();
        }

        public static bool Insertar(Vivero vivero)
        {
            Validar(vivero);

            vivero.IdVivero = 0;

            return ViveroDao.Insertar(vivero) > 0;
        }

        public static bool Actualizar(Vivero vivero)
        {
            if (vivero.IdVivero <= 0)
            {
                throw new Exception(
                    "Seleccione un vivero para editar."
                );
            }

            Validar(vivero);

            return ViveroDao.Actualizar(vivero) > 0;
        }

        public static bool Eliminar(int idVivero)
        {
            if (idVivero <= 0)
            {
                throw new Exception(
                    "Seleccione un vivero para eliminar."
                );
            }

            return ViveroDao.Eliminar(idVivero) > 0;
        }

        private static void Validar(Vivero vivero)
        {
            if (vivero == null)
            {
                throw new Exception(
                    "Los datos del vivero son obligatorios."
                );
            }

            if (string.IsNullOrWhiteSpace(
                    vivero.NombreVivero))
            {
                throw new Exception(
                    "Ingrese el nombre del vivero."
                );
            }

            if (vivero.NombreVivero.Trim().Length > 100)
            {
                throw new Exception(
                    "El nombre no puede superar 100 caracteres."
                );
            }

            if (string.IsNullOrWhiteSpace(
                    vivero.Ubicacion))
            {
                throw new Exception(
                    "Ingrese la ubicación del vivero."
                );
            }

            if (vivero.Ubicacion.Trim().Length > 120)
            {
                throw new Exception(
                    "La ubicación no puede superar 120 caracteres."
                );
            }

            if (string.IsNullOrWhiteSpace(
                    vivero.TipoVivero))
            {
                throw new Exception(
                    "Ingrese el tipo de vivero."
                );
            }

            if (vivero.TipoVivero.Trim().Length > 50)
            {
                throw new Exception(
                    "El tipo de vivero no puede superar 50 caracteres."
                );
            }

            if (vivero.FechaInstalacion == DateTime.MinValue)
            {
                vivero.FechaInstalacion = DateTime.Now;
            }

            if (!string.IsNullOrWhiteSpace(
                    vivero.Descripcion) &&
                vivero.Descripcion.Trim().Length > 255)
            {
                throw new Exception(
                    "La descripción no puede superar 255 caracteres."
                );
            }
        }
    }
}