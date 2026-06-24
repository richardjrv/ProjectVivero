using BusinessLogic;
using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectVivero
{
    public partial class frmViveros : Form
    {
        private int idViveroSeleccionado = 0;

        public frmViveros()
        {
            InitializeComponent();
        }

        private void frmViveros_Load(object sender, EventArgs e)
        {
            AplicarPermisos();
            LimpiarCampos();
            CargarViveros();
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
            bool esAdministrador = EsAdministrador();

            if (esAdministrador)
            {
                // El administrador ve el formulario y la tabla.
                pnlFormulario.Visible = true;
                pnlFormulario.Dock = DockStyle.Left;

                pnlListado.Dock = DockStyle.Fill;

                btnGuardar.Visible = true;
                btnEditar.Visible = true;
                btnEliminar.Visible = true;
                btnLimpiar.Visible = true;

                txtNombre.ReadOnly = false;
                txtUbicacion.ReadOnly = false;
                cmbTipo.Enabled = true;
                dtpFechaInstalacion.Enabled = true;
                txtDescripcion.ReadOnly = false;

                lblModo.Text =
                    "Modo administrador: puede registrar, editar y eliminar.";

                lblModo.ForeColor =
                    Color.FromArgb(28, 120, 58);

                lblListado.Text = "Viveros registrados";
            }
            else
            {
                // El usuario normal solamente ve la tabla.
                pnlFormulario.Visible = false;

                pnlListado.Dock = DockStyle.Fill;

                btnGuardar.Visible = false;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                btnLimpiar.Visible = false;
                dgvViveros.AutoSizeColumnsMode =
    DataGridViewAutoSizeColumnsMode.Fill;

                dgvViveros.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvViveros.ReadOnly = true;

                lblModo.Text =
                    "Seleccione un vivero para consultar su información.";

                lblModo.ForeColor =
                    Color.FromArgb(90, 90, 90);

                lblListado.Text = "Viveros disponibles";
            }
        }

        private void CargarViveros()
        {
            try
            {
                List<Vivero> viveros = ViveroLogic.Listar();

                dgvViveros.DataSource = null;
                dgvViveros.DataSource = viveros;

                lblCantidad.Text = $"Viveros registrados: {viveros.Count}";
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

        private Vivero ObtenerDatosFormulario()
        {
            return new Vivero
            {
                IdVivero = idViveroSeleccionado,
                NombreVivero = txtNombre.Text.Trim(),
                Ubicacion = txtUbicacion.Text.Trim(),
                TipoVivero = cmbTipo.Text.Trim(),
                FechaInstalacion = dtpFechaInstalacion.Value,
                Descripcion = txtDescripcion.Text.Trim()
            };
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!EsAdministrador())
            {
                MostrarAccesoRestringido();
                return;
            }

            try
            {
                Vivero vivero = ObtenerDatosFormulario();
                bool guardado = ViveroLogic.Insertar(vivero);

                if (!guardado)
                {
                    MessageBox.Show(
                        "No se pudo registrar el vivero.",
                        "Registro no realizado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                MessageBox.Show(
                    "Vivero registrado correctamente.",
                    "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LimpiarCampos();
                CargarViveros();
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
            if (!EsAdministrador())
            {
                MostrarAccesoRestringido();
                return;
            }

            if (idViveroSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Seleccione un vivero de la tabla.",
                    "Vivero no seleccionado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                Vivero vivero = ObtenerDatosFormulario();
                bool actualizado = ViveroLogic.Actualizar(vivero);

                if (!actualizado)
                {
                    MessageBox.Show(
                        "No se pudo actualizar el vivero.",
                        "Actualización no realizada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                MessageBox.Show(
                    "Vivero actualizado correctamente.",
                    "Actualización exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LimpiarCampos();
                CargarViveros();
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
            if (!EsAdministrador())
            {
                MostrarAccesoRestringido();
                return;
            }

            if (idViveroSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Seleccione un vivero de la tabla.",
                    "Vivero no seleccionado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                $"¿Desea eliminar el vivero \"{txtNombre.Text.Trim()}\"?\n\n" +
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
                bool eliminado = ViveroLogic.Eliminar(idViveroSeleccionado);

                if (!eliminado)
                {
                    MessageBox.Show(
                        "No se pudo eliminar el vivero.",
                        "Eliminación no realizada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                MessageBox.Show(
                    "Vivero eliminado correctamente.",
                    "Eliminación exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LimpiarCampos();
                CargarViveros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo eliminar el vivero.\n\n" +
                    "Es posible que tenga cultivos, sensores o mediciones relacionados.\n\n" +
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
        }

        private void dgvViveros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow fila = dgvViveros.Rows[e.RowIndex];

            idViveroSeleccionado = Convert.ToInt32(fila.Cells["colIdVivero"].Value);
            txtId.Text = idViveroSeleccionado.ToString();
            txtNombre.Text = Convert.ToString(fila.Cells["colNombreVivero"].Value) ?? "";
            txtUbicacion.Text = Convert.ToString(fila.Cells["colUbicacion"].Value) ?? "";
            cmbTipo.Text = Convert.ToString(fila.Cells["colTipoVivero"].Value) ?? "";

            object fecha = fila.Cells["colFechaInstalacion"].Value;

            if (fecha != null &&
                fecha != DBNull.Value &&
                DateTime.TryParse(fecha.ToString(), out DateTime fechaInstalacion))
            {
                dtpFechaInstalacion.Value = fechaInstalacion;
            }

            txtDescripcion.Text = Convert.ToString(fila.Cells["colDescripcion"].Value) ?? "";
        }

        private void LimpiarCampos()
        {
            idViveroSeleccionado = 0;

            txtId.Clear();
            txtNombre.Clear();
            txtUbicacion.Clear();
            cmbTipo.SelectedIndex = -1;
            cmbTipo.Text = "";
            dtpFechaInstalacion.Value = DateTime.Today;
            txtDescripcion.Clear();
            dgvViveros.ClearSelection();

            if (EsAdministrador())
            {
                txtNombre.Focus();
            }
        }

        private static void MostrarAccesoRestringido()
        {
            MessageBox.Show(
                "Solo el administrador puede realizar esta acción.",
                "Acceso restringido",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }
    }
}
