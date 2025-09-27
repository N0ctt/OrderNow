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

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Evitar encabezados
            if (e.RowIndex < 0) return;

            // Verificamos si la columna es "colVer"
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colVer")
            {
                e.PaintBackground(e.ClipBounds, true);

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
                    new Font("Segoe UI Semibold", 11, FontStyle.Bold),
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

        }

    }
}
