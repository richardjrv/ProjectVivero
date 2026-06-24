using BusinessLogic;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensoresController : ControllerBase
    {
        [HttpPost]
        public IActionResult Guardar([FromBody] Sensor sensor)
        {
            if (sensor == null)
            {
                return BadRequest(
                    new
                    {
                        mensaje = "No se recibieron datos del sensor."
                    }
                );
            }

            try
            {
                bool guardado = SensorLogic.Guardar(sensor);

                if (!guardado)
                {
                    return BadRequest(
                        new
                        {
                            mensaje = "No se pudo guardar la medición."
                        }
                    );
                }

                return Ok(
                    new
                    {
                        mensaje = "Medición guardada correctamente."
                    }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    new
                    {
                        mensaje = "Error al guardar la medición.",
                        error = ex.Message
                    }
                );
            }
        }
    }
}