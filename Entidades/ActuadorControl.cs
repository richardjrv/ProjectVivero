using System;

namespace Entidades
{
    public class ActuadorControl
    {
        public int IdActuador { get; set; }

        public int IdVivero { get; set; }

        public string NombreVivero { get; set; } = "";

        public string NombreActuador { get; set; } = "";

        public string TipoActuador { get; set; } = "";

        public string ModoControl { get; set; } = "Automatico";

        public bool EstadoDeseado { get; set; }

        public bool EstadoActual { get; set; }

        public DateTime FechaActualizacion { get; set; }

        public string EstadoRegistro { get; set; } = "Activo";

        public string EstadoDeseadoTexto =>
            EstadoDeseado ? "Encendido" : "Apagado";

        public string EstadoActualTexto =>
            EstadoActual ? "Encendido" : "Apagado";
    }
}
