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
    public partial class RegistrarVendedor : Form
    {
        public RegistrarVendedor()
        {
            InitializeComponent();
        }

        private void RegistrarVendedor_Load(object sender, EventArgs e)
        {
            int radio = 20; // curvatura
            GraphicsPath path = new GraphicsPath();

            // Usar un rectángulo más preciso para evitar cortes
            Rectangle rect = new Rectangle(0, 0, button1.Width - 1, button1.Height - 1);

            // Esquinas redondeadas
            path.AddArc(rect.X, rect.Y, radio, radio, 180, 90); // arriba-izquierda
            path.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90); // arriba-derecha
            path.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90); // abajo-derecha
            path.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90); // abajo-izquierda
            path.CloseFigure();

            // Aplicar región al botón
            button1.Region = new Region(path);

            // 🔑 Activar suavizado (muy importante)
            button1.Paint += (s, ev) =>
            {
                ev.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            };
        }
    }
}
