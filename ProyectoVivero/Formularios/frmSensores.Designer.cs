using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectVivero
{
    partial class frmSensores
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
            lblVivero = new Label();
            cmbVivero = new ComboBox();
            lblNombreSensor = new Label();
            txtNombreSensor = new TextBox();
            lblTipoSensor = new Label();
            cmbTipoSensor = new ComboBox();
            lblFechaInstalacion = new Label();
            dtpFechaInstalacion = new DateTimePicker();
            lblEstadoSensor = new Label();
            cmbEstadoSensor = new ComboBox();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();

            pnlListado = new Panel();
            lblListado = new Label();
            lblCantidad = new Label();
            btnRecargar = new Button();
            dgvSensores = new DataGridView();

            colIdSensor = new DataGridViewTextBoxColumn();
            colIdVivero = new DataGridViewTextBoxColumn();
            colNombreVivero = new DataGridViewTextBoxColumn();
            colNombreSensor = new DataGridViewTextBoxColumn();
            colTipoSensor = new DataGridViewTextBoxColumn();
            colFechaInstalacion = new DataGridViewTextBoxColumn();
            colEstadoSensor = new DataGridViewTextBoxColumn();

            pnlSuperior.SuspendLayout();
            pnlFormulario.SuspendLayout();
            pnlListado.SuspendLayout();
            ((ISupportInitialize)dgvSensores).BeginInit();
            SuspendLayout();

            // =====================================================
            // PANEL SUPERIOR
            // =====================================================
            pnlSuperior.BackColor = Color.White;
            pnlSuperior.Controls.Add(lblModo);
            pnlSuperior.Controls.Add(lblTitulo);
            pnlSuperior.Dock = DockStyle.Top;
            pnlSuperior.Location = new Point(0, 0);
            pnlSuperior.Name = "pnlSuperior";
            pnlSuperior.Size = new Size(1180, 82);
            pnlSuperior.TabIndex = 0;

            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font(
                "Segoe UI",
                20F,
                FontStyle.Bold
            );
            lblTitulo.ForeColor =
                Color.FromArgb(24, 101, 52);
            lblTitulo.Location = new Point(24, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(273, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de sensores";

            lblModo.AutoSize = true;
            lblModo.Font = new Font("Segoe UI", 9F);
            lblModo.ForeColor = Color.Gray;
            lblModo.Location = new Point(27, 54);
            lblModo.Name = "lblModo";
            lblModo.Size = new Size(91, 15);
            lblModo.TabIndex = 1;
            lblModo.Text = "Modo de acceso";

            // =====================================================
            // PANEL FORMULARIO
            // =====================================================
            pnlFormulario.AutoScroll = true;
            pnlFormulario.BackColor = Color.White;
            pnlFormulario.BorderStyle = BorderStyle.FixedSingle;
            pnlFormulario.Controls.Add(btnLimpiar);
            pnlFormulario.Controls.Add(btnEliminar);
            pnlFormulario.Controls.Add(btnEditar);
            pnlFormulario.Controls.Add(btnGuardar);
            pnlFormulario.Controls.Add(cmbEstadoSensor);
            pnlFormulario.Controls.Add(lblEstadoSensor);
            pnlFormulario.Controls.Add(dtpFechaInstalacion);
            pnlFormulario.Controls.Add(lblFechaInstalacion);
            pnlFormulario.Controls.Add(cmbTipoSensor);
            pnlFormulario.Controls.Add(lblTipoSensor);
            pnlFormulario.Controls.Add(txtNombreSensor);
            pnlFormulario.Controls.Add(lblNombreSensor);
            pnlFormulario.Controls.Add(cmbVivero);
            pnlFormulario.Controls.Add(lblVivero);
            pnlFormulario.Controls.Add(txtId);
            pnlFormulario.Controls.Add(lblId);
            pnlFormulario.Controls.Add(lblDatos);
            pnlFormulario.Dock = DockStyle.Left;
            pnlFormulario.Location = new Point(0, 82);
            pnlFormulario.Name = "pnlFormulario";
            pnlFormulario.Size = new Size(405, 598);
            pnlFormulario.TabIndex = 1;

            lblDatos.AutoSize = true;
            lblDatos.Font =
                new Font("Segoe UI", 13F, FontStyle.Bold);
            lblDatos.ForeColor =
                Color.FromArgb(45, 55, 50);
            lblDatos.Location = new Point(24, 20);
            lblDatos.Name = "lblDatos";
            lblDatos.Size = new Size(171, 25);
            lblDatos.TabIndex = 0;
            lblDatos.Text = "Datos del sensor";

            lblId.AutoSize = true;
            lblId.Font =
                new Font("Segoe UI", 8F, FontStyle.Bold);
            lblId.ForeColor =
                Color.FromArgb(85, 95, 90);
            lblId.Location = new Point(25, 63);
            lblId.Name = "lblId";
            lblId.Size = new Size(19, 13);
            lblId.TabIndex = 1;
            lblId.Text = "ID";

            txtId.BackColor =
                Color.FromArgb(240, 242, 241);
            txtId.BorderStyle = BorderStyle.FixedSingle;
            txtId.Font = new Font("Segoe UI", 10F);
            txtId.Location = new Point(25, 81);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(340, 25);
            txtId.TabIndex = 0;

            lblVivero.AutoSize = true;
            lblVivero.Font =
                new Font("Segoe UI", 8F, FontStyle.Bold);
            lblVivero.ForeColor =
                Color.FromArgb(85, 95, 90);
            lblVivero.Location = new Point(25, 121);
            lblVivero.Name = "lblVivero";
            lblVivero.Size = new Size(46, 13);
            lblVivero.TabIndex = 3;
            lblVivero.Text = "VIVERO";

            cmbVivero.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cmbVivero.Font = new Font("Segoe UI", 10F);
            cmbVivero.FormattingEnabled = true;
            cmbVivero.Location = new Point(25, 139);
            cmbVivero.Name = "cmbVivero";
            cmbVivero.Size = new Size(340, 25);
            cmbVivero.TabIndex = 1;

            lblNombreSensor.AutoSize = true;
            lblNombreSensor.Font =
                new Font("Segoe UI", 8F, FontStyle.Bold);
            lblNombreSensor.ForeColor =
                Color.FromArgb(85, 95, 90);
            lblNombreSensor.Location =
                new Point(25, 179);
            lblNombreSensor.Name = "lblNombreSensor";
            lblNombreSensor.Size = new Size(123, 13);
            lblNombreSensor.TabIndex = 5;
            lblNombreSensor.Text = "NOMBRE DEL SENSOR";

            txtNombreSensor.BorderStyle =
                BorderStyle.FixedSingle;
            txtNombreSensor.Font =
                new Font("Segoe UI", 10F);
            txtNombreSensor.Location =
                new Point(25, 197);
            txtNombreSensor.MaxLength = 100;
            txtNombreSensor.Name = "txtNombreSensor";
            txtNombreSensor.Size = new Size(340, 25);
            txtNombreSensor.TabIndex = 2;

            lblTipoSensor.AutoSize = true;
            lblTipoSensor.Font =
                new Font("Segoe UI", 8F, FontStyle.Bold);
            lblTipoSensor.ForeColor =
                Color.FromArgb(85, 95, 90);
            lblTipoSensor.Location = new Point(25, 237);
            lblTipoSensor.Name = "lblTipoSensor";
            lblTipoSensor.Size = new Size(92, 13);
            lblTipoSensor.TabIndex = 7;
            lblTipoSensor.Text = "TIPO DE SENSOR";

            cmbTipoSensor.AutoCompleteMode =
                AutoCompleteMode.SuggestAppend;
            cmbTipoSensor.AutoCompleteSource =
                AutoCompleteSource.ListItems;
            cmbTipoSensor.Font =
                new Font("Segoe UI", 10F);
            cmbTipoSensor.FormattingEnabled = true;
            cmbTipoSensor.Items.AddRange(
                new object[]
                {
                    "Temperatura y Humedad Ambiente",
                    "Humedad del Suelo"
                }
            );
            cmbTipoSensor.Location =
                new Point(25, 255);
            cmbTipoSensor.MaxLength = 50;
            cmbTipoSensor.Name = "cmbTipoSensor";
            cmbTipoSensor.Size = new Size(340, 25);
            cmbTipoSensor.TabIndex = 3;

            lblFechaInstalacion.AutoSize = true;
            lblFechaInstalacion.Font =
                new Font("Segoe UI", 8F, FontStyle.Bold);
            lblFechaInstalacion.ForeColor =
                Color.FromArgb(85, 95, 90);
            lblFechaInstalacion.Location =
                new Point(25, 295);
            lblFechaInstalacion.Name =
                "lblFechaInstalacion";
            lblFechaInstalacion.Size =
                new Size(137, 13);
            lblFechaInstalacion.TabIndex = 9;
            lblFechaInstalacion.Text =
                "FECHA DE INSTALACIÓN";

            dtpFechaInstalacion.Font =
                new Font("Segoe UI", 10F);
            dtpFechaInstalacion.Format =
                DateTimePickerFormat.Short;
            dtpFechaInstalacion.Location =
                new Point(25, 313);
            dtpFechaInstalacion.Name =
                "dtpFechaInstalacion";
            dtpFechaInstalacion.ShowCheckBox = true;
            dtpFechaInstalacion.Size =
                new Size(340, 25);
            dtpFechaInstalacion.TabIndex = 4;

            lblEstadoSensor.AutoSize = true;
            lblEstadoSensor.Font =
                new Font("Segoe UI", 8F, FontStyle.Bold);
            lblEstadoSensor.ForeColor =
                Color.FromArgb(85, 95, 90);
            lblEstadoSensor.Location =
                new Point(25, 353);
            lblEstadoSensor.Name =
                "lblEstadoSensor";
            lblEstadoSensor.Size = new Size(47, 13);
            lblEstadoSensor.TabIndex = 11;
            lblEstadoSensor.Text = "ESTADO";

            cmbEstadoSensor.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cmbEstadoSensor.Font =
                new Font("Segoe UI", 10F);
            cmbEstadoSensor.FormattingEnabled = true;
            cmbEstadoSensor.Items.AddRange(
                new object[]
                {
                    "Activo",
                    "Inactivo",
                    "Mantenimiento"
                }
            );
            cmbEstadoSensor.Location =
                new Point(25, 371);
            cmbEstadoSensor.Name =
                "cmbEstadoSensor";
            cmbEstadoSensor.Size =
                new Size(340, 25);
            cmbEstadoSensor.TabIndex = 5;

            btnGuardar.BackColor =
                Color.FromArgb(34, 139, 60);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location =
                new Point(25, 425);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(105, 38);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            btnEditar.BackColor =
                Color.FromArgb(45, 116, 181);
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location =
                new Point(142, 425);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(105, 38);
            btnEditar.TabIndex = 7;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;

            btnEliminar.BackColor =
                Color.FromArgb(207, 48, 68);
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location =
                new Point(260, 425);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(105, 38);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;

            btnLimpiar.BackColor =
                Color.FromArgb(125, 136, 147);
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location =
                new Point(25, 475);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(340, 38);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "Limpiar campos";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;

            // =====================================================
            // PANEL LISTADO
            // =====================================================
            pnlListado.BackColor =
                Color.FromArgb(242, 245, 243);
            pnlListado.Controls.Add(dgvSensores);
            pnlListado.Controls.Add(btnRecargar);
            pnlListado.Controls.Add(lblCantidad);
            pnlListado.Controls.Add(lblListado);
            pnlListado.Dock = DockStyle.Fill;
            pnlListado.Location =
                new Point(405, 82);
            pnlListado.Name = "pnlListado";
            pnlListado.Padding = new Padding(22);
            pnlListado.Size = new Size(775, 598);
            pnlListado.TabIndex = 2;

            lblListado.AutoSize = true;
            lblListado.Font =
                new Font("Segoe UI", 14F, FontStyle.Bold);
            lblListado.ForeColor =
                Color.FromArgb(45, 55, 50);
            lblListado.Location = new Point(22, 20);
            lblListado.Name = "lblListado";
            lblListado.Size = new Size(210, 25);
            lblListado.TabIndex = 0;
            lblListado.Text = "Sensores registrados";

            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 9F);
            lblCantidad.ForeColor = Color.Gray;
            lblCantidad.Location = new Point(24, 51);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(133, 15);
            lblCantidad.TabIndex = 1;
            lblCantidad.Text = "Sensores registrados: 0";

            btnRecargar.Anchor =
                AnchorStyles.Top | AnchorStyles.Right;
            btnRecargar.BackColor =
                Color.FromArgb(34, 139, 60);
            btnRecargar.Cursor = Cursors.Hand;
            btnRecargar.FlatAppearance.BorderSize = 0;
            btnRecargar.FlatStyle = FlatStyle.Flat;
            btnRecargar.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRecargar.ForeColor = Color.White;
            btnRecargar.Location =
                new Point(638, 25);
            btnRecargar.Name = "btnRecargar";
            btnRecargar.Size = new Size(112, 36);
            btnRecargar.TabIndex = 0;
            btnRecargar.Text = "Recargar";
            btnRecargar.UseVisualStyleBackColor = false;
            btnRecargar.Click += btnRecargar_Click;

            dgvSensores.AllowUserToAddRows = false;
            dgvSensores.AllowUserToDeleteRows = false;
            dgvSensores.AllowUserToResizeRows = false;
            dgvSensores.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;
            dgvSensores.AutoGenerateColumns = false;
            dgvSensores.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvSensores.BackgroundColor = Color.White;
            dgvSensores.BorderStyle = BorderStyle.None;
            dgvSensores.ColumnHeadersHeight = 42;
            dgvSensores.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSensores.Columns.AddRange(
                new DataGridViewColumn[]
                {
                    colIdSensor,
                    colIdVivero,
                    colNombreVivero,
                    colNombreSensor,
                    colTipoSensor,
                    colFechaInstalacion,
                    colEstadoSensor
                }
            );
            dgvSensores.Location = new Point(22, 82);
            dgvSensores.MultiSelect = false;
            dgvSensores.Name = "dgvSensores";
            dgvSensores.ReadOnly = true;
            dgvSensores.RowHeadersVisible = false;
            dgvSensores.RowTemplate.Height = 30;
            dgvSensores.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvSensores.Size = new Size(728, 490);
            dgvSensores.TabIndex = 1;
            dgvSensores.CellClick += dgvSensores_CellClick;

            colIdSensor.DataPropertyName = "IdSensor";
            colIdSensor.FillWeight = 35F;
            colIdSensor.HeaderText = "ID";
            colIdSensor.Name = "colIdSensor";
            colIdSensor.ReadOnly = true;

            colIdVivero.DataPropertyName = "IdVivero";
            colIdVivero.HeaderText = "ID vivero";
            colIdVivero.Name = "colIdVivero";
            colIdVivero.ReadOnly = true;
            colIdVivero.Visible = false;

            colNombreVivero.DataPropertyName =
                "NombreVivero";
            colNombreVivero.FillWeight = 95F;
            colNombreVivero.HeaderText = "Vivero";
            colNombreVivero.Name = "colNombreVivero";
            colNombreVivero.ReadOnly = true;

            colNombreSensor.DataPropertyName =
                "NombreSensor";
            colNombreSensor.FillWeight = 95F;
            colNombreSensor.HeaderText = "Sensor";
            colNombreSensor.Name = "colNombreSensor";
            colNombreSensor.ReadOnly = true;

            colTipoSensor.DataPropertyName =
                "TipoSensor";
            colTipoSensor.FillWeight = 125F;
            colTipoSensor.HeaderText = "Tipo de sensor";
            colTipoSensor.Name = "colTipoSensor";
            colTipoSensor.ReadOnly = true;

            colFechaInstalacion.DataPropertyName =
                "FechaInstalacion";
            colFechaInstalacion.DefaultCellStyle.Format =
                "dd/MM/yyyy";
            colFechaInstalacion.FillWeight = 75F;
            colFechaInstalacion.HeaderText =
                "Fecha instalación";
            colFechaInstalacion.Name =
                "colFechaInstalacion";
            colFechaInstalacion.ReadOnly = true;

            colEstadoSensor.DataPropertyName =
                "EstadoSensor";
            colEstadoSensor.FillWeight = 65F;
            colEstadoSensor.HeaderText = "Estado";
            colEstadoSensor.Name = "colEstadoSensor";
            colEstadoSensor.ReadOnly = true;

            // =====================================================
            // FORMULARIO
            // =====================================================
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1180, 680);
            Controls.Add(pnlListado);
            Controls.Add(pnlFormulario);
            Controls.Add(pnlSuperior);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(0, 0);
            Name = "frmSensores";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de sensores";
            Load += frmSensores_Load;

            pnlSuperior.ResumeLayout(false);
            pnlSuperior.PerformLayout();
            pnlFormulario.ResumeLayout(false);
            pnlFormulario.PerformLayout();
            pnlListado.ResumeLayout(false);
            pnlListado.PerformLayout();
            ((ISupportInitialize)dgvSensores).EndInit();
            ResumeLayout(false);
        }

        private Panel pnlSuperior;
        private Label lblTitulo;
        private Label lblModo;

        private Panel pnlFormulario;
        private Label lblDatos;
        private Label lblId;
        private TextBox txtId;
        private Label lblVivero;
        private ComboBox cmbVivero;
        private Label lblNombreSensor;
        private TextBox txtNombreSensor;
        private Label lblTipoSensor;
        private ComboBox cmbTipoSensor;
        private Label lblFechaInstalacion;
        private DateTimePicker dtpFechaInstalacion;
        private Label lblEstadoSensor;
        private ComboBox cmbEstadoSensor;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnLimpiar;

        private Panel pnlListado;
        private Label lblListado;
        private Label lblCantidad;
        private Button btnRecargar;
        private DataGridView dgvSensores;

        private DataGridViewTextBoxColumn colIdSensor;
        private DataGridViewTextBoxColumn colIdVivero;
        private DataGridViewTextBoxColumn colNombreVivero;
        private DataGridViewTextBoxColumn colNombreSensor;
        private DataGridViewTextBoxColumn colTipoSensor;
        private DataGridViewTextBoxColumn colFechaInstalacion;
        private DataGridViewTextBoxColumn colEstadoSensor;
    }
}
