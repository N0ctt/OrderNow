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

        public bool InhabilitarProducto(int productoId)
        {
            try
            {
                using var conn = conexion.CrearConexion();
                conn.Open();

                // Verificar si el producto está en pedidos que NO estén cancelados (Estado ≠ 2)
                string checkQuery = @"
            SELECT COUNT(*) 
            FROM PedidoDetalles pd
            INNER JOIN Pedidos p ON pd.PedidoID = p.Id
            WHERE pd.ProductoID = @Id AND p.Estado <> 2";  // 2 = Cancelado

                using (var checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Id", productoId);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("No se puede inhabilitar el producto porque está en pedidos activos o entregados.",
                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                // Inhabilitar el producto
                string query = "UPDATE Productos SET Activo = 0 WHERE Id = @Id";
                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", productoId);

                bool inhabilitado = cmd.ExecuteNonQuery() > 0;

                if (inhabilitado)
                {
                    MessageBox.Show("Producto inhabilitado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return inhabilitado;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inhabilitar producto: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool HabilitarProducto(int productoId)
        {
            try
            {
                using var conn = conexion.CrearConexion();
                conn.Open();

                string query = "UPDATE Productos SET Activo = 1 WHERE Id = @Id";
                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", productoId);

                bool habilitado = cmd.ExecuteNonQuery() > 0;

                if (habilitado)
                {
                    MessageBox.Show("Producto habilitado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return habilitado;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al habilitar producto: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<Producto> ConsultarProductos()
        {
            var lista = new List<Producto>();

            using var conn = conexion.CrearConexion();
            conn.Open();

            string query = "SELECT Id, Nombre, Descripcion, Precio, Imagen, Activo FROM Productos";
            using var cmd = new SqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var producto = new Producto(
                    id: reader.GetInt32(0),
                    nombre: reader.GetString(1),
                    descripcion: reader.IsDBNull(2) ? "" : reader.GetString(2),
                    precio: reader.GetInt32(3),
                    imagen: reader.IsDBNull(4) ? null : (byte[])reader["Imagen"]
                );
                
                producto.Activo = reader.GetBoolean(5); 

                lista.Add(producto);
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
                var pedido = new Pedido
                {
                    Id = reader.GetInt32(0),
                    Mesa = reader.GetInt32(1),
                    Estado = (EstadoPedido)reader.GetInt32(2)
                };

                lista.Add(pedido);
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

        public Pedido ConsultarPedidoPorId(int id)
        {
            Pedido pedido = null;

            using var conn = conexion.CrearConexion();
            conn.Open();

            // Traer datos del pedido
            using (var cmd = new SqlCommand("SELECT Id, Mesa, Estado FROM Pedidos WHERE Id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                using var rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    pedido = new Pedido
                    {
                        Id = rdr.GetInt32(0),
                        Mesa = rdr.GetInt32(1),
                        Estado = (EstadoPedido)rdr.GetInt32(2),
                        Detalles = new List<PedidoDetalle>()
                    };
                }
            }

            if (pedido == null)
                return null;

            // 🔹 Cambiamos el INNER JOIN a LEFT JOIN para incluir productos inhabilitados
            using (var cmd = new SqlCommand(@"
        SELECT dp.Id, dp.PedidoId, dp.ProductoId, dp.Cantidad, dp.PrecioUnitario,
               p.Nombre, p.Precio, p.Activo, p.Imagen
        FROM PedidoDetalles dp
        LEFT JOIN Productos p ON dp.ProductoId = p.Id
        WHERE dp.PedidoId = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                using var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var detalle = new PedidoDetalle
                    {
                        Id = rdr.GetInt32(0),
                        PedidoId = rdr.GetInt32(1),
                        ProductoId = rdr.GetInt32(2),
                        Cantidad = rdr.GetInt32(3),
                        PrecioUnitario = rdr.GetInt32(4),
                        Producto = new Producto
                        {
                            Id = rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2),
                            Nombre = rdr.IsDBNull(5) ? "(Producto eliminado)" : rdr.GetString(5),
                            Precio = rdr.IsDBNull(6) ? 0 : rdr.GetInt32(6),
                            Activo = rdr.IsDBNull(7) ? false : rdr.GetBoolean(7),
                            Imagen = rdr.IsDBNull(8) ? null : (byte[])rdr[8]
                        }
                    };

                    pedido.Detalles.Add(detalle);
                }
            }

            return pedido;
        }



        public bool CancelarPedido(int id)
        {
            using var conn = conexion.CrearConexion();
            conn.Open();

            string query = "UPDATE Pedidos SET Estado = @estado WHERE Id = @id";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@estado", (int)EstadoPedido.Cancelado); // 2
            cmd.Parameters.AddWithValue("@id", id);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool EntregarPedido(int id)
        {
            using var conn = conexion.CrearConexion();
            conn.Open();

            string query = "UPDATE Pedidos SET Estado = @estado WHERE Id = @id";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@estado", (int)EstadoPedido.Entregado); // 1
            cmd.Parameters.AddWithValue("@id", id);

            return cmd.ExecuteNonQuery() > 0;
        }

    }
}


