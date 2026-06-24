using BusinessLogic;
using Entidades;
using ProyectoVivero;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProjectVivero
{
    public partial class frmLogin : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int SendMessage(
            IntPtr hWnd,
            int msg,
            IntPtr wParam,
            string lParam
        );

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            SendMessage(
                txtUsuario.Handle,
                EM_SETCUEBANNER,
                (IntPtr)1,
                "Ingrese su usuario"
            );

            SendMessage(
                txtPassword.Handle,
                EM_SETCUEBANNER,
                (IntPtr)1,
                "Ingrese su contraseña"
            );

            txtUsuario.Focus();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(nombreUsuario) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Complete el usuario y la contraseña.",
                    "Campos vacíos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {
                Usuario usuario =
                    UsuarioLogic.getUsuarioPorUsername(nombreUsuario);

                if (usuario == null)
                {
                    MessageBox.Show(
                        "El usuario no existe o está inactivo.",
                        "Acceso denegado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    txtUsuario.Focus();
                    txtUsuario.SelectAll();
                    return;
                }

                // Contraseña normal, sin PasswordHash.
                if (password != usuario.Password)
                {
                    MessageBox.Show(
                        "La contraseña es incorrecta.",
                        "Acceso denegado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                LoginSistema.IdUsuario = usuario.IdUsuario;
                LoginSistema.Nombre = usuario.NombreCompleto;
                LoginSistema.Rol = usuario.NombreRol;

                Hide();

                using (frmInicio principal = new frmInicio())
                {
                    principal.ShowDialog();
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo iniciar sesión.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void lnkRegistrar_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            // Se oculta temporalmente el Login.
            Hide();

            using (frmRegistro registro = new frmRegistro())
            {
                DialogResult resultado = registro.ShowDialog();

                // Al cerrar Registro vuelve a mostrarse EL MISMO Login.
                Show();
                Activate();

                if (resultado == DialogResult.OK)
                {
                    txtUsuario.Text = registro.UsuarioRegistrado;
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
                else
                {
                    txtUsuario.Focus();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
