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
using BLL.Repository;
using DAL.Db;

namespace InventarioTienda.Forms.Categoria
{
    public partial class FmrCategoria : Form
    {
        private bool _Nuevo = false;
        private bool _Editar = false;
        CategoriaRepository repository;
        public FmrCategoria()
        {
            InitializeComponent();
            repository = new CategoriaRepository();
            this.txt_busqueda.Focus();
            this.mostrarDatos();
            this.txt_nombre.Enabled = false;
            this.txt_descripcion.Enabled = false;
        }

        void mostrarDatos()
        {
            if (repository.GetAll() == null)
            {
                MessageBox.Show("Error inesperado.");
                return;
            }

                dataGridView1.DataSource = repository.GetAll();
                if (dataGridView1.Columns.Count == 4)
                    dataGridView1.Columns[3].Visible = false;
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
                else if (RadioDescrip.Checked)
                {
                    result = repository.GetAllFilter(p => p.Descripcion.ToLower().Contains(txt_busqueda.Text.ToLower()));
                }
                dataGridView1.DataSource = result;
                if (dataGridView1.Columns.Count == 4)
                    dataGridView1.Columns[3].Visible = false;
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_busqueda.Clear();
            RadioID.Checked = false;
            RadioNombre.Checked = false;
            RadioDescrip.Checked = false;
            this.txt_busqueda.Focus();
            this.mostrarDatos();
        }

        private void BTN_NUEVO_Click(object sender, EventArgs e)
        {
            this.txt_nombre.Enabled = true;
            this.txt_descripcion.Enabled = true;
            this.txt_id.Clear();
            this.txt_nombre.Clear();
            this.txt_descripcion.Clear();
            this.BTN_ELIMINAR.Enabled = false;
            this.BTN_GUARDAR.Enabled = true;
            this._Nuevo = true;
            this._Editar = false;
        }

        private void BTN_GUARDAR_Click(object sender, EventArgs e)
        {
            if(_Nuevo && _Editar == false)
            {
                //Si estan los campos
                if(!string.IsNullOrEmpty(txt_nombre.Text) && !string.IsNullOrEmpty(txt_descripcion.Text))
                {
                    var n = new CategoriaInsertDTO()
                    {
                        Nombre = txt_nombre.Text,
                        Descripcion = txt_descripcion.Text,
                    };
                    var message = repository.Add(n);
                    if (message.Success)
                    {
                        this.mostrarDatos();
                        MessageBox.Show("Categoria ingresada correctamente.");
                        this.BTN_GUARDAR.Enabled=false;
                        this.txt_id.Clear();
                        this.txt_nombre.Clear();
                        this.txt_descripcion.Clear();
                        this.txt_nombre.Enabled = false;
                        this.txt_descripcion.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show(message.ErrorMessage);
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txt_nombre.Text) || !string.IsNullOrEmpty(txt_descripcion.Text))
                {
                    var catEncontrado = repository.GetFilter(p => p.ID == int.Parse(txt_id.Text.Trim()));
                    if(catEncontrado != null)
                    {
                        catEncontrado.Nombre = txt_nombre.Text;
                        catEncontrado.Descripcion = txt_descripcion.Text;
                        var updateCat = new CategoriaUpdateDTO()
                        {
                            ID = catEncontrado.ID,
                            Nombre = catEncontrado.Nombre,
                            Descripcion = catEncontrado.Descripcion
                        };

                        var message = repository.Update(updateCat);

                        if(message.Success)
                        {
                            this.mostrarDatos();
                            this.BTN_GUARDAR.Enabled = false;
                            this.txt_id.Clear();
                            this.txt_nombre.Clear();
                            this.txt_descripcion.Clear();
                            this.txt_nombre.Enabled = false;
                            this.txt_descripcion.Enabled = false;
                            MessageBox.Show("Categoria actualizado correctamente.");
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
                var descripcion = selectedRow.Cells["Descripcion"].Value;

                this.txt_nombre.Enabled = true;
                this.txt_descripcion.Enabled = true;

                txt_nombre.Text = nombre.ToString();
                txt_descripcion.Text = descripcion.ToString();
                txt_id.Text = id.ToString();
                this._Editar = true;
                this._Nuevo = false;

                this.BTN_GUARDAR.Enabled = true;
                this.BTN_ELIMINAR.Enabled = true;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            mostrarDatos();
        }

        private void BTN_ELIMINAR_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Desea eliminar el registro?", "¡Advertencia!",MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                var message = repository.Delete(int.Parse(txt_id.Text.Trim()));
                if (message.Success)
                {
                    this.mostrarDatos();
                    this.BTN_GUARDAR.Enabled = false;
                    this.BTN_ELIMINAR.Enabled = false;
                    this.txt_id.Clear();
                    this.txt_nombre.Clear();
                    this.txt_descripcion.Clear();
                    this.txt_nombre.Enabled = false;
                    this.txt_descripcion.Enabled = false;
                    MessageBox.Show("Categoria eliminada correctamente.");
                }
                else
                {
                    MessageBox.Show(message.ErrorMessage);
                }
            }
        }
    }
}
