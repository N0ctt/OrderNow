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
                    DataPropertyName = "Descripcion",
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        WrapMode = DataGridViewTriState.True,
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    }
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
                    Name = "colAccion",
                    HeaderText = "Acción",
                    UseColumnTextForButtonValue = false 
                });


                dataGridView1.DataSource = lista;

                // Ajustar texto del botón según estado
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var prod = (Producto)row.DataBoundItem;
                    if (prod.Activo)
                    {
                        row.Cells["colAccion"].Value = "Inhabilitar";
                    }
                    else
                    {
                        row.Cells["colAccion"].Value = "Habilitar";
                    }
                }


                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dataGridView1.RowTemplate.Height = 90; // altura fija deseada
                dataGridView1.AllowUserToResizeRows = false; // evitar que el usuario cambie altura
                dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;

                // 🔹 Aplicar la altura fija a todas las filas cargadas
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Height = 105; // asegúrate que todas las filas queden iguales
                }

                dataGridView1.Columns["colId"].Width = 62;
                dataGridView1.Columns["colImagen"].Width = 120;
                dataGridView1.Columns["colNombre"].Width = 128;
                dataGridView1.Columns["colDescripcion"].Width = 215;
                dataGridView1.Columns["colPrecio"].Width = 110;
                dataGridView1.Columns["colEditar"].Width = 160;
                dataGridView1.Columns["colAccion"].Width = 160;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}");
            }
        }




        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Evitar pintar encabezados
            if (e.RowIndex < 0) return;

            string colName = dataGridView1.Columns[e.ColumnIndex].Name;

            // Solo personalizamos las columnas Editar y Acción
            if (colName != "colEditar" && colName != "colAccion") return;

            // Fondo blanco para el margen
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }

            // Determinar color y texto según columna y estado
            Color backColor;
            Color foreColor = Color.White;
            string texto;

            if (colName == "colEditar")
            {
                backColor = Color.FromArgb(39, 39, 39); // gris oscuro
                texto = "Editar";
            }
            else // colAccion
            {
                var producto = (Producto)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                if (producto.Activo)
                {
                    backColor = Color.FromArgb(192, 57, 43); // rojo -> Inhabilitar
                    texto = "Inhabilitar";
                }
                else
                {
                    backColor = Color.FromArgb(46, 204, 113); // verde -> Habilitar
                    texto = "Habilitar";
                }
            }

            // Margen interno
            int margin = 6;
            Rectangle rect = new Rectangle(
                e.CellBounds.X + margin,
                e.CellBounds.Y + margin,
                e.CellBounds.Width - (margin * 2),
                e.CellBounds.Height - (margin * 2)
            );

            int radius = 10; // esquinas redondeadas

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                // Relleno del botón
                using (SolidBrush btnBrush = new SolidBrush(backColor))
                {
                    e.Graphics.FillPath(btnBrush, path);
                }

                // Borde blanco del botón
                using (Pen borderPen = new Pen(Color.White, 1))
                {
                    e.Graphics.DrawPath(borderPen, path);
                }
            }

            // Dibujar texto centrado
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


        // 👇 Evento para cambiar el cursor cuando pasa sobre Editar o Eliminar
        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string colName = dataGridView1.Columns[e.ColumnIndex].Name;

                if (colName == "colEditar" || colName == "colAccion")
                {
                    dataGridView1.Cursor = Cursors.Hand;
                }
                else
                {
                    dataGridView1.Cursor = Cursors.Default;
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string colName = dataGridView1.Columns[e.ColumnIndex].Name;

                
                Producto producto = (Producto)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                if (colName == "colAccion")
                {
                    bool esActivo = producto.Activo;
                    string accion = esActivo ? "Inhabilitar" : "Habilitar";

                    var confirm = MessageBox.Show($"¿Seguro que quieres {accion.ToLower()} '{producto.Nombre}'?",
                                                  "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        bool resultado = esActivo
                            ? _adminService.InhabilitarProducto(producto.Id)
                            : _adminService.HabilitarProducto(producto.Id);

                        if (resultado)
                        {
                            CargarProductos();
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
