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
        public VerDetallesDePedido()
        {
            InitializeComponent();
        }

        private void VerDetallesDePedido_Load(object sender, EventArgs e)
        {

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

        // 👇 Evento para cambiar el cursor cuando pasa sobre Cancelar o Entregar
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}
