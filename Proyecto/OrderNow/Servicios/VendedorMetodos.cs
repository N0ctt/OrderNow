using Microsoft.Data.SqlClient;
using OrderNow.Datos;
using OrderNow.Modelos;

namespace OrderNow.Servicios
{
    public class VendedorMetodos
    {
        private readonly ConexionBD _conexion;

        public VendedorMetodos()
        {
            _conexion = new ConexionBD();
        }

        public List<Producto> ConsultarProductos()
        {
            var lista = new List<Producto>();

            using var conexion = _conexion.CrearConexion();
            conexion.Open();

            using var cmd = new SqlCommand("SELECT Id, Nombre, Descripcion, Precio, Imagen FROM Productos", conexion);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var producto = new Producto(
                    id: reader.GetInt32(0),
                    nombre: reader.GetString(1),
                    descripcion: reader.IsDBNull(2) ? "" : reader.GetString(2),
                    precio: reader.GetInt32(3)
                );

                // Validar si hay imagen
                if (!reader.IsDBNull(4))
                {
                    byte[] bytesImagen = (byte[])reader[4];
                    producto.Imagen = bytesImagen;

                    // Convertir a Bitmap para mostrar en el PictureBox
                    using var ms = new MemoryStream(bytesImagen);
                    producto.ImagenBitmap = Image.FromStream(ms);
                }

                lista.Add(producto);
            }

            return lista;
        }



        public bool CrearPedido(Pedido pedido)
        {
            if (pedido.Detalles == null || pedido.Detalles.Count == 0)
                throw new InvalidOperationException("No se puede crear un pedido sin productos.");

            using var conexion = _conexion.CrearConexion();
            conexion.Open();

            using var transaccion = conexion.BeginTransaction();

            try
            {
                // 1. Insertar en Pedidos
                var cmdPedido = new SqlCommand(
                    "INSERT INTO Pedidos (Mesa, Estado) OUTPUT INSERTED.Id VALUES (@Mesa, @Estado)",
                    conexion, transaccion
                );

                cmdPedido.Parameters.AddWithValue("@Mesa", pedido.Mesa);
                cmdPedido.Parameters.AddWithValue("@Estado", (int)pedido.Estado);

                int pedidoId = (int)cmdPedido.ExecuteScalar();
                pedido.Id = pedidoId;

                // 2. Insertar cada detalle en PedidoDetalles
                foreach (var detalle in pedido.Detalles)
                {
                    var cmdDetalle = new SqlCommand(
                        "INSERT INTO PedidoDetalles (PedidoId, ProductoId, Cantidad, PrecioUnitario) " +
                        "VALUES (@PedidoId, @ProductoId, @Cantidad, @PrecioUnitario)",
                        conexion, transaccion
                    );

                    cmdDetalle.Parameters.AddWithValue("@PedidoId", pedidoId);
                    cmdDetalle.Parameters.AddWithValue("@ProductoId", detalle.ProductoId);
                    cmdDetalle.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                    cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);

                    cmdDetalle.ExecuteNonQuery();
                }

                transaccion.Commit();
                return true;
            }
            catch
            {
                transaccion.Rollback();
                throw;
            }
        }

    }
}
