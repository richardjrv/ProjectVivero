using BusinessLogic;
using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace ProjectVivero
{
    public partial class frmMediciones : Form
    {
        private bool actualizando;

        public frmMediciones()
        {
            InitializeComponent();
        }

        private void frmMediciones_Load(object sender, EventArgs e)
        {
            if (!EsAdministrador())
            {
                MessageBox.Show(
                    "El módulo Mediciones está disponible únicamente para administradores.",
                    "Acceso restringido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                Close();
                return;
            }

            timerDatos.Interval = 3000;
            CargarMediciones();
            timerDatos.Start();
        }

        private bool EsAdministrador()
        {
            return string.Equals(
                LoginSistema.Rol,
                "Administrador",
                StringComparison.OrdinalIgnoreCase);
        }

        private void timerDatos_Tick(object sender, EventArgs e)
        {
            CargarMediciones();
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarMediciones();
        }

        private void CargarMediciones()
        {
            if (actualizando)
            {
                return;
            }

            actualizando = true;
            timerDatos.Stop();

            try
            {
                DatoSensor ultima = DatoSensorLogic.ObtenerUltima();
                List<DatoSensor> historial = DatoSensorLogic.ListarUltimos(100);

                MostrarUltimaMedicion(ultima);

                dgvMediciones.DataSource = null;
                dgvMediciones.DataSource = historial;
                lblCantidad.Text = $"Registros mostrados: {historial.Count}";

                List<DatoSensor> datosGrafica = historial
                    .OrderBy(d => d.FechaHora)
                    .TakeLast(30)
                    .ToList();

                graficaMediciones.EstablecerDatos(datosGrafica);

                lblActualizacion.Text =
                    "Actualizado: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            }
            catch (Exception ex)
            {
                lblEstadoConexion.Text = "Error de conexión";
                lblEstadoConexion.ForeColor = Color.FromArgb(190, 45, 45);

                MessageBox.Show(
                    "No se pudieron cargar las mediciones.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                actualizando = false;
                if (!IsDisposed)
                {
                    timerDatos.Start();
                }
            }
        }

        private void MostrarUltimaMedicion(DatoSensor dato)
        {
            if (dato == null)
            {
                lblTemperaturaValor.Text = "-- °C";
                lblHumedadAireValor.Text = "-- %";
                lblHumedadSueloValor.Text = "-- %";
                lblUltimaMedicion.Text = "Última medición: sin registros";
                lblEstadoConexion.Text = "Sin datos";
                lblEstadoConexion.ForeColor = Color.Gray;
                return;
            }

            lblTemperaturaValor.Text = $"{dato.Temperatura:0.0} °C";
            lblHumedadAireValor.Text = $"{dato.HumedadAire:0.0} %";
            lblHumedadSueloValor.Text = $"{dato.HumedadSuelo:0.0} %";
            lblUltimaMedicion.Text =
                "Última medición: " + dato.FechaHora.ToString("dd/MM/yyyy HH:mm:ss");

            TimeSpan antiguedad = DateTime.Now - dato.FechaHora;

            if (antiguedad.TotalSeconds <= 15)
            {
                lblEstadoConexion.Text = "En línea";
                lblEstadoConexion.ForeColor = Color.FromArgb(28, 135, 65);
            }
            else
            {
                lblEstadoConexion.Text = "Sin datos recientes";
                lblEstadoConexion.ForeColor = Color.FromArgb(205, 125, 25);
            }
        }

        private void frmMediciones_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerDatos.Stop();
        }
    }

    internal class GraficaMedicionesPanel : Panel
    {
        private List<DatoSensor> datos = new List<DatoSensor>();

        public GraficaMedicionesPanel()
        {
            DoubleBuffered = true;
            BackColor = Color.White;
            ResizeRedraw = true;
        }

        public void EstablecerDatos(List<DatoSensor> nuevosDatos)
        {
            datos = nuevosDatos ?? new List<DatoSensor>();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Color.White);

            Rectangle area = new Rectangle(
                58,
                44,
                Math.Max(50, Width - 116),
                Math.Max(50, Height - 96));

            DibujarTituloYLeyenda(e.Graphics);
            DibujarCuadriculaYEjes(e.Graphics, area);

            if (datos.Count == 0)
            {
                using Font fuente = new Font("Segoe UI", 11F);
                using Brush brocha = new SolidBrush(Color.Gray);
                const string mensaje = "No existen mediciones para graficar.";
                SizeF medida = e.Graphics.MeasureString(mensaje, fuente);
                e.Graphics.DrawString(
                    mensaje,
                    fuente,
                    brocha,
                    area.Left + (area.Width - medida.Width) / 2,
                    area.Top + (area.Height - medida.Height) / 2);
                return;
            }

            DibujarSeries(e.Graphics, area);
            DibujarEtiquetasTiempo(e.Graphics, area);
        }

        private void DibujarTituloYLeyenda(Graphics g)
        {
            using Font titulo = new Font("Segoe UI", 12F, FontStyle.Bold);
            using Brush tituloBrocha = new SolidBrush(Color.FromArgb(24, 101, 52));
            g.DrawString("Histórico de variables ambientales", titulo, tituloBrocha, 14, 10);

            int x = Math.Max(330, Width - 520);
            DibujarLeyenda(g, x, 19, Color.FromArgb(30, 120, 220), "Temperatura");
            DibujarLeyenda(g, x + 145, 19, Color.FromArgb(35, 150, 70), "Humedad aire");
            DibujarLeyenda(g, x + 305, 19, Color.FromArgb(240, 145, 25), "Humedad suelo");
        }

        private static void DibujarLeyenda(Graphics g, int x, int y, Color color, string texto)
        {
            using Pen lapiz = new Pen(color, 3F);
            using Brush punto = new SolidBrush(color);
            using Font fuente = new Font("Segoe UI", 8.5F);
            using Brush textoBrocha = new SolidBrush(Color.FromArgb(55, 55, 55));

            g.DrawLine(lapiz, x, y + 6, x + 24, y + 6);
            g.FillEllipse(punto, x + 9, y + 2, 8, 8);
            g.DrawString(texto, fuente, textoBrocha, x + 30, y - 2);
        }

        private static void DibujarCuadriculaYEjes(Graphics g, Rectangle area)
        {
            using Pen cuadricula = new Pen(Color.FromArgb(225, 230, 228), 1F)
            {
                DashStyle = DashStyle.Dash
            };

            for (int i = 0; i <= 5; i++)
            {
                float y = area.Bottom - area.Height * i / 5F;
                g.DrawLine(cuadricula, area.Left, y, area.Right, y);
            }

            for (int i = 0; i <= 6; i++)
            {
                float x = area.Left + area.Width * i / 6F;
                g.DrawLine(cuadricula, x, area.Top, x, area.Bottom);
            }

            using Pen eje = new Pen(Color.FromArgb(115, 120, 118), 1.2F);
            g.DrawLine(eje, area.Left, area.Top, area.Left, area.Bottom);
            g.DrawLine(eje, area.Right, area.Top, area.Right, area.Bottom);
            g.DrawLine(eje, area.Left, area.Bottom, area.Right, area.Bottom);

            using Font fuente = new Font("Segoe UI", 8F);
            using Brush brocha = new SolidBrush(Color.FromArgb(80, 80, 80));

            for (int i = 0; i <= 5; i++)
            {
                int humedad = i * 20;
                int temperatura = i * 10;
                float y = area.Bottom - area.Height * i / 5F;
                string izquierda = humedad.ToString();
                SizeF medida = g.MeasureString(izquierda, fuente);

                g.DrawString(izquierda, fuente, brocha, area.Left - medida.Width - 7, y - medida.Height / 2);
                g.DrawString(temperatura.ToString(), fuente, brocha, area.Right + 7, y - medida.Height / 2);
            }

            g.DrawString("Humedad (%)", fuente, brocha, 5, area.Top - 18);
            g.DrawString("Temperatura (°C)", fuente, brocha, area.Right - 40, area.Top - 18);
        }

        private void DibujarSeries(Graphics g, Rectangle area)
        {
            PointF[] temperatura = CrearPuntos(area, d => d.Temperatura, 50);
            PointF[] humedadAire = CrearPuntos(area, d => d.HumedadAire, 100);
            PointF[] humedadSuelo = CrearPuntos(area, d => d.HumedadSuelo, 100);

            DibujarSerie(g, temperatura, Color.FromArgb(30, 120, 220));
            DibujarSerie(g, humedadAire, Color.FromArgb(35, 150, 70));
            DibujarSerie(g, humedadSuelo, Color.FromArgb(240, 145, 25));
        }

        private PointF[] CrearPuntos(Rectangle area, Func<DatoSensor, double> selector, double maximo)
        {
            PointF[] puntos = new PointF[datos.Count];

            for (int i = 0; i < datos.Count; i++)
            {
                float x = datos.Count == 1
                    ? area.Left + area.Width / 2F
                    : area.Left + area.Width * i / (float)(datos.Count - 1);

                double valor = Math.Max(0, Math.Min(maximo, selector(datos[i])));
                float y = area.Bottom - (float)(area.Height * (valor / maximo));
                puntos[i] = new PointF(x, y);
            }

            return puntos;
        }

        private static void DibujarSerie(Graphics g, PointF[] puntos, Color color)
        {
            using Pen lapiz = new Pen(color, 2.5F);
            using Brush brocha = new SolidBrush(color);

            if (puntos.Length > 1)
            {
                g.DrawLines(lapiz, puntos);
            }

            foreach (PointF punto in puntos)
            {
                g.FillEllipse(brocha, punto.X - 4, punto.Y - 4, 8, 8);
            }
        }

        private void DibujarEtiquetasTiempo(Graphics g, Rectangle area)
        {
            using Font fuente = new Font("Segoe UI", 8F);
            using Brush brocha = new SolidBrush(Color.FromArgb(75, 75, 75));
            int cantidad = Math.Min(6, datos.Count);

            for (int i = 0; i < cantidad; i++)
            {
                int indice = cantidad == 1
                    ? 0
                    : (int)Math.Round(i * (datos.Count - 1D) / (cantidad - 1D));

                float x = datos.Count == 1
                    ? area.Left + area.Width / 2F
                    : area.Left + area.Width * indice / (float)(datos.Count - 1);

                string texto = datos[indice].FechaHora.ToString("HH:mm:ss");
                SizeF medida = g.MeasureString(texto, fuente);
                g.DrawString(texto, fuente, brocha, x - medida.Width / 2, area.Bottom + 8);
            }
        }
    }
}
