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
    public partial class ProductoCard : UserControl
    {

        // === PROPIEDADES DEL PRODUCTO ===
        public int IdProducto { get; set; }

        private string nombreProducto;
        public string NombreProducto
        {
            get => nombreProducto;
            set
            {
                nombreProducto = value;
                lblNombre.Text = value; // lblNombre es el Label con "XXXXXX"
            }
        }

        private decimal precioProducto;
        public decimal PrecioProducto
        {
            get => precioProducto;
            set
            {
                precioProducto = value;
                // Puedes mostrarlo si quieres en otro label
            }
        }

        public Image ImagenProducto
        {
            get => pictureBox1.Image;   // pictureBox1 es tu recuadro en blanco
            set => pictureBox1.Image = value;
        }

        // === EVENTO ===
        public event EventHandler ProductoAgregado;
        public ProductoCard()
        {
            InitializeComponent();
        }

        private void ProductoCard_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductoAgregado?.Invoke(this, EventArgs.Empty);
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }
    }
}
