using DataAccess;
using Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace BusinessLogic
{
    public static class UsuarioAdminLogic
    {
        public static List<Usuario> Listar()
        {
            return UsuarioAdminDao.Listar();
        }

        public static bool Insertar(Usuario usuario)
        {
            Validar(
                usuario,
                passwordObligatoria: true
            );

            if (UsuarioAdminDao.ExisteUsuarioOCorreo(
                    usuario.Username,
                    usuario.Correo,
                    0))
            {
                throw new Exception(
                    "El nombre de usuario o correo ya está registrado."
                );
            }

            try
            {
                return UsuarioAdminDao.Insertar(usuario) > 0;
            }
            catch (SqlException ex)
                when (ex.Number == 2601 ||
                      ex.Number == 2627)
            {
                throw new Exception(
                    "El nombre de usuario o correo ya está registrado."
                );
            }
        }

        public static bool Actualizar(Usuario usuario)
        {
            if (usuario == null ||
                usuario.IdUsuario <= 0)
            {
                throw new Exception(
                    "Seleccione un usuario para editar."
                );
            }

            Validar(
                usuario,
                passwordObligatoria: false
            );

            if (UsuarioAdminDao.ExisteUsuarioOCorreo(
                    usuario.Username,
                    usuario.Correo,
                    usuario.IdUsuario))
            {
                throw new Exception(
                    "El nombre de usuario o correo ya pertenece a otra cuenta."
                );
            }

            try
            {
                return UsuarioAdminDao.Actualizar(usuario) > 0;
            }
            catch (SqlException ex)
                when (ex.Number == 2601 ||
                      ex.Number == 2627)
            {
                throw new Exception(
                    "El nombre de usuario o correo ya pertenece a otra cuenta."
                );
            }
        }

        public static bool Eliminar(int idUsuario)
        {
            if (idUsuario <= 0)
            {
                throw new Exception(
                    "Seleccione un usuario para eliminar."
                );
            }

            return UsuarioAdminDao.Eliminar(idUsuario) > 0;
        }

        private static void Validar(
            Usuario usuario,
            bool passwordObligatoria)
        {
            if (usuario == null)
            {
                throw new Exception(
                    "Los datos del usuario son obligatorios."
                );
            }

            if (string.IsNullOrWhiteSpace(
                    usuario.NombreCompleto))
            {
                throw new Exception(
                    "Ingrese el nombre completo."
                );
            }

            if (usuario.NombreCompleto.Trim().Length > 100)
            {
                throw new Exception(
                    "El nombre no puede superar 100 caracteres."
                );
            }

            if (string.IsNullOrWhiteSpace(
                    usuario.Username))
            {
                throw new Exception(
                    "Ingrese el nombre de usuario."
                );
            }

            if (usuario.Username.Trim().Length > 50)
            {
                throw new Exception(
                    "El nombre de usuario no puede superar 50 caracteres."
                );
            }

            if (!string.IsNullOrWhiteSpace(usuario.Correo))
            {
                try
                {
                    _ = new MailAddress(
                        usuario.Correo.Trim()
                    );
                }
                catch
                {
                    throw new Exception(
                        "Ingrese un correo válido."
                    );
                }
            }

            if (passwordObligatoria &&
                string.IsNullOrWhiteSpace(
                    usuario.Password))
            {
                throw new Exception(
                    "Ingrese una contraseña."
                );
            }

            if (!string.IsNullOrWhiteSpace(
                    usuario.Password) &&
                usuario.Password.Length < 4)
            {
                throw new Exception(
                    "La contraseña debe tener al menos 4 caracteres."
                );
            }

            if (string.IsNullOrWhiteSpace(
                    usuario.NombreRol))
            {
                throw new Exception(
                    "Seleccione un rol."
                );
            }

            if (string.IsNullOrWhiteSpace(
                    usuario.Estado))
            {
                usuario.Estado = "Activo";
            }
        }
    }
}
