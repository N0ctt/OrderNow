using Microsoft.Data.SqlClient;
using OrderNow.Datos;
using OrderNow.Modelos;
using System;
using System.Data;

namespace OrderNow.Servicios
{
    public class UsuarioService
    {
        private readonly ConexionBD _conexion;

        public UsuarioService()
        {
            _conexion = new ConexionBD();
        }

        public Usuario? ValidarCredenciales(string nombre, string contrasena)
        {
            using var conexion = _conexion.CrearConexion();
            conexion.Open();

            string query = "SELECT Nombre, Contrasena, Rol FROM Usuarios WHERE Nombre = @Nombre AND Contrasena = @Contrasena";

            using SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Contrasena", contrasena);

            using SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string rol = reader["Rol"].ToString()!;

                if (rol == "Administrador")
                {
                    return new Administrador(nombre, contrasena);
                }
                else if (rol == "Vendedor")
                {
                    return new Vendedor(nombre, contrasena);
                }
            }

            return null; 
        }
    }
}
