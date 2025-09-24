using Microsoft.Data.SqlClient;

namespace OrderNow.Datos
{
    public class ConexionBD
    {
        private readonly string Servidor;
        private readonly string BaseDatos;

        public ConexionBD()
        {
            Servidor = "localhost\\SQLEXPRESS";
            BaseDatos = "OrderNow";
        }

        public SqlConnection CrearConexion()
        {
            return new SqlConnection(
                $"Server={Servidor}; Database={BaseDatos}; Trusted_Connection=True; TrustServerCertificate=True;");
        }

        public bool ProbarConexion()
        {
            using var conexion = CrearConexion();
            try
            {
                conexion.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
