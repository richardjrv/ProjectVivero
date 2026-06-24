using System.Drawing;
using System.Windows.Forms;

namespace ProjectVivero
{
    partial class frmRegistro
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
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblCorreo = new Label();
            txtCorreo = new TextBox();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmar = new Label();
            txtConfirmar = new TextBox();
            btnRegistrar = new Button();
            btnVolver = new Button();
            SuspendLayout();

            // pnlSuperior
            pnlSuperior.BackColor = Color.FromArgb(34, 139, 60);
            pnlSuperior.Dock = DockStyle.Top;
            pnlSuperior.Location = new Point(0, 0);
            pnlSuperior.Name = "pnlSuperior";
            pnlSuperior.Size = new Size(460, 7);
            pnlSuperior.TabIndex = 0;

            // lblTitulo
            lblTitulo.Font = new Font(
                "Segoe UI",
                16F,
                FontStyle.Bold
            );
            lblTitulo.ForeColor = Color.FromArgb(26, 112, 48);
            lblTitulo.Location = new Point(40, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(380, 38);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Crear cuenta";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // lblSubtitulo
            lblSubtitulo.Font = new Font("Segoe UI", 9F);
            lblSubtitulo.ForeColor = Color.Gray;
            lblSubtitulo.Location = new Point(35, 57);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(390, 24);
            lblSubtitulo.TabIndex = 2;
            lblSubtitulo.Text =
                "Registro de usuario - Vivero automatizado";
            lblSubtitulo.TextAlign =
                ContentAlignment.MiddleCenter;

            // lblNombre
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font(
                "Segoe UI",
                8F,
                FontStyle.Bold
            );
            lblNombre.ForeColor =
                Color.FromArgb(90, 100, 110);
            lblNombre.Location = new Point(55, 91);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(116, 13);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "NOMBRE COMPLETO";

            // txtNombre
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 11F);
            txtNombre.Location = new Point(55, 112);
            txtNombre.MaxLength = 100;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(350, 27);
            txtNombre.TabIndex = 0;

            // lblCorreo
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new Font(
                "Segoe UI",
                8F,
                FontStyle.Bold
            );
            lblCorreo.ForeColor =
                Color.FromArgb(90, 100, 110);
            lblCorreo.Location = new Point(55, 151);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(132, 13);
            lblCorreo.TabIndex = 5;
            lblCorreo.Text = "CORREO ELECTRÓNICO";

            // txtCorreo
            txtCorreo.BorderStyle = BorderStyle.FixedSingle;
            txtCorreo.Font = new Font("Segoe UI", 11F);
            txtCorreo.Location = new Point(55, 172);
            txtCorreo.MaxLength = 150;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(350, 27);
            txtCorreo.TabIndex = 1;

            // lblUsuario
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font(
                "Segoe UI",
                8F,
                FontStyle.Bold
            );
            lblUsuario.ForeColor =
                Color.FromArgb(90, 100, 110);
            lblUsuario.Location = new Point(55, 211);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(54, 13);
            lblUsuario.TabIndex = 7;
            lblUsuario.Text = "USUARIO";

            // txtUsuario
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Segoe UI", 11F);
            txtUsuario.Location = new Point(55, 232);
            txtUsuario.MaxLength = 50;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(350, 27);
            txtUsuario.TabIndex = 2;

            // lblPassword
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font(
                "Segoe UI",
                8F,
                FontStyle.Bold
            );
            lblPassword.ForeColor =
                Color.FromArgb(90, 100, 110);
            lblPassword.Location = new Point(55, 271);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(78, 13);
            lblPassword.TabIndex = 9;
            lblPassword.Text = "CONTRASEÑA";

            // txtPassword
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(55, 292);
            txtPassword.MaxLength = 100;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(350, 27);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;

            // lblConfirmar
            lblConfirmar.AutoSize = true;
            lblConfirmar.Font = new Font(
                "Segoe UI",
                8F,
                FontStyle.Bold
            );
            lblConfirmar.ForeColor =
                Color.FromArgb(90, 100, 110);
            lblConfirmar.Location = new Point(55, 331);
            lblConfirmar.Name = "lblConfirmar";
            lblConfirmar.Size = new Size(148, 13);
            lblConfirmar.TabIndex = 11;
            lblConfirmar.Text = "CONFIRMAR CONTRASEÑA";

            // txtConfirmar
            txtConfirmar.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmar.Font = new Font("Segoe UI", 11F);
            txtConfirmar.Location = new Point(55, 352);
            txtConfirmar.MaxLength = 100;
            txtConfirmar.Name = "txtConfirmar";
            txtConfirmar.Size = new Size(350, 27);
            txtConfirmar.TabIndex = 4;
            txtConfirmar.UseSystemPasswordChar = true;

            // btnRegistrar
            btnRegistrar.BackColor = Color.FromArgb(34, 139, 60);
            btnRegistrar.Cursor = Cursors.Hand;
            btnRegistrar.FlatAppearance.BorderSize = 0;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold
            );
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(55, 407);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(165, 40);
            btnRegistrar.TabIndex = 5;
            btnRegistrar.Text = "Registrarse";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;

            // btnVolver
            btnVolver.BackColor =
                Color.FromArgb(125, 136, 147);
            btnVolver.Cursor = Cursors.Hand;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold
            );
            btnVolver.ForeColor = Color.White;
            btnVolver.Location = new Point(240, 407);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(165, 40);
            btnVolver.TabIndex = 6;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;

            // frmRegistro
            AcceptButton = btnRegistrar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnVolver;
            ClientSize = new Size(460, 480);
            Controls.Add(btnVolver);
            Controls.Add(btnRegistrar);
            Controls.Add(txtConfirmar);
            Controls.Add(lblConfirmar);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(txtCorreo);
            Controls.Add(lblCorreo);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblTitulo);
            Controls.Add(pnlSuperior);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmRegistro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de usuario";
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel pnlSuperior;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblCorreo;
        private TextBox txtCorreo;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirmar;
        private TextBox txtConfirmar;
        private Button btnRegistrar;
        private Button btnVolver;
    }
}
