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
using BLL.Dto.Proveedor;
using BLL.Repository;

namespace InventarioTienda.Forms.Proveedor
{
    public partial class FmrProveedor : Form
    {
        private bool _Nuevo = false;
        private bool _Editar = false;
        ProveedorRepository repository;
        public FmrProveedor()
        {
            repository = new ProveedorRepository();
            InitializeComponent();
            this.mostrarDatos();
            //this.desactBusqueda();
            this.ha_inhabilitarCampos(false);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            mostrarDatos();
        }
        void desactBusqueda()
        {
            if(RadioTelefono.Checked || RadioNombre.Checked || RadioID.Checked)
            {
                this.txt_busqueda.Enabled = true;
            }
            else
            {
                this.txt_busqueda.Enabled = false;
            }
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
                if (dataGridView1.Columns.Count == 8)
                    dataGridView1.Columns[7].Visible = false;
            }catch
            {

            }
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
                else if (RadioTelefono.Checked)
                {
                    result = repository.GetAllFilter(p => p.Telefono.ToLower().Trim().Contains(txt_busqueda.Text.ToLower().Trim()));
                }
                dataGridView1.DataSource = result;
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
            RadioTelefono.Checked = false;
            this.txt_busqueda.Focus();
            this.mostrarDatos();
        }
        void limpiarCampos()
        {
            this.txt_id.Clear();
            this.txt_nombre.Clear();
            this.txt_contacto.Clear();
            this.txt_direccion.Clear();
            this.txt_email.Clear();
            this.txt_id.Clear();
            this.txt_telefono.Clear();
            this.txt_email.Clear();
        }
        void ha_inhabilitarCampos(bool habilitar)
        {
            this.txt_nombre.Enabled = habilitar;
            this.txt_contacto.Enabled = habilitar;
            this.txt_direccion.Enabled = habilitar;
            this.txt_email.Enabled = habilitar;
            this.txt_telefono.Enabled = habilitar;
            this.txt_email.Enabled = habilitar;
        }
        private void BTN_NUEVO_Click(object sender, EventArgs e)
        {
            this.ha_inhabilitarCampos(true);
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
                if (!string.IsNullOrEmpty(txt_nombre.Text) && !string.IsNullOrEmpty(txt_telefono.Text)
                    && !string.IsNullOrEmpty(txt_email.Text) && !string.IsNullOrEmpty(txt_direccion.Text)
                    && !string.IsNullOrEmpty(txt_contacto.Text))
                {
                    var n = new ProveedorInsertDTO()
                    {
                        Nombre = txt_nombre.Text,
                        Contacto = txt_contacto.Text,
                        Telefono = txt_telefono.Text,
                        Email = txt_email.Text,
                        Direccion = txt_direccion.Text,
                    };
                    var message = repository.Add(n);
                    if (message.Success)
                    {
                        this.mostrarDatos();
                        MessageBox.Show("Proveedor ingresado correctamente.");
                        this.BTN_GUARDAR.Enabled = false;
                        this.limpiarCampos();
                        this.ha_inhabilitarCampos(false);
                    }
                    else
                    {
                        MessageBox.Show(message.ErrorMessage);
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txt_nombre.Text) || !string.IsNullOrEmpty(txt_telefono.Text)
                    || !string.IsNullOrEmpty(txt_email.Text) || !string.IsNullOrEmpty(txt_direccion.Text)
                    || !string.IsNullOrEmpty(txt_contacto.Text))
                {
                    var provEncontrado = repository.GetFilter(p => p.ID == int.Parse(txt_id.Text.Trim()));
                    if (provEncontrado != null)
                    {
                        provEncontrado.Nombre = txt_nombre.Text;
                        provEncontrado.Contacto = txt_contacto.Text;
                        provEncontrado.Telefono = txt_telefono.Text;
                        provEncontrado.Email = txt_email.Text;
                        provEncontrado.Direccion = txt_direccion.Text;
                        var updateProv = new ProveedorUpdateDTO()
                        {
                            ID = provEncontrado.ID,
                            Nombre = provEncontrado.Nombre,
                            Contacto = provEncontrado.Contacto,
                            Telefono = provEncontrado.Telefono,
                            Email = provEncontrado.Email,
                            Direccion = provEncontrado.Direccion
                        };

                        var message = repository.Update(updateProv);

                        if (message.Success)
                        {
                            this.mostrarDatos();
                            this.BTN_GUARDAR.Enabled = false;
                            this.limpiarCampos();
                            this.ha_inhabilitarCampos(false);
                            MessageBox.Show("Proveedor actualizado correctamente.");
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
                var contacot = selectedRow.Cells["Contacto"].Value;
                var telefono = selectedRow.Cells["Telefono"].Value;
                var email = selectedRow.Cells["Email"].Value;
                var direccion = selectedRow.Cells["Direccion"].Value;

                this.ha_inhabilitarCampos(true);    

                txt_nombre.Text = nombre.ToString();
                txt_contacto.Text = contacot.ToString();
                txt_direccion.Text = direccion.ToString();
                txt_email.Text = email.ToString();
                txt_telefono.Text = telefono.ToString();
                txt_id.Text = id.ToString();

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
                    this.ha_inhabilitarCampos(false);
                    MessageBox.Show("Proveedor eliminado correctamente.");
                }
                else
                {
                    MessageBox.Show(message.ErrorMessage);
                }
            }
        }
    }
}
