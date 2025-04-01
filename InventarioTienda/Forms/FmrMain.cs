using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventarioTienda.Forms.Categoria;
using InventarioTienda.Forms.Producto;
using InventarioTienda.Forms.Proveedor;

namespace InventarioTienda.Forms
{
    public partial class FmrMain : Form
    {
        private FmrProveedor proveedor = null;
        private FmrCategoria categoria = null;
        private FmrProducto producto = null;
        public FmrMain()
        {
            InitializeComponent();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (producto == null || producto.IsDisposed)
            {
                producto = new FmrProducto();
                producto.Show();
            }
            else
            {
                MessageBox.Show("El formulario ya está abierto.");
            }
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (categoria == null || categoria.IsDisposed)
            {
                categoria = new FmrCategoria();
                categoria.Show();
            }
            else
            {
                MessageBox.Show("El formulario ya está abierto.");
            }
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (proveedor == null || proveedor.IsDisposed)
            {
                proveedor = new FmrProveedor();
                proveedor.Show();
            }
            else
            {
                MessageBox.Show("El formulario ya está abierto.");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }
    }
}
