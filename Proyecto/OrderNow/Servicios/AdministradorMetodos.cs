using OrderNow.Modelos;
using OrderNow.Datos;
using Microsoft.Data.SqlClient;


namespace OrderNow.Servicios
{
    public class AdministradorMetodos
    {
        private readonly ConexionBD conexion;

        public AdministradorMetodos()
        {
            conexion = new ConexionBD();
        }


        public bool AgregarProducto(Producto producto)
        {
            using var conn = conexion.CrearConexion();
            conn.Open();

            string query = "INSERT INTO Productos (Nombre, Descripcion, Precio) VALUES (@Nombre, @Descripcion, @Precio)";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
            cmd.Parameters.AddWithValue("@Precio", producto.Precio);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool EditarProducto(Producto producto)
        {
            using var conn = conexion.CrearConexion();
            conn.Open();

            string query = "UPDATE Productos SET Nombre=@Nombre, Descripcion=@Descripcion, Precio=@Precio WHERE Id=@Id";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", producto.Id);
            cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
            cmd.Parameters.AddWithValue("@Precio", producto.Precio);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool EliminarProducto(int productoId)
        {
            using var conn = conexion.CrearConexion();
            conn.Open();

            string query = "DELETE FROM Productos WHERE Id=@Id";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", productoId);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}

