using System;
using System.Windows.Forms;

namespace ProjectVivero
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            lblNombreUsuario.Text =
                string.IsNullOrWhiteSpace(LoginSistema.Nombre)
                    ? "Usuario"
                    : LoginSistema.Nombre;

            lblRolUsuario.Text =
                string.IsNullOrWhiteSpace(LoginSistema.Rol)
                    ? "Sin rol"
                    : LoginSistema.Rol;

            MostrarInicio();
            timerReloj.Start();
        }

        private void MostrarInicio()
        {
            lblTituloContenido.Text = "Panel principal";

            lblMensajeContenido.Text =
                "Bienvenido al Sistema Inteligente de Monitoreo Agrícola.\n\n" +
                "Seleccione una opción del menú para comenzar.";
        }

        private void MostrarModulo(
            string titulo,
            string mensaje)
        {
            lblTituloContenido.Text = titulo;
            lblMensajeContenido.Text = mensaje;
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            MostrarInicio();
        }

        private void btnSensores_Click(object sender, EventArgs e)
        {
            MostrarModulo(
                "Sensores",
                "En este apartado se mostrarán los sensores registrados."
            );
        }

        private void btnMediciones_Click(object sender, EventArgs e)
        {
            MostrarModulo(
                "Mediciones",
                "En este apartado se mostrarán las mediciones del vivero."
            );
        }

        private void btnActuadores_Click(object sender, EventArgs e)
        {
            MostrarModulo(
                "Actuadores",
                "En este apartado se mostrarán la bomba, ventiladores y demás actuadores."
            );
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (!string.Equals(
                    LoginSistema.Rol,
                    "Administrador",
                    StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "Esta opción está disponible únicamente para administradores.",
                    "Acceso restringido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            MostrarModulo(
                "Administración de usuarios",
                "En este apartado el administrador podrá consultar y administrar usuarios."
            );
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Desea cerrar la aplicación?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void timerReloj_Tick(object sender, EventArgs e)
        {
            lblFechaHora.Text =
                DateTime.Now.ToString("dd/MM/yyyy  hh:mm:ss tt");
        }
    }
}