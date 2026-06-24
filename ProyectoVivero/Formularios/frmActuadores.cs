using BusinessLogic;
using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProjectVivero
{
    public partial class frmActuadores : Form
    {
        private int idActuadorSeleccionado = 0;
        private bool actualizando = false;

        public frmActuadores()
        {
            InitializeComponent();
        }

        private void frmActuadores_Load(
            object sender,
            EventArgs e)
        {
            AplicarPermisos();
            CargarViveros();
            CargarActuadores();
            LimpiarCampos();

            timerActualizacion.Interval = 3000;
            timerActualizacion.Start();
        }

        private bool EsAdministrador()
        {
            return string.Equals(
                LoginSistema.Rol,
                "Administrador",
                StringComparison.OrdinalIgnoreCase
            );
        }

        private void AplicarPermisos()
        {
            bool esAdministrador =
                EsAdministrador();

            pnlFormulario.Visible =
                esAdministrador;

            if (esAdministrador)
            {
                pnlFormulario.Dock =
                    DockStyle.Left;

                pnlListado.Dock =
                    DockStyle.Fill;

                lblModoAcceso.Text =
                    "Modo administrador: puede configurar y controlar actuadores.";

                lblModoAcceso.ForeColor =
                    Color.FromArgb(28, 120, 58);
            }
            else
            {
                pnlFormulario.Visible =
                    false;

                pnlListado.Dock =
                    DockStyle.Fill;

                lblModoAcceso.Text =
                    "Modo consulta: puede visualizar el estado de los actuadores.";

                lblModoAcceso.ForeColor =
                    Color.FromArgb(90, 90, 90);
            }
        }

        private void timerActualizacion_Tick(
            object sender,
            EventArgs e)
        {
            CargarActuadores(
                mostrarErrores: false
            );
        }

        private void CargarViveros()
        {
            try
            {
                List<Vivero> viveros =
                    ViveroLogic.Listar();

                cmbVivero.DataSource = null;
                cmbVivero.DisplayMember =
                    "NombreVivero";
                cmbVivero.ValueMember =
                    "IdVivero";
                cmbVivero.DataSource =
                    viveros;

                cmbVivero.SelectedIndex =
                    viveros.Count > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los viveros.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CargarActuadores(
            bool mostrarErrores = true)
        {
            if (actualizando)
            {
                return;
            }

            actualizando = true;

            try
            {
                List<ActuadorControl> lista =
                    ActuadorControlLogic.Listar();

                dgvActuadores.DataSource = null;
                dgvActuadores.DataSource = lista;

                lblCantidad.Text =
                    $"Actuadores registrados: {lista.Count}";

                ActualizarTarjetas(lista);
            }
            catch (Exception ex)
            {
                if (mostrarErrores)
                {
                    MessageBox.Show(
                        "No se pudieron cargar los actuadores.\n\n" +
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            finally
            {
                actualizando = false;
            }
        }

        private void ActualizarTarjetas(
            List<ActuadorControl> lista)
        {
            ActuadorControl bomba =
                lista.FirstOrDefault(
                    a => a.NombreActuador
                        .IndexOf(
                            "bomba",
                            StringComparison.OrdinalIgnoreCase
                        ) >= 0
                );

            ActuadorControl ventiladores =
                lista.FirstOrDefault(
                    a => a.NombreActuador
                        .IndexOf(
                            "vent",
                            StringComparison.OrdinalIgnoreCase
                        ) >= 0
                );

            MostrarTarjeta(
                bomba,
                lblBombaEstado,
                lblBombaModo,
                "Bomba no registrada"
            );

            MostrarTarjeta(
                ventiladores,
                lblVentiladorEstado,
                lblVentiladorModo,
                "Ventiladores no registrados"
            );
        }

        private static void MostrarTarjeta(
            ActuadorControl actuador,
            Label lblEstado,
            Label lblModo,
            string textoSinRegistro)
        {
            if (actuador == null)
            {
                lblEstado.Text =
                    textoSinRegistro;

                lblEstado.ForeColor =
                    Color.Gray;

                lblModo.Text =
                    "Modo: --";

                return;
            }

            lblEstado.Text =
                actuador.EstadoActual
                    ? "ENCENDIDO"
                    : "APAGADO";

            lblEstado.ForeColor =
                actuador.EstadoActual
                    ? Color.FromArgb(28, 140, 65)
                    : Color.FromArgb(185, 55, 55);

            lblModo.Text =
                "Modo: " +
                actuador.ModoControl +
                " | Solicitado: " +
                actuador.EstadoDeseadoTexto;
        }

        private ActuadorControl ObtenerFormulario()
        {
            int idVivero = 0;

            if (cmbVivero.SelectedValue != null)
            {
                int.TryParse(
                    cmbVivero.SelectedValue.ToString(),
                    out idVivero
                );
            }

            return new ActuadorControl
            {
                IdActuador =
                    idActuadorSeleccionado,

                IdVivero =
                    idVivero,

                NombreActuador =
                    txtNombreActuador.Text.Trim(),

                TipoActuador =
                    cmbTipoActuador.Text.Trim(),

                ModoControl =
                    cmbModoControl.Text.Trim(),

                EstadoDeseado =
                    cmbEstadoDeseado.Text ==
                    "Encendido",

                EstadoActual = false,

                EstadoRegistro =
                    cmbEstadoRegistro.Text.Trim()
            };
        }

        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                bool guardado =
                    ActuadorControlLogic.Insertar(
                        ObtenerFormulario()
                    );

                if (!guardado)
                {
                    MessageBox.Show(
                        "No se pudo registrar el actuador.",
                        "Registro no realizado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                MessageBox.Show(
                    "Actuador registrado correctamente.",
                    "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarActuadores();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "No se pudo registrar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnEditar_Click(
            object sender,
            EventArgs e)
        {
            if (idActuadorSeleccionado <= 0)
            {
                MostrarSeleccione();
                return;
            }

            try
            {
                bool actualizado =
                    ActuadorControlLogic.Actualizar(
                        ObtenerFormulario()
                    );

                if (!actualizado)
                {
                    MessageBox.Show(
                        "No se pudo actualizar el actuador.",
                        "Actualización no realizada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                MessageBox.Show(
                    "Actuador actualizado correctamente.",
                    "Actualización exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarActuadores();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "No se pudo actualizar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnEliminar_Click(
            object sender,
            EventArgs e)
        {
            if (idActuadorSeleccionado <= 0)
            {
                MostrarSeleccione();
                return;
            }

            DialogResult respuesta =
                MessageBox.Show(
                    "¿Desea eliminar el actuador seleccionado?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                ActuadorControlLogic.Eliminar(
                    idActuadorSeleccionado
                );

                CargarActuadores();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "No se pudo eliminar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEncender_Click(
            object sender,
            EventArgs e)
        {
            EjecutarComando(
                () => ActuadorControlLogic
                    .Encender(
                        idActuadorSeleccionado
                    ),
                "Orden de encendido registrada."
            );
        }

        private void btnApagar_Click(
            object sender,
            EventArgs e)
        {
            EjecutarComando(
                () => ActuadorControlLogic
                    .Apagar(
                        idActuadorSeleccionado
                    ),
                "Orden de apagado registrada."
            );
        }

        private void btnAutomatico_Click(
            object sender,
            EventArgs e)
        {
            EjecutarComando(
                () => ActuadorControlLogic
                    .EstablecerAutomatico(
                        idActuadorSeleccionado
                    ),
                "Modo automático activado."
            );
        }

        private void btnManual_Click(
            object sender,
            EventArgs e)
        {
            EjecutarComando(
                () => ActuadorControlLogic
                    .EstablecerManual(
                        idActuadorSeleccionado
                    ),
                "Modo manual activado."
            );
        }

        private void EjecutarComando(
            Func<bool> accion,
            string mensaje)
        {
            if (idActuadorSeleccionado <= 0)
            {
                MostrarSeleccione();
                return;
            }

            try
            {
                bool resultado =
                    accion();

                if (!resultado)
                {
                    MessageBox.Show(
                        "No se pudo registrar el comando.",
                        "Comando no realizado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                MessageBox.Show(
                    mensaje +
                    "\n\nEl dispositivo físico cambiará cuando el ESP8266 consulte este comando.",
                    "Comando guardado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarActuadores();
                SeleccionarPorId(
                    idActuadorSeleccionado
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "No se pudo ejecutar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnLimpiar_Click(
            object sender,
            EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnRecargar_Click(
            object sender,
            EventArgs e)
        {
            CargarActuadores();
        }

        private void dgvActuadores_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            CargarFila(
                dgvActuadores.Rows[
                    e.RowIndex
                ]
            );
        }

        private void CargarFila(
            DataGridViewRow fila)
        {
            idActuadorSeleccionado =
                Convert.ToInt32(
                    fila.Cells[
                        "colIdActuador"
                    ].Value
                );

            txtId.Text =
                idActuadorSeleccionado.ToString();

            cmbVivero.SelectedValue =
                Convert.ToInt32(
                    fila.Cells[
                        "colIdVivero"
                    ].Value
                );

            txtNombreActuador.Text =
                Convert.ToString(
                    fila.Cells[
                        "colNombreActuador"
                    ].Value
                ) ?? "";

            cmbTipoActuador.Text =
                Convert.ToString(
                    fila.Cells[
                        "colTipoActuador"
                    ].Value
                ) ?? "";

            cmbModoControl.Text =
                Convert.ToString(
                    fila.Cells[
                        "colModoControl"
                    ].Value
                ) ?? "Automatico";

            cmbEstadoDeseado.Text =
                Convert.ToString(
                    fila.Cells[
                        "colEstadoDeseadoTexto"
                    ].Value
                ) ?? "Apagado";

            cmbEstadoRegistro.Text =
                Convert.ToString(
                    fila.Cells[
                        "colEstadoRegistro"
                    ].Value
                ) ?? "Activo";
        }

        private void SeleccionarPorId(
            int idActuador)
        {
            foreach (DataGridViewRow fila
                     in dgvActuadores.Rows)
            {
                if (Convert.ToInt32(
                        fila.Cells[
                            "colIdActuador"
                        ].Value
                    ) == idActuador)
                {
                    fila.Selected = true;
                    CargarFila(fila);
                    break;
                }
            }
        }

        private void LimpiarCampos()
        {
            idActuadorSeleccionado = 0;

            txtId.Clear();

            if (cmbVivero.Items.Count > 0)
            {
                cmbVivero.SelectedIndex = 0;
            }

            txtNombreActuador.Clear();
            cmbTipoActuador.SelectedIndex = 0;
            cmbModoControl.SelectedItem =
                "Automatico";
            cmbEstadoDeseado.SelectedItem =
                "Apagado";
            cmbEstadoRegistro.SelectedItem =
                "Activo";

            dgvActuadores.ClearSelection();
        }

        private static void MostrarSeleccione()
        {
            MessageBox.Show(
                "Seleccione un actuador de la tabla.",
                "Actuador no seleccionado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        private void frmActuadores_FormClosed(
            object sender,
            FormClosedEventArgs e)
        {
            timerActualizacion.Stop();
        }
    }
}
