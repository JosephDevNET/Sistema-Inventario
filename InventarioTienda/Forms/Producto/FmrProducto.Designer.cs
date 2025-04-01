namespace InventarioTienda.Forms.Producto
{
    partial class FmrProducto
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.RadioCat = new System.Windows.Forms.RadioButton();
            this.RadioID = new System.Windows.Forms.RadioButton();
            this.RadioNombre = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.BTN_ELIMINAR = new System.Windows.Forms.Button();
            this.BTN_NUEVO = new System.Windows.Forms.Button();
            this.BTN_GUARDAR = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.txt_busqueda = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_stock = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_categoria = new System.Windows.Forms.ComboBox();
            this.txt_proveedor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_precio = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.RadioCat);
            this.panel1.Controls.Add(this.RadioID);
            this.panel1.Controls.Add(this.RadioNombre);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txt_busqueda);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 515);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(884, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Refrescar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RadioCat
            // 
            this.RadioCat.AutoSize = true;
            this.RadioCat.Location = new System.Drawing.Point(797, 22);
            this.RadioCat.Name = "RadioCat";
            this.RadioCat.Size = new System.Drawing.Size(70, 17);
            this.RadioCat.TabIndex = 5;
            this.RadioCat.TabStop = true;
            this.RadioCat.Text = "Categoria";
            this.RadioCat.UseVisualStyleBackColor = true;
            // 
            // RadioID
            // 
            this.RadioID.AutoSize = true;
            this.RadioID.Location = new System.Drawing.Point(689, 22);
            this.RadioID.Name = "RadioID";
            this.RadioID.Size = new System.Drawing.Size(34, 17);
            this.RadioID.TabIndex = 4;
            this.RadioID.TabStop = true;
            this.RadioID.Text = "Id";
            this.RadioID.UseVisualStyleBackColor = true;
            // 
            // RadioNombre
            // 
            this.RadioNombre.AutoSize = true;
            this.RadioNombre.Location = new System.Drawing.Point(729, 22);
            this.RadioNombre.Name = "RadioNombre";
            this.RadioNombre.Size = new System.Drawing.Size(62, 17);
            this.RadioNombre.TabIndex = 3;
            this.RadioNombre.TabStop = true;
            this.RadioNombre.Text = "Nombre";
            this.RadioNombre.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_precio);
            this.groupBox1.Controls.Add(this.txt_proveedor);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_categoria);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_stock);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_id);
            this.groupBox1.Controls.Add(this.BTN_ELIMINAR);
            this.groupBox1.Controls.Add(this.BTN_NUEVO);
            this.groupBox1.Controls.Add(this.BTN_GUARDAR);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_nombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 484);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Id";
            // 
            // txt_id
            // 
            this.txt_id.Enabled = false;
            this.txt_id.Location = new System.Drawing.Point(6, 49);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(63, 20);
            this.txt_id.TabIndex = 7;
            // 
            // BTN_ELIMINAR
            // 
            this.BTN_ELIMINAR.Enabled = false;
            this.BTN_ELIMINAR.Location = new System.Drawing.Point(170, 455);
            this.BTN_ELIMINAR.Name = "BTN_ELIMINAR";
            this.BTN_ELIMINAR.Size = new System.Drawing.Size(75, 23);
            this.BTN_ELIMINAR.TabIndex = 6;
            this.BTN_ELIMINAR.Text = "&Eliminar";
            this.BTN_ELIMINAR.UseVisualStyleBackColor = true;
            this.BTN_ELIMINAR.Click += new System.EventHandler(this.BTN_ELIMINAR_Click);
            // 
            // BTN_NUEVO
            // 
            this.BTN_NUEVO.Location = new System.Drawing.Point(8, 455);
            this.BTN_NUEVO.Name = "BTN_NUEVO";
            this.BTN_NUEVO.Size = new System.Drawing.Size(75, 23);
            this.BTN_NUEVO.TabIndex = 5;
            this.BTN_NUEVO.Text = "&Nuevo";
            this.BTN_NUEVO.UseVisualStyleBackColor = true;
            this.BTN_NUEVO.Click += new System.EventHandler(this.BTN_NUEVO_Click);
            // 
            // BTN_GUARDAR
            // 
            this.BTN_GUARDAR.Enabled = false;
            this.BTN_GUARDAR.Location = new System.Drawing.Point(89, 455);
            this.BTN_GUARDAR.Name = "BTN_GUARDAR";
            this.BTN_GUARDAR.Size = new System.Drawing.Size(75, 23);
            this.BTN_GUARDAR.TabIndex = 4;
            this.BTN_GUARDAR.Text = "&Guardar";
            this.BTN_GUARDAR.UseVisualStyleBackColor = true;
            this.BTN_GUARDAR.Click += new System.EventHandler(this.BTN_GUARDAR_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre de producto";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(6, 97);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(185, 20);
            this.txt_nombre.TabIndex = 0;
            // 
            // txt_busqueda
            // 
            this.txt_busqueda.Location = new System.Drawing.Point(272, 19);
            this.txt_busqueda.Name = "txt_busqueda";
            this.txt_busqueda.Size = new System.Drawing.Size(396, 20);
            this.txt_busqueda.TabIndex = 1;
            this.txt_busqueda.TextChanged += new System.EventHandler(this.txt_busqueda_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(272, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(683, 451);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Stock";
            // 
            // txt_stock
            // 
            this.txt_stock.Location = new System.Drawing.Point(6, 191);
            this.txt_stock.Name = "txt_stock";
            this.txt_stock.Size = new System.Drawing.Size(74, 20);
            this.txt_stock.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Categoria";
            // 
            // txt_categoria
            // 
            this.txt_categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_categoria.FormattingEnabled = true;
            this.txt_categoria.Location = new System.Drawing.Point(6, 253);
            this.txt_categoria.Name = "txt_categoria";
            this.txt_categoria.Size = new System.Drawing.Size(121, 21);
            this.txt_categoria.TabIndex = 13;
            // 
            // txt_proveedor
            // 
            this.txt_proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_proveedor.FormattingEnabled = true;
            this.txt_proveedor.Location = new System.Drawing.Point(9, 303);
            this.txt_proveedor.Name = "txt_proveedor";
            this.txt_proveedor.Size = new System.Drawing.Size(121, 21);
            this.txt_proveedor.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Proveedor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Precio";
            // 
            // txt_precio
            // 
            this.txt_precio.Location = new System.Drawing.Point(6, 144);
            this.txt_precio.Name = "txt_precio";
            this.txt_precio.Size = new System.Drawing.Size(74, 20);
            this.txt_precio.TabIndex = 16;
            // 
            // FmrProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 515);
            this.Controls.Add(this.panel1);
            this.Name = "FmrProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FmrProducto";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton RadioCat;
        private System.Windows.Forms.RadioButton RadioID;
        private System.Windows.Forms.RadioButton RadioNombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Button BTN_ELIMINAR;
        private System.Windows.Forms.Button BTN_NUEVO;
        private System.Windows.Forms.Button BTN_GUARDAR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_busqueda;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox txt_categoria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_stock;
        private System.Windows.Forms.ComboBox txt_proveedor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_precio;
    }
}