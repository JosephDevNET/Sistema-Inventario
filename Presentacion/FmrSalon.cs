using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FmrSalon : Form
    {
        bool _Nuevo = false;
        bool _Editar = false;
        public FmrSalon()
        {
            InitializeComponent();
            this.MostrarGrid();
        }

        private void MostrarGrid()
        {
            SalonMD salon = new SalonMD();
            this.dataGridView1.DataSource = salon.Get();
        }
        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }
        private bool Validation()
        {
            if (string.IsNullOrEmpty(txt_nombre.Text) || string.IsNullOrEmpty(txt_ubicacion.Text)) return false;
            return true;
        }
        private void Limpiar()
        {
            this.txt_id.Clear();
            this.txt_nombre.Clear();
            this.txt_ubicacion.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SalonMD salon = new SalonMD();
            if(Validation())
            {
                if(this._Nuevo)
                {
                    if (salon.Add(txt_nombre.Text, txt_ubicacion.Text))
                    {
                        this._Nuevo = false;
                        MessageBox.Show("Salon ingresado correctamente");
                        this.Limpiar();
                        tabControl1.SelectedIndex = 0;
                        this.button1.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("No se ingreso el salon", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                if (this._Editar)
                {
                    if (salon.Update(txt_nombre.Text, txt_ubicacion.Text.ToUpper(), int.Parse(txt_id.Text.Trim().ToUpper())))
                    {
                        this._Editar = false;
                        MessageBox.Show("Salon actualizado correctamente");
                        this.Limpiar();
                        tabControl1.SelectedIndex = 0;
                        this.button1.Enabled = false;
                    }
                    else MessageBox.Show("No se actualizo el salon", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                this.MostrarGrid();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this._Editar = false;
            this._Nuevo = true;
            this.button1.Enabled = true;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
            this._Editar = true;
            this._Nuevo = false;
            txt_id.Text = GetId().ToString();
            SalonMD salonMD = new SalonMD();
            var salon = salonMD.Get((int)GetId());
            txt_nombre.Text = salon.Nombre_Salon;
            txt_ubicacion.Text = salon.Ubicacion;
            tabControl1.SelectedIndex = 1;

        }
        private void button6_Click(object sender, EventArgs e)
        {
            var opcion = MessageBox.Show("Desea eliminar el salon","Eliminar",MessageBoxButtons.OKCancel);
            if(opcion == DialogResult.OK)
            {
                SalonMD salonMD = new SalonMD();
                int id = (int)GetId();
                if (salonMD.Delete(id))
                {
                    MessageBox.Show("Salon eliminado correctamente");
                    this.MostrarGrid();
                }
                else
                {
                    MessageBox.Show("No se elimino el salon", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    this.MostrarGrid();
                }
            }
        }
        private void txt_buscador_TextChanged(object sender, EventArgs e)
        {
            SalonMD salon = new SalonMD();
            this.dataGridView1.DataSource = salon.Get(txt_buscador.Text.ToUpper());
        }
    }
}
