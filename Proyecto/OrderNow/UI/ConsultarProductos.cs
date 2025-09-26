using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderNow
{
    public partial class ConsultarProductos : Form
    {
        public ConsultarProductos()
        {
            InitializeComponent();
        }

        private void ConsultarProductos_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Solo filas válidas
            if (e.RowIndex < 0) return;

            // Índices de las columnas Editar y Eliminar (ajusta según corresponda)
            int colEditar = 6;
            int colEliminar = 7;

            if (e.ColumnIndex == colEditar || e.ColumnIndex == colEliminar)
            {
                e.PaintBackground(e.ClipBounds, true);

                Color backColor = Color.FromArgb(39, 39, 39);
                Color foreColor = Color.White;

                using (SolidBrush brush = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }

                TextRenderer.DrawText(e.Graphics,
                    e.Value?.ToString() ?? "",
                    new Font("Segoe UI Semibold", 12, FontStyle.Bold),
                    e.CellBounds,
                    foreColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
