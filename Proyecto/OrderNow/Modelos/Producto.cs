using System;

namespace OrderNow.Modelos
{
    public class Producto
    {
        public int Id { get; set; }
        public byte[] Imagen { get; set; }
        public Image ImagenBitmap { get; set; }

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

        public bool Activo { get; set; }

        public Producto() { }

        public Producto(int id, string nombre, string descripcion, int precio, byte[] imagen = null, bool activo = true)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Imagen = imagen;
            Activo = activo;


            if (Imagen != null && Imagen.Length > 0)
            {
                using var ms = new MemoryStream(Imagen);
                ImagenBitmap = Image.FromStream(ms);
            }

            
        }
    }
}
