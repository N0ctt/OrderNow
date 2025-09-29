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
                MessageBox.Show("No se pudo conectar a la base de datos. La aplicaci�n se cerrar�.", "Error de Conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new InterfazPrincipal());
        }
    }
}