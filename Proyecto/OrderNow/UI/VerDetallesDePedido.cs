using OrderNow.Datos;
using OrderNow.Modelos;
using OrderNow.Servicios;
using Org.BouncyCastle.Asn1.Ocsp;
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
    public partial class VerDetallesDePedido : Form
    {
        private int _pedidoId;
        private AdministradorMetodos _admin = new AdministradorMetodos();


        public VerDetallesDePedido(int pedidoId)
        {
            InitializeComponent();
            _pedidoId = pedidoId;

        }

        private void VerDetallesDePedido_Load(object sender, EventArgs e)
        {
            // Obtener el pedido completo con sus detalles
            var pedido = _admin.ConsultarPedidoPorId(_pedidoId);

            if (pedido == null)
            {
                MessageBox.Show("No se encontró el pedido.");
                Close();
                return;
            }

            // Labels
            lblDetallesPedido.Text = pedido.Id.ToString();

            lblMesa.Text = pedido.Mesa.ToString();

            lblPrecioTotal.Text = pedido.Total.ToString();


            // Configurar DataGridView
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            // Producto
            var colProducto = new DataGridViewTextBoxColumn();
            colProducto.HeaderText = "Producto";
            colProducto.DataPropertyName = "NombreProducto";
            dataGridView1.Columns.Add(colProducto);

            // Cantidad
            var colCantidad = new DataGridViewTextBoxColumn();
            colCantidad.HeaderText = "Cantidad";
            colCantidad.DataPropertyName = "Cantidad";
            dataGridView1.Columns.Add(colCantidad);

            // Precio Unitario
            var colPrecio = new DataGridViewTextBoxColumn();
            colPrecio.HeaderText = "Precio Unitario";
            colPrecio.DataPropertyName = "PrecioUnitario";
            dataGridView1.Columns.Add(colPrecio);

            // Botón Cancelar
            var colCancelar = new DataGridViewButtonColumn();
            colCancelar.HeaderText = "Cancelar";
            colCancelar.Text = "Cancelar";
            colCancelar.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(colCancelar);

            // Botón Entregar
            var colEntregar = new DataGridViewButtonColumn();
            colEntregar.HeaderText = "Entregar";
            colEntregar.Text = "Entregar";
            colEntregar.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(colEntregar);


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.RowTemplate.Height = 55;
            dataGridView1.AllowUserToResizeRows = false;

            // Anchos uniformes para que coincidan
            colProducto.Width = 190;
            colCantidad.Width = 190;
            colPrecio.Width = 235;
            colCancelar.Width = 165;
            colEntregar.Width = 165;

            // Centrar texto en todas las celdas
            colProducto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colPrecio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCancelar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEntregar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            // Fuente de datos: los detalles del pedido
            dataGridView1.DataSource = pedido.Detalles;
        }


        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Evitar encabezados
            if (e.RowIndex < 0) return;

            // Verificamos si la columna es Cancelar o Entregar
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;

            if (colName == "colcancelar" || colName == "colEntregar")
            {
                // Fondo blanco para el margen
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }

                // Colores diferentes para cada botón
                Color backColor = colName == "colcancelar"
                    ? Color.FromArgb(192, 57, 43) // Rojo
                    : Color.FromArgb(39, 174, 96); // Verde

                Color foreColor = Color.White;

                // Margen para que no se peguen entre sí
                int margin = 6;
                Rectangle rect = new Rectangle(
                    e.CellBounds.X + margin,
                    e.CellBounds.Y + margin,
                    e.CellBounds.Width - (margin * 2),
                    e.CellBounds.Height - (margin * 2)
                );

                int radius = 10; // radio de las esquinas

                using (GraphicsPath path = new GraphicsPath())
                {
                    // Dibujar figura redondeada
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                    path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                    path.CloseFigure();

                    // Rellenar
                    using (SolidBrush brush = new SolidBrush(backColor))
                    {
                        e.Graphics.FillPath(brush, path);
                    }

                }

                // Texto del botón
                string texto = colName == "colcancelar" ? "Cancelar" : "Entregar";

                TextRenderer.DrawText(
                    e.Graphics,
                    texto,
                    new Font("Segoe UI Semibold", 11, FontStyle.Bold),
                    rect,
                    foreColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );

                e.Handled = true;
            }
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string accion = dataGridView1.Columns[e.ColumnIndex].HeaderText;

                if (accion == "Cancelar")
                {
                    if (_admin.CancelarPedido(_pedidoId))
                    {
                        MessageBox.Show("Pedido cancelado.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo cancelar el pedido.");
                    }
                }
                else if (accion == "Entregar")
                {
                    if (_admin.EntregarPedido(_pedidoId))
                    {
                        MessageBox.Show("Pedido entregado.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo entregar el pedido.");
                    }
                }
            }
        }



        private void dataGridView1_CellMouseMove_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string colName = dataGridView1.Columns[e.ColumnIndex].Name;

                if (colName == "colCancelar" || colName == "colEntregar")
                {
                    dataGridView1.Cursor = Cursors.Hand; // 👆 manito
                }
                else
                {
                    dataGridView1.Cursor = Cursors.Default; // ➡️ flecha normal
                }
            }
        }

        private void lblDetallesPedido_Click(object sender, EventArgs e)
        {

        }
    }
}
