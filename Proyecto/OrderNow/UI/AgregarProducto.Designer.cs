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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarProducto));
            pictureBox1 = new PictureBox();
            button1 = new Button();
            pictureBox2 = new PictureBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
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
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(760, 209);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(154, 136);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Cursor = Cursors.IBeam;
            textBox1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            textBox1.ForeColor = Color.Black;
            textBox1.Location = new Point(610, 363);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(304, 20);
            textBox1.TabIndex = 3;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.White;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Cursor = Cursors.IBeam;
            textBox2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            textBox2.ForeColor = Color.Black;
            textBox2.Location = new Point(535, 424);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.Size = new Size(402, 48);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.White;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Cursor = Cursors.IBeam;
            textBox3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            textBox3.Location = new Point(593, 486);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(321, 20);
            textBox3.TabIndex = 5;
            textBox3.TextAlign = HorizontalAlignment.Center;
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
            // 
            // AgregarProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(234, 233, 232);
            ClientSize = new Size(980, 617);
            Controls.Add(button2);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(pictureBox2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
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
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button2;
    }
}