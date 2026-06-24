using System;
using System.Net.Mail;
using System.Windows.Forms;
using BusinessLogic;

namespace ProjectVivero
{
    public partial class frmRegistro : Form
    {
        public string UsuarioRegistrado { get; private set; } = "";

        public frmRegistro()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string nombreUsuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text;
            string confirmar = txtConfirmar.Text;

            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(nombreUsuario) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmar))
            {
                MessageBox.Show(
                    "Complete todos los campos.",
                    "Campos vacíos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (!CorreoValido(correo))
            {
                MessageBox.Show(
                    "Ingrese un correo electrónico válido.",
                    "Correo inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtCorreo.Focus();
                txtCorreo.SelectAll();
                return;
            }

            if (nombreUsuario.Contains(" "))
            {
                MessageBox.Show(
                    "El usuario no debe contener espacios.",
                    "Usuario inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtUsuario.Focus();
                txtUsuario.SelectAll();
                return;
            }

            if (password.Length < 4)
            {
                MessageBox.Show(
                    "La contraseña debe tener al menos 4 caracteres.",
                    "Contraseña inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtPassword.Focus();
                return;
            }

            if (password != confirmar)
            {
                MessageBox.Show(
                    "Las contraseñas no coinciden.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                txtConfirmar.Clear();
                txtConfirmar.Focus();
                return;
            }

            try
            {
                bool registrado =
                    UsuarioLogic.InsertarNuevoUsuario(
                        nombre,
                        correo,
                        nombreUsuario,
                        password,
                        "Usuario"
                    );

                if (!registrado)
                {
                    MessageBox.Show(
                        "El correo o el usuario ya existen.",
                        "Registro no realizado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                UsuarioRegistrado = nombreUsuario;

                MessageBox.Show(
                    "Usuario registrado correctamente.\n" +
                    "Ahora puede iniciar sesión.",
                    "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Cierra Registro y devuelve el control al mismo Login.
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo registrar el usuario.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private static bool CorreoValido(string correo)
        {
            try
            {
                MailAddress direccion = new MailAddress(correo);
                return direccion.Address == correo;
            }
            catch
            {
                return false;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
