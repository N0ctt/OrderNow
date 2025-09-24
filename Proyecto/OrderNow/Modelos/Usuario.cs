using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderNow.Modelos
{
    public abstract class Usuario
    {
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

        private string contrasena;

        public string Contrasena
        {
            get => contrasena;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    contrasena = value;
                }
                else
                {
                    contrasena = value;
                }
            }
        }
        public Usuario(string nombre, string contrasena)
        {
            Nombre = nombre;
            Contrasena = contrasena;
        }

        public abstract string ObtenerRol();
    }
}
