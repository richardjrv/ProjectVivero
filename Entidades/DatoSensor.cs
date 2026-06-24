using System;

namespace Entidades
{
    public class DatoSensor
    {
        public int IdDato { get; set; }

        public double Temperatura { get; set; }

        public double HumedadAire { get; set; }

        public double HumedadSuelo { get; set; }

        public DateTime FechaHora { get; set; }
    }
}