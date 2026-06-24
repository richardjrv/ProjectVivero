using System;

namespace Entidades
{
    public class SensorCatalogo
    {
        public int IdSensor { get; set; }

        public int IdVivero { get; set; }

        public string NombreVivero { get; set; } = "";

        public string NombreSensor { get; set; } = "";

        public string TipoSensor { get; set; } = "";

        public DateTime? FechaInstalacion { get; set; }

        public string EstadoSensor { get; set; } = "Activo";
    }
}