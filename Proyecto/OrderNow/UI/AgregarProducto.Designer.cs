namespace OrderNow
{
    partial class AgregarProducto
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
            pictureBox1 = new PictureBox();
            button1 = new Button();
            pictureBox2 = new PictureBox();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            txtPrecio = new TextBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Green_and_White_Elegant_Symmetrical_Login_Page_Desktop_Prototype__12_;
            pictureBox1.Location = new Point(0, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(981, 614);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(39, 39, 39);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(515, 247);
            button1.Name = "button1";
            button1.Size = new Size(204, 38);
            button1.TabIndex = 1;
            button1.Text = "Selecciona una imagen";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(760, 209);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(154, 136);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.None;
            txtNombre.Cursor = Cursors.IBeam;
            txtNombre.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            txtNombre.ForeColor = Color.Black;
            txtNombre.Location = new Point(610, 363);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(304, 20);
            txtNombre.TabIndex = 3;
            txtNombre.TextAlign = HorizontalAlignment.Center;
            txtNombre.TextChanged += textBox1_TextChanged;
            // 
            // txtDescripcion
            // 
            txtDescripcion.BackColor = Color.White;
            txtDescripcion.BorderStyle = BorderStyle.None;
            txtDescripcion.Cursor = Cursors.IBeam;
            txtDescripcion.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            txtDescripcion.ForeColor = Color.Black;
            txtDescripcion.Location = new Point(535, 424);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(402, 48);
            txtDescripcion.TabIndex = 4;
            txtDescripcion.TextChanged += textBox2_TextChanged;
            // 
            // txtPrecio
            // 
            txtPrecio.BackColor = Color.White;
            txtPrecio.BorderStyle = BorderStyle.None;
            txtPrecio.Cursor = Cursors.IBeam;
            txtPrecio.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            txtPrecio.Location = new Point(593, 486);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(321, 20);
            txtPrecio.TabIndex = 5;
            txtPrecio.TextAlign = HorizontalAlignment.Center;
            txtPrecio.TextChanged += textBox3_TextChanged;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(39, 39, 39);
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(619, 527);
            button2.Name = "button2";
            button2.Size = new Size(204, 37);
            button2.TabIndex = 6;
            button2.Text = "Guardar Producto";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // AgregarProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(234, 233, 232);
            ClientSize = new Size(980, 617);
            Controls.Add(button2);
            Controls.Add(txtPrecio);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombre);
            Controls.Add(pictureBox2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AgregarProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AGREGAR PRODUCTO";
            Load += AgregarProducto_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private PictureBox pictureBox2;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private TextBox txtPrecio;
        private Button button2;
    }
}