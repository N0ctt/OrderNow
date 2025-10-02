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
    public partial class ConsultarProductos : Form
    {
        private AdministradorMetodos _adminService = new AdministradorMetodos();
        public ConsultarProductos()
        {
            InitializeComponent();
            this.dataGridView1.CellPainting += dataGridView1_CellPainting;

        }
        private void ConsultarProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            try
            {
                var lista = _adminService.ConsultarProductos();

                // Convertir byte[] a Image
                foreach (var prod in lista)
                {
                    if (prod.Imagen != null && prod.Imagen.Length > 0)
                    {
                        using var ms = new System.IO.MemoryStream(prod.Imagen);
                        // Crear un Bitmap desconectado del stream
                        prod.ImagenBitmap = new Bitmap(ms);
                    }
                    else
                    {
                        prod.ImagenBitmap = null; // Evitar imágenes fantasma
                    }
                }

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.ReadOnly = true;

                // Limpiar columnas existentes
                dataGridView1.Columns.Clear();

                // Columnas en el orden correcto: ID | Imagen | Nombre | Descripción | Precio | Editar | Eliminar
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colId",
                    HeaderText = "ID",
                    DataPropertyName = "Id"
                });

                dataGridView1.Columns.Add(new DataGridViewImageColumn
                {
                    Name = "colImagen",
                    HeaderText = "Imagen",
                    DataPropertyName = "ImagenBitmap",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colNombre",
                    HeaderText = "Nombre",
                    DataPropertyName = "Nombre"
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colDescripcion",
                    HeaderText = "Descripción",
                    DataPropertyName = "Descripcion"
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colPrecio",
                    HeaderText = "Precio",
                    DataPropertyName = "Precio"
                });

                // Columnas de botones
                dataGridView1.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "colEditar",
                    HeaderText = "Editar",
                    Text = "Editar",
                    UseColumnTextForButtonValue = true
                });

                dataGridView1.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "colEliminar",
                    HeaderText = "Eliminar",
                    Text = "Eliminar",
                    UseColumnTextForButtonValue = true
                });

                // Asignar la lista como DataSource al final
                dataGridView1.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}");
            }
        }




        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Evitar encabezados
            if (e.RowIndex < 0) return;

            // Verificamos si la columna es Editar o Eliminar
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;

            if (colName == "colEditar" || colName == "colEliminar")
            {
                // Fondo blanco para el margen
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }

                // Colores diferentes para cada botón
                Color backColor = colName == "colEditar" ? Color.FromArgb(39, 39, 39) : Color.FromArgb(192, 57, 43);
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

                    // Borde blanco
                    using (Pen pen = new Pen(Color.White, 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }

                // Texto del botón
                string texto = colName == "colEditar" ? "Editar" : "Eliminar";

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

        // 👇 Evento para cambiar el cursor cuando pasa sobre Editar o Eliminar
        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string colName = dataGridView1.Columns[e.ColumnIndex].Name;

                if (colName == "colEditar" || colName == "colEliminar")
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
            if (e.RowIndex >= 0)
            {
                string colName = dataGridView1.Columns[e.ColumnIndex].Name;

                
                Producto producto = (Producto)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                if (colName == "colEliminar")
                {
                    var confirm = MessageBox.Show($"¿Seguro que quieres eliminar '{producto.Nombre}'?",
                                                  "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        if (_adminService.EliminarProducto(producto.Id))
                        {
                            MessageBox.Show("Producto eliminado con éxito");
                            CargarProductos(); 
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar producto");
                        }
                    }
                }

                if (colName == "colEditar")
                {
                
                    var frmEditar = new EditarProducto(producto);
                    frmEditar.ShowDialog();

                    
                    CargarProductos();
                }
            }
        }
    }
}
