using System;

namespace Entidades
{
    public class Cultivo
    {
        public int IdCultivo { get; set; }

        public int IdVivero { get; set; }

        public string NombreVivero { get; set; } = "";

        public string NombreCultivo { get; set; } = "";

        public string Variedad { get; set; } = "";

        public DateTime? FechaSiembra { get; set; }

        public DateTime? FechaEstimadaCosecha { get; set; }

        public DateTime? FechaCosecha { get; set; }

        public string Etapa { get; set; } = "";

        public string Estado { get; set; } = "Activo";

        public string Descripcion { get; set; } = "";
    }
}
