using BusinessLogic;
using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectVivero
{
    public partial class frmSensores : Form
    {
        private int idSensorSeleccionado = 0;

        public frmSensores()
        {
            InitializeComponent();
        }

        private void frmSensores_Load(object sender, EventArgs e)
        {
            if (!EsAdministrador())
            {
                MessageBox.Show(
                    "El módulo Sensores está disponible únicamente para administradores.",
                    "Acceso restringido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                Close();
                return;
            }

            AplicarPermisos();
            CargarViveros();
            CargarSensores();
            LimpiarCampos();
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
            pnlFormulario.Visible = true;
            pnlFormulario.Dock = DockStyle.Left;
            pnlListado.Dock = DockStyle.Fill;

            lblModo.Text =
                "Modo administrador: puede registrar, editar y eliminar sensores.";

            lblModo.ForeColor =
                Color.FromArgb(28, 120, 58);
        }

        private void CargarViveros()
        {
            try
            {
                List<Vivero> viveros = ViveroLogic.Listar();

                cmbVivero.DataSource = null;
                cmbVivero.DisplayMember = "NombreVivero";
                cmbVivero.ValueMember = "IdVivero";
                cmbVivero.DataSource = viveros;

                cmbVivero.SelectedIndex =
                    viveros.Count > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los viveros.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CargarSensores()
        {
            try
            {
                List<SensorCatalogo> sensores =
                    SensorCatalogoLogic.Listar();

                dgvSensores.DataSource = null;
                dgvSensores.DataSource = sensores;

                lblCantidad.Text =
                    $"Sensores registrados: {sensores.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los sensores.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private SensorCatalogo ObtenerDatosFormulario()
        {
            int idVivero = 0;

            if (cmbVivero.SelectedValue != null)
            {
                int.TryParse(
                    cmbVivero.SelectedValue.ToString(),
                    out idVivero
                );
            }

            return new SensorCatalogo
            {
                IdSensor = idSensorSeleccionado,
                IdVivero = idVivero,
                NombreSensor = txtNombreSensor.Text.Trim(),
                TipoSensor = cmbTipoSensor.Text.Trim(),
                FechaInstalacion =
                    dtpFechaInstalacion.Checked
                        ? dtpFechaInstalacion.Value
                        : null,
                EstadoSensor = cmbEstadoSensor.Text.Trim()
            };
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                SensorCatalogo sensor =
                    ObtenerDatosFormulario();

                bool guardado =
                    SensorCatalogoLogic.Insertar(sensor);

                if (!guardado)
                {
                    MessageBox.Show(
                        "No se pudo registrar el sensor.",
                        "Registro no realizado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                MessageBox.Show(
                    "Sensor registrado correctamente.",
                    "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarSensores();
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSensorSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Seleccione un sensor de la tabla.",
                    "Sensor no seleccionado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {
                SensorCatalogo sensor =
                    ObtenerDatosFormulario();

                bool actualizado =
                    SensorCatalogoLogic.Actualizar(sensor);

                if (!actualizado)
                {
                    MessageBox.Show(
                        "No se pudo actualizar el sensor.",
                        "Actualización no realizada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                MessageBox.Show(
                    "Sensor actualizado correctamente.",
                    "Actualización exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarSensores();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSensorSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Seleccione un sensor de la tabla.",
                    "Sensor no seleccionado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult respuesta = MessageBox.Show(
                $"¿Desea eliminar el sensor \"{txtNombreSensor.Text.Trim()}\"?\n\n" +
                "Esta acción no se puede deshacer.",
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
                bool eliminado =
                    SensorCatalogoLogic.Eliminar(idSensorSeleccionado);

                if (!eliminado)
                {
                    MessageBox.Show(
                        "No se pudo eliminar el sensor.",
                        "Eliminación no realizada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                MessageBox.Show(
                    "Sensor eliminado correctamente.",
                    "Eliminación exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarSensores();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo eliminar el sensor.\n\n" +
                    "Es posible que tenga mediciones relacionadas.\n\n" +
                    ex.Message,
                    "Error al eliminar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarViveros();
            CargarSensores();
            LimpiarCampos();
        }

        private void dgvSensores_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow fila =
                dgvSensores.Rows[e.RowIndex];

            idSensorSeleccionado =
                Convert.ToInt32(
                    fila.Cells["colIdSensor"].Value
                );

            txtId.Text =
                idSensorSeleccionado.ToString();

            cmbVivero.SelectedValue =
                Convert.ToInt32(
                    fila.Cells["colIdVivero"].Value
                );

            txtNombreSensor.Text =
                Convert.ToString(
                    fila.Cells["colNombreSensor"].Value
                ) ?? "";

            cmbTipoSensor.Text =
                Convert.ToString(
                    fila.Cells["colTipoSensor"].Value
                ) ?? "";

            object fecha =
                fila.Cells["colFechaInstalacion"].Value;

            if (fecha != null &&
                fecha != DBNull.Value &&
                DateTime.TryParse(
                    fecha.ToString(),
                    out DateTime fechaInstalacion))
            {
                dtpFechaInstalacion.Value =
                    fechaInstalacion;

                dtpFechaInstalacion.Checked = true;
            }
            else
            {
                dtpFechaInstalacion.Value =
                    DateTime.Today;

                dtpFechaInstalacion.Checked = false;
            }

            cmbEstadoSensor.Text =
                Convert.ToString(
                    fila.Cells["colEstadoSensor"].Value
                ) ?? "";
        }

        private void LimpiarCampos()
        {
            idSensorSeleccionado = 0;

            txtId.Clear();

            if (cmbVivero.Items.Count > 0)
            {
                cmbVivero.SelectedIndex = 0;
            }
            else
            {
                cmbVivero.SelectedIndex = -1;
            }

            txtNombreSensor.Clear();
            cmbTipoSensor.SelectedIndex = -1;
            cmbTipoSensor.Text = "";

            dtpFechaInstalacion.Value =
                DateTime.Today;

            dtpFechaInstalacion.Checked = true;

            cmbEstadoSensor.SelectedItem =
                "Activo";

            dgvSensores.ClearSelection();
            txtNombreSensor.Focus();
        }
    }
}
