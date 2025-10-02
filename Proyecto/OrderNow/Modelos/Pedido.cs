namespace OrderNow.Modelos
{
    public enum EstadoPedido
    {
        Pendiente = 0,
        Entregado = 1,
        Cancelado = 2
    }

    public class Pedido
    {
        public int Id { get; set; }
        public int Mesa { get; set; }
        public EstadoPedido Estado { get; set; }

        public List<PedidoDetalle> Detalles { get; set; } = new List<PedidoDetalle>();

        public int Total => Detalles.Sum(d => d.Subtotal);
    }
}
