using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectVivero
{
    partial class frmUsuarios
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlSuperior = new Panel();
            lblTitulo = new Label();
            lblModo = new Label();

            pnlFormulario = new Panel();
            lblDatos = new Label();
            lblId = new Label();
            txtId = new TextBox();
            lblNombreCompleto = new Label();
            txtNombreCompleto = new TextBox();
            lblCorreo = new Label();
            txtCorreo = new TextBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            chkMostrarPassword = new CheckBox();
            lblPasswordAyuda = new Label();
            lblRol = new Label();
            cmbRol = new ComboBox();
            lblEstado = new Label();
            cmbEstado = new ComboBox();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();

            pnlListado = new Panel();
            lblListado = new Label();
            lblCantidad = new Label();
            btnRecargar = new Button();
            dgvUsuarios = new DataGridView();

            colIdUsuario = new DataGridViewTextBoxColumn();
            colNombreCompleto = new DataGridViewTextBoxColumn();
            colCorreo = new DataGridViewTextBoxColumn();
            colUsername = new DataGridViewTextBoxColumn();
            colNombreRol = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();

            pnlSuperior.SuspendLayout();
            pnlFormulario.SuspendLayout();
            pnlListado.SuspendLayout();
            ((ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();

            // =====================================================
            // PANEL SUPERIOR
            // =====================================================
            pnlSuperior.BackColor = Color.White;
            pnlSuperior.Controls.Add(lblModo);
            pnlSuperior.Controls.Add(lblTitulo);
            pnlSuperior.Dock = DockStyle.Top;
            pnlSuperior.Height = 82;

            lblTitulo.AutoSize = true;
            lblTitulo.Font =
                new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor =
                Color.FromArgb(24, 101, 52);
            lblTitulo.Location = new Point(24, 14);
            lblTitulo.Text = "Administración de usuarios";

            lblModo.AutoSize = true;
            lblModo.Font = new Font("Segoe UI", 9F);
            lblModo.ForeColor =
                Color.FromArgb(28, 120, 58);
            lblModo.Location = new Point(27, 54);
            lblModo.Text =
                "Modo administrador: puede registrar, editar y eliminar usuarios.";

            // =====================================================
            // PANEL FORMULARIO
            // =====================================================
            pnlFormulario.AutoScroll = true;
            pnlFormulario.BackColor = Color.White;
            pnlFormulario.BorderStyle =
                BorderStyle.FixedSingle;

            pnlFormulario.Controls.Add(btnLimpiar);
            pnlFormulario.Controls.Add(btnEliminar);
            pnlFormulario.Controls.Add(btnEditar);
            pnlFormulario.Controls.Add(btnGuardar);
            pnlFormulario.Controls.Add(cmbEstado);
            pnlFormulario.Controls.Add(lblEstado);
            pnlFormulario.Controls.Add(cmbRol);
            pnlFormulario.Controls.Add(lblRol);
            pnlFormulario.Controls.Add(lblPasswordAyuda);
            pnlFormulario.Controls.Add(chkMostrarPassword);
            pnlFormulario.Controls.Add(txtPassword);
            pnlFormulario.Controls.Add(lblPassword);
            pnlFormulario.Controls.Add(txtUsername);
            pnlFormulario.Controls.Add(lblUsername);
            pnlFormulario.Controls.Add(txtCorreo);
            pnlFormulario.Controls.Add(lblCorreo);
            pnlFormulario.Controls.Add(txtNombreCompleto);
            pnlFormulario.Controls.Add(lblNombreCompleto);
            pnlFormulario.Controls.Add(txtId);
            pnlFormulario.Controls.Add(lblId);
            pnlFormulario.Controls.Add(lblDatos);

            pnlFormulario.Dock = DockStyle.Left;
            pnlFormulario.Width = 405;

            lblDatos.AutoSize = true;
            lblDatos.Font =
                new Font("Segoe UI", 13F, FontStyle.Bold);
            lblDatos.ForeColor =
                Color.FromArgb(45, 55, 50);
            lblDatos.Location = new Point(24, 18);
            lblDatos.Text = "Datos del usuario";

            lblId.AutoSize = true;
            lblId.Font =
                new Font("Segoe UI", 8F, FontStyle.Bold);
            lblId.ForeColor =
                Color.FromArgb(85, 95, 90);
            lblId.Location = new Point(25, 57);
            lblId.Text = "ID";

            txtId.BackColor =
                Color.FromArgb(240, 242, 241);
            txtId.BorderStyle =
                BorderStyle.FixedSingle;
            txtId.Font = new Font("Segoe UI", 10F);
            txtId.Location = new Point(25, 75);
            txtId.ReadOnly = true;
            txtId.Size = new Size(340, 25);

            lblNombreCompleto.AutoSize = true;
            lblNombreCompleto.Font =
                new Font("Segoe UI", 8F, FontStyle.Bold);
            lblNombreCompleto.ForeColor =
                Color.FromArgb(85, 95, 90);
            lblNombreCompleto.Location =
                new Point(25, 111);
            lblNombreCompleto.Text =
                "NOMBRE COMPLETO";

            txtNombreCompleto.BorderStyle =
                BorderStyle.FixedSingle;
            txtNombreCompleto.Font =
                new Font("Segoe UI", 10F);
            txtNombreCompleto.Location =
                new Point(25, 129);
            txtNombreCompleto.MaxLength = 100;
            txtNombreCompleto.Size =
                new Size(340, 25);

            lblCorreo.AutoSize = true;
            lblCorreo.Font =
                new Font("Segoe UI", 8F, FontStyle.Bold);
            lblCorreo.ForeColor =
                Color.FromArgb(85, 95, 90);
            lblCorreo.Location =
                new Point(25, 165);
            lblCorreo.Text = "CORREO";

            txtCorreo.BorderStyle =
                BorderStyle.FixedSingle;
            txtCorreo.Font =
                new Font("Segoe UI", 10F);
            txtCorreo.Location =
                new Point(25, 183);
            txtCorreo.MaxLength = 150;
            txtCorreo.Size =
                new Size(340, 25);

            lblUsername.AutoSize = true;
            lblUsername.Font =
                new Font("Segoe UI", 8F, FontStyle.Bold);
            lblUsername.ForeColor =
                Color.FromArgb(85, 95, 90);
            lblUsername.Location =
                new Point(25, 219);
            lblUsername.Text =
                "NOMBRE DE USUARIO";

            txtUsername.BorderStyle =
                BorderStyle.FixedSingle;
            txtUsername.Font =
                new Font("Segoe UI", 10F);
            txtUsername.Location =
                new Point(25, 237);
            txtUsername.MaxLength = 50;
            txtUsername.Size =
                new Size(340, 25);

            lblPassword.AutoSize = true;
            lblPassword.Font =
                new Font("Segoe UI", 8F, FontStyle.Bold);
            lblPassword.ForeColor =
                Color.FromArgb(85, 95, 90);
            lblPassword.Location =
                new Point(25, 273);
            lblPassword.Text =
                "CONTRASEÑA / NUEVA CONTRASEÑA";

            txtPassword.BorderStyle =
                BorderStyle.FixedSingle;
            txtPassword.Font =
                new Font("Segoe UI", 10F);
            txtPassword.Location =
                new Point(25, 291);
            txtPassword.MaxLength = 255;
            txtPassword.Size =
                new Size(340, 25);
            txtPassword.UseSystemPasswordChar = true;

            chkMostrarPassword.AutoSize = true;
            chkMostrarPassword.Font =
                new Font("Segoe UI", 8.5F);
            chkMostrarPassword.Location =
                new Point(25, 324);
            chkMostrarPassword.Text =
                "Mostrar contraseña";
            chkMostrarPassword.CheckedChanged +=
                chkMostrarPassword_CheckedChanged;

            lblPasswordAyuda.Font =
                new Font("Segoe UI", 8F);
            lblPasswordAyuda.ForeColor = Color.Gray;
            lblPasswordAyuda.Location =
                new Point(25, 348);
            lblPasswordAyuda.Size =
                new Size(340, 34);
            lblPasswordAyuda.Text =
                "Obligatoria al registrar. Al editar puede dejarla vacía.";

            lblRol.AutoSize = true;
            lblRol.Font =
                new Font("Segoe UI", 8F, FontStyle.Bold);
            lblRol.ForeColor =
                Color.FromArgb(85, 95, 90);
            lblRol.Location =
                new Point(25, 390);
            lblRol.Text = "ROL";

            cmbRol.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cmbRol.Font =
                new Font("Segoe UI", 10F);
            cmbRol.Items.AddRange(
                new object[]
                {
                    "Administrador",
                    "Usuario"
                }
            );
            cmbRol.Location =
                new Point(25, 408);
            cmbRol.Size =
                new Size(340, 25);

            lblEstado.AutoSize = true;
            lblEstado.Font =
                new Font("Segoe UI", 8F, FontStyle.Bold);
            lblEstado.ForeColor =
                Color.FromArgb(85, 95, 90);
            lblEstado.Location =
                new Point(25, 444);
            lblEstado.Text = "ESTADO";

            cmbEstado.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cmbEstado.Font =
                new Font("Segoe UI", 10F);
            cmbEstado.Items.AddRange(
                new object[]
                {
                    "Activo",
                    "Inactivo"
                }
            );
            cmbEstado.Location =
                new Point(25, 462);
            cmbEstado.Size =
                new Size(340, 25);

            btnGuardar.BackColor =
                Color.FromArgb(34, 139, 60);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location =
                new Point(25, 515);
            btnGuardar.Size =
                new Size(105, 38);
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;

            btnEditar.BackColor =
                Color.FromArgb(45, 116, 181);
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location =
                new Point(142, 515);
            btnEditar.Size =
                new Size(105, 38);
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;

            btnEliminar.BackColor =
                Color.FromArgb(207, 48, 68);
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location =
                new Point(260, 515);
            btnEliminar.Size =
                new Size(105, 38);
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;

            btnLimpiar.BackColor =
                Color.FromArgb(125, 136, 147);
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location =
                new Point(25, 565);
            btnLimpiar.Size =
                new Size(340, 38);
            btnLimpiar.Text = "Limpiar campos";
            btnLimpiar.Click += btnLimpiar_Click;

            // =====================================================
            // LISTADO
            // =====================================================
            pnlListado.BackColor =
                Color.FromArgb(242, 245, 243);
            pnlListado.Controls.Add(dgvUsuarios);
            pnlListado.Controls.Add(btnRecargar);
            pnlListado.Controls.Add(lblCantidad);
            pnlListado.Controls.Add(lblListado);
            pnlListado.Dock = DockStyle.Fill;
            pnlListado.Padding =
                new Padding(22);

            lblListado.AutoSize = true;
            lblListado.Font =
                new Font("Segoe UI", 14F, FontStyle.Bold);
            lblListado.ForeColor =
                Color.FromArgb(45, 55, 50);
            lblListado.Location =
                new Point(22, 20);
            lblListado.Text =
                "Usuarios registrados";

            lblCantidad.AutoSize = true;
            lblCantidad.Font =
                new Font("Segoe UI", 9F);
            lblCantidad.ForeColor =
                Color.Gray;
            lblCantidad.Location =
                new Point(24, 51);
            lblCantidad.Text =
                "Usuarios registrados: 0";

            btnRecargar.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;
            btnRecargar.BackColor =
                Color.FromArgb(34, 139, 60);
            btnRecargar.FlatAppearance.BorderSize = 0;
            btnRecargar.FlatStyle =
                FlatStyle.Flat;
            btnRecargar.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRecargar.ForeColor =
                Color.White;
            btnRecargar.Location =
                new Point(638, 25);
            btnRecargar.Size =
                new Size(112, 36);
            btnRecargar.Text =
                "Recargar";
            btnRecargar.Click +=
                btnRecargar_Click;

            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AllowUserToResizeRows = false;
            dgvUsuarios.AllowUserToResizeColumns = true;
            dgvUsuarios.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;
            dgvUsuarios.AutoGenerateColumns = false;

            // IMPORTANTE:
            // None conserva el ancho individual de cada columna.
            // Como el ancho total supera el espacio disponible,
            // aparece la barra de desplazamiento horizontal.
            dgvUsuarios.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.None;

            dgvUsuarios.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;

            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.ColumnHeadersHeight = 40;
            dgvUsuarios.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvUsuarios.Columns.AddRange(
                new DataGridViewColumn[]
                {
                    colIdUsuario,
                    colNombreCompleto,
                    colCorreo,
                    colUsername,
                    colNombreRol,
                    colEstado
                }
            );
            dgvUsuarios.Location =
                new Point(22, 82);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.RowTemplate.Height = 30;

            // Activa desplazamiento horizontal y vertical.
            dgvUsuarios.ScrollBars = ScrollBars.Both;

            dgvUsuarios.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size =
                new Size(728, 490);
            dgvUsuarios.TabIndex = 1;
            dgvUsuarios.CellClick +=
                dgvUsuarios_CellClick;

            // =====================================================
            // COLUMNAS
            // =====================================================
            colIdUsuario.DataPropertyName =
                "IdUsuario";
            colIdUsuario.HeaderText = "ID";
            colIdUsuario.Name = "colIdUsuario";
            colIdUsuario.ReadOnly = true;
            colIdUsuario.Width = 65;
            colIdUsuario.Frozen = true;

            colNombreCompleto.DataPropertyName =
                "NombreCompleto";
            colNombreCompleto.HeaderText =
                "Nombre completo";
            colNombreCompleto.Name =
                "colNombreCompleto";
            colNombreCompleto.ReadOnly = true;
            colNombreCompleto.Width = 220;

            colCorreo.DataPropertyName =
                "Correo";
            colCorreo.HeaderText =
                "Correo electrónico";
            colCorreo.Name =
                "colCorreo";
            colCorreo.ReadOnly = true;
            colCorreo.Width = 260;

            colUsername.DataPropertyName =
                "Username";
            colUsername.HeaderText =
                "Nombre de usuario";
            colUsername.Name =
                "colUsername";
            colUsername.ReadOnly = true;
            colUsername.Width = 160;

            colNombreRol.DataPropertyName =
                "NombreRol";
            colNombreRol.HeaderText =
                "Rol";
            colNombreRol.Name =
                "colNombreRol";
            colNombreRol.ReadOnly = true;
            colNombreRol.Width = 140;

            colEstado.DataPropertyName =
                "Estado";
            colEstado.HeaderText =
                "Estado";
            colEstado.Name =
                "colEstado";
            colEstado.ReadOnly = true;
            colEstado.Width = 110;

            // =====================================================
            // FORMULARIO
            // =====================================================
            AutoScaleDimensions =
                new SizeF(7F, 15F);
            AutoScaleMode =
                AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize =
                new Size(1180, 680);
            Controls.Add(pnlListado);
            Controls.Add(pnlFormulario);
            Controls.Add(pnlSuperior);
            Font =
                new Font("Segoe UI", 9F);
            MinimumSize =
                new Size(0, 0);
            Name = "frmUsuarios";
            Text =
                "Administración de usuarios";
            Load += frmUsuarios_Load;

            pnlSuperior.ResumeLayout(false);
            pnlSuperior.PerformLayout();
            pnlFormulario.ResumeLayout(false);
            pnlFormulario.PerformLayout();
            pnlListado.ResumeLayout(false);
            pnlListado.PerformLayout();
            ((ISupportInitialize)dgvUsuarios)
                .EndInit();
            ResumeLayout(false);
        }

        private Panel pnlSuperior;
        private Label lblTitulo;
        private Label lblModo;

        private Panel pnlFormulario;
        private Label lblDatos;
        private Label lblId;
        private TextBox txtId;
        private Label lblNombreCompleto;
        private TextBox txtNombreCompleto;
        private Label lblCorreo;
        private TextBox txtCorreo;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private CheckBox chkMostrarPassword;
        private Label lblPasswordAyuda;
        private Label lblRol;
        private ComboBox cmbRol;
        private Label lblEstado;
        private ComboBox cmbEstado;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnLimpiar;

        private Panel pnlListado;
        private Label lblListado;
        private Label lblCantidad;
        private Button btnRecargar;
        private DataGridView dgvUsuarios;

        private DataGridViewTextBoxColumn colIdUsuario;
        private DataGridViewTextBoxColumn colNombreCompleto;
        private DataGridViewTextBoxColumn colCorreo;
        private DataGridViewTextBoxColumn colUsername;
        private DataGridViewTextBoxColumn colNombreRol;
        private DataGridViewTextBoxColumn colEstado;
    }
}
