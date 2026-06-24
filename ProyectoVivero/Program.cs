using ProyectoVivero;
using System;
using System.Windows.Forms;

namespace ProjectVivero
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // SIEMPRE inicia mostrando primero el formulario de Login.
            Application.Run(new frmLogin());
        }
    }
}
