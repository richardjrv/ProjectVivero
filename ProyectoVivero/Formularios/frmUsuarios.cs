using BusinessLogic;
using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectVivero
{
    public partial class frmUsuarios : Form
    {
        private int idUsuarioSeleccionado = 0;

        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(
            object sender,
            EventArgs e)
        {
            if (!EsAdministrador())
            {
                MessageBox.Show(
                    "El módulo Usuarios está disponible únicamente para administradores.",
                    "Acceso restringido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                Close();
                return;
            }

            CargarUsuarios();
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

        private void CargarUsuarios()
        {
            try
            {
                List<Usuario> usuarios =
                    UsuarioAdminLogic.Listar();

                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = usuarios;

                lblCantidad.Text =
                    $"Usuarios registrados: {usuarios.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los usuarios.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private Usuario ObtenerDatosFormulario()
        {
            return new Usuario
            {
                IdUsuario = idUsuarioSeleccionado,
                NombreCompleto =
                    txtNombreCompleto.Text.Trim(),
                Correo =
                    txtCorreo.Text.Trim(),
                Username =
                    txtUsername.Text.Trim(),
                Password =
                    txtPassword.Text,
                NombreRol =
                    cmbRol.Text.Trim(),
                Estado =
                    cmbEstado.Text.Trim()
            };
        }

        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                Usuario usuario =
                    ObtenerDatosFormulario();

                bool guardado =
                    UsuarioAdminLogic.Insertar(usuario);

                if (!guardado)
                {
                    MessageBox.Show(
                        "No se pudo registrar el usuario. Verifique que el rol exista.",
                        "Registro no realizado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                MessageBox.Show(
                    "Usuario registrado correctamente.",
                    "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarUsuarios();
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
            if (idUsuarioSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Seleccione un usuario de la tabla.",
                    "Usuario no seleccionado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            Usuario usuario =
                ObtenerDatosFormulario();

            if (idUsuarioSeleccionado ==
                LoginSistema.IdUsuario)
            {
                if (!string.Equals(
                        usuario.NombreRol,
                        "Administrador",
                        StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "No puede quitarse su propio rol de administrador.",
                        "Operación no permitida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                if (!string.Equals(
                        usuario.Estado,
                        "Activo",
                        StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "No puede desactivar su propia cuenta mientras está en sesión.",
                        "Operación no permitida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }
            }

            try
            {
                bool actualizado =
                    UsuarioAdminLogic.Actualizar(usuario);

                if (!actualizado)
                {
                    MessageBox.Show(
                        "No se pudo actualizar el usuario. Verifique que el rol exista.",
                        "Actualización no realizada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                MessageBox.Show(
                    "Usuario actualizado correctamente.",
                    "Actualización exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarUsuarios();
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
            if (idUsuarioSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Seleccione un usuario de la tabla.",
                    "Usuario no seleccionado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (idUsuarioSeleccionado ==
                LoginSistema.IdUsuario)
            {
                MessageBox.Show(
                    "No puede eliminar la cuenta con la que inició sesión.",
                    "Operación no permitida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult respuesta =
                MessageBox.Show(
                    $"¿Desea eliminar al usuario \"{txtNombreCompleto.Text.Trim()}\"?\n\n" +
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
                    UsuarioAdminLogic.Eliminar(
                        idUsuarioSeleccionado
                    );

                if (!eliminado)
                {
                    MessageBox.Show(
                        "No se pudo eliminar el usuario.",
                        "Eliminación no realizada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                MessageBox.Show(
                    "Usuario eliminado correctamente.",
                    "Eliminación exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarUsuarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo eliminar el usuario.\n\n" +
                    "Puede tener registros relacionados. En ese caso, cambie su estado a Inactivo.\n\n" +
                    ex.Message,
                    "Error al eliminar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
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
            CargarUsuarios();
            LimpiarCampos();
        }

        private void dgvUsuarios_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow fila =
                dgvUsuarios.Rows[e.RowIndex];

            idUsuarioSeleccionado =
                Convert.ToInt32(
                    fila.Cells["colIdUsuario"].Value
                );

            txtId.Text =
                idUsuarioSeleccionado.ToString();

            txtNombreCompleto.Text =
                Convert.ToString(
                    fila.Cells[
                        "colNombreCompleto"
                    ].Value
                ) ?? "";

            txtCorreo.Text =
                Convert.ToString(
                    fila.Cells["colCorreo"].Value
                ) ?? "";

            txtUsername.Text =
                Convert.ToString(
                    fila.Cells["colUsername"].Value
                ) ?? "";

            cmbRol.Text =
                Convert.ToString(
                    fila.Cells["colNombreRol"].Value
                ) ?? "";

            cmbEstado.Text =
                Convert.ToString(
                    fila.Cells["colEstado"].Value
                ) ?? "";

            txtPassword.Clear();

            lblPasswordAyuda.Text =
                "Déjela vacía para conservar la contraseña actual.";
        }

        private void chkMostrarPassword_CheckedChanged(
            object sender,
            EventArgs e)
        {
            txtPassword.UseSystemPasswordChar =
                !chkMostrarPassword.Checked;
        }

        private void LimpiarCampos()
        {
            idUsuarioSeleccionado = 0;

            txtId.Clear();
            txtNombreCompleto.Clear();
            txtCorreo.Clear();
            txtUsername.Clear();
            txtPassword.Clear();

            cmbRol.SelectedItem = "Usuario";
            cmbEstado.SelectedItem = "Activo";

            chkMostrarPassword.Checked = false;
            txtPassword.UseSystemPasswordChar = true;

            lblPasswordAyuda.Text =
                "Obligatoria al registrar. Al editar puede dejarla vacía.";

            dgvUsuarios.ClearSelection();
            txtNombreCompleto.Focus();
        }
    }
}
