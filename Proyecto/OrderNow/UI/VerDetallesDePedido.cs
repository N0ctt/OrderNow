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


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.RowTemplate.Height = 55;
            dataGridView1.AllowUserToResizeRows = false;

            // Anchos uniformes para que coincidan
            colProducto.Width = 190;
            colCantidad.Width = 190;
            colPrecio.Width = 235;

            colEntregar.Width = 165;

            // Centrar texto en todas las celdas
            colProducto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colPrecio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            colEntregar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            // Fuente de datos: los detalles del pedido
            dataGridView1.DataSource = pedido.Detalles;
        }


        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void dataGridView1_CellMouseMove_1(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void lblDetallesPedido_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_admin.CancelarPedido(_pedidoId))
            {
                MessageBox.Show("Pedido cancelado correctamente.");
                Close();
            }
            else
            {
                MessageBox.Show("No se pudo cancelar el pedido.");
            }
        }

        private void btnEntregarPedido_Click(object sender, EventArgs e)
        {
            if (_admin.EntregarPedido(_pedidoId))
            {
                MessageBox.Show("Pedido entregado correctamente.");
                Close();
            }
            else
            {
                MessageBox.Show("No se pudo entregar el pedido.");
            }
        }
    }
}
