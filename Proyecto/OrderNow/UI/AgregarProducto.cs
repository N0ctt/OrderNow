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
    public partial class AgregarProducto : Form
    {

        private readonly AdministradorMetodos _adminService;
        public AgregarProducto()
        {
            InitializeComponent();
            _adminService = new AdministradorMetodos();
        }

        private void AgregarProducto_Load(object sender, EventArgs e)
        {
            RedondearBoton(button1, 20);
            RedondearBoton(button2, 20);
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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imágenes|*.jpg;*.png;*.jpeg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Producto nuevoProducto = new Producto
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = int.Parse(txtPrecio.Text)
                };

                if (pictureBox2.Image != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
                        nuevoProducto.Imagen = ms.ToArray();
                    }
                }

                bool guardado = _adminService.AgregarProducto(nuevoProducto);

                if (guardado)
                {
                    MessageBox.Show("Producto agregado con éxito ✅", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNombre.Clear();
                    txtDescripcion.Clear();
                    txtPrecio.Clear();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el producto ❌", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("El precio debe ser un número entero válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
