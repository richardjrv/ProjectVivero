namespace Entidades
{
public class Sensor
{
    public int IdSensor { get; set; }

    public string NombreSensor { get; set; } = "";
    public double Temperatura { get; set; }
    public double HumedadAmbiente { get; set; }
    public double HumedadSuelo { get; set; }
    public DateTime Fecha { get; set; }
}
}