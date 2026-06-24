using BusinessLogic;
using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectVivero
{
    public partial class frmCultivos : Form
    {
        private int idCultivoSeleccionado = 0;

        public frmCultivos()
        {
            InitializeComponent();
        }

        private void frmCultivos_Load(object sender, EventArgs e)
        {
            AplicarPermisos();
            CargarViveros();
            CargarCultivos();
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
            bool esAdministrador = EsAdministrador();

            if (esAdministrador)
            {
                pnlFormulario.Visible = true;
                pnlFormulario.Dock = DockStyle.Left;
                pnlListado.Dock = DockStyle.Fill;

                btnGuardar.Visible = true;
                btnEditar.Visible = true;
                btnEliminar.Visible = true;
                btnLimpiar.Visible = true;

                cmbVivero.Enabled = true;
                txtNombreCultivo.ReadOnly = false;
                txtVariedad.ReadOnly = false;
                dtpFechaSiembra.Enabled = true;
                dtpFechaEstimadaCosecha.Enabled = true;
                dtpFechaCosecha.Enabled = true;
                cmbEtapa.Enabled = true;
                cmbEstado.Enabled = true;
                txtDescripcion.ReadOnly = false;

                lblModo.Text =
                    "Modo administrador: puede registrar, editar y eliminar cultivos.";

                lblModo.ForeColor =
                    Color.FromArgb(28, 120, 58);

                lblListado.Text = "Cultivos registrados";
            }
            else
            {
                pnlFormulario.Visible = false;
                pnlListado.Dock = DockStyle.Fill;

                btnGuardar.Visible = false;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                btnLimpiar.Visible = false;

                dgvCultivos.ReadOnly = true;
                dgvCultivos.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                lblModo.Text =
                    "Modo consulta: puede visualizar los cultivos registrados.";

                lblModo.ForeColor =
                    Color.FromArgb(90, 90, 90);

                lblListado.Text = "Cultivos disponibles";
            }
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

        private void CargarCultivos()
        {
            try
            {
                List<Cultivo> cultivos = CultivoLogic.Listar();

                dgvCultivos.DataSource = null;
                dgvCultivos.DataSource = cultivos;

                lblCantidad.Text =
                    $"Cultivos registrados: {cultivos.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los cultivos.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private Cultivo ObtenerDatosFormulario()
        {
            int idVivero = 0;

            if (cmbVivero.SelectedValue != null)
            {
                int.TryParse(
                    cmbVivero.SelectedValue.ToString(),
                    out idVivero
                );
            }

            return new Cultivo
            {
                IdCultivo = idCultivoSeleccionado,
                IdVivero = idVivero,
                NombreCultivo = txtNombreCultivo.Text.Trim(),
                Variedad = txtVariedad.Text.Trim(),
                FechaSiembra = dtpFechaSiembra.Value,
                FechaEstimadaCosecha =
                    dtpFechaEstimadaCosecha.Checked
                        ? dtpFechaEstimadaCosecha.Value.Date
                        : null,
                FechaCosecha =
                    dtpFechaCosecha.Checked
                        ? dtpFechaCosecha.Value.Date
                        : null,
                Etapa = cmbEtapa.Text.Trim(),
                Estado = cmbEstado.Text.Trim(),
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
                bool guardado =
                    CultivoLogic.Insertar(ObtenerDatosFormulario());

                if (!guardado)
                {
                    MessageBox.Show(
                        "No se pudo registrar el cultivo.",
                        "Registro no realizado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                MessageBox.Show(
                    "Cultivo registrado correctamente.",
                    "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarCultivos();
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
            if (!EsAdministrador())
            {
                MostrarAccesoRestringido();
                return;
            }

            if (idCultivoSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Seleccione un cultivo de la tabla.",
                    "Cultivo no seleccionado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                bool actualizado =
                    CultivoLogic.Actualizar(ObtenerDatosFormulario());

                if (!actualizado)
                {
                    MessageBox.Show(
                        "No se pudo actualizar el cultivo.",
                        "Actualización no realizada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                MessageBox.Show(
                    "Cultivo actualizado correctamente.",
                    "Actualización exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarCultivos();
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
            if (!EsAdministrador())
            {
                MostrarAccesoRestringido();
                return;
            }

            if (idCultivoSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Seleccione un cultivo de la tabla.",
                    "Cultivo no seleccionado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                $"¿Desea eliminar el cultivo \"{txtNombreCultivo.Text.Trim()}\"?\n\n" +
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
                    CultivoLogic.Eliminar(idCultivoSeleccionado);

                if (!eliminado)
                {
                    MessageBox.Show(
                        "No se pudo eliminar el cultivo.",
                        "Eliminación no realizada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                MessageBox.Show(
                    "Cultivo eliminado correctamente.",
                    "Eliminación exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarCultivos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo eliminar el cultivo.\n\n" +
                    "Es posible que tenga sensores o mediciones relacionados.\n\n" +
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
            CargarCultivos();
            LimpiarCampos();
        }

        private void dgvCultivos_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow fila =
                dgvCultivos.Rows[e.RowIndex];

            idCultivoSeleccionado = Convert.ToInt32(
                fila.Cells["colIdCultivo"].Value
            );

            txtId.Text = idCultivoSeleccionado.ToString();

            cmbVivero.SelectedValue = Convert.ToInt32(
                fila.Cells["colIdVivero"].Value
            );

            txtNombreCultivo.Text = Convert.ToString(
                fila.Cells["colNombreCultivo"].Value
            ) ?? "";

            txtVariedad.Text = Convert.ToString(
                fila.Cells["colVariedad"].Value
            ) ?? "";

            AsignarFecha(
                dtpFechaSiembra,
                fila.Cells["colFechaSiembra"].Value,
                true
            );

            AsignarFecha(
                dtpFechaEstimadaCosecha,
                fila.Cells["colFechaEstimadaCosecha"].Value,
                false
            );

            AsignarFecha(
                dtpFechaCosecha,
                fila.Cells["colFechaCosecha"].Value,
                false
            );

            cmbEtapa.Text = Convert.ToString(
                fila.Cells["colEtapa"].Value
            ) ?? "";

            cmbEstado.Text = Convert.ToString(
                fila.Cells["colEstado"].Value
            ) ?? "";

            txtDescripcion.Text = Convert.ToString(
                fila.Cells["colDescripcion"].Value
            ) ?? "";
        }

        private static void AsignarFecha(
            DateTimePicker control,
            object valor,
            bool obligatoria)
        {
            if (valor != null &&
                valor != DBNull.Value &&
                DateTime.TryParse(valor.ToString(), out DateTime fecha))
            {
                control.Value = fecha;
                control.Checked = true;
            }
            else
            {
                control.Value = DateTime.Today;
                control.Checked = obligatoria;
            }
        }

        private void LimpiarCampos()
        {
            idCultivoSeleccionado = 0;
            txtId.Clear();

            cmbVivero.SelectedIndex =
                cmbVivero.Items.Count > 0 ? 0 : -1;

            txtNombreCultivo.Clear();
            txtVariedad.Clear();

            dtpFechaSiembra.Value = DateTime.Today;
            dtpFechaSiembra.Checked = true;

            dtpFechaEstimadaCosecha.Value =
                DateTime.Today.AddDays(30);
            dtpFechaEstimadaCosecha.Checked = true;

            dtpFechaCosecha.Value = DateTime.Today;
            dtpFechaCosecha.Checked = false;

            cmbEtapa.SelectedItem = "Siembra";
            cmbEstado.SelectedItem = "Activo";

            txtDescripcion.Clear();
            dgvCultivos.ClearSelection();

            if (EsAdministrador())
            {
                txtNombreCultivo.Focus();
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
