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

        public List<Pedido> ConsultarPedidos()
        {
            var lista = new List<Pedido>();

            using var conn = conexion.CrearConexion();
            conn.Open();

            using var cmd = new SqlCommand("SELECT Id, Mesa, Estado FROM Pedidos", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Pedido(
                    id: reader.GetInt32(0),
                    mesa: reader.GetInt32(1),
                    estado: (EstadoPedido)reader.GetInt32(2) 
                ));
            }

            return lista;
        }

        public bool RegistrarVendedor(Vendedor vendedor)
        {
            using var conn = conexion.CrearConexion();
            conn.Open();

            string query = "INSERT INTO Usuarios (Nombre, Contrasena, Rol) VALUES (@Nombre, @Contrasena, @Rol)";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Nombre", vendedor.Nombre);
            cmd.Parameters.AddWithValue("@Contrasena", vendedor); 
            cmd.Parameters.AddWithValue("@Rol", "Vendedor"); 

            return cmd.ExecuteNonQuery() > 0;
        }


    }
}

