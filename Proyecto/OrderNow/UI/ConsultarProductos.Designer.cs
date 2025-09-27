namespace OrderNow
{
    partial class ConsultarProductos
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colImagen = new DataGridViewImageColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            colEditar = new DataGridViewButtonColumn();
            colEliminar = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colID, colImagen, colNombre, colDescripcion, colPrecio, colEditar, colEliminar });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = Color.White;
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(39, 39, 39);
            dataGridView1.Location = new Point(56, 224);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.DefaultCellStyle.Padding = new Padding(0, 5, 0, 5);
            dataGridView1.RowTemplate.Height = 90;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.Size = new Size(959, 374);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellMouseMove += dataGridView1_CellMouseMove;
            dataGridView1.CellPainting += dataGridView1_CellPainting;
            // 
            // colID
            // 
            colID.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colID.DefaultCellStyle = dataGridViewCellStyle2;
            colID.FillWeight = 315.950623F;
            colID.HeaderText = "ID";
            colID.Name = "colID";
            colID.Resizable = DataGridViewTriState.False;
            colID.Width = 70;
            // 
            // colImagen
            // 
            colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colImagen.FillWeight = 87.05584F;
            colImagen.HeaderText = "Imagen";
            colImagen.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colImagen.Name = "colImagen";
            colImagen.Resizable = DataGridViewTriState.False;
            colImagen.Width = 110;
            // 
            // colNombre
            // 
            colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colNombre.FillWeight = 59.398716F;
            colNombre.HeaderText = "Nombre";
            colNombre.Name = "colNombre";
            colNombre.Resizable = DataGridViewTriState.False;
            colNombre.Width = 135;
            // 
            // colDescripcion
            // 
            colDescripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            colDescripcion.DefaultCellStyle = dataGridViewCellStyle3;
            colDescripcion.FillWeight = 59.398716F;
            colDescripcion.HeaderText = "Descripcion";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.Resizable = DataGridViewTriState.False;
            colDescripcion.Width = 195;
            // 
            // colPrecio
            // 
            colPrecio.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colPrecio.FillWeight = 59.398716F;
            colPrecio.HeaderText = "Precio";
            colPrecio.Name = "colPrecio";
            colPrecio.Resizable = DataGridViewTriState.False;
            colPrecio.Width = 140;
            // 
            // colEditar
            // 
            colEditar.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(39, 39, 39);
            dataGridViewCellStyle4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(39, 39, 39);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            colEditar.DefaultCellStyle = dataGridViewCellStyle4;
            colEditar.FillWeight = 59.398716F;
            colEditar.FlatStyle = FlatStyle.Flat;
            colEditar.HeaderText = "Editar";
            colEditar.Name = "colEditar";
            colEditar.Resizable = DataGridViewTriState.False;
            colEditar.UseColumnTextForButtonValue = true;
            colEditar.Width = 157;
            // 
            // colEliminar
            // 
            colEliminar.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(39, 39, 39);
            dataGridViewCellStyle5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(39, 39, 39);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            colEliminar.DefaultCellStyle = dataGridViewCellStyle5;
            colEliminar.FillWeight = 59.398716F;
            colEliminar.FlatStyle = FlatStyle.Flat;
            colEliminar.HeaderText = "Eliminar";
            colEliminar.Name = "colEliminar";
            colEliminar.Resizable = DataGridViewTriState.False;
            colEliminar.UseColumnTextForButtonValue = true;
            colEliminar.Width = 150;
            // 
            // ConsultarProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(234, 233, 232);
            BackgroundImage = Properties.Resources.Green_and_White_Elegant_Symmetrical_Login_Page_Desktop_Prototype__14_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1067, 637);
            Controls.Add(dataGridView1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConsultarProductos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CONSULTAR PRODUCTOS";
            Load += ConsultarProductos_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewImageColumn colImagen;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colDescripcion;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewButtonColumn colEditar;
        private DataGridViewButtonColumn colEliminar;
    }
}