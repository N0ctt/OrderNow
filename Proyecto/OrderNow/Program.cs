using OrderNow.Interfaces;
using OrderNow.Datos;

namespace OrderNow
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            
            var conexion = new ConexionBD();

            if (!conexion.ProbarConexion())
            {
                MessageBox.Show("No se pudo conectar a la base de datos. La aplicación se cerrará.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new InterfazPrincipal());
        }
    }
}