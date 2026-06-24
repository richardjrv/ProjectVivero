using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectVivero
{
    public partial class frmInicio : Form
    {
        // Formulario abierto dentro del panel central.
        // Esta variable debe existir una sola vez.
        private Form formularioActivo = null;

        public frmInicio()
        {
            InitializeComponent();
        }

        // =====================================================
        // CARGAR FORMULARIO PRINCIPAL
        // =====================================================
        private void frmInicio_Load(
            object sender,
            EventArgs e)
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
        // COMPROBAR SI ES ADMINISTRADOR
        // =====================================================
        private bool EsAdministrador()
        {
            return string.Equals(
                LoginSistema.Rol,
                "Administrador",
                StringComparison.OrdinalIgnoreCase
            );
        }

        // =====================================================
        // PERMISOS SEGÚN EL ROL
        // =====================================================
        private void AplicarPermisos()
        {
            bool esAdministrador =
                EsAdministrador();

            // Opciones visibles para todos.
            btnInicio.Visible = true;
            btnViveros.Visible = true;
            btnCultivos.Visible = true;
            btnActuadores.Visible = true;

            // Opciones exclusivas del administrador.
            btnSensores.Visible = esAdministrador;
            btnMediciones.Visible = esAdministrador;
            btnUsuarios.Visible = esAdministrador;

            ReorganizarMenu();
        }

        // =====================================================
        // REORGANIZAR BOTONES PARA EVITAR ESPACIOS VACÍOS
        // =====================================================
        private void ReorganizarMenu()
        {
            pnlMenu.SuspendLayout();

            int posicionY = 110;
            const int altoBoton = 48;

            Button[] botonesMenu =
            {
                btnInicio,
                btnViveros,
                btnCultivos,
                btnSensores,
                btnMediciones,
                btnActuadores,
                btnUsuarios
            };

            foreach (Button boton in botonesMenu)
            {
                if (!boton.Visible)
                {
                    continue;
                }

                boton.Location = new Point(
                    0,
                    posicionY
                );

                boton.Size = new Size(
                    pnlMenu.Width,
                    altoBoton
                );

                posicionY += altoBoton;
            }

            pnlMenu.ResumeLayout();
        }

        // =====================================================
        // CERRAR FORMULARIO ACTIVO
        // =====================================================
        private void CerrarFormularioActivo()
        {
            if (formularioActivo == null)
            {
                return;
            }

            pnlContenido.Controls.Remove(
                formularioActivo
            );

            formularioActivo.Close();
            formularioActivo.Dispose();
            formularioActivo = null;
        }

        // =====================================================
        // ABRIR FORMULARIO DENTRO DEL PANEL CENTRAL
        // =====================================================
        private void AbrirFormularioEnPanel(
            Form formulario)
        {
            CerrarFormularioActivo();

            pnlContenido.Controls.Clear();

            formularioActivo = formulario;

            formulario.TopLevel = false;

            formulario.FormBorderStyle =
                FormBorderStyle.None;

            formulario.Dock =
                DockStyle.Fill;

            pnlContenido.Controls.Add(
                formulario
            );

            pnlContenido.Tag =
                formulario;

            formulario.BringToFront();
            formulario.Show();
        }

        // =====================================================
        // ABRIR UN FORMULARIO POR SU NOMBRE
        // =====================================================
        // Esto se usa para Actuadores.
        // Mientras frmActuadores no exista, muestra un mensaje.
        // Cuando lo creemos, se abrirá automáticamente sin editar
        // otra vez este archivo.
        private void AbrirFormularioPorNombre(
            string nombreFormulario,
            string tituloTemporal,
            string mensajeTemporal)
        {
            Type tipoFormulario =
                typeof(frmInicio)
                    .Assembly
                    .GetType(
                        "ProjectVivero." +
                        nombreFormulario
                    );

            if (tipoFormulario != null &&
                typeof(Form).IsAssignableFrom(
                    tipoFormulario
                ))
            {
                Form formulario =
                    Activator.CreateInstance(
                        tipoFormulario
                    ) as Form;

                if (formulario != null)
                {
                    AbrirFormularioEnPanel(
                        formulario
                    );

                    return;
                }
            }

            MostrarContenido(
                tituloTemporal,
                mensajeTemporal
            );
        }

        // =====================================================
        // MOSTRAR CONTENIDO SIMPLE
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

                BackColor =
                    Color.FromArgb(
                        242,
                        245,
                        243
                    ),

                Padding =
                    new Padding(40)
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

                ForeColor =
                    Color.FromArgb(
                        27,
                        94,
                        52
                    ),

                Text = titulo,

                TextAlign =
                    ContentAlignment.MiddleLeft
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

                ForeColor =
                    Color.FromArgb(
                        70,
                        80,
                        75
                    ),

                Text = mensaje,

                TextAlign =
                    ContentAlignment.TopLeft,

                Padding =
                    new Padding(
                        0,
                        35,
                        0,
                        0
                    )
            };

            panelModulo.Controls.Add(
                lblMensaje
            );

            panelModulo.Controls.Add(
                lblTitulo
            );

            pnlContenido.Controls.Add(
                panelModulo
            );
        }

        // =====================================================
        // MOSTRAR INICIO
        // =====================================================
        private void MostrarInicio()
        {
            MostrarContenido(
                "Panel principal",

                "Bienvenido al Sistema Inteligente de " +
                "Monitoreo Agrícola.\n\n" +

                "Seleccione una opción del menú " +
                "para comenzar."
            );
        }

        // =====================================================
        // BOTÓN INICIO
        // =====================================================
        private void btnInicio_Click(
            object sender,
            EventArgs e)
        {
            MostrarInicio();
        }

        // =====================================================
        // BOTÓN VIVEROS
        // =====================================================
        private void btnViveros_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormularioEnPanel(
                new frmViveros()
            );
        }

        // =====================================================
        // BOTÓN CULTIVOS
        // =====================================================
        private void btnCultivos_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormularioEnPanel(
                new frmCultivos()
            );
        }

        // =====================================================
        // BOTÓN SENSORES
        // =====================================================
        private void btnSensores_Click(
            object sender,
            EventArgs e)
        {
            if (!EsAdministrador())
            {
                MostrarAccesoRestringido();
                return;
            }

            AbrirFormularioEnPanel(
                new frmSensores()
            );
        }

        // =====================================================
        // BOTÓN MEDICIONES
        // =====================================================
        private void btnMediciones_Click(
            object sender,
            EventArgs e)
        {
            if (!EsAdministrador())
            {
                MostrarAccesoRestringido();
                return;
            }

            AbrirFormularioEnPanel(
                new frmMediciones()
            );
        }

        // =====================================================
        // BOTÓN ACTUADORES
        // =====================================================
        private void btnActuadores_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormularioPorNombre(
                "frmActuadores",

                "Control de actuadores",

                "En este apartado se mostrarán y controlarán " +
                "los actuadores del vivero.\n\n" +

                "Bomba de agua\n" +
                "Ventiladores\n" +
                "Modo automático y manual\n\n" +

                "El administrador podrá encender y apagar " +
                "los dispositivos.\n\n" +

                "El usuario normal podrá consultar su estado."
            );
        }

        // =====================================================
        // BOTÓN USUARIOS
        // =====================================================
        private void btnUsuarios_Click(
            object sender,
            EventArgs e)
        {
            if (!EsAdministrador())
            {
                MostrarAccesoRestringido();
                return;
            }

            AbrirFormularioEnPanel(
                new frmUsuarios()
            );
        }

        // =====================================================
        // MENSAJE DE ACCESO RESTRINGIDO
        // =====================================================
        private static void MostrarAccesoRestringido()
        {
            MessageBox.Show(
                "Esta opción está disponible únicamente " +
                "para administradores.",

                "Acceso restringido",

                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        // =====================================================
        // BOTÓN SALIR
        // =====================================================
        private void btnSalir_Click(
            object sender,
            EventArgs e)
        {
            DialogResult respuesta =
                MessageBox.Show(
                    "¿Desea cerrar la aplicación?",

                    "Confirmar salida",

                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (respuesta ==
                DialogResult.Yes)
            {
                CerrarFormularioActivo();

                LoginSistema.CerrarSesion();

                Application.Exit();
            }
        }

        // =====================================================
        // RELOJ
        // =====================================================
        private void timerReloj_Tick(
            object sender,
            EventArgs e)
        {
            lblFechaHora.Text =
                DateTime.Now.ToString(
                    "dd/MM/yyyy  hh:mm:ss tt"
                );
        }
    }
}