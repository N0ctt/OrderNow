using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderNow.Modelos
{

    public class Producto
    {
        public int Id { get; set; }
        private string nombre;
        public string Nombre
        {
            get => nombre;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    nombre = char.ToUpper(value[0]) + value.Substring(1).ToLower();
                }

                else
                {
                    nombre = value;
                }
            }
        }

        public string Descripcion { get; set; }
        public int Precio { get; set; }

        public Producto(int id,string nombre, string descripcion, int precio)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
        }
    }
}
