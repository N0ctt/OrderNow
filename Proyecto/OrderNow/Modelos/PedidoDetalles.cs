using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderNow.Modelos
{
    public class PedidoDetalles
    {

        public int CantidadProductos => Productos?.Count ?? 0;
        public List<Producto> Productos { get; set; }
        public int PrecioTotal => Productos?.Sum(p => p.Precio) ?? 0;


        public PedidoDetalles  (List<Producto> productos)
        {
            Productos = productos ?? new List<Producto>();
        }

    }
}
