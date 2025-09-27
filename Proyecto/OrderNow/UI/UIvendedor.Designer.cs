namespace OrderNow
{
    partial class UIvendedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelContenedor = new Panel();
            button2 = new Button();
            button1 = new Button();
            panelCarrusel = new Panel();
            productoCard1 = new ProductoCard();
            panelLista = new Panel();
            productRow1 = new ProductRow();
            label1 = new Label();
            button3 = new Button();
            button4 = new Button();
            panelContenedor.SuspendLayout();
            panelCarrusel.SuspendLayout();
            panelLista.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.White;
            panelContenedor.Controls.Add(button2);
            panelContenedor.Controls.Add(button1);
            panelContenedor.Controls.Add(panelCarrusel);
            panelContenedor.Location = new Point(36, 336);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(698, 258);
            panelContenedor.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(39, 39, 39);
            button2.Cursor = Cursors.PanEast;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(678, 0);
            button2.Name = "button2";
            button2.Size = new Size(21, 258);
            button2.TabIndex = 2;
            button2.Text = ">";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(39, 39, 39);
            button1.Cursor = Cursors.PanWest;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(2, 0);
            button1.Name = "button1";
            button1.Size = new Size(21, 258);
            button1.TabIndex = 1;
            button1.Text = "<";
            button1.UseVisualStyleBackColor = false;
            // 
            // panelCarrusel
            // 
            panelCarrusel.BackColor = Color.Transparent;
            panelCarrusel.Controls.Add(productoCard1);
            panelCarrusel.Dock = DockStyle.Fill;
            panelCarrusel.Location = new Point(0, 0);
            panelCarrusel.Name = "panelCarrusel";
            panelCarrusel.Size = new Size(698, 258);
            panelCarrusel.TabIndex = 0;
            // 
            // productoCard1
            // 
            productoCard1.BackColor = Color.White;
            productoCard1.Location = new Point(37, 9);
            productoCard1.Name = "productoCard1";
            productoCard1.Size = new Size(211, 242);
            productoCard1.TabIndex = 0;
            // 
            // panelLista
            // 
            panelLista.AutoScroll = true;
            panelLista.BackColor = Color.White;
            panelLista.Controls.Add(productRow1);
            panelLista.Location = new Point(756, 81);
            panelLista.Name = "panelLista";
            panelLista.Size = new Size(296, 424);
            panelLista.TabIndex = 1;
            // 
            // productRow1
            // 
            productRow1.BackColor = Color.White;
            productRow1.Dock = DockStyle.Top;
            productRow1.Location = new Point(0, 0);
            productRow1.Name = "productRow1";
            productRow1.Size = new Size(296, 40);
            productRow1.TabIndex = 0;
            productRow1.Load += productRow1_Load;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(793, 41);
            label1.Name = "label1";
            label1.Size = new Size(225, 30);
            label1.TabIndex = 2;
            label1.Text = "Productos Agregados";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            button3.BackColor = Color.Red;
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(756, 517);
            button3.Name = "button3";
            button3.Size = new Size(296, 32);
            button3.TabIndex = 3;
            button3.Text = "Eliminar Productos";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Chartreuse;
            button4.Cursor = Cursors.Hand;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(756, 555);
            button4.Name = "button4";
            button4.Size = new Size(296, 32);
            button4.TabIndex = 4;
            button4.Text = "Crear Pedido";
            button4.UseVisualStyleBackColor = false;
            // 
            // UIvendedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            BackgroundImage = Properties.Resources.VENDEDOR__2_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1067, 637);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(panelLista);
            Controls.Add(panelContenedor);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UIvendedor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VENDEDOR";
            Load += UIvendedor_Load;
            panelContenedor.ResumeLayout(false);
            panelCarrusel.ResumeLayout(false);
            panelLista.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelContenedor;
        private Panel panelCarrusel;
        private Button button2;
        private Button button1;
        private ProductoCard productoCard1;
        private Panel panelLista;
        private Label label1;
        private Button button3;
        private Button button4;
        private ProductRow productRow1;
    }
}