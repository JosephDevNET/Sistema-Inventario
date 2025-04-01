using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Dto.Categoria;
using BLL.Dto.NewFolder1.Producto;
using BLL.Repository;

namespace InventarioTienda.Forms.Producto
{
    public partial class FmrProducto : Form
    {
        private bool _Nuevo = false;
        private bool _Editar = false;
        ProductoRepository repository;
        public FmrProducto()
        {
            InitializeComponent();
            repository = new ProductoRepository();
            this.mostrarDatos();
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            this.llenarCategorias();
            this.llenarProveedores();
            this.habilitarCampos(false);
        }

        void mostrarDatos()
        {
            try
            {
                if (repository.GetAll() == null)
                {
                    MessageBox.Show("Error inesperado.");
                    return;
                }
                dataGridView1.DataSource = repository.GetAll();
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
            }
            catch
            {
            }
        }

        void llenarCategorias()
        {
            try
            {
                CategoriaRepository categoriaRepository = new CategoriaRepository();
                this.txt_categoria.DataSource = categoriaRepository.GetAll();
                this.txt_categoria.DisplayMember = "Nombre";
                this.txt_categoria.ValueMember = "ID";
            }
            catch
            {
            }
        }
        void llenarProveedores()
        {
            try
            {
                ProveedorRepository proveedorRepository = new ProveedorRepository();
                this.txt_proveedor.DataSource = proveedorRepository.GetAll();
                this.txt_proveedor.DisplayMember = "Nombre";
                this.txt_proveedor.ValueMember = "ID";
            }
            catch
            {
            }
        }

        void limpiarCampos()
        {
            this.txt_id.Clear();
            this.txt_nombre.Clear();
            this.txt_stock.Clear();
            this.txt_precio.Clear();
            this.txt_categoria.SelectedIndex = 0;
            this.txt_proveedor.SelectedIndex = 0;
        }
        
