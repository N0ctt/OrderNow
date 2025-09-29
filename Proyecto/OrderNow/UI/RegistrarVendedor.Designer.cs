namespace OrderNow
{
    partial class RegistrarVendedor
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
            txtNombre = new TextBox();
            txtContrasena = new TextBox();
            txtConfirmarContrasena = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Green_and_White_Elegant_Symmetrical_Login_Page_Desktop_Prototype__13_;
            pictureBox1.Location = new Point(12, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(959, 617);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.White;
            txtNombre.BorderStyle = BorderStyle.None;
            txtNombre.Cursor = Cursors.IBeam;
            txtNombre.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtNombre.ForeColor = Color.Black;
            txtNombre.Location = new Point(156, 336);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(297, 22);
            txtNombre.TabIndex = 1;
            // 
            // txtContrasena
            // 
            txtContrasena.BackColor = Color.White;
            txtContrasena.BorderStyle = BorderStyle.None;
            txtContrasena.Cursor = Cursors.IBeam;
            txtContrasena.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtContrasena.ForeColor = Color.Black;
            txtContrasena.Location = new Point(178, 386);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(275, 22);
            txtContrasena.TabIndex = 2;
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // txtConfirmarContrasena
            // 
            txtConfirmarContrasena.BackColor = Color.White;
            txtConfirmarContrasena.BorderStyle = BorderStyle.None;
            txtConfirmarContrasena.Cursor = Cursors.IBeam;
            txtConfirmarContrasena.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtConfirmarContrasena.ForeColor = Color.Black;
            txtConfirmarContrasena.Location = new Point(178, 447);
            txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            txtConfirmarContrasena.Size = new Size(275, 22);
            txtConfirmarContrasena.TabIndex = 3;
            txtConfirmarContrasena.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(39, 39, 39);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(123, 508);
            button1.Name = "button1";
            button1.Size = new Size(265, 51);
            button1.TabIndex = 4;
            button1.Text = "Registrar Vendedor";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // RegistrarVendedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(234, 233, 232);
            ClientSize = new Size(993, 629);
            Controls.Add(button1);
            Controls.Add(txtConfirmarContrasena);
            Controls.Add(txtContrasena);
            Controls.Add(txtNombre);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegistrarVendedor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "REGISTRAR VENDEDOR";
            Load += RegistrarVendedor_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox txtNombre;
        private TextBox txtContrasena;
        private TextBox txtConfirmarContrasena;
        private Button button1;
    }
}