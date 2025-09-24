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

            using var cmd = new SqlCommand("SELECT Id, Nombre, Descripcion, Precio FROM Productos", conexion);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Producto(
                    id: reader.GetInt32(0),
                    nombre: reader.GetString(1),
                    descripcion: reader.IsDBNull(2) ? "" : reader.GetString(2),
                    precio: reader.GetInt32(3)
                ));
            }

            return lista;
        }

        public bool CrearPedido(Pedido pedido)
        {
            
            if (pedido.Detalles == null || pedido.Detalles.CantidadProductos == 0)
                throw new InvalidOperationException("No se puede crear un pedido sin productos.");

            using var conexion = _conexion.CrearConexion();
            conexion.Open();

            using var transaccion = conexion.BeginTransaction();

            try
            {
                
                var cmdPedido = new SqlCommand(
                    "INSERT INTO Pedidos (Mesa, Estado) OUTPUT INSERTED.Id VALUES (@Mesa, @Estado)",
                    conexion, transaccion
                );

                cmdPedido.Parameters.AddWithValue("@Mesa", pedido.Mesa);
                cmdPedido.Parameters.AddWithValue("@Estado", (int)pedido.Estado); 

                int pedidoId = (int)cmdPedido.ExecuteScalar();
                pedido.Id = pedidoId;

                // tabla PedidoDetalles
                foreach (var producto in pedido.Detalles.Productos)
                {
                    var cmdDetalle = new SqlCommand(
                        "INSERT INTO PedidoDetalles (PedidoId, ProductoId, Cantidad, PrecioUnitario) " +
                        "VALUES (@PedidoId, @ProductoId, @Cantidad, @PrecioUnitario)",
                        conexion, transaccion
                    );

                    cmdDetalle.Parameters.AddWithValue("@PedidoId", pedidoId);
                    cmdDetalle.Parameters.AddWithValue("@ProductoId", producto.Id);
                    cmdDetalle.Parameters.AddWithValue("@Cantidad", 1); 
                    cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", producto.Precio);

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
