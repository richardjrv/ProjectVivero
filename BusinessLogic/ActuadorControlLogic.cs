using DataAccess;
using Entidades;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public static class ActuadorControlLogic
    {
        public static List<ActuadorControl> Listar()
        {
            return ActuadorControlDao.Listar();
        }

        public static ActuadorControl ObtenerPorId(
            int idActuador)
        {
            if (idActuador <= 0)
            {
                return null;
            }

            return ActuadorControlDao.ObtenerPorId(
                idActuador
            );
        }

        public static bool Insertar(
            ActuadorControl actuador)
        {
            Validar(actuador);

            actuador.IdActuador = 0;

            return ActuadorControlDao.Insertar(
                actuador
            ) > 0;
        }

        public static bool Actualizar(
            ActuadorControl actuador)
        {
            if (actuador == null ||
                actuador.IdActuador <= 0)
            {
                throw new Exception(
                    "Seleccione un actuador para editar."
                );
            }

            Validar(actuador);

            return ActuadorControlDao.Actualizar(
                actuador
            ) > 0;
        }

        public static bool EstablecerAutomatico(
            int idActuador)
        {
            ActuadorControl actual =
                ObtenerObligatorio(idActuador);

            return ActuadorControlDao
                .ActualizarComando(
                    idActuador,
                    "Automatico",
                    actual.EstadoDeseado
                ) > 0;
        }

        public static bool EstablecerManual(
            int idActuador)
        {
            ActuadorControl actual =
                ObtenerObligatorio(idActuador);

            return ActuadorControlDao
                .ActualizarComando(
                    idActuador,
                    "Manual",
                    actual.EstadoDeseado
                ) > 0;
        }

        public static bool Encender(
            int idActuador)
        {
            ObtenerObligatorio(idActuador);

            return ActuadorControlDao
                .ActualizarComando(
                    idActuador,
                    "Manual",
                    true
                ) > 0;
        }

        public static bool Apagar(
            int idActuador)
        {
            ObtenerObligatorio(idActuador);

            return ActuadorControlDao
                .ActualizarComando(
                    idActuador,
                    "Manual",
                    false
                ) > 0;
        }

        public static bool ReportarEstadoActual(
            int idActuador,
            bool estadoActual)
        {
            ObtenerObligatorio(idActuador);

            return ActuadorControlDao
                .ActualizarEstadoActual(
                    idActuador,
                    estadoActual
                ) > 0;
        }

        public static bool Eliminar(int idActuador)
        {
            if (idActuador <= 0)
            {
                throw new Exception(
                    "Seleccione un actuador para eliminar."
                );
            }

            return ActuadorControlDao.Eliminar(
                idActuador
            ) > 0;
        }

        private static ActuadorControl ObtenerObligatorio(
            int idActuador)
        {
            if (idActuador <= 0)
            {
                throw new Exception(
                    "Seleccione un actuador."
                );
            }

            ActuadorControl actuador =
                ActuadorControlDao.ObtenerPorId(
                    idActuador
                );

            if (actuador == null)
            {
                throw new Exception(
                    "El actuador seleccionado ya no existe."
                );
            }

            if (!string.Equals(
                    actuador.EstadoRegistro,
                    "Activo",
                    StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                    "El actuador está inactivo."
                );
            }

            return actuador;
        }

        private static void Validar(
            ActuadorControl actuador)
        {
            if (actuador == null)
            {
                throw new Exception(
                    "Los datos del actuador son obligatorios."
                );
            }

            if (actuador.IdVivero <= 0)
            {
                throw new Exception(
                    "Seleccione el vivero."
                );
            }

            if (string.IsNullOrWhiteSpace(
                    actuador.NombreActuador))
            {
                throw new Exception(
                    "Ingrese el nombre del actuador."
                );
            }

            if (actuador.NombreActuador.Trim().Length > 100)
            {
                throw new Exception(
                    "El nombre no puede superar 100 caracteres."
                );
            }

            if (string.IsNullOrWhiteSpace(
                    actuador.TipoActuador))
            {
                throw new Exception(
                    "Seleccione el tipo de actuador."
                );
            }

            if (string.IsNullOrWhiteSpace(
                    actuador.ModoControl))
            {
                actuador.ModoControl = "Automatico";
            }

            if (actuador.ModoControl != "Automatico" &&
                actuador.ModoControl != "Manual")
            {
                throw new Exception(
                    "El modo debe ser Automatico o Manual."
                );
            }

            if (string.IsNullOrWhiteSpace(
                    actuador.EstadoRegistro))
            {
                actuador.EstadoRegistro = "Activo";
            }
        }
    }
}
