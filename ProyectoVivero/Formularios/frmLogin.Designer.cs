using System.Drawing;
using System.Windows.Forms;

namespace ProjectVivero
{
    partial class frmLogin
    {
        private System.ComponentModel.IContainer components = null;

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
            lblSubtitulo = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnIngresar = new Button();
            btnCancelar = new Button();
            lnkRegistrar = new LinkLabel();
            SuspendLayout();

            // pnlSuperior
            pnlSuperior.BackColor = Color.FromArgb(34, 139, 60);
            pnlSuperior.Dock = DockStyle.Top;
            pnlSuperior.Location = new Point(0, 0);
            pnlSuperior.Name = "pnlSuperior";
            pnlSuperior.Size = new Size(430, 7);
            pnlSuperior.TabIndex = 0;

            // lblTitulo
            lblTitulo.Font = new Font(
                "Segoe UI",
                16F,
                FontStyle.Bold
            );
            lblTitulo.ForeColor = Color.FromArgb(26, 112, 48);
            lblTitulo.Location = new Point(40, 28);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(350, 38);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Iniciar sesión";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // lblSubtitulo
            lblSubtitulo.Font = new Font("Segoe UI", 9F);
            lblSubtitulo.ForeColor = Color.Gray;
            lblSubtitulo.Location = new Point(35, 65);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(360, 24);
            lblSubtitulo.TabIndex = 2;
            lblSubtitulo.Text =
                "Plataforma de Investigación Fitopatológica";
            lblSubtitulo.TextAlign =
                ContentAlignment.MiddleCenter;

            // lblUsuario
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font(
                "Segoe UI",
                8F,
                FontStyle.Bold
            );
            lblUsuario.ForeColor =
                Color.FromArgb(90, 100, 110);
            lblUsuario.Location = new Point(55, 108);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(54, 13);
            lblUsuario.TabIndex = 3;
            lblUsuario.Text = "USUARIO";

            // txtUsuario
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Segoe UI", 11F);
            txtUsuario.Location = new Point(55, 129);
            txtUsuario.MaxLength = 50;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(320, 27);
            txtUsuario.TabIndex = 0;

            // lblPassword
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font(
                "Segoe UI",
                8F,
                FontStyle.Bold
            );
            lblPassword.ForeColor =
                Color.FromArgb(90, 100, 110);
            lblPassword.Location = new Point(55, 177);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(78, 13);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "CONTRASEÑA";

            // txtPassword
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(55, 198);
            txtPassword.MaxLength = 100;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(320, 27);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;

            // btnIngresar
            btnIngresar.BackColor = Color.FromArgb(34, 139, 60);
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold
            );
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(55, 251);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(150, 40);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;

            // btnCancelar
            btnCancelar.BackColor =
                Color.FromArgb(125, 136, 147);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold
            );
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(225, 251);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(150, 40);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;

            // lnkRegistrar
            lnkRegistrar.Cursor = Cursors.Hand;
            lnkRegistrar.Font = new Font("Segoe UI", 9F);
            lnkRegistrar.LinkColor =
                Color.FromArgb(34, 139, 60);
            lnkRegistrar.Location = new Point(40, 313);
            lnkRegistrar.Name = "lnkRegistrar";
            lnkRegistrar.Size = new Size(350, 25);
            lnkRegistrar.TabIndex = 4;
            lnkRegistrar.TabStop = true;
            lnkRegistrar.Text =
                "¿No tienes cuenta? Regístrate aquí";
            lnkRegistrar.TextAlign =
                ContentAlignment.MiddleCenter;
            lnkRegistrar.LinkClicked +=
                lnkRegistrar_LinkClicked;

            // frmLogin
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnCancelar;
            ClientSize = new Size(430, 365);
            Controls.Add(lnkRegistrar);
            Controls.Add(btnCancelar);
            Controls.Add(btnIngresar);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblTitulo);
            Controls.Add(pnlSuperior);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Plataforma de Investigación - Login";
            Load += frmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel pnlSuperior;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnIngresar;
        private Button btnCancelar;
        private LinkLabel lnkRegistrar;
    }
}
