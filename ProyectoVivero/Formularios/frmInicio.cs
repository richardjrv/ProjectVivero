using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectVivero
{
    public partial class frmInicio : Form
    {
        // Solo debe existir UNA vez.
        private Form formularioActivo = null;

        public frmInicio()
        {
            InitializeComponent();
        }

        // =====================================================
        // CARGAR FORMULARIO PRINCIPAL
        // =====================================================
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

            AplicarPermisos();
            MostrarInicio();

            timerReloj.Start();
        }

        // =====================================================
        // PERMISOS SEGÚN EL ROL
        // =====================================================
        private void AplicarPermisos()
        {
            bool esAdministrador =
                string.Equals(
                    LoginSistema.Rol,
                    "Administrador",
                    StringComparison.OrdinalIgnoreCase
                );

            // Usuarios solamente será visible para administrador.
            btnUsuarios.Visible = esAdministrador;

            // Los demás módulos pueden verse con ambos roles.
            btnInicio.Visible = true;
            btnSensores.Visible = true;
            btnMediciones.Visible = true;
            btnActuadores.Visible = true;

            // Solo ejecuta esta línea si ya tienes btnViveros
            // creado en frmInicio.Designer.cs.
            btnViveros.Visible = true;
        }

        // =====================================================
        // CERRAR FORMULARIO QUE ESTÁ DENTRO DEL PANEL
        // =====================================================
        private void CerrarFormularioActivo()
        {
            if (formularioActivo == null)
            {
                return;
            }

            pnlContenido.Controls.Remove(formularioActivo);

            formularioActivo.Close();
            formularioActivo.Dispose();
            formularioActivo = null;
        }

        // =====================================================
        // ABRIR FORMULARIO DENTRO DEL PANEL CENTRAL
        // =====================================================
        private void AbrirFormularioEnPanel(Form formulario)
        {
            CerrarFormularioActivo();

            pnlContenido.Controls.Clear();

            formularioActivo = formulario;

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            pnlContenido.Controls.Add(formulario);
            pnlContenido.Tag = formulario;

            formulario.BringToFront();
            formulario.Show();
        }

        // =====================================================
        // CONSTRUIR CONTENIDO SIMPLE DENTRO DEL PANEL
        // =====================================================
        private void MostrarContenido(
            string titulo,
            string mensaje)
        {
            CerrarFormularioActivo();

            pnlContenido.Controls.Clear();

            Panel panelModulo = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(242, 245, 243),
                Padding = new Padding(40)
            };

            Label lblTitulo = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Top,
                Height = 75,
                Font = new Font(
                    "Segoe UI",
                    22F,
                    FontStyle.Bold
                ),
                ForeColor = Color.FromArgb(27, 94, 52),
                Text = titulo,
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblMensaje = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                Font = new Font(
                    "Segoe UI",
                    13F,
                    FontStyle.Regular
                ),
                ForeColor = Color.FromArgb(70, 80, 75),
                Text = mensaje,
                TextAlign = ContentAlignment.TopLeft,
                Padding = new Padding(0, 35, 0, 0)
            };

            panelModulo.Controls.Add(lblMensaje);
            panelModulo.Controls.Add(lblTitulo);

            pnlContenido.Controls.Add(panelModulo);
        }

        // =====================================================
        // MOSTRAR PANTALLA DE INICIO
        // =====================================================
        private void MostrarInicio()
        {
            MostrarContenido(
                "Panel principal",
                "Bienvenido al Sistema Inteligente de Monitoreo Agrícola.\n\n" +
                "Seleccione una opción del menú para comenzar."
            );
        }

        // =====================================================
        // BOTÓN INICIO
        // =====================================================
        private void btnInicio_Click(object sender, EventArgs e)
        {
            MostrarInicio();
        }

        // =====================================================
        // BOTÓN VIVEROS
        // =====================================================
        private void btnViveros_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(
                new frmViveros()
            );
        }

        // =====================================================
        // BOTÓN SENSORES
        // =====================================================
        private void btnSensores_Click(object sender, EventArgs e)
        {
            MostrarContenido(
                "Sensores",
                "En este apartado se mostrarán los sensores registrados.\n\n" +
                "Aquí podrá consultar temperatura, humedad ambiental " +
                "y humedad del suelo."
            );
        }

        // =====================================================
        // BOTÓN MEDICIONES
        // =====================================================
        private void btnMediciones_Click(object sender, EventArgs e)
        {
            MostrarContenido(
                "Mediciones",
                "En este apartado se mostrarán las mediciones almacenadas " +
                "en la base de datos.\n\n" +
                "Posteriormente se actualizarán automáticamente cada " +
                "3 a 5 segundos."
            );
        }

        // =====================================================
        // BOTÓN ACTUADORES
        // =====================================================
        private void btnActuadores_Click(object sender, EventArgs e)
        {
            MostrarContenido(
                "Actuadores",
                "En este apartado se mostrarán la bomba de agua, " +
                "los ventiladores y sus estados actuales.\n\n" +
                "Posteriormente se agregarán los controles de modo " +
                "automático y manual."
            );
        }

        // =====================================================
        // BOTÓN USUARIOS
        // =====================================================
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            bool esAdministrador =
                string.Equals(
                    LoginSistema.Rol,
                    "Administrador",
                    StringComparison.OrdinalIgnoreCase
                );

            if (!esAdministrador)
            {
                MessageBox.Show(
                    "Esta opción está disponible únicamente para administradores.",
                    "Acceso restringido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            MostrarContenido(
                "Administración de usuarios",
                "En este apartado el administrador podrá consultar, " +
                "editar y administrar las cuentas del sistema."
            );
        }

        // =====================================================
        // BOTÓN SALIR
        // =====================================================
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
                LoginSistema.CerrarSesion();
                Application.Exit();
            }
        }

        // =====================================================
        // RELOJ
        // =====================================================
        private void timerReloj_Tick(object sender, EventArgs e)
        {
            lblFechaHora.Text =
                DateTime.Now.ToString(
                    "dd/MM/yyyy  hh:mm:ss tt"
                );
        }
    }
}

