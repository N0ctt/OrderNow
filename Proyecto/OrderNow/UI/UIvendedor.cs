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
    public partial class UIvendedor : Form
    {

        public UIvendedor()
        {
            InitializeComponent();

        }

        private void UIvendedor_Load(object sender, EventArgs e)
        {
            RedondearBoton(button3, 20);
            RedondearBoton(button4, 20);

            // Configuración del carrusel
            panelCarrusel.AutoScroll = true;
            panelCarrusel.FlowDirection = FlowDirection.LeftToRight;
            panelCarrusel.WrapContents = true;

            // Configuración del DataGridView
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Nombre", "Nombre");
            dataGridView1.Columns.Add("Cantidad", "Cantidad");
            dataGridView1.Columns.Add("Precio", "Precio");
            dataGridView1.Columns.Add("Subtotal", "Subtotal");

            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            CargarProductos();
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

        private void CargarProductos()
        {
            var vendedorMetodos = new VendedorMetodos();
            var productos = vendedorMetodos.ConsultarProductos();

            panelCarrusel.Controls.Clear();

            foreach (var prod in productos)
            {
                var card = new ProductoCard
                {
                    IdProducto = prod.Id,
                    NombreProducto = prod.Nombre,
                    PrecioProducto = prod.Precio,
                    ImagenProducto = prod.ImagenBitmap,
                    Width = 180,   // 👈 tamaño fijo
                    Height = 250   // 👈 tamaño fijo

                };

                card.ProductoAgregado += (s, e) =>
                {
                    AgregarProductoAlPedido(prod);
                };

                panelCarrusel.Controls.Add(card);
            }
        }


        private void AgregarProductoAlPedido(Producto producto)
        {
            // Buscar si ya existe el producto en la lista
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Nombre"].Value != null && row.Cells["Nombre"].Value.ToString() == producto.Nombre)
                {
                    // Si ya existe, aumentar la cantidad
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    cantidad++;
                    row.Cells["Cantidad"].Value = cantidad;

                    // Actualizar subtotal
                    decimal precio = Convert.ToDecimal(row.Cells["Precio"].Value);
                    row.Cells["Subtotal"].Value = cantidad * precio;
                    return;
                }
            }

            // Si no existe, lo agregamos como nueva fila
            int rowIndex = dataGridView1.Rows.Add();
            dataGridView1.Rows[rowIndex].Cells["Id"].Value = producto.Id; // Guardar Id oculto
            dataGridView1.Rows[rowIndex].Cells["Nombre"].Value = producto.Nombre;
            dataGridView1.Rows[rowIndex].Cells["Cantidad"].Value = 1;
            dataGridView1.Rows[rowIndex].Cells["Precio"].Value = producto.Precio;
            dataGridView1.Rows[rowIndex].Cells["Subtotal"].Value = producto.Precio;
        }



        private void productRow1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("No hay productos en el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar mesa
                if (string.IsNullOrWhiteSpace(txtMesa.Text))
                {
                    MessageBox.Show("Debe ingresar un número de mesa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtMesa.Text, out int numeroMesa))
                {
                    MessageBox.Show("El número de mesa debe ser válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var detalles = new List<PedidoDetalle>();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (row.Cells["Id"].Value == null ||
                        row.Cells["Cantidad"].Value == null ||
                        row.Cells["Precio"].Value == null)
                    {
                        MessageBox.Show("Hay un producto con datos incompletos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int idProducto = Convert.ToInt32(row.Cells["Id"].Value);
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    int precioUnitario = Convert.ToInt32(row.Cells["Precio"].Value);

                    detalles.Add(new PedidoDetalle
                    {
                        ProductoId = idProducto,
                        Cantidad = cantidad,
                        PrecioUnitario = precioUnitario
                    });
                }

                var pedido = new Pedido
                {
                    Mesa = numeroMesa,
                    Estado = EstadoPedido.Pendiente,
                    Detalles = detalles
                };

                var vendedorMetodos = new VendedorMetodos();
                bool creado = vendedorMetodos.CrearPedido(pedido);

                if (creado)
                {
                    MessageBox.Show("Pedido creado con éxito ✅", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.Clear();
                    txtMesa.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void productoCard1_Load(object sender, EventArgs e)
        {

        }

        private void panelCarrusel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "¿Estás seguro de limpiar el pedido?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.ClearSelection();
                MessageBox.Show("El pedido fue limpiado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
