using Microsoft.Data.SqlClient;
using Mysqlx.Crud;
using OrderNow.Datos;
using OrderNow.Modelos;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
            
            if (string.IsNullOrWhiteSpace(producto.Nombre) || producto.Precio <= 0 || string.IsNullOrWhiteSpace(producto.Descripcion))
            {
                MessageBox.Show("El producto debe tener un nombre y descripcion");
                return false;
            }

            try
            {
                using var conn = conexion.CrearConexion();
                conn.Open();

                string query = "INSERT INTO Productos(Nombre, Descripcion, Precio, Imagen) VALUES(@Nombre, @Descripcion, @Precio, @Imagen)";
                using var cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", string.IsNullOrWhiteSpace(producto.Descripcion) ? (object)DBNull.Value : producto.Descripcion);
                cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                cmd.Parameters.AddWithValue("@Imagen", producto.Imagen ?? (object)DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el producto: {ex.Message}");
                return false;
            }
        }


        public bool EditarProducto(Producto producto)
        {
            using var conn = conexion.CrearConexion();
            conn.Open();

            string query = "UPDATE Productos SET Nombre=@Nombre, Descripcion=@Descripcion, Precio=@Precio , Imagen=@Imagen WHERE Id=@Id";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", producto.Id);
            cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
            cmd.Parameters.AddWithValue("@Precio", producto.Precio);
            cmd.Parameters.AddWithValue("@Imagen", producto.Imagen ?? (object)DBNull.Value);

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

        public List<Producto> ConsultarProductos()
        {
            var lista = new List<Producto>();

            using var conn = conexion.CrearConexion();
            conn.Open();

            string query = "SELECT Id, Nombre, Descripcion, Precio, Imagen FROM Productos";
            using var cmd = new SqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Producto(
                    id: reader.GetInt32(0),
                    nombre: reader.GetString(1),
                    descripcion: reader.IsDBNull(2) ? "" : reader.GetString(2),
                    precio: reader.GetInt32(3),
                    imagen: reader.IsDBNull(4) ? null : (byte[])reader["Imagen"]
                ));
            }

            return lista;
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

        public bool RegistrarVendedor(Vendedor vendedor, string confirmacion)
        {

            if (string.IsNullOrWhiteSpace(vendedor.Nombre) || string.IsNullOrWhiteSpace(vendedor.Contrasena) || string.IsNullOrWhiteSpace(confirmacion))
            {
                MessageBox.Show("El vendedor debe tener un nombre y contrasena. Ademas, debe confirmar la contrasena");
                return false;
            }

            if (vendedor.Contrasena != confirmacion)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return false;
            }

            try
            {
                using var conn = conexion.CrearConexion();
                conn.Open();

                string query = "INSERT INTO Usuarios (Nombre, Contrasena, Rol) VALUES (@Nombre, @Contrasena, @Rol)";

                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", vendedor.Nombre);
                cmd.Parameters.AddWithValue("@Contrasena", vendedor.Contrasena);
                cmd.Parameters.AddWithValue("@Rol", "Vendedor");

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el vendedor: {ex.Message}");
                return false;
            }
        }
    }
}

