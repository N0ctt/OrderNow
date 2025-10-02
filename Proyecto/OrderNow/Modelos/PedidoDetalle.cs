namespace OrderNow.Modelos
{
    public class PedidoDetalle
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public int PrecioUnitario { get; set; }
        public Producto Producto { get; set; }

        public int Subtotal => Cantidad * PrecioUnitario;

       
        public string NombreProducto => Producto?.Nombre;
    }
}

