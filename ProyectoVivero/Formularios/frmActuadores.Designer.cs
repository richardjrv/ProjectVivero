using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectVivero
{
    partial class frmActuadores
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
            components = new Container();

            pnlSuperior = new Panel();
            lblTitulo = new Label();
            lblModoAcceso = new Label();

            pnlTarjetas = new TableLayoutPanel();

            pnlBomba = new Panel();
            lblBombaTitulo = new Label();
            lblBombaEstado = new Label();
            lblBombaModo = new Label();

            pnlVentiladores = new Panel();
            lblVentiladorTitulo = new Label();
            lblVentiladorEstado = new Label();
            lblVentiladorModo = new Label();

            pnlFormulario = new Panel();
            lblDatos = new Label();
            lblId = new Label();
            txtId = new TextBox();
            lblVivero = new Label();
            cmbVivero = new ComboBox();
            lblNombreActuador = new Label();
            txtNombreActuador = new TextBox();
            lblTipoActuador = new Label();
            cmbTipoActuador = new ComboBox();
            lblModoControl = new Label();
            cmbModoControl = new ComboBox();
            lblEstadoDeseado = new Label();
            cmbEstadoDeseado = new ComboBox();
            lblEstadoRegistro = new Label();
            cmbEstadoRegistro = new ComboBox();

            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();

            btnEncender = new Button();
            btnApagar = new Button();
            btnAutomatico = new Button();
            btnManual = new Button();

            pnlListado = new Panel();
            lblListado = new Label();
            lblCantidad = new Label();
            btnRecargar = new Button();
            dgvActuadores = new DataGridView();

            colIdActuador =
                new DataGridViewTextBoxColumn();
            colIdVivero =
                new DataGridViewTextBoxColumn();
            colNombreVivero =
                new DataGridViewTextBoxColumn();
            colNombreActuador =
                new DataGridViewTextBoxColumn();
            colTipoActuador =
                new DataGridViewTextBoxColumn();
            colModoControl =
                new DataGridViewTextBoxColumn();
            colEstadoDeseadoTexto =
                new DataGridViewTextBoxColumn();
            colEstadoActualTexto =
                new DataGridViewTextBoxColumn();
            colFechaActualizacion =
                new DataGridViewTextBoxColumn();
            colEstadoRegistro =
                new DataGridViewTextBoxColumn();

            timerActualizacion =
                new System.Windows.Forms.Timer(
                    components
                );

            pnlSuperior.SuspendLayout();
            pnlTarjetas.SuspendLayout();
            pnlBomba.SuspendLayout();
            pnlVentiladores.SuspendLayout();
            pnlFormulario.SuspendLayout();
            pnlListado.SuspendLayout();

            ((ISupportInitialize)dgvActuadores)
                .BeginInit();

            SuspendLayout();

            // =====================================================
            // SUPERIOR
            // =====================================================
            pnlSuperior.BackColor =
                Color.White;
            pnlSuperior.Controls.Add(
                lblModoAcceso
            );
            pnlSuperior.Controls.Add(
                lblTitulo
            );
            pnlSuperior.Dock =
                DockStyle.Top;
            pnlSuperior.Height = 82;

            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font(
                "Segoe UI",
                20F,
                FontStyle.Bold
            );
            lblTitulo.ForeColor =
                Color.FromArgb(24, 101, 52);
            lblTitulo.Location =
                new Point(24, 14);
            lblTitulo.Text =
                "Control de actuadores";

            lblModoAcceso.AutoSize = true;
            lblModoAcceso.Font =
                new Font("Segoe UI", 9F);
            lblModoAcceso.ForeColor =
                Color.Gray;
            lblModoAcceso.Location =
                new Point(27, 54);
            lblModoAcceso.Text =
                "Modo de acceso";

            // =====================================================
            // TARJETAS
            // =====================================================
            pnlTarjetas.BackColor =
                Color.FromArgb(242, 245, 243);
            pnlTarjetas.ColumnCount = 2;
            pnlTarjetas.ColumnStyles.Add(
                new ColumnStyle(
                    SizeType.Percent,
                    50F
                )
            );
            pnlTarjetas.ColumnStyles.Add(
                new ColumnStyle(
                    SizeType.Percent,
                    50F
                )
            );
            pnlTarjetas.Controls.Add(
                pnlBomba,
                0,
                0
            );
            pnlTarjetas.Controls.Add(
                pnlVentiladores,
                1,
                0
            );
            pnlTarjetas.Dock =
                DockStyle.Top;
            pnlTarjetas.Height = 130;
            pnlTarjetas.Padding =
                new Padding(20, 12, 20, 12);

            pnlBomba.BackColor = Color.White;
            pnlBomba.BorderStyle =
                BorderStyle.FixedSingle;
            pnlBomba.Controls.Add(
                lblBombaModo
            );
            pnlBomba.Controls.Add(
                lblBombaEstado
            );
            pnlBomba.Controls.Add(
                lblBombaTitulo
            );
            pnlBomba.Dock = DockStyle.Fill;
            pnlBomba.Margin =
                new Padding(0, 0, 8, 0);

            lblBombaTitulo.AutoSize = true;
            lblBombaTitulo.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold
                );
            lblBombaTitulo.ForeColor =
                Color.FromArgb(65, 75, 70);
            lblBombaTitulo.Location =
                new Point(18, 14);
            lblBombaTitulo.Text =
                "Bomba de agua";

            lblBombaEstado.AutoSize = true;
            lblBombaEstado.Font =
                new Font(
                    "Segoe UI",
                    22F,
                    FontStyle.Bold
                );
            lblBombaEstado.ForeColor =
                Color.FromArgb(185, 55, 55);
            lblBombaEstado.Location =
                new Point(16, 37);
            lblBombaEstado.Text =
                "APAGADO";

            lblBombaModo.AutoSize = true;
            lblBombaModo.Font =
                new Font("Segoe UI", 8.5F);
            lblBombaModo.ForeColor =
                Color.Gray;
            lblBombaModo.Location =
                new Point(19, 82);
            lblBombaModo.Text =
                "Modo: --";

            pnlVentiladores.BackColor =
                Color.White;
            pnlVentiladores.BorderStyle =
                BorderStyle.FixedSingle;
            pnlVentiladores.Controls.Add(
                lblVentiladorModo
            );
            pnlVentiladores.Controls.Add(
                lblVentiladorEstado
            );
            pnlVentiladores.Controls.Add(
                lblVentiladorTitulo
            );
            pnlVentiladores.Dock =
                DockStyle.Fill;
            pnlVentiladores.Margin =
                new Padding(8, 0, 0, 0);

            lblVentiladorTitulo.AutoSize = true;
            lblVentiladorTitulo.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold
                );
            lblVentiladorTitulo.ForeColor =
                Color.FromArgb(65, 75, 70);
            lblVentiladorTitulo.Location =
                new Point(18, 14);
            lblVentiladorTitulo.Text =
                "Ventiladores";

            lblVentiladorEstado.AutoSize = true;
            lblVentiladorEstado.Font =
                new Font(
                    "Segoe UI",
                    22F,
                    FontStyle.Bold
                );
            lblVentiladorEstado.ForeColor =
                Color.FromArgb(185, 55, 55);
            lblVentiladorEstado.Location =
                new Point(16, 37);
            lblVentiladorEstado.Text =
                "APAGADO";

            lblVentiladorModo.AutoSize = true;
            lblVentiladorModo.Font =
                new Font("Segoe UI", 8.5F);
            lblVentiladorModo.ForeColor =
                Color.Gray;
            lblVentiladorModo.Location =
                new Point(19, 82);
            lblVentiladorModo.Text =
                "Modo: --";

            // =====================================================
            // FORMULARIO ADMIN
            // =====================================================
            pnlFormulario.AutoScroll = true;
            pnlFormulario.BackColor =
                Color.White;
            pnlFormulario.BorderStyle =
                BorderStyle.FixedSingle;
            pnlFormulario.Dock =
                DockStyle.Left;
            pnlFormulario.Width = 405;

            pnlFormulario.Controls.Add(btnManual);
            pnlFormulario.Controls.Add(btnAutomatico);
            pnlFormulario.Controls.Add(btnApagar);
            pnlFormulario.Controls.Add(btnEncender);
            pnlFormulario.Controls.Add(btnLimpiar);
            pnlFormulario.Controls.Add(btnEliminar);
            pnlFormulario.Controls.Add(btnEditar);
            pnlFormulario.Controls.Add(btnGuardar);
            pnlFormulario.Controls.Add(cmbEstadoRegistro);
            pnlFormulario.Controls.Add(lblEstadoRegistro);
            pnlFormulario.Controls.Add(cmbEstadoDeseado);
            pnlFormulario.Controls.Add(lblEstadoDeseado);
            pnlFormulario.Controls.Add(cmbModoControl);
            pnlFormulario.Controls.Add(lblModoControl);
            pnlFormulario.Controls.Add(cmbTipoActuador);
            pnlFormulario.Controls.Add(lblTipoActuador);
            pnlFormulario.Controls.Add(txtNombreActuador);
            pnlFormulario.Controls.Add(lblNombreActuador);
            pnlFormulario.Controls.Add(cmbVivero);
            pnlFormulario.Controls.Add(lblVivero);
            pnlFormulario.Controls.Add(txtId);
            pnlFormulario.Controls.Add(lblId);
            pnlFormulario.Controls.Add(lblDatos);

            lblDatos.AutoSize = true;
            lblDatos.Font =
                new Font(
                    "Segoe UI",
                    13F,
                    FontStyle.Bold
                );
            lblDatos.ForeColor =
                Color.FromArgb(45, 55, 50);
            lblDatos.Location =
                new Point(24, 16);
            lblDatos.Text =
                "Datos del actuador";

            lblId.AutoSize = true;
            lblId.Font =
                new Font(
                    "Segoe UI",
                    8F,
                    FontStyle.Bold
                );
            lblId.ForeColor =
                Color.FromArgb(85, 95, 90);
            lblId.Location =
                new Point(25, 54);
            lblId.Text = "ID";

            txtId.BackColor =
                Color.FromArgb(240, 242, 241);
            txtId.BorderStyle =
                BorderStyle.FixedSingle;
            txtId.Font =
                new Font("Segoe UI", 10F);
            txtId.Location =
                new Point(25, 72);
            txtId.ReadOnly = true;
            txtId.Size =
                new Size(340, 25);

            lblVivero.AutoSize = true;
            lblVivero.Font =
                new Font(
                    "Segoe UI",
                    8F,
                    FontStyle.Bold
                );
            lblVivero.ForeColor =
                Color.FromArgb(85, 95, 90);
            lblVivero.Location =
                new Point(25, 108);
            lblVivero.Text =
                "VIVERO";

            cmbVivero.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cmbVivero.Font =
                new Font("Segoe UI", 10F);
            cmbVivero.Location =
                new Point(25, 126);
            cmbVivero.Size =
                new Size(340, 25);

            lblNombreActuador.AutoSize = true;
            lblNombreActuador.Font =
                new Font(
                    "Segoe UI",
                    8F,
                    FontStyle.Bold
                );
            lblNombreActuador.ForeColor =
                Color.FromArgb(85, 95, 90);
            lblNombreActuador.Location =
                new Point(25, 162);
            lblNombreActuador.Text =
                "NOMBRE DEL ACTUADOR";

            txtNombreActuador.BorderStyle =
                BorderStyle.FixedSingle;
            txtNombreActuador.Font =
                new Font("Segoe UI", 10F);
            txtNombreActuador.Location =
                new Point(25, 180);
            txtNombreActuador.MaxLength = 100;
            txtNombreActuador.Size =
                new Size(340, 25);

            lblTipoActuador.AutoSize = true;
            lblTipoActuador.Font =
                new Font(
                    "Segoe UI",
                    8F,
                    FontStyle.Bold
                );
            lblTipoActuador.ForeColor =
                Color.FromArgb(85, 95, 90);
            lblTipoActuador.Location =
                new Point(25, 216);
            lblTipoActuador.Text =
                "TIPO";

            cmbTipoActuador.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cmbTipoActuador.Font =
                new Font("Segoe UI", 10F);
            cmbTipoActuador.Items.AddRange(
                new object[]
                {
                    "Bomba",
                    "Ventilacion",
                    "Servo",
                    "Otro"
                }
            );
            cmbTipoActuador.Location =
                new Point(25, 234);
            cmbTipoActuador.Size =
                new Size(340, 25);

            lblModoControl.AutoSize = true;
            lblModoControl.Font =
                new Font(
                    "Segoe UI",
                    8F,
                    FontStyle.Bold
                );
            lblModoControl.ForeColor =
                Color.FromArgb(85, 95, 90);
            lblModoControl.Location =
                new Point(25, 270);
            lblModoControl.Text =
                "MODO DE CONTROL";

            cmbModoControl.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cmbModoControl.Font =
                new Font("Segoe UI", 10F);
            cmbModoControl.Items.AddRange(
                new object[]
                {
                    "Automatico",
                    "Manual"
                }
            );
            cmbModoControl.Location =
                new Point(25, 288);
            cmbModoControl.Size =
                new Size(340, 25);

            lblEstadoDeseado.AutoSize = true;
            lblEstadoDeseado.Font =
                new Font(
                    "Segoe UI",
                    8F,
                    FontStyle.Bold
                );
            lblEstadoDeseado.ForeColor =
                Color.FromArgb(85, 95, 90);
            lblEstadoDeseado.Location =
                new Point(25, 324);
            lblEstadoDeseado.Text =
                "ESTADO SOLICITADO";

            cmbEstadoDeseado.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cmbEstadoDeseado.Font =
                new Font("Segoe UI", 10F);
            cmbEstadoDeseado.Items.AddRange(
                new object[]
                {
                    "Apagado",
                    "Encendido"
                }
            );
            cmbEstadoDeseado.Location =
                new Point(25, 342);
            cmbEstadoDeseado.Size =
                new Size(340, 25);

            lblEstadoRegistro.AutoSize = true;
            lblEstadoRegistro.Font =
                new Font(
                    "Segoe UI",
                    8F,
                    FontStyle.Bold
                );
            lblEstadoRegistro.ForeColor =
                Color.FromArgb(85, 95, 90);
            lblEstadoRegistro.Location =
                new Point(25, 378);
            lblEstadoRegistro.Text =
                "ESTADO DEL REGISTRO";

            cmbEstadoRegistro.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cmbEstadoRegistro.Font =
                new Font("Segoe UI", 10F);
            cmbEstadoRegistro.Items.AddRange(
                new object[]
                {
                    "Activo",
                    "Inactivo"
                }
            );
            cmbEstadoRegistro.Location =
                new Point(25, 396);
            cmbEstadoRegistro.Size =
                new Size(340, 25);

            ConfigurarBoton(
                btnGuardar,
                "Guardar",
                Color.FromArgb(34, 139, 60),
                25,
                445,
                btnGuardar_Click
            );

            ConfigurarBoton(
                btnEditar,
                "Editar",
                Color.FromArgb(45, 116, 181),
                142,
                445,
                btnEditar_Click
            );

            ConfigurarBoton(
                btnEliminar,
                "Eliminar",
                Color.FromArgb(207, 48, 68),
                260,
                445,
                btnEliminar_Click
            );

            ConfigurarBoton(
                btnLimpiar,
                "Limpiar campos",
                Color.FromArgb(125, 136, 147),
                25,
                493,
                btnLimpiar_Click,
                340
            );

            ConfigurarBoton(
                btnEncender,
                "Encender",
                Color.FromArgb(28, 140, 65),
                25,
                550,
                btnEncender_Click,
                160
            );

            ConfigurarBoton(
                btnApagar,
                "Apagar",
                Color.FromArgb(185, 55, 55),
                205,
                550,
                btnApagar_Click,
                160
            );

            ConfigurarBoton(
                btnAutomatico,
                "Modo automático",
                Color.FromArgb(45, 116, 181),
                25,
                598,
                btnAutomatico_Click,
                160
            );

            ConfigurarBoton(
                btnManual,
                "Modo manual",
                Color.FromArgb(115, 90, 145),
                205,
                598,
                btnManual_Click,
                160
            );

            // =====================================================
            // LISTADO
            // =====================================================
            pnlListado.BackColor =
                Color.FromArgb(242, 245, 243);
            pnlListado.Controls.Add(
                dgvActuadores
            );
            pnlListado.Controls.Add(
                btnRecargar
            );
            pnlListado.Controls.Add(
                lblCantidad
            );
            pnlListado.Controls.Add(
                lblListado
            );
            pnlListado.Dock =
                DockStyle.Fill;
            pnlListado.Padding =
                new Padding(22);

            lblListado.AutoSize = true;
            lblListado.Font =
                new Font(
                    "Segoe UI",
                    14F,
                    FontStyle.Bold
                );
            lblListado.ForeColor =
                Color.FromArgb(45, 55, 50);
            lblListado.Location =
                new Point(22, 20);
            lblListado.Text =
                "Actuadores registrados";

            lblCantidad.AutoSize = true;
            lblCantidad.Font =
                new Font("Segoe UI", 9F);
            lblCantidad.ForeColor =
                Color.Gray;
            lblCantidad.Location =
                new Point(24, 51);
            lblCantidad.Text =
                "Actuadores registrados: 0";

            btnRecargar.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;
            btnRecargar.BackColor =
                Color.FromArgb(34, 139, 60);
            btnRecargar.FlatAppearance.BorderSize =
                0;
            btnRecargar.FlatStyle =
                FlatStyle.Flat;
            btnRecargar.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold
                );
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

            dgvActuadores.AllowUserToAddRows =
                false;
            dgvActuadores.AllowUserToDeleteRows =
                false;
            dgvActuadores.AllowUserToResizeRows =
                false;
            dgvActuadores.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;
            dgvActuadores.AutoGenerateColumns =
                false;
            dgvActuadores.BackgroundColor =
                Color.White;
            dgvActuadores.BorderStyle =
                BorderStyle.None;
            dgvActuadores.ColumnHeadersHeight =
                42;
            dgvActuadores.Columns.AddRange(
                new DataGridViewColumn[]
                {
                    colIdActuador,
                    colIdVivero,
                    colNombreVivero,
                    colNombreActuador,
                    colTipoActuador,
                    colModoControl,
                    colEstadoDeseadoTexto,
                    colEstadoActualTexto,
                    colFechaActualizacion,
                    colEstadoRegistro
                }
            );
            dgvActuadores.Location =
                new Point(22, 82);
            dgvActuadores.MultiSelect =
                false;
            dgvActuadores.ReadOnly =
                true;
            dgvActuadores.RowHeadersVisible =
                false;
            dgvActuadores.RowTemplate.Height =
                30;
            dgvActuadores.ScrollBars =
                ScrollBars.Both;
            dgvActuadores.SelectionMode =
                DataGridViewSelectionMode
                    .FullRowSelect;
            dgvActuadores.Size =
                new Size(728, 466);
            dgvActuadores.CellClick +=
                dgvActuadores_CellClick;

            ConfigurarColumna(
                colIdActuador,
                "IdActuador",
                "ID",
                50
            );

            colIdVivero.DataPropertyName =
                "IdVivero";
            colIdVivero.Name =
                "colIdVivero";
            colIdVivero.Visible =
                false;

            ConfigurarColumna(
                colNombreVivero,
                "NombreVivero",
                "Vivero",
                170
            );

            ConfigurarColumna(
                colNombreActuador,
                "NombreActuador",
                "Actuador",
                130
            );

            ConfigurarColumna(
                colTipoActuador,
                "TipoActuador",
                "Tipo",
                95
            );

            ConfigurarColumna(
                colModoControl,
                "ModoControl",
                "Modo",
                95
            );

            ConfigurarColumna(
                colEstadoDeseadoTexto,
                "EstadoDeseadoTexto",
                "Solicitado",
                95
            );

            ConfigurarColumna(
                colEstadoActualTexto,
                "EstadoActualTexto",
                "Estado real",
                95
            );

            ConfigurarColumna(
                colFechaActualizacion,
                "FechaActualizacion",
                "Última actualización",
                145
            );

            colFechaActualizacion
                .DefaultCellStyle.Format =
                "dd/MM/yyyy HH:mm:ss";

            ConfigurarColumna(
                colEstadoRegistro,
                "EstadoRegistro",
                "Registro",
                85
            );

            // =====================================================
            // TIMER Y FORMULARIO
            // =====================================================
            timerActualizacion.Interval =
                3000;
            timerActualizacion.Tick +=
                timerActualizacion_Tick;

            AutoScaleDimensions =
                new SizeF(7F, 15F);
            AutoScaleMode =
                AutoScaleMode.Font;
            BackColor =
                Color.White;
            ClientSize =
                new Size(1180, 680);
            Controls.Add(pnlListado);
            Controls.Add(pnlFormulario);
            Controls.Add(pnlTarjetas);
            Controls.Add(pnlSuperior);
            Font =
                new Font("Segoe UI", 9F);
            MinimumSize =
                new Size(0, 0);
            Name =
                "frmActuadores";
            Text =
                "Control de actuadores";
            FormClosed +=
                frmActuadores_FormClosed;
            Load +=
                frmActuadores_Load;

            pnlSuperior.ResumeLayout(false);
            pnlSuperior.PerformLayout();
            pnlTarjetas.ResumeLayout(false);
            pnlBomba.ResumeLayout(false);
            pnlBomba.PerformLayout();
            pnlVentiladores.ResumeLayout(false);
            pnlVentiladores.PerformLayout();
            pnlFormulario.ResumeLayout(false);
            pnlFormulario.PerformLayout();
            pnlListado.ResumeLayout(false);
            pnlListado.PerformLayout();

            ((ISupportInitialize)dgvActuadores)
                .EndInit();

            ResumeLayout(false);
        }

        private static void ConfigurarBoton(
            Button boton,
            string texto,
            Color color,
            int x,
            int y,
            System.EventHandler evento,
            int ancho = 105)
        {
            boton.BackColor = color;
            boton.Cursor = Cursors.Hand;
            boton.FlatAppearance.BorderSize = 0;
            boton.FlatStyle = FlatStyle.Flat;
            boton.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold
                );
            boton.ForeColor =
                Color.White;
            boton.Location =
                new Point(x, y);
            boton.Size =
                new Size(ancho, 38);
            boton.Text = texto;
            boton.UseVisualStyleBackColor =
                false;
            boton.Click += evento;
        }

        private static void ConfigurarColumna(
            DataGridViewTextBoxColumn columna,
            string propiedad,
            string encabezado,
            int ancho)
        {
            columna.DataPropertyName =
                propiedad;
            columna.HeaderText =
                encabezado;
            columna.Name =
                "col" + propiedad;
            columna.ReadOnly =
                true;
            columna.Width =
                ancho;
        }

        private Panel pnlSuperior;
        private Label lblTitulo;
        private Label lblModoAcceso;

        private TableLayoutPanel pnlTarjetas;

        private Panel pnlBomba;
        private Label lblBombaTitulo;
        private Label lblBombaEstado;
        private Label lblBombaModo;

        private Panel pnlVentiladores;
        private Label lblVentiladorTitulo;
        private Label lblVentiladorEstado;
        private Label lblVentiladorModo;

        private Panel pnlFormulario;
        private Label lblDatos;
        private Label lblId;
        private TextBox txtId;
        private Label lblVivero;
        private ComboBox cmbVivero;
        private Label lblNombreActuador;
        private TextBox txtNombreActuador;
        private Label lblTipoActuador;
        private ComboBox cmbTipoActuador;
        private Label lblModoControl;
        private ComboBox cmbModoControl;
        private Label lblEstadoDeseado;
        private ComboBox cmbEstadoDeseado;
        private Label lblEstadoRegistro;
        private ComboBox cmbEstadoRegistro;

        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Button btnEncender;
        private Button btnApagar;
        private Button btnAutomatico;
        private Button btnManual;

        private Panel pnlListado;
        private Label lblListado;
        private Label lblCantidad;
        private Button btnRecargar;
        private DataGridView dgvActuadores;

        private DataGridViewTextBoxColumn colIdActuador;
        private DataGridViewTextBoxColumn colIdVivero;
        private DataGridViewTextBoxColumn colNombreVivero;
        private DataGridViewTextBoxColumn colNombreActuador;
        private DataGridViewTextBoxColumn colTipoActuador;
        private DataGridViewTextBoxColumn colModoControl;
        private DataGridViewTextBoxColumn colEstadoDeseadoTexto;
        private DataGridViewTextBoxColumn colEstadoActualTexto;
        private DataGridViewTextBoxColumn colFechaActualizacion;
        private DataGridViewTextBoxColumn colEstadoRegistro;

        private System.Windows.Forms.Timer timerActualizacion;
    }
}
