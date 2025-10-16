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
            label1 = new Label();
            button3 = new Button();
            button4 = new Button();
            dataGridView1 = new DataGridView();
            panelCarrusel = new FlowLayoutPanel();
            label2 = new Label();
            txtMesa = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
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
            button3.Click += button3_Click;
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
            button4.Click += button4_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(756, 95);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(296, 332);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // panelCarrusel
            // 
            panelCarrusel.Location = new Point(56, 341);
            panelCarrusel.Name = "panelCarrusel";
            panelCarrusel.Size = new Size(663, 233);
            panelCarrusel.TabIndex = 6;
            panelCarrusel.Paint += panelCarrusel_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(756, 446);
            label2.Name = "label2";
            label2.Size = new Size(70, 30);
            label2.TabIndex = 7;
            label2.Text = "Mesa:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // txtMesa
            // 
            txtMesa.Location = new Point(832, 453);
            txtMesa.Name = "txtMesa";
            txtMesa.Size = new Size(220, 23);
            txtMesa.TabIndex = 8;
            txtMesa.TextAlign = HorizontalAlignment.Center;
            txtMesa.TextChanged += textBox1_TextChanged;
            // 
            // UIvendedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            BackgroundImage = Properties.Resources.VENDEDOR__2_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1067, 637);
            Controls.Add(txtMesa);
            Controls.Add(label2);
            Controls.Add(panelCarrusel);
            Controls.Add(dataGridView1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UIvendedor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VENDEDOR";
            Load += UIvendedor_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button button3;
        private Button button4;
        private DataGridView dataGridView1;
        private ProductoCard productoCard1;
        private FlowLayoutPanel panelCarrusel;
        private Label label2;
        private TextBox txtMesa;
    }
}