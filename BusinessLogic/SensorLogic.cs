using System;
using DataAccess;
using Entidades;

namespace BusinessLogic
{
    public class SensorLogic
    {
        public static int Insertar(Sensor sensor)
        {
            if (sensor == null)
            {
                throw new ArgumentNullException(nameof(sensor));
            }

            return SensorDao.Insertar(sensor);
        }

        public static bool Guardar(Sensor sensor)
        {
            int filasAfectadas = Insertar(sensor);

            return filasAfectadas > 0;
        }
    }
}