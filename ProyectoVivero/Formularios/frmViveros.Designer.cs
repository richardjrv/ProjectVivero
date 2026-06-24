using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectVivero
{
    partial class frmViveros
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
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblUbicacion = new Label();
            txtUbicacion = new TextBox();
            lblTipo = new Label();
            cmbTipo = new ComboBox();
            lblFecha = new Label();
            dtpFechaInstalacion = new DateTimePicker();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();

            pnlListado = new Panel();
            lblListado = new Label();
            lblCantidad = new Label();
            btnRecargar = new Button();
            dgvViveros = new DataGridView();

            colIdVivero = new DataGridViewTextBoxColumn();
            colNombreVivero = new DataGridViewTextBoxColumn();
            colUbicacion = new DataGridViewTextBoxColumn();
            colTipoVivero = new DataGridViewTextBoxColumn();
            colFechaInstalacion = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();

            pnlSuperior.SuspendLayout();
            pnlFormulario.SuspendLayout();
            pnlListado.SuspendLayout();
            ((ISupportInitialize)dgvViveros).BeginInit();
            SuspendLayout();

            pnlSuperior.BackColor = Color.White;
            pnlSuperior.Controls.Add(lblModo);
            pnlSuperior.Controls.Add(lblTitulo);
            pnlSuperior.Dock = DockStyle.Top;
            pnlSuperior.Location = new Point(0, 0);
            pnlSuperior.Name = "pnlSuperior";
            pnlSuperior.Size = new Size(1180, 82);
            pnlSuperior.TabIndex = 0;

            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(24, 101, 52);
            lblTitulo.Location = new Point(24, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(273, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de viveros";

            lblModo.AutoSize = true;
            lblModo.Font = new Font("Segoe UI", 9F);
            lblModo.ForeColor = Color.Gray;
            lblModo.Location = new Point(27, 54);
            lblModo.Name = "lblModo";
            lblModo.Size = new Size(91, 15);
            lblModo.TabIndex = 1;
            lblModo.Text = "Modo de acceso";

            pnlFormulario.BackColor = Color.White;
            pnlFormulario.BorderStyle = BorderStyle.FixedSingle;
            pnlFormulario.Controls.Add(btnLimpiar);
            pnlFormulario.Controls.Add(btnEliminar);
            pnlFormulario.Controls.Add(btnEditar);
            pnlFormulario.Controls.Add(btnGuardar);
            pnlFormulario.Controls.Add(txtDescripcion);
            pnlFormulario.Controls.Add(lblDescripcion);
            pnlFormulario.Controls.Add(dtpFechaInstalacion);
            pnlFormulario.Controls.Add(lblFecha);
            pnlFormulario.Controls.Add(cmbTipo);
            pnlFormulario.Controls.Add(lblTipo);
            pnlFormulario.Controls.Add(txtUbicacion);
            pnlFormulario.Controls.Add(lblUbicacion);
            pnlFormulario.Controls.Add(txtNombre);
            pnlFormulario.Controls.Add(lblNombre);
            pnlFormulario.Controls.Add(txtId);
            pnlFormulario.Controls.Add(lblId);
            pnlFormulario.Controls.Add(lblDatos);
            pnlFormulario.Dock = DockStyle.Left;
            pnlFormulario.Location = new Point(0, 82);
            pnlFormulario.Name = "pnlFormulario";
            pnlFormulario.Padding = new Padding(24);
            pnlFormulario.Size = new Size(370, 598);
            pnlFormulario.TabIndex = 1;

            lblDatos.AutoSize = true;
            lblDatos.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblDatos.ForeColor = Color.FromArgb(45, 55, 50);
            lblDatos.Location = new Point(24, 20);
            lblDatos.Name = "lblDatos";
            lblDatos.Size = new Size(157, 25);
            lblDatos.TabIndex = 0;
            lblDatos.Text = "Datos del vivero";

            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblId.ForeColor = Color.FromArgb(85, 95, 90);
            lblId.Location = new Point(25, 61);
            lblId.Name = "lblId";
            lblId.Size = new Size(19, 13);
            lblId.TabIndex = 1;
            lblId.Text = "ID";

            txtId.BackColor = Color.FromArgb(240, 242, 241);
            txtId.BorderStyle = BorderStyle.FixedSingle;
            txtId.Font = new Font("Segoe UI", 10F);
            txtId.Location = new Point(25, 79);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(315, 25);
            txtId.TabIndex = 0;

            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(85, 95, 90);
            lblNombre.Location = new Point(25, 119);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(118, 13);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "NOMBRE DEL VIVERO";

            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 10F);
            txtNombre.Location = new Point(25, 137);
            txtNombre.MaxLength = 100;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(315, 25);
            txtNombre.TabIndex = 1;

            lblUbicacion.AutoSize = true;
            lblUbicacion.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblUbicacion.ForeColor = Color.FromArgb(85, 95, 90);
            lblUbicacion.Location = new Point(25, 177);
            lblUbicacion.Name = "lblUbicacion";
            lblUbicacion.Size = new Size(66, 13);
            lblUbicacion.TabIndex = 5;
            lblUbicacion.Text = "UBICACIÓN";

            txtUbicacion.BorderStyle = BorderStyle.FixedSingle;
            txtUbicacion.Font = new Font("Segoe UI", 10F);
            txtUbicacion.Location = new Point(25, 195);
            txtUbicacion.MaxLength = 120;
            txtUbicacion.Name = "txtUbicacion";
            txtUbicacion.Size = new Size(315, 25);
            txtUbicacion.TabIndex = 2;

            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblTipo.ForeColor = Color.FromArgb(85, 95, 90);
            lblTipo.Location = new Point(25, 235);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(91, 13);
            lblTipo.TabIndex = 7;
            lblTipo.Text = "TIPO DE VIVERO";

            cmbTipo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbTipo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbTipo.Font = new Font("Segoe UI", 10F);
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[]
            {
                "Invernadero",
                "Malla sombra",
                "Agrícola",
                "Hidropónico",
                "Otro"
            });
            cmbTipo.Location = new Point(25, 253);
            cmbTipo.MaxLength = 50;
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(315, 25);
            cmbTipo.TabIndex = 3;

            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblFecha.ForeColor = Color.FromArgb(85, 95, 90);
            lblFecha.Location = new Point(25, 293);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(137, 13);
            lblFecha.TabIndex = 9;
            lblFecha.Text = "FECHA DE INSTALACIÓN";

            dtpFechaInstalacion.Font = new Font("Segoe UI", 10F);
            dtpFechaInstalacion.Format = DateTimePickerFormat.Short;
            dtpFechaInstalacion.Location = new Point(25, 311);
            dtpFechaInstalacion.Name = "dtpFechaInstalacion";
            dtpFechaInstalacion.Size = new Size(315, 25);
            dtpFechaInstalacion.TabIndex = 4;

            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblDescripcion.ForeColor = Color.FromArgb(85, 95, 90);
            lblDescripcion.Location = new Point(25, 351);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(76, 13);
            lblDescripcion.TabIndex = 11;
            lblDescripcion.Text = "DESCRIPCIÓN";

            txtDescripcion.BorderStyle = BorderStyle.FixedSingle;
            txtDescripcion.Font = new Font("Segoe UI", 10F);
            txtDescripcion.Location = new Point(25, 369);
            txtDescripcion.MaxLength = 255;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(315, 80);
            txtDescripcion.TabIndex = 5;

            btnGuardar.BackColor = Color.FromArgb(34, 139, 60);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(25, 475);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(98, 38);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            btnEditar.BackColor = Color.FromArgb(45, 116, 181);
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(132, 475);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(98, 38);
            btnEditar.TabIndex = 7;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;

            btnEliminar.BackColor = Color.FromArgb(207, 48, 68);
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(239, 475);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(101, 38);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;

            btnLimpiar.BackColor = Color.FromArgb(125, 136, 147);
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(25, 525);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(315, 38);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "Limpiar campos";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;

            pnlListado.BackColor = Color.FromArgb(242, 245, 243);
            pnlListado.Controls.Add(dgvViveros);
            pnlListado.Controls.Add(btnRecargar);
            pnlListado.Controls.Add(lblCantidad);
            pnlListado.Controls.Add(lblListado);
            pnlListado.Dock = DockStyle.Fill;
            pnlListado.Location = new Point(370, 82);
            pnlListado.Name = "pnlListado";
            pnlListado.Padding = new Padding(22);
            pnlListado.Size = new Size(810, 598);
            pnlListado.TabIndex = 2;

            lblListado.AutoSize = true;
            lblListado.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblListado.ForeColor = Color.FromArgb(45, 55, 50);
            lblListado.Location = new Point(22, 20);
            lblListado.Name = "lblListado";
            lblListado.Size = new Size(190, 25);
            lblListado.TabIndex = 0;
            lblListado.Text = "Viveros registrados";

            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 9F);
            lblCantidad.ForeColor = Color.Gray;
            lblCantidad.Location = new Point(24, 51);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(123, 15);
            lblCantidad.TabIndex = 1;
            lblCantidad.Text = "Viveros registrados: 0";

            btnRecargar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRecargar.BackColor = Color.FromArgb(34, 139, 60);
            btnRecargar.Cursor = Cursors.Hand;
            btnRecargar.FlatAppearance.BorderSize = 0;
            btnRecargar.FlatStyle = FlatStyle.Flat;
            btnRecargar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRecargar.ForeColor = Color.White;
            btnRecargar.Location = new Point(673, 25);
            btnRecargar.Name = "btnRecargar";
            btnRecargar.Size = new Size(112, 36);
            btnRecargar.TabIndex = 0;
            btnRecargar.Text = "Recargar";
            btnRecargar.UseVisualStyleBackColor = false;
            btnRecargar.Click += btnRecargar_Click;

            dgvViveros.AllowUserToAddRows = false;
            dgvViveros.AllowUserToDeleteRows = false;
            dgvViveros.AllowUserToResizeRows = false;
            dgvViveros.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvViveros.AutoGenerateColumns = false;
            dgvViveros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvViveros.BackgroundColor = Color.White;
            dgvViveros.BorderStyle = BorderStyle.None;
            dgvViveros.ColumnHeadersHeight = 38;
            dgvViveros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvViveros.Columns.AddRange(new DataGridViewColumn[]
            {
                colIdVivero,
                colNombreVivero,
                colUbicacion,
                colTipoVivero,
                colFechaInstalacion,
                colDescripcion
            });
            dgvViveros.Location = new Point(22, 82);
            dgvViveros.MultiSelect = false;
            dgvViveros.Name = "dgvViveros";
            dgvViveros.ReadOnly = true;
            dgvViveros.RowHeadersVisible = false;
            dgvViveros.RowTemplate.Height = 30;
            dgvViveros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvViveros.Size = new Size(763, 490);
            dgvViveros.TabIndex = 1;
            dgvViveros.CellClick += dgvViveros_CellClick;

            colIdVivero.DataPropertyName = "IdVivero";
            colIdVivero.FillWeight = 35F;
            colIdVivero.HeaderText = "ID";
            colIdVivero.Name = "colIdVivero";
            colIdVivero.ReadOnly = true;

            colNombreVivero.DataPropertyName = "NombreVivero";
            colNombreVivero.FillWeight = 105F;
            colNombreVivero.HeaderText = "Nombre del vivero";
            colNombreVivero.Name = "colNombreVivero";
            colNombreVivero.ReadOnly = true;

            colUbicacion.DataPropertyName = "Ubicacion";
            colUbicacion.FillWeight = 100F;
            colUbicacion.HeaderText = "Ubicación";
            colUbicacion.Name = "colUbicacion";
            colUbicacion.ReadOnly = true;

            colTipoVivero.DataPropertyName = "TipoVivero";
            colTipoVivero.FillWeight = 70F;
            colTipoVivero.HeaderText = "Tipo";
            colTipoVivero.Name = "colTipoVivero";
            colTipoVivero.ReadOnly = true;

            colFechaInstalacion.DataPropertyName = "FechaInstalacion";
            colFechaInstalacion.DefaultCellStyle.Format = "dd/MM/yyyy";
            colFechaInstalacion.FillWeight = 75F;
            colFechaInstalacion.HeaderText = "Fecha instalación";
            colFechaInstalacion.Name = "colFechaInstalacion";
            colFechaInstalacion.ReadOnly = true;

            colDescripcion.DataPropertyName = "Descripcion";
            colDescripcion.FillWeight = 120F;
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1180, 680);
            Controls.Add(pnlListado);
            Controls.Add(pnlFormulario);
            Controls.Add(pnlSuperior);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(0,0);
            Name = "frmViveros";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de viveros";
            Load += frmViveros_Load;

            pnlFormulario.AutoScroll = true;
            pnlSuperior.ResumeLayout(false);
            pnlSuperior.PerformLayout();
            pnlFormulario.ResumeLayout(false);
            pnlFormulario.PerformLayout();
            pnlListado.ResumeLayout(false);
            pnlListado.PerformLayout();
            ((ISupportInitialize)dgvViveros).EndInit();
            ResumeLayout(false);
        }

        private Panel pnlSuperior;
        private Label lblTitulo;
        private Label lblModo;

        private Panel pnlFormulario;
        private Label lblDatos;
        private Label lblId;
        private TextBox txtId;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblUbicacion;
        private TextBox txtUbicacion;
        private Label lblTipo;
        private ComboBox cmbTipo;
        private Label lblFecha;
        private DateTimePicker dtpFechaInstalacion;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnLimpiar;

        private Panel pnlListado;
        private Label lblListado;
        private Label lblCantidad;
        private Button btnRecargar;
        private DataGridView dgvViveros;

        private DataGridViewTextBoxColumn colIdVivero;
        private DataGridViewTextBoxColumn colNombreVivero;
        private DataGridViewTextBoxColumn colUbicacion;
        private DataGridViewTextBoxColumn colTipoVivero;
        private DataGridViewTextBoxColumn colFechaInstalacion;
        private DataGridViewTextBoxColumn colDescripcion;
    }
}
