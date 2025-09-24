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


namespace OrderNow.Interfaces
{
    public partial class InterfazPrincipal : Form
    {

        public InterfazPrincipal()
        {
            InitializeComponent();
        }

        private void InterfazPrincipal_Load(object sender, EventArgs e)
        {
            int radio = 20; // Ajusta aquí la curvatura

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radio, radio, 180, 90);
            path.AddArc(button1.Width - radio, 0, radio, radio, 270, 90);
            path.AddArc(button1.Width - radio, button1.Height - radio, radio, radio, 0, 90);
            path.AddArc(0, button1.Height - radio, radio, radio, 90, 90);
            path.CloseAllFigures();

            button1.Region = new Region(path);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
