using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderNow.Modelos
{
    public class Vendedor : Usuario
    {
        public Vendedor(string nombre, string contrasena) : base(nombre, contrasena)
        {
        }
        public override string ObtenerRol()
        {
            return "Vendedor";
        }
    }

}

