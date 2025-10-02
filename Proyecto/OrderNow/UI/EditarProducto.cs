using OrderNow.Modelos;
using OrderNow.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OrderNow
{
    public partial class EditarProducto : Form
    {
        private Producto _producto; 
        private AdministradorMetodos _adminService;
        public EditarProducto(Producto producto)
        {
            InitializeComponent();
            _producto = producto;
            _adminService = new AdministradorMetodos();
        }

        private void EditarProducto_Load(object sender, EventArgs e)
        {
            RedondearBoton(button1, 20);
            RedondearBoton(button2, 20);
            textBox1.Text = _producto.Nombre;
            textBox2.Text = _producto.Descripcion;
            textBox3.Text = _producto.Precio.ToString();
        }

        private void RedondearBoton(Button boton, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, boton.Width - 1, boton.Height - 1);

            // Arcos de las 4 esquinas
            path.AddArc(rect.X, rect.Y, radio, radio, 180, 90); // arriba-izquierda
            path.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90); // arriba-derecha
            path.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90); // abajo-derecha
            path.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90); // abajo-izquierda
            path.CloseFigure();

            boton.Region = new Region(path);

            // Activar suavizado en el evento Paint del botón
            boton.Paint += (s, ev) =>
            {
                ev.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _producto.Nombre = textBox1.Text;
            _producto.Descripcion = textBox2.Text;

            if (int.TryParse(textBox3.Text, out int precio))
            {
                _producto.Precio = precio;
            }
            else
            {
                MessageBox.Show("Precio inválido");
                return;
            }

            // Guardar la imagen
            if (pictureBox2.Image != null)
            {
                using var ms = new MemoryStream();
                pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                _producto.Imagen = ms.ToArray();
            }

            if (_adminService.EditarProducto(_producto))
            {
                MessageBox.Show("Producto actualizado correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar el producto");
            }
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imágenes|*.jpg;*.png;*.jpeg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(ofd.FileName);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
