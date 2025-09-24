using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderNow.Modelos
{
    public class Administrador : Usuario
    {
        public Administrador(string nombre, string contrasena) : base(nombre, contrasena)
        {
        }
        public override string ObtenerRol()
        {
            return "Administrador";
        }
    }


}
