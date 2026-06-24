namespace ProjectVivero
{
    public static class LoginSistema
    {
        public static int IdUsuario { get; set; }

        public static string Nombre { get; set; } = "";

        public static string Rol { get; set; } = "";

        public static void CerrarSesion()
        {
            IdUsuario = 0;
            Nombre = "";
            Rol = "";
        }
    }
}