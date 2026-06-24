using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectVivero
{
    partial class frmCultivos
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
            lblNombreCultivo = new Label();
            txtNombreCultivo = new TextBox();
            lblVariedad = new Label();
            txtVariedad = new TextBox();
            lblFechaSiembra = new Label();
            dtpFechaSiembra = new DateTimePicker();
            lblFechaEstimada = new Label();
            dtpFechaEstimadaCosecha = new DateTimePicker();
            lblFechaCosecha = new Label();
            dtpFechaCosecha = new DateTimePicker();
            lblEtapa = new Label();
            cmbEtapa = new ComboBox();
            lblEstado = new Label();
            cmbEstado = new ComboBox();
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
            dgvCultivos = new DataGridView();

            colIdCultivo = new DataGridViewTextBoxColumn();
            colIdVivero = new DataGridViewTextBoxColumn();
            colNombreVivero = new DataGridViewTextBoxColumn();
            colNombreCultivo = new DataGridViewTextBoxColumn();
            colVariedad = new DataGridViewTextBoxColumn();
            colFechaSiembra = new DataGridViewTextBoxColumn();
            colFechaEstimadaCosecha = new DataGridViewTextBoxColumn();
            colFechaCosecha = new DataGridViewTextBoxColumn();
            colEtapa = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();

            pnlSuperior.SuspendLayout();
            pnlFormulario.SuspendLayout();
            pnlListado.SuspendLayout();
            ((ISupportInitialize)dgvCultivos).BeginInit();
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
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(24, 101, 52);
            lblTitulo.Location = new Point(24, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(250, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de cultivos";

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
            pnlFormulario.Controls.Add(txtDescripcion);
            pnlFormulario.Controls.Add(lblDescripcion);
            pnlFormulario.Controls.Add(cmbEstado);
            pnlFormulario.Controls.Add(lblEstado);
            pnlFormulario.Controls.Add(cmbEtapa);
            pnlFormulario.Controls.Add(lblEtapa);
            pnlFormulario.Controls.Add(dtpFechaCosecha);
            pnlFormulario.Controls.Add(lblFechaCosecha);
            pnlFormulario.Controls.Add(dtpFechaEstimadaCosecha);
            pnlFormulario.Controls.Add(lblFechaEstimada);
            pnlFormulario.Controls.Add(dtpFechaSiembra);
            pnlFormulario.Controls.Add(lblFechaSiembra);
            pnlFormulario.Controls.Add(txtVariedad);
            pnlFormulario.Controls.Add(lblVariedad);
            pnlFormulario.Controls.Add(txtNombreCultivo);
            pnlFormulario.Controls.Add(lblNombreCultivo);
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
            lblDatos.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblDatos.ForeColor = Color.FromArgb(45, 55, 50);
            lblDatos.Location = new Point(24, 18);
            lblDatos.Name = "lblDatos";
            lblDatos.Size = new Size(163, 25);
            lblDatos.TabIndex = 0;
            lblDatos.Text = "Datos del cultivo";

            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblId.ForeColor = Color.FromArgb(85, 95, 90);
            lblId.Location = new Point(25, 58);
            lblId.Name = "lblId";
            lblId.Size = new Size(19, 13);
            lblId.TabIndex = 1;
            lblId.Text = "ID";

            txtId.BackColor = Color.FromArgb(240, 242, 241);
            txtId.BorderStyle = BorderStyle.FixedSingle;
            txtId.Font = new Font("Segoe UI", 10F);
            txtId.Location = new Point(25, 76);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(340, 25);
            txtId.TabIndex = 0;

            lblVivero.AutoSize = true;
            lblVivero.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblVivero.ForeColor = Color.FromArgb(85, 95, 90);
            lblVivero.Location = new Point(25, 112);
            lblVivero.Name = "lblVivero";
            lblVivero.Size = new Size(46, 13);
            lblVivero.TabIndex = 3;
            lblVivero.Text = "VIVERO";

            cmbVivero.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVivero.Font = new Font("Segoe UI", 10F);
            cmbVivero.FormattingEnabled = true;
            cmbVivero.Location = new Point(25, 130);
            cmbVivero.Name = "cmbVivero";
            cmbVivero.Size = new Size(340, 25);
            cmbVivero.TabIndex = 1;

            lblNombreCultivo.AutoSize = true;
            lblNombreCultivo.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblNombreCultivo.ForeColor = Color.FromArgb(85, 95, 90);
            lblNombreCultivo.Location = new Point(25, 166);
            lblNombreCultivo.Name = "lblNombreCultivo";
            lblNombreCultivo.Size = new Size(126, 13);
            lblNombreCultivo.TabIndex = 5;
            lblNombreCultivo.Text = "NOMBRE DEL CULTIVO";

            txtNombreCultivo.BorderStyle = BorderStyle.FixedSingle;
            txtNombreCultivo.Font = new Font("Segoe UI", 10F);
            txtNombreCultivo.Location = new Point(25, 184);
            txtNombreCultivo.MaxLength = 100;
            txtNombreCultivo.Name = "txtNombreCultivo";
            txtNombreCultivo.Size = new Size(340, 25);
            txtNombreCultivo.TabIndex = 2;

            lblVariedad.AutoSize = true;
            lblVariedad.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblVariedad.ForeColor = Color.FromArgb(85, 95, 90);
            lblVariedad.Location = new Point(25, 220);
            lblVariedad.Name = "lblVariedad";
            lblVariedad.Size = new Size(59, 13);
            lblVariedad.TabIndex = 7;
            lblVariedad.Text = "VARIEDAD";

            txtVariedad.BorderStyle = BorderStyle.FixedSingle;
            txtVariedad.Font = new Font("Segoe UI", 10F);
            txtVariedad.Location = new Point(25, 238);
            txtVariedad.MaxLength = 100;
            txtVariedad.Name = "txtVariedad";
            txtVariedad.Size = new Size(340, 25);
            txtVariedad.TabIndex = 3;

            lblFechaSiembra.AutoSize = true;
            lblFechaSiembra.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblFechaSiembra.ForeColor = Color.FromArgb(85, 95, 90);
            lblFechaSiembra.Location = new Point(25, 274);
            lblFechaSiembra.Name = "lblFechaSiembra";
            lblFechaSiembra.Size = new Size(102, 13);
            lblFechaSiembra.TabIndex = 9;
            lblFechaSiembra.Text = "FECHA DE SIEMBRA";

            dtpFechaSiembra.Font = new Font("Segoe UI", 10F);
            dtpFechaSiembra.Format = DateTimePickerFormat.Short;
            dtpFechaSiembra.Location = new Point(25, 292);
            dtpFechaSiembra.Name = "dtpFechaSiembra";
            dtpFechaSiembra.Size = new Size(340, 25);
            dtpFechaSiembra.TabIndex = 4;

            lblFechaEstimada.AutoSize = true;
            lblFechaEstimada.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblFechaEstimada.ForeColor = Color.FromArgb(85, 95, 90);
            lblFechaEstimada.Location = new Point(25, 328);
            lblFechaEstimada.Name = "lblFechaEstimada";
            lblFechaEstimada.Size = new Size(187, 13);
            lblFechaEstimada.TabIndex = 11;
            lblFechaEstimada.Text = "FECHA ESTIMADA DE COSECHA";

            dtpFechaEstimadaCosecha.Font = new Font("Segoe UI", 10F);
            dtpFechaEstimadaCosecha.Format = DateTimePickerFormat.Short;
            dtpFechaEstimadaCosecha.Location = new Point(25, 346);
            dtpFechaEstimadaCosecha.Name = "dtpFechaEstimadaCosecha";
            dtpFechaEstimadaCosecha.ShowCheckBox = true;
            dtpFechaEstimadaCosecha.Size = new Size(340, 25);
            dtpFechaEstimadaCosecha.TabIndex = 5;

            lblFechaCosecha.AutoSize = true;
            lblFechaCosecha.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblFechaCosecha.ForeColor = Color.FromArgb(85, 95, 90);
            lblFechaCosecha.Location = new Point(25, 382);
            lblFechaCosecha.Name = "lblFechaCosecha";
            lblFechaCosecha.Size = new Size(108, 13);
            lblFechaCosecha.TabIndex = 13;
            lblFechaCosecha.Text = "FECHA DE COSECHA";

            dtpFechaCosecha.Font = new Font("Segoe UI", 10F);
            dtpFechaCosecha.Format = DateTimePickerFormat.Short;
            dtpFechaCosecha.Location = new Point(25, 400);
            dtpFechaCosecha.Name = "dtpFechaCosecha";
            dtpFechaCosecha.ShowCheckBox = true;
            dtpFechaCosecha.Size = new Size(340, 25);
            dtpFechaCosecha.TabIndex = 6;

            lblEtapa.AutoSize = true;
            lblEtapa.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblEtapa.ForeColor = Color.FromArgb(85, 95, 90);
            lblEtapa.Location = new Point(25, 436);
            lblEtapa.Name = "lblEtapa";
            lblEtapa.Size = new Size(40, 13);
            lblEtapa.TabIndex = 15;
            lblEtapa.Text = "ETAPA";

            cmbEtapa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEtapa.Font = new Font("Segoe UI", 10F);
            cmbEtapa.FormattingEnabled = true;
            cmbEtapa.Items.AddRange(new object[]
            {
                "Siembra",
                "Germinación",
                "Crecimiento",
                "Desarrollo",
                "Cosecha",
                "Finalizado"
            });
            cmbEtapa.Location = new Point(25, 454);
            cmbEtapa.Name = "cmbEtapa";
            cmbEtapa.Size = new Size(340, 25);
            cmbEtapa.TabIndex = 7;

            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblEstado.ForeColor = Color.FromArgb(85, 95, 90);
            lblEstado.Location = new Point(25, 490);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(47, 13);
            lblEstado.TabIndex = 17;
            lblEstado.Text = "ESTADO";

            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Font = new Font("Segoe UI", 10F);
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Items.AddRange(new object[]
            {
                "Activo",
                "Inactivo",
                "Finalizado"
            });
            cmbEstado.Location = new Point(25, 508);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(340, 25);
            cmbEstado.TabIndex = 8;

            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblDescripcion.ForeColor = Color.FromArgb(85, 95, 90);
            lblDescripcion.Location = new Point(25, 544);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(76, 13);
            lblDescripcion.TabIndex = 19;
            lblDescripcion.Text = "DESCRIPCIÓN";

            txtDescripcion.BorderStyle = BorderStyle.FixedSingle;
            txtDescripcion.Font = new Font("Segoe UI", 10F);
            txtDescripcion.Location = new Point(25, 562);
            txtDescripcion.MaxLength = 255;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(340, 78);
            txtDescripcion.TabIndex = 9;

            btnGuardar.BackColor = Color.FromArgb(34, 139, 60);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(25, 660);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(105, 38);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            btnEditar.BackColor = Color.FromArgb(45, 116, 181);
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(142, 660);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(105, 38);
            btnEditar.TabIndex = 11;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;

            btnEliminar.BackColor = Color.FromArgb(207, 48, 68);
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(260, 660);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(105, 38);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;

            btnLimpiar.BackColor = Color.FromArgb(125, 136, 147);
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(25, 710);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(340, 38);
            btnLimpiar.TabIndex = 13;
            btnLimpiar.Text = "Limpiar campos";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;

            // =====================================================
            // PANEL LISTADO
            // =====================================================
            pnlListado.BackColor = Color.FromArgb(242, 245, 243);
            pnlListado.Controls.Add(dgvCultivos);
            pnlListado.Controls.Add(btnRecargar);
            pnlListado.Controls.Add(lblCantidad);
            pnlListado.Controls.Add(lblListado);
            pnlListado.Dock = DockStyle.Fill;
            pnlListado.Location = new Point(405, 82);
            pnlListado.Name = "pnlListado";
            pnlListado.Padding = new Padding(22);
            pnlListado.Size = new Size(775, 598);
            pnlListado.TabIndex = 2;

            lblListado.AutoSize = true;
            lblListado.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblListado.ForeColor = Color.FromArgb(45, 55, 50);
            lblListado.Location = new Point(22, 20);
            lblListado.Name = "lblListado";
            lblListado.Size = new Size(201, 25);
            lblListado.TabIndex = 0;
            lblListado.Text = "Cultivos registrados";

            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 9F);
            lblCantidad.ForeColor = Color.Gray;
            lblCantidad.Location = new Point(24, 51);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(128, 15);
            lblCantidad.TabIndex = 1;
            lblCantidad.Text = "Cultivos registrados: 0";

            btnRecargar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRecargar.BackColor = Color.FromArgb(34, 139, 60);
            btnRecargar.Cursor = Cursors.Hand;
            btnRecargar.FlatAppearance.BorderSize = 0;
            btnRecargar.FlatStyle = FlatStyle.Flat;
            btnRecargar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRecargar.ForeColor = Color.White;
            btnRecargar.Location = new Point(638, 25);
            btnRecargar.Name = "btnRecargar";
            btnRecargar.Size = new Size(112, 36);
            btnRecargar.TabIndex = 0;
            btnRecargar.Text = "Recargar";
            btnRecargar.UseVisualStyleBackColor = false;
            btnRecargar.Click += btnRecargar_Click;

            dgvCultivos.AllowUserToAddRows = false;
            dgvCultivos.AllowUserToDeleteRows = false;
            dgvCultivos.AllowUserToResizeRows = false;
            dgvCultivos.Anchor = AnchorStyles.Top |
                                 AnchorStyles.Bottom |
                                 AnchorStyles.Left |
                                 AnchorStyles.Right;
            dgvCultivos.AutoGenerateColumns = false;
            dgvCultivos.BackgroundColor = Color.White;
            dgvCultivos.BorderStyle = BorderStyle.None;
            dgvCultivos.ColumnHeadersHeight = 42;
            dgvCultivos.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCultivos.Columns.AddRange(new DataGridViewColumn[]
            {
                colIdCultivo,
                colIdVivero,
                colNombreVivero,
                colNombreCultivo,
                colVariedad,
                colFechaSiembra,
                colFechaEstimadaCosecha,
                colFechaCosecha,
                colEtapa,
                colEstado,
                colDescripcion
            });
            dgvCultivos.Location = new Point(22, 82);
            dgvCultivos.MultiSelect = false;
            dgvCultivos.Name = "dgvCultivos";
            dgvCultivos.ReadOnly = true;
            dgvCultivos.RowHeadersVisible = false;
            dgvCultivos.RowTemplate.Height = 30;
            dgvCultivos.ScrollBars = ScrollBars.Both;
            dgvCultivos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCultivos.Size = new Size(728, 490);
            dgvCultivos.TabIndex = 1;
            dgvCultivos.CellClick += dgvCultivos_CellClick;

            colIdCultivo.DataPropertyName = "IdCultivo";
            colIdCultivo.HeaderText = "ID";
            colIdCultivo.Name = "colIdCultivo";
            colIdCultivo.ReadOnly = true;
            colIdCultivo.Width = 50;

            colIdVivero.DataPropertyName = "IdVivero";
            colIdVivero.HeaderText = "ID vivero";
            colIdVivero.Name = "colIdVivero";
            colIdVivero.ReadOnly = true;
            colIdVivero.Visible = false;

            colNombreVivero.DataPropertyName = "NombreVivero";
            colNombreVivero.HeaderText = "Vivero";
            colNombreVivero.Name = "colNombreVivero";
            colNombreVivero.ReadOnly = true;
            colNombreVivero.Width = 170;

            colNombreCultivo.DataPropertyName = "NombreCultivo";
            colNombreCultivo.HeaderText = "Cultivo";
            colNombreCultivo.Name = "colNombreCultivo";
            colNombreCultivo.ReadOnly = true;
            colNombreCultivo.Width = 120;

            colVariedad.DataPropertyName = "Variedad";
            colVariedad.HeaderText = "Variedad";
            colVariedad.Name = "colVariedad";
            colVariedad.ReadOnly = true;
            colVariedad.Width = 120;

            colFechaSiembra.DataPropertyName = "FechaSiembra";
            colFechaSiembra.DefaultCellStyle.Format = "dd/MM/yyyy";
            colFechaSiembra.HeaderText = "Fecha siembra";
            colFechaSiembra.Name = "colFechaSiembra";
            colFechaSiembra.ReadOnly = true;
            colFechaSiembra.Width = 105;

            colFechaEstimadaCosecha.DataPropertyName = "FechaEstimadaCosecha";
            colFechaEstimadaCosecha.DefaultCellStyle.Format = "dd/MM/yyyy";
            colFechaEstimadaCosecha.HeaderText = "Cosecha estimada";
            colFechaEstimadaCosecha.Name = "colFechaEstimadaCosecha";
            colFechaEstimadaCosecha.ReadOnly = true;
            colFechaEstimadaCosecha.Width = 115;

            colFechaCosecha.DataPropertyName = "FechaCosecha";
            colFechaCosecha.DefaultCellStyle.Format = "dd/MM/yyyy";
            colFechaCosecha.HeaderText = "Fecha cosecha";
            colFechaCosecha.Name = "colFechaCosecha";
            colFechaCosecha.ReadOnly = true;
            colFechaCosecha.Width = 105;

            colEtapa.DataPropertyName = "Etapa";
            colEtapa.HeaderText = "Etapa";
            colEtapa.Name = "colEtapa";
            colEtapa.ReadOnly = true;
            colEtapa.Width = 105;

            colEstado.DataPropertyName = "Estado";
            colEstado.HeaderText = "Estado";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            colEstado.Width = 85;

            colDescripcion.DataPropertyName = "Descripcion";
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;
            colDescripcion.Width = 230;

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
            Name = "frmCultivos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de cultivos";
            Load += frmCultivos_Load;

            pnlSuperior.ResumeLayout(false);
            pnlSuperior.PerformLayout();
            pnlFormulario.ResumeLayout(false);
            pnlFormulario.PerformLayout();
            pnlListado.ResumeLayout(false);
            pnlListado.PerformLayout();
            ((ISupportInitialize)dgvCultivos).EndInit();
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
        private Label lblNombreCultivo;
        private TextBox txtNombreCultivo;
        private Label lblVariedad;
        private TextBox txtVariedad;
        private Label lblFechaSiembra;
        private DateTimePicker dtpFechaSiembra;
        private Label lblFechaEstimada;
        private DateTimePicker dtpFechaEstimadaCosecha;
        private Label lblFechaCosecha;
        private DateTimePicker dtpFechaCosecha;
        private Label lblEtapa;
        private ComboBox cmbEtapa;
        private Label lblEstado;
        private ComboBox cmbEstado;
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
        private DataGridView dgvCultivos;
        private DataGridViewTextBoxColumn colIdCultivo;
        private DataGridViewTextBoxColumn colIdVivero;
        private DataGridViewTextBoxColumn colNombreVivero;
        private DataGridViewTextBoxColumn colNombreCultivo;
        private DataGridViewTextBoxColumn colVariedad;
        private DataGridViewTextBoxColumn colFechaSiembra;
        private DataGridViewTextBoxColumn colFechaEstimadaCosecha;
        private DataGridViewTextBoxColumn colFechaCosecha;
        private DataGridViewTextBoxColumn colEtapa;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewTextBoxColumn colDescripcion;
    }
}
