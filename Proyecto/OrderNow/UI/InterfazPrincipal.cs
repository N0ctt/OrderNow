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
            int radio = 20; 
            GraphicsPath path = new GraphicsPath();

       
            Rectangle rect = new Rectangle(0, 0, button1.Width - 1, button1.Height - 1);

            
            path.AddArc(rect.X, rect.Y, radio, radio, 180, 90); 
            path.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90); 
            path.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90); 
            path.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90);
            path.CloseFigure();

            
            button1.Region = new Region(path);

            
            button1.Paint += (s, ev) =>
            {
                ev.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            };

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsuarioService servicio = new UsuarioService();
            var usuario = servicio.ValidarCredenciales(txtUsuario.Text, txtContrasena.Text);

            if (usuario is Administrador)
            {
                using (var adminUI = new UIadministrador())
                {
                 
                    adminUI.ShowDialog();   
                    this.Show();            
                }
            }
            else if (usuario is Vendedor)
            {
                using (var vendedorUI = new UIvendedor())
                {
             
                    vendedorUI.ShowDialog();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Credenciales inválidas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