        void habilitarCampos(bool estado)
        {
            this.txt_nombre.Enabled = estado;
            this.txt_stock.Enabled = estado;
            this.txt_categoria.Enabled = estado;
            this.txt_proveedor.Enabled = estado;
            this.txt_precio.Enabled = estado;
        }
        private void txt_busqueda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                object result = "";
                if (RadioID.Checked)
                {
                    result = repository.GetAllFilter(p => p.ID == int.Parse(txt_busqueda.Text.Trim()));
                }
                else if (RadioNombre.Checked)
                {
                    result = repository.GetAllFilter(p => p.Nombre.ToLower().Contains(txt_busqueda.Text.ToLower()));
                }
                else if (RadioCat.Checked)
                {
                    if(int.Parse(txt_busqueda.Text) >= 0)
                        result = repository.GetAllFilter(p => p.CategoriaID.Equals(int.Parse(txt_busqueda.Text.ToLower())));
                }
                dataGridView1.DataSource = result;
            
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[7].Visible = false;
            }catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_busqueda.Clear();
            RadioID.Checked = false;
            RadioNombre.Checked = false;
            RadioCat.Checked = false;
            this.txt_busqueda.Focus();
            this.mostrarDatos();
        }

        private void BTN_NUEVO_Click(object sender, EventArgs e)
        {
            this.habilitarCampos(true);
            this.limpiarCampos();
            this.BTN_ELIMINAR.Enabled = false;
            this.BTN_GUARDAR.Enabled = true;
            this._Nuevo = true;
            this._Editar = false;
        }

        private void BTN_GUARDAR_Click(object sender, EventArgs e)
        {
            if (_Nuevo && _Editar == false)
            {
                //Si estan los campos
                if (!string.IsNullOrEmpty(txt_nombre.Text) && !string.IsNullOrEmpty(txt_stock.Text))
                {
                    var categoria = new CategoriaRepository();
                    var categoriaID = int.Parse(txt_categoria.SelectedValue.ToString());
                    var categoriaResult = categoria.GetFilter(p => p.ID == categoriaID);

                    var proveedor = new ProveedorRepository();
                    var proveedorID = int.Parse(txt_proveedor.SelectedValue.ToString());
                    var proveedorResult = proveedor.GetFilter(p => p.ID == proveedorID);

                    if(categoriaResult!=null && proveedorResult != null)
                    {
                        var n = new ProductoInsertDTO()
                        {
                            Nombre = txt_nombre.Text,
                            Stock = int.Parse(txt_stock.Text),
                            Precio = decimal.Parse(txt_precio.Text),
                            CategoriaID = categoriaID,
                            ProveedorID = proveedorID
                        };

                        var message = repository.Add(n);

                        if (message.Success)
                        {
                            this.mostrarDatos();
                            MessageBox.Show("Producto ingresado correctamente.");
                            this.BTN_GUARDAR.Enabled = false;
                            this.limpiarCampos();
                            this.habilitarCampos(false);
                        }
                        else
                        {
                            MessageBox.Show(message.ErrorMessage);
                        }

                    }
                    
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txt_nombre.Text) || !string.IsNullOrEmpty(txt_stock.Text)
                    || !string.IsNullOrEmpty(txt_precio.Text))
                {
                    var categoria = new CategoriaRepository();
                    var categoriaID = int.Parse(txt_categoria.SelectedValue.ToString());
                    var categoriaResult = categoria.GetFilter(p => p.ID == categoriaID);

                    var proveedor = new ProveedorRepository();
                    var proveedorID = int.Parse(txt_proveedor.SelectedValue.ToString());
                    var proveedorResult = proveedor.GetFilter(p => p.ID == proveedorID);

                    var prudctoEncontrado = repository.GetFilter(p => p.ID == int.Parse(txt_id.Text.Trim()));

                    if (categoriaResult != null && proveedorResult != null)
                    {
                        prudctoEncontrado.Nombre = txt_nombre.Text;
                        prudctoEncontrado.Stock = int.Parse(txt_stock.Text);
                        prudctoEncontrado.Precio = decimal.Parse(txt_precio.Text);
                        prudctoEncontrado.CategoriaID = categoriaID;
                        prudctoEncontrado.ProveedorID = proveedorID;

                        var n = new ProductoUpdateDTO()
                        {
                            ID = prudctoEncontrado.ID,
                            Nombre = prudctoEncontrado.Nombre,
                            Stock = (int)prudctoEncontrado.Stock,
                            Precio = (decimal)prudctoEncontrado.Precio,
                            CategoriaID = (int)prudctoEncontrado.CategoriaID,
                            ProveedorID = (int)prudctoEncontrado.ProveedorID
                        };

                        var message = repository.Update(n);

                        if (message.Success)
                        {
                            this.mostrarDatos();
                            MessageBox.Show("Producto actualizado correctamente.");
                            this.BTN_GUARDAR.Enabled = false;
                            this.limpiarCampos();
                            this.habilitarCampos(false);
                        }
                        else
                        {
                            MessageBox.Show(message.ErrorMessage);
                        }

                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtenemos la fila seleccionada
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                var id = selectedRow.Cells["ID"].Value;
                var nombre = selectedRow.Cells["Nombre"].Value;
                var precio = selectedRow.Cells["Precio"].Value;
                var stock = selectedRow.Cells["Stock"].Value;
                var proveedorID = selectedRow.Cells["ProveedorID"].Value;
                var categoriaID = selectedRow.Cells["CategoriaID"].Value;

                this.habilitarCampos(true);

                txt_id.Text = id.ToString();
                txt_nombre.Text = nombre.ToString();
                txt_proveedor.Text = proveedorID.ToString();
                txt_stock.Text = stock.ToString();
                txt_precio.Text = precio.ToString();
                txt_categoria.SelectedIndex = int.Parse(categoriaID.ToString()) - 1;
                txt_proveedor.SelectedIndex = int.Parse(proveedorID.ToString()) - 1;
                this._Editar = true;
                this._Nuevo = false;

                this.BTN_GUARDAR.Enabled = true;
                this.BTN_ELIMINAR.Enabled = true;
            }
        }

        private void BTN_ELIMINAR_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Desea eliminar el registro?", "¡Advertencia!", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                var message = repository.Delete(int.Parse(txt_id.Text.Trim()));
                if (message.Success)
                {
                    this.mostrarDatos();
                    this.BTN_GUARDAR.Enabled = false;
                    this.BTN_ELIMINAR.Enabled = false;
                    this.limpiarCampos();
                    this.habilitarCampos(false);
                    MessageBox.Show("Producto eliminado correctamente.");
                }
                else
                {
                    MessageBox.Show(message.ErrorMessage);
                }
            }
        }
    }
}
