using DataAccess;
using Entidades;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public static class CultivoLogic
    {
        // =====================================================
        // LISTAR
        // =====================================================
        public static List<Cultivo> Listar()
        {
            return CultivoDao.Listar();
        }

        // =====================================================
        // INSERTAR
        // =====================================================
        public static bool Insertar(Cultivo cultivo)
        {
            Validar(cultivo);

            cultivo.IdCultivo = 0;

            return CultivoDao.Insertar(cultivo) > 0;
        }

        // =====================================================
        // ACTUALIZAR
        // =====================================================
        public static bool Actualizar(Cultivo cultivo)
        {
            if (cultivo == null)
            {
                throw new Exception(
                    "Los datos del cultivo son obligatorios."
                );
            }

            if (cultivo.IdCultivo <= 0)
            {
                throw new Exception(
                    "Seleccione un cultivo para editar."
                );
            }

            Validar(cultivo);

            return CultivoDao.Actualizar(cultivo) > 0;
        }

        // =====================================================
        // ELIMINAR
        // =====================================================
        public static bool Eliminar(int idCultivo)
        {
            if (idCultivo <= 0)
            {
                throw new Exception(
                    "Seleccione un cultivo para eliminar."
                );
            }

            return CultivoDao.Eliminar(idCultivo) > 0;
        }

        // =====================================================
        // VALIDACIONES
        // =====================================================
        private static void Validar(Cultivo cultivo)
        {
            if (cultivo == null)
            {
                throw new Exception(
                    "Los datos del cultivo son obligatorios."
                );
            }

            if (cultivo.IdVivero <= 0)
            {
                throw new Exception(
                    "Seleccione el vivero al que pertenece el cultivo."
                );
            }

            if (string.IsNullOrWhiteSpace(
                    cultivo.NombreCultivo))
            {
                throw new Exception(
                    "Ingrese el nombre del cultivo."
                );
            }

            if (cultivo.NombreCultivo.Trim().Length > 100)
            {
                throw new Exception(
                    "El nombre del cultivo no puede superar " +
                    "los 100 caracteres."
                );
            }

            if (!string.IsNullOrWhiteSpace(
                    cultivo.Variedad) &&
                cultivo.Variedad.Trim().Length > 100)
            {
                throw new Exception(
                    "La variedad no puede superar " +
                    "los 100 caracteres."
                );
            }

            if (!cultivo.FechaSiembra.HasValue)
            {
                throw new Exception(
                    "Seleccione la fecha de siembra."
                );
            }

            if (cultivo.FechaEstimadaCosecha.HasValue &&
                cultivo.FechaEstimadaCosecha.Value.Date <
                cultivo.FechaSiembra.Value.Date)
            {
                throw new Exception(
                    "La fecha estimada de cosecha no puede ser " +
                    "anterior a la fecha de siembra."
                );
            }

            if (cultivo.FechaCosecha.HasValue &&
                cultivo.FechaCosecha.Value.Date <
                cultivo.FechaSiembra.Value.Date)
            {
                throw new Exception(
                    "La fecha de cosecha no puede ser anterior " +
                    "a la fecha de siembra."
                );
            }

            if (string.IsNullOrWhiteSpace(cultivo.Etapa))
            {
                cultivo.Etapa = "Siembra";
            }

            if (cultivo.Etapa.Trim().Length > 50)
            {
                throw new Exception(
                    "La etapa no puede superar los 50 caracteres."
                );
            }

            if (string.IsNullOrWhiteSpace(cultivo.Estado))
            {
                cultivo.Estado = "Activo";
            }

            if (cultivo.Estado.Trim().Length > 20)
            {
                throw new Exception(
                    "El estado no puede superar los 20 caracteres."
                );
            }

            if (!string.IsNullOrWhiteSpace(
                    cultivo.Descripcion) &&
                cultivo.Descripcion.Trim().Length > 255)
            {
                throw new Exception(
                    "La descripción no puede superar " +
                    "los 255 caracteres."
                );
            }
        }
    }
}