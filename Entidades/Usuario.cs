namespace Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public string NombreCompleto { get; set; } = "";

        public string Correo { get; set; } = "";

        public string Username { get; set; } = "";

        public string Password { get; set; } = "";

        public string NombreRol { get; set; } = "";
    }
}