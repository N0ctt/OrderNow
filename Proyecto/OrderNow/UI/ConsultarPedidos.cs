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
    public partial class ConsultarPedidos : Form
    {
        public ConsultarPedidos()
        {
            InitializeComponent();
        }

        private void ConsultarPedidos_Load(object sender, EventArgs e)
        {

            CargarPedidos();
            dataGridView1.ClearSelection();
        }

        private void CargarPedidos()
        {
            var admin = new AdministradorMetodos();
            var lista = admin.ConsultarPedidos();

            // Limpiar configuraciones previas
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            // Columna Id
            var colId = new DataGridViewTextBoxColumn();
            colId.HeaderText = "ID Pedido";
            colId.DataPropertyName = "Id";
            dataGridView1.Columns.Add(colId);


            // Columna Estado
            var colEstado = new DataGridViewTextBoxColumn();
            colEstado.HeaderText = "Estado";
            colEstado.DataPropertyName = "Estado";
            dataGridView1.Columns.Add(colEstado);

            // Columna botón
            var btnCol = new DataGridViewButtonColumn();
            btnCol.HeaderText = "Acciones";
            btnCol.Text = "Ver Pedido";
            btnCol.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btnCol);
            btnCol.Name = "colVer";


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.RowTemplate.Height = 55;
            dataGridView1.AllowUserToResizeRows = false;

            // Anchos uniformes para que coincidan
            colId.Width = 190;
            colEstado.Width = 190;
            btnCol.Width = 170;

            // Centrar texto en todas las celdas
            colId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEstado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            btnCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Asignar DataSource
            dataGridView1.DataSource = lista;


        }





        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Evitar encabezados
            if (e.RowIndex < 0) return;

            // Verificamos si la columna es "colVer"
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colVer")
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;

                e.PaintBackground(e.ClipBounds, true);


                // 🎨 Colores y fuente solicitados
                Color backColor = Color.FromArgb(39, 39, 39); // fondo oscuro
                Color foreColor = Color.White;                // texto blanco

                // Definir el área del botón con un pequeño margen
                Rectangle rect = new Rectangle(
                    e.CellBounds.X + 4,
                    e.CellBounds.Y + 4,
                    e.CellBounds.Width - 8,
                    e.CellBounds.Height - 8
                );

                int radius = 10; // radio de las esquinas

                using (GraphicsPath path = new GraphicsPath())
                {
                    // Crear figura con esquinas redondeadas
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                    path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                    path.CloseFigure();

                    // Rellenar con el color del botón
                    using (SolidBrush brush = new SolidBrush(backColor))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                }

                // Dibujar el texto centrado
                TextRenderer.DrawText(
                    e.Graphics,
                    "Ver Pedido", // Texto fijo
                    new Font("Segoe UI Semibold", 12, FontStyle.Bold),
                    rect,
                    foreColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );

                e.Handled = true; // ya pintamos la celda
            }
        }

        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string colName = dataGridView1.Columns[e.ColumnIndex].Name;

                if (colName == "colVer")
                {
                    dataGridView1.Cursor = Cursors.Hand; // 👆 manito
                }
                else
                {
                    dataGridView1.Cursor = Cursors.Default; // ➡️ flecha normal
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                int pedidoId = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;

                
                var formDetalles = new VerDetallesDePedido(pedidoId);
                formDetalles.ShowDialog();

                
                CargarPedidos();
            }
        }


    }
}
