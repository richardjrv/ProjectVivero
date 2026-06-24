using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectVivero
{
    partial class frmMediciones
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

            pnlScroll = new Panel();
            pnlContenidoVertical = new Panel();

            pnlSuperior = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            lblEstadoConexion = new Label();
            lblActualizacion = new Label();
            btnRecargar = new Button();

            pnlTarjetas = new TableLayoutPanel();

            pnlTemperatura = CrearTarjeta(
                out lblTemperaturaTitulo,
                out lblTemperaturaValor,
                out lblTemperaturaDetalle
            );

            pnlHumedadAire = CrearTarjeta(
                out lblHumedadAireTitulo,
                out lblHumedadAireValor,
                out lblHumedadAireDetalle
            );

            pnlHumedadSuelo = CrearTarjeta(
                out lblHumedadSueloTitulo,
                out lblHumedadSueloValor,
                out lblHumedadSueloDetalle
            );

            pnlGrafica = new Panel();
            graficaMediciones = new GraficaMedicionesPanel();

            pnlHistorial = new Panel();
            lblHistorial = new Label();
            lblCantidad = new Label();
            lblUltimaMedicion = new Label();
            dgvMediciones = new DataGridView();

            colIdDato = new DataGridViewTextBoxColumn();
            colTemperatura = new DataGridViewTextBoxColumn();
            colHumedadAire = new DataGridViewTextBoxColumn();
            colHumedadSuelo = new DataGridViewTextBoxColumn();
            colFechaHora = new DataGridViewTextBoxColumn();

            timerDatos =
                new System.Windows.Forms.Timer(components);

            pnlScroll.SuspendLayout();
            pnlContenidoVertical.SuspendLayout();
            pnlSuperior.SuspendLayout();
            pnlTarjetas.SuspendLayout();
            pnlGrafica.SuspendLayout();
            pnlHistorial.SuspendLayout();

            ((ISupportInitialize)dgvMediciones)
                .BeginInit();

            SuspendLayout();

            // =====================================================
            // PANEL DE DESPLAZAMIENTO GENERAL
            // =====================================================
            pnlScroll.AutoScroll = true;
            pnlScroll.BackColor =
                Color.FromArgb(242, 245, 243);
            pnlScroll.Controls.Add(pnlContenidoVertical);
            pnlScroll.Dock = DockStyle.Fill;
            pnlScroll.Location = new Point(0, 0);
            pnlScroll.Name = "pnlScroll";
            pnlScroll.Size = new Size(1180, 680);
            pnlScroll.TabIndex = 0;

            // Este panel es más alto que la ventana.
            // Por eso aparece la barra de desplazamiento vertical.
            pnlContenidoVertical.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;
            pnlContenidoVertical.BackColor =
                Color.FromArgb(242, 245, 243);
            pnlContenidoVertical.Controls.Add(pnlHistorial);
            pnlContenidoVertical.Controls.Add(pnlGrafica);
            pnlContenidoVertical.Controls.Add(pnlTarjetas);
            pnlContenidoVertical.Controls.Add(pnlSuperior);
            pnlContenidoVertical.Location = new Point(0, 0);
            pnlContenidoVertical.Name = "pnlContenidoVertical";
            pnlContenidoVertical.Size = new Size(1160, 940);
            pnlContenidoVertical.TabIndex = 0;

            // =====================================================
            // PANEL SUPERIOR
            // =====================================================
            pnlSuperior.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;
            pnlSuperior.BackColor = Color.White;
            pnlSuperior.Controls.Add(btnRecargar);
            pnlSuperior.Controls.Add(lblActualizacion);
            pnlSuperior.Controls.Add(lblEstadoConexion);
            pnlSuperior.Controls.Add(lblSubtitulo);
            pnlSuperior.Controls.Add(lblTitulo);
            pnlSuperior.Location = new Point(0, 0);
            pnlSuperior.Name = "pnlSuperior";
            pnlSuperior.Size = new Size(1160, 80);
            pnlSuperior.TabIndex = 0;

            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font(
                "Segoe UI",
                20F,
                FontStyle.Bold
            );
            lblTitulo.ForeColor =
                Color.FromArgb(24, 101, 52);
            lblTitulo.Location = new Point(24, 8);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(327, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text =
                "Monitoreo de mediciones";

            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font =
                new Font("Segoe UI", 9F);
            lblSubtitulo.ForeColor =
                Color.FromArgb(95, 95, 95);
            lblSubtitulo.Location = new Point(27, 47);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(333, 15);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text =
                "Temperatura, humedad ambiental y humedad del suelo.";

            lblEstadoConexion.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;
            lblEstadoConexion.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold
                );
            lblEstadoConexion.ForeColor =
                Color.Gray;
            lblEstadoConexion.Location =
                new Point(740, 12);
            lblEstadoConexion.Name =
                "lblEstadoConexion";
            lblEstadoConexion.Size =
                new Size(145, 22);
            lblEstadoConexion.TabIndex = 2;
            lblEstadoConexion.Text =
                "Comprobando...";
            lblEstadoConexion.TextAlign =
                ContentAlignment.MiddleRight;

            lblActualizacion.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;
            lblActualizacion.Font =
                new Font("Segoe UI", 8.5F);
            lblActualizacion.ForeColor =
                Color.Gray;
            lblActualizacion.Location =
                new Point(670, 39);
            lblActualizacion.Name =
                "lblActualizacion";
            lblActualizacion.Size =
                new Size(215, 22);
            lblActualizacion.TabIndex = 3;
            lblActualizacion.Text =
                "Actualizado: --";
            lblActualizacion.TextAlign =
                ContentAlignment.MiddleRight;

            btnRecargar.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;
            btnRecargar.BackColor =
                Color.FromArgb(34, 139, 60);
            btnRecargar.Cursor =
                Cursors.Hand;
            btnRecargar.FlatAppearance
                .BorderSize = 0;
            btnRecargar.FlatStyle =
                FlatStyle.Flat;
            btnRecargar.Font = new Font(
                "Segoe UI",
                9F,
                FontStyle.Bold
            );
            btnRecargar.ForeColor =
                Color.White;
            btnRecargar.Location =
                new Point(910, 20);
            btnRecargar.Name = "btnRecargar";
            btnRecargar.Size =
                new Size(120, 38);
            btnRecargar.TabIndex = 4;
            btnRecargar.Text =
                "Recargar";
            btnRecargar.UseVisualStyleBackColor =
                false;
            btnRecargar.Click +=
                btnRecargar_Click;

            // =====================================================
            // TARJETAS
            // =====================================================
            pnlTarjetas.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;
            pnlTarjetas.BackColor =
                Color.FromArgb(242, 245, 243);
            pnlTarjetas.ColumnCount = 3;
            pnlTarjetas.ColumnStyles.Add(
                new ColumnStyle(
                    SizeType.Percent,
                    33.33333F
                )
            );
            pnlTarjetas.ColumnStyles.Add(
                new ColumnStyle(
                    SizeType.Percent,
                    33.33333F
                )
            );
            pnlTarjetas.ColumnStyles.Add(
                new ColumnStyle(
                    SizeType.Percent,
                    33.33333F
                )
            );
            pnlTarjetas.Controls.Add(
                pnlTemperatura,
                0,
                0
            );
            pnlTarjetas.Controls.Add(
                pnlHumedadAire,
                1,
                0
            );
            pnlTarjetas.Controls.Add(
                pnlHumedadSuelo,
                2,
                0
            );
            pnlTarjetas.Location =
                new Point(0, 80);
            pnlTarjetas.Name = "pnlTarjetas";
            pnlTarjetas.Padding =
                new Padding(20, 10, 20, 10);
            pnlTarjetas.RowCount = 1;
            pnlTarjetas.RowStyles.Add(
                new RowStyle(
                    SizeType.Percent,
                    100F
                )
            );
            pnlTarjetas.Size =
                new Size(1160, 125);
            pnlTarjetas.TabIndex = 1;

            ConfigurarTarjeta(
                pnlTemperatura,
                lblTemperaturaTitulo,
                lblTemperaturaValor,
                lblTemperaturaDetalle,
                "Temperatura ambiente",
                "-- °C",
                "Medida por DHT11",
                Color.FromArgb(30, 120, 220)
            );

            ConfigurarTarjeta(
                pnlHumedadAire,
                lblHumedadAireTitulo,
                lblHumedadAireValor,
                lblHumedadAireDetalle,
                "Humedad ambiente",
                "-- %",
                "Medida por DHT11",
                Color.FromArgb(35, 150, 70)
            );

            ConfigurarTarjeta(
                pnlHumedadSuelo,
                lblHumedadSueloTitulo,
                lblHumedadSueloValor,
                lblHumedadSueloDetalle,
                "Humedad del suelo",
                "-- %",
                "Medida por YL-69",
                Color.FromArgb(240, 145, 25)
            );

            pnlTemperatura.Margin =
                new Padding(0, 0, 8, 0);
            pnlHumedadAire.Margin =
                new Padding(4, 0, 4, 0);
            pnlHumedadSuelo.Margin =
                new Padding(8, 0, 0, 0);

            // =====================================================
            // GRÁFICA
            // =====================================================
            pnlGrafica.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;
            pnlGrafica.BackColor =
                Color.FromArgb(242, 245, 243);
            pnlGrafica.Controls.Add(
                graficaMediciones
            );
            pnlGrafica.Location =
                new Point(0, 205);
            pnlGrafica.Name =
                "pnlGrafica";
            pnlGrafica.Padding =
                new Padding(20, 5, 20, 10);
            pnlGrafica.Size =
                new Size(1160, 240);
            pnlGrafica.TabIndex = 2;

            graficaMediciones.BackColor =
                Color.White;
            graficaMediciones.BorderStyle =
                BorderStyle.FixedSingle;
            graficaMediciones.Dock =
                DockStyle.Fill;
            graficaMediciones.Location =
                new Point(20, 5);
            graficaMediciones.Name =
                "graficaMediciones";
            graficaMediciones.Size =
                new Size(1120, 225);
            graficaMediciones.TabIndex = 0;

            // =====================================================
            // HISTORIAL
            // =====================================================
            pnlHistorial.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;
            pnlHistorial.BackColor =
                Color.FromArgb(242, 245, 243);
            pnlHistorial.Controls.Add(
                dgvMediciones
            );
            pnlHistorial.Controls.Add(
                lblUltimaMedicion
            );
            pnlHistorial.Controls.Add(
                lblCantidad
            );
            pnlHistorial.Controls.Add(
                lblHistorial
            );
            pnlHistorial.Location =
                new Point(0, 445);
            pnlHistorial.Name =
                "pnlHistorial";
            pnlHistorial.Padding =
                new Padding(20, 5, 20, 20);
            pnlHistorial.Size =
                new Size(1160, 470);
            pnlHistorial.TabIndex = 3;

            lblHistorial.AutoSize = true;
            lblHistorial.Font = new Font(
                "Segoe UI",
                13F,
                FontStyle.Bold
            );
            lblHistorial.ForeColor =
                Color.FromArgb(45, 55, 50);
            lblHistorial.Location =
                new Point(20, 8);
            lblHistorial.Name =
                "lblHistorial";
            lblHistorial.Size =
                new Size(209, 25);
            lblHistorial.TabIndex = 0;
            lblHistorial.Text =
                "Historial de mediciones";

            lblCantidad.AutoSize = true;
            lblCantidad.Font =
                new Font("Segoe UI", 8.5F);
            lblCantidad.ForeColor =
                Color.Gray;
            lblCantidad.Location =
                new Point(22, 38);
            lblCantidad.Name =
                "lblCantidad";
            lblCantidad.Size =
                new Size(127, 15);
            lblCantidad.TabIndex = 1;
            lblCantidad.Text =
                "Registros mostrados: 0";

            lblUltimaMedicion.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;
            lblUltimaMedicion.Font =
                new Font("Segoe UI", 8.5F);
            lblUltimaMedicion.ForeColor =
                Color.FromArgb(80, 90, 85);
            lblUltimaMedicion.Location =
                new Point(705, 34);
            lblUltimaMedicion.Name =
                "lblUltimaMedicion";
            lblUltimaMedicion.Size =
                new Size(430, 22);
            lblUltimaMedicion.TabIndex = 2;
            lblUltimaMedicion.Text =
                "Última medición: --";
            lblUltimaMedicion.TextAlign =
                ContentAlignment.MiddleRight;

            // =====================================================
            // TABLA
            // =====================================================
            dgvMediciones.AllowUserToAddRows =
                false;
            dgvMediciones.AllowUserToDeleteRows =
                false;
            dgvMediciones.AllowUserToResizeRows =
                false;
            dgvMediciones.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;
            dgvMediciones.AutoGenerateColumns =
                false;
            dgvMediciones.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvMediciones.BackgroundColor =
                Color.White;
            dgvMediciones.BorderStyle =
                BorderStyle.None;
            dgvMediciones.ColumnHeadersHeight =
                38;
            dgvMediciones.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode
                    .DisableResizing;
            dgvMediciones.Columns.AddRange(
                new DataGridViewColumn[]
                {
                    colIdDato,
                    colTemperatura,
                    colHumedadAire,
                    colHumedadSuelo,
                    colFechaHora
                }
            );
            dgvMediciones.Location =
                new Point(20, 64);
            dgvMediciones.MultiSelect =
                false;
            dgvMediciones.Name =
                "dgvMediciones";
            dgvMediciones.ReadOnly =
                true;
            dgvMediciones.RowHeadersVisible =
                false;
            dgvMediciones.RowTemplate.Height =
                28;
            dgvMediciones.SelectionMode =
                DataGridViewSelectionMode
                    .FullRowSelect;
            dgvMediciones.Size =
                new Size(1120, 380);
            dgvMediciones.TabIndex = 3;

            // =====================================================
            // COLUMNAS
            // =====================================================
            colIdDato.DataPropertyName =
                "IdDato";
            colIdDato.FillWeight = 35F;
            colIdDato.HeaderText = "ID";
            colIdDato.Name = "colIdDato";
            colIdDato.ReadOnly = true;

            colTemperatura.DataPropertyName =
                "Temperatura";
            colTemperatura.DefaultCellStyle.Format =
                "0.0";
            colTemperatura.HeaderText =
                "Temperatura (°C)";
            colTemperatura.Name =
                "colTemperatura";
            colTemperatura.ReadOnly = true;

            colHumedadAire.DataPropertyName =
                "HumedadAire";
            colHumedadAire.DefaultCellStyle.Format =
                "0.0";
            colHumedadAire.HeaderText =
                "Humedad ambiente (%)";
            colHumedadAire.Name =
                "colHumedadAire";
            colHumedadAire.ReadOnly = true;

            colHumedadSuelo.DataPropertyName =
                "HumedadSuelo";
            colHumedadSuelo.DefaultCellStyle.Format =
                "0.0";
            colHumedadSuelo.HeaderText =
                "Humedad suelo (%)";
            colHumedadSuelo.Name =
                "colHumedadSuelo";
            colHumedadSuelo.ReadOnly = true;

            colFechaHora.DataPropertyName =
                "FechaHora";
            colFechaHora.DefaultCellStyle.Format =
                "dd/MM/yyyy HH:mm:ss";
            colFechaHora.FillWeight = 110F;
            colFechaHora.HeaderText =
                "Fecha y hora";
            colFechaHora.Name =
                "colFechaHora";
            colFechaHora.ReadOnly = true;

            // =====================================================
            // TIMER
            // =====================================================
            timerDatos.Interval = 3000;
            timerDatos.Tick +=
                timerDatos_Tick;

            // =====================================================
            // FORMULARIO
            // =====================================================
            AutoScaleDimensions =
                new SizeF(7F, 15F);
            AutoScaleMode =
                AutoScaleMode.Font;
            BackColor =
                Color.White;
            ClientSize =
                new Size(1180, 680);
            Controls.Add(pnlScroll);
            Font =
                new Font("Segoe UI", 9F);
            MinimumSize =
                new Size(0, 0);
            Name =
                "frmMediciones";
            Text =
                "Monitoreo de mediciones";
            FormClosed +=
                frmMediciones_FormClosed;
            Load +=
                frmMediciones_Load;

            pnlScroll.ResumeLayout(false);
            pnlContenidoVertical.ResumeLayout(false);
            pnlSuperior.ResumeLayout(false);
            pnlSuperior.PerformLayout();
            pnlTarjetas.ResumeLayout(false);
            pnlGrafica.ResumeLayout(false);
            pnlHistorial.ResumeLayout(false);
            pnlHistorial.PerformLayout();

            ((ISupportInitialize)dgvMediciones)
                .EndInit();

            ResumeLayout(false);
        }

        private static Panel CrearTarjeta(
            out Label titulo,
            out Label valor,
            out Label detalle)
        {
            Panel panel = new Panel();

            titulo = new Label();
            valor = new Label();
            detalle = new Label();

            panel.Controls.Add(detalle);
            panel.Controls.Add(valor);
            panel.Controls.Add(titulo);

            return panel;
        }

        private static void ConfigurarTarjeta(
            Panel panel,
            Label titulo,
            Label valor,
            Label detalle,
            string textoTitulo,
            string textoValor,
            string textoDetalle,
            Color colorValor)
        {
            panel.BackColor =
                Color.White;
            panel.BorderStyle =
                BorderStyle.FixedSingle;
            panel.Dock =
                DockStyle.Fill;

            titulo.AutoSize =
                true;
            titulo.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold
            );
            titulo.ForeColor =
                Color.FromArgb(65, 75, 70);
            titulo.Location =
                new Point(18, 10);
            titulo.Text =
                textoTitulo;

            valor.AutoSize =
                true;
            valor.Font = new Font(
                "Segoe UI",
                21F,
                FontStyle.Bold
            );
            valor.ForeColor =
                colorValor;
            valor.Location =
                new Point(16, 31);
            valor.Text =
                textoValor;

            detalle.AutoSize =
                true;
            detalle.Font =
                new Font("Segoe UI", 8.5F);
            detalle.ForeColor =
                Color.Gray;
            detalle.Location =
                new Point(19, 74);
            detalle.Text =
                textoDetalle;
        }

        private Panel pnlScroll;
        private Panel pnlContenidoVertical;

        private Panel pnlSuperior;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblEstadoConexion;
        private Label lblActualizacion;
        private Button btnRecargar;

        private TableLayoutPanel pnlTarjetas;

        private Panel pnlTemperatura;
        private Label lblTemperaturaTitulo;
        private Label lblTemperaturaValor;
        private Label lblTemperaturaDetalle;

        private Panel pnlHumedadAire;
        private Label lblHumedadAireTitulo;
        private Label lblHumedadAireValor;
        private Label lblHumedadAireDetalle;

        private Panel pnlHumedadSuelo;
        private Label lblHumedadSueloTitulo;
        private Label lblHumedadSueloValor;
        private Label lblHumedadSueloDetalle;

        private Panel pnlGrafica;
        private GraficaMedicionesPanel graficaMediciones;

        private Panel pnlHistorial;
        private Label lblHistorial;
        private Label lblCantidad;
        private Label lblUltimaMedicion;
        private DataGridView dgvMediciones;

        private DataGridViewTextBoxColumn colIdDato;
        private DataGridViewTextBoxColumn colTemperatura;
        private DataGridViewTextBoxColumn colHumedadAire;
        private DataGridViewTextBoxColumn colHumedadSuelo;
        private DataGridViewTextBoxColumn colFechaHora;

        private System.Windows.Forms.Timer timerDatos;
    }
}
