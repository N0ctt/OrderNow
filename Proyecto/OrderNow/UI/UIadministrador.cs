using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace OrderNow
{
    public partial class UIadministrador : Form
    {
        public UIadministrador()
        {
            InitializeComponent();
        }

        private void UIadministrador_Load(object sender, EventArgs e)
        {
            RedondearBoton(button1, 20);
            RedondearBoton(button2, 20);
            RedondearBoton(button3, 20);
            RedondearBoton(button4, 20);
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
    }
}
