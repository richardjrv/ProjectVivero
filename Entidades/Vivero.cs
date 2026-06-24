using System;

namespace Entidades
{
    public class Vivero
    {
        public int IdVivero { get; set; }

        public string NombreVivero { get; set; } = "";

        public string Ubicacion { get; set; } = "";

        public string TipoVivero { get; set; } = "";

        public DateTime FechaInstalacion { get; set; }

        public string Descripcion { get; set; } = "";
    }
}