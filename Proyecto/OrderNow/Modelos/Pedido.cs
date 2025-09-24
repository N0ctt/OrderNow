namespace OrderNow.Modelos
{
    public enum EstadoPedido
    {
        Pendiente,
        Entregado,
        Cancelado
    }
    public class Pedido
    {
        public int Id { get; set; }
        public int Mesa { get; set; }                       
        public EstadoPedido Estado { get; set; }

       
        public Pedido(int id, int mesa, EstadoPedido estado)
        {
            Id = id;
            Mesa = mesa;
            Estado = estado;
        }
    }
}
