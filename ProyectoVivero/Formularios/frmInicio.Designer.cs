using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectVivero
{
    partial class frmInicio
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

            pnlMenu = new Panel();
            lblSistema = new Label();
            btnInicio = new Button();
            btnViveros = new Button();
            btnSensores = new Button();
            btnMediciones = new Button();
            btnActuadores = new Button();
            btnUsuarios = new Button();
            btnSalir = new Button();

            pnlSuperior = new Panel();
            lblNombreUsuario = new Label();
            lblRolUsuario = new Label();
            lblFechaHora = new Label();

            pnlContenido = new Panel();
            lblTituloContenido = new Label();
            lblMensajeContenido = new Label();

            timerReloj = new System.Windows.Forms.Timer(components);

            pnlMenu.SuspendLayout();
            pnlSuperior.SuspendLayout();
            pnlContenido.SuspendLayout();
            SuspendLayout();

            // =====================================================
            // PANEL DEL MENÚ
            // =====================================================
            pnlMenu.BackColor = Color.FromArgb(27, 94, 52);
            pnlMenu.Controls.Add(btnSalir);
            pnlMenu.Controls.Add(btnUsuarios);
            pnlMenu.Controls.Add(btnActuadores);
            pnlMenu.Controls.Add(btnMediciones);
            pnlMenu.Controls.Add(btnSensores);
            pnlMenu.Controls.Add(btnViveros);
            pnlMenu.Controls.Add(btnInicio);
            pnlMenu.Controls.Add(lblSistema);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(220, 650);
            pnlMenu.TabIndex = 0;

            // =====================================================
            // NOMBRE DEL SISTEMA
            // =====================================================
            lblSistema.Dock = DockStyle.Top;
            lblSistema.Font = new Font(
                "Segoe UI",
                13F,
                FontStyle.Bold
            );
            lblSistema.ForeColor = Color.White;
            lblSistema.Location = new Point(0, 0);
            lblSistema.Name = "lblSistema";
            lblSistema.Size = new Size(220, 100);
            lblSistema.TabIndex = 0;
            lblSistema.Text =
                "VIVERO\nINTELIGENTE";
            lblSistema.TextAlign =
                ContentAlignment.MiddleCenter;

            // =====================================================
            // BOTÓN INICIO
            // =====================================================
            btnInicio.BackColor = Color.FromArgb(34, 139, 60);
            btnInicio.Cursor = Cursors.Hand;
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold
            );
            btnInicio.ForeColor = Color.White;
            btnInicio.Location = new Point(0, 110);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(220, 48);
            btnInicio.TabIndex = 1;
            btnInicio.Text = "Inicio";
            btnInicio.UseVisualStyleBackColor = false;
            btnInicio.Click += btnInicio_Click;

            // =====================================================
            // BOTÓN VIVEROS
            // =====================================================
            btnViveros.BackColor = Color.FromArgb(27, 94, 52);
            btnViveros.Cursor = Cursors.Hand;
            btnViveros.FlatAppearance.BorderSize = 0;
            btnViveros.FlatStyle = FlatStyle.Flat;
            btnViveros.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold
            );
            btnViveros.ForeColor = Color.White;
            btnViveros.Location = new Point(0, 158);
            btnViveros.Name = "btnViveros";
            btnViveros.Size = new Size(220, 48);
            btnViveros.TabIndex = 2;
            btnViveros.Text = "Viveros";
            btnViveros.UseVisualStyleBackColor = false;
            btnViveros.Click += btnViveros_Click;
            // =====================================================
            // BOTÓN SENSORES
            // =====================================================
            btnSensores.BackColor = Color.FromArgb(27, 94, 52);
            btnSensores.Cursor = Cursors.Hand;
            btnSensores.FlatAppearance.BorderSize = 0;
            btnSensores.FlatStyle = FlatStyle.Flat;
            btnSensores.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold
            );
            btnSensores.ForeColor = Color.White;
            btnSensores.Location = new Point(0, 206);
            btnSensores.Name = "btnSensores";
            btnSensores.Size = new Size(220, 48);
            btnSensores.TabIndex = 3;
            btnSensores.Text = "Sensores";
            btnSensores.UseVisualStyleBackColor = false;
            btnSensores.Click += btnSensores_Click;

            // =====================================================
            // BOTÓN MEDICIONES
            // =====================================================
            btnMediciones.BackColor = Color.FromArgb(27, 94, 52);
            btnMediciones.Cursor = Cursors.Hand;
            btnMediciones.FlatAppearance.BorderSize = 0;
            btnMediciones.FlatStyle = FlatStyle.Flat;
            btnMediciones.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold
            );
            btnMediciones.ForeColor = Color.White;
            btnMediciones.Location = new Point(0, 254);
            btnMediciones.Name = "btnMediciones";
            btnMediciones.Size = new Size(220, 48);
            btnMediciones.TabIndex = 4;
            btnMediciones.Text = "Mediciones";
            btnMediciones.UseVisualStyleBackColor = false;
            btnMediciones.Click += btnMediciones_Click;

            // =====================================================
            // BOTÓN ACTUADORES
            // =====================================================
            btnActuadores.BackColor = Color.FromArgb(27, 94, 52);
            btnActuadores.Cursor = Cursors.Hand;
            btnActuadores.FlatAppearance.BorderSize = 0;
            btnActuadores.FlatStyle = FlatStyle.Flat;
            btnActuadores.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold
            );
            btnActuadores.ForeColor = Color.White;
            btnActuadores.Location = new Point(0, 302);
            btnActuadores.Name = "btnActuadores";
            btnActuadores.Size = new Size(220, 48);
            btnActuadores.TabIndex = 5;
            btnActuadores.Text = "Actuadores";
            btnActuadores.UseVisualStyleBackColor = false;
            btnActuadores.Click += btnActuadores_Click;

            // =====================================================
            // BOTÓN USUARIOS
            // =====================================================
            btnUsuarios.BackColor = Color.FromArgb(27, 94, 52);
            btnUsuarios.Cursor = Cursors.Hand;
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold
            );
            btnUsuarios.ForeColor = Color.White;
            btnUsuarios.Location = new Point(0, 350);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(220, 48);
            btnUsuarios.TabIndex = 6;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.UseVisualStyleBackColor = false;
            btnUsuarios.Click += btnUsuarios_Click;

            // =====================================================
            // BOTÓN SALIR
            // =====================================================
            btnSalir.BackColor = Color.FromArgb(180, 55, 55);
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.Dock = DockStyle.Bottom;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold
            );
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(0, 600);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(220, 50);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;

            // =====================================================
            // PANEL SUPERIOR
            // =====================================================
            pnlSuperior.BackColor = Color.White;
            pnlSuperior.Controls.Add(lblFechaHora);
            pnlSuperior.Controls.Add(lblRolUsuario);
            pnlSuperior.Controls.Add(lblNombreUsuario);
            pnlSuperior.Dock = DockStyle.Top;
            pnlSuperior.Location = new Point(220, 0);
            pnlSuperior.Name = "pnlSuperior";
            pnlSuperior.Size = new Size(880, 85);
            pnlSuperior.TabIndex = 1;

            // =====================================================
            // NOMBRE DEL USUARIO
            // =====================================================
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font(
                "Segoe UI",
                12F,
                FontStyle.Bold
            );
            lblNombreUsuario.ForeColor =
                Color.FromArgb(27, 94, 52);
            lblNombreUsuario.Location = new Point(25, 18);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(67, 21);
            lblNombreUsuario.TabIndex = 0;
            lblNombreUsuario.Text = "Usuario";

            // =====================================================
            // ROL
            // =====================================================
            lblRolUsuario.AutoSize = true;
            lblRolUsuario.Font = new Font(
                "Segoe UI",
                9F
            );
            lblRolUsuario.ForeColor = Color.Gray;
            lblRolUsuario.Location = new Point(27, 45);
            lblRolUsuario.Name = "lblRolUsuario";
            lblRolUsuario.Size = new Size(26, 15);
            lblRolUsuario.TabIndex = 1;
            lblRolUsuario.Text = "Rol";

            // =====================================================
            // FECHA Y HORA
            // =====================================================
            lblFechaHora.Anchor =
                AnchorStyles.Top | AnchorStyles.Right;
            lblFechaHora.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold
            );
            lblFechaHora.ForeColor =
                Color.FromArgb(80, 90, 100);
            lblFechaHora.Location = new Point(615, 27);
            lblFechaHora.Name = "lblFechaHora";
            lblFechaHora.Size = new Size(235, 30);
            lblFechaHora.TabIndex = 2;
            lblFechaHora.Text = "Fecha y hora";
            lblFechaHora.TextAlign =
                ContentAlignment.MiddleRight;

            // =====================================================
            // PANEL DE CONTENIDO
            // =====================================================
            pnlContenido.BackColor =
                Color.FromArgb(242, 245, 243);
            pnlContenido.Controls.Add(lblMensajeContenido);
            pnlContenido.Controls.Add(lblTituloContenido);
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(220, 85);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Padding = new Padding(0);
            pnlContenido.Size = new Size(880, 565);
            pnlContenido.TabIndex = 2;

            // =====================================================
            // TÍTULO DEL CONTENIDO
            // =====================================================
            lblTituloContenido.Dock = DockStyle.Top;
            lblTituloContenido.Font = new Font(
                "Segoe UI",
                22F,
                FontStyle.Bold
            );
            lblTituloContenido.ForeColor =
                Color.FromArgb(27, 94, 52);
            lblTituloContenido.Location =
                new Point(35, 35);
            lblTituloContenido.Name =
                "lblTituloContenido";
            lblTituloContenido.Size =
                new Size(810, 60);
            lblTituloContenido.TabIndex = 0;
            lblTituloContenido.Text =
                "Panel principal";

            // =====================================================
            // MENSAJE DEL CONTENIDO
            // =====================================================
            lblMensajeContenido.Dock = DockStyle.Fill;
            lblMensajeContenido.Font = new Font(
                "Segoe UI",
                13F
            );
            lblMensajeContenido.ForeColor =
                Color.FromArgb(70, 80, 75);
            lblMensajeContenido.Location =
                new Point(35, 95);
            lblMensajeContenido.Name =
                "lblMensajeContenido";
            lblMensajeContenido.Padding =
                new Padding(0, 30, 0, 0);
            lblMensajeContenido.Size =
                new Size(810, 435);
            lblMensajeContenido.TabIndex = 1;
            lblMensajeContenido.Text =
                "Bienvenido al sistema.";

            // =====================================================
            // TEMPORIZADOR
            // =====================================================
            timerReloj.Enabled = true;
            timerReloj.Interval = 1000;
            timerReloj.Tick += timerReloj_Tick;

            // =====================================================
            // FRM INICIO
            // =====================================================
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1100, 650);
            Controls.Add(pnlContenido);
            Controls.Add(pnlSuperior);
            Controls.Add(pnlMenu);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimumSize = new Size(1100, 650);
            WindowState = FormWindowState.Maximized;
            Name = "frmInicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema Inteligente de Monitoreo Agrícola";
            Load += frmInicio_Load;

            pnlMenu.ResumeLayout(false);
            pnlSuperior.ResumeLayout(false);
            pnlSuperior.PerformLayout();
            pnlContenido.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel pnlMenu;
        private Label lblSistema;
        private Button btnInicio;
        private Button btnViveros;
        private Button btnSensores;
        private Button btnMediciones;
        private Button btnActuadores;
        private Button btnUsuarios;
        private Button btnSalir;

        private Panel pnlSuperior;
        private Label lblNombreUsuario;
        private Label lblRolUsuario;
        private Label lblFechaHora;

        private Panel pnlContenido;
        private Label lblTituloContenido;
        private Label lblMensajeContenido;

        private System.Windows.Forms.Timer timerReloj;
    }
}