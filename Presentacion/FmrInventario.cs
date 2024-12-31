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
    public partial class FmrInventario : Form
    {
        bool _Nuevo = false;
        bool _Editar = false;
        public FmrInventario()
        {
            InitializeComponent();
            this.MostrarGrid();
            this.LlenarSalones();
            this.button1.Enabled = false;
            this.txt_cantidad.Enabled = false;
            this.txt_salon.Enabled = false;
            this.txt_modelo.Enabled = false;
        }
        private void MostrarGrid()
        {
            InventarioMD inventario = new InventarioMD();
            this.dataGridView1.DataSource = inventario.Get();
            this.dataGridView1.Columns["Id_Salon"].Visible = false ;
            this.dataGridView1.Columns["Id_Modelo"].Visible = false;
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
        private int? GetIdModelo()
        {
            ModeloMD modeloMD = new ModeloMD();
            var result = modeloMD.Get().Find(p => p.Nombre_Modelo == txt_modelo.Text);
            return result.Id_Modelo;
        }
        private int GetIdSalon()
        {
            SalonMD salon = new SalonMD();
            var result = salon.Get().Find(p => p.Nombre_Salon == txt_salon.Text);
            return result.Id_Salon;
        }
        private bool Validation()
        {
            if (string.IsNullOrEmpty(txt_cantidad.Text)) return false;
            return true;
        }
        private void Limpiar()
        {
            this.txt_id.Clear();
            this.txt_modelo.Text = "";
            this.txt_salon.Text = "";
            this.txt_cantidad.Clear();
            this.button1.Enabled = false;
            this.txt_cantidad.Enabled = false;
            this.txt_salon.Enabled = false;
            this.txt_modelo.Enabled = false;
        }
        private void LlenarSalones()
        {
            SalonMD salonMD = new SalonMD();
            foreach(var item in salonMD.Get())
            {
                txt_salon.Items.Add(item.Nombre_Salon);
                comboBox1.Items.Add(item.Nombre_Salon);
            }
        }
        private void LlenarModelo()
        {
            txt_modelo.Items.Clear();
            ModeloMD modelo = new ModeloMD();
            foreach (var item in modelo.Get())
            {
                txt_modelo.Items.Add(item.Nombre_Modelo);
            }
        }
        private void txt_modelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModeloMD modelo = new ModeloMD();
            var result = modelo.Get().Find(p => p.Nombre_Modelo == txt_modelo.Text);
            pictureBox1.ImageLocation = result.URL_Modelo;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this._Editar = false;
            this._Nuevo = true;
            this.txt_cantidad.Enabled = true;
            this.txt_salon.Enabled = true;
            this.txt_modelo.Enabled = true;
            this.button1.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            InventarioMD inventarioMD = new InventarioMD();
            if (Validation())
            {
                if (this._Nuevo)
                {
                    if (inventarioMD.Add(GetIdSalon(), (int)GetIdModelo(), int.Parse(txt_cantidad.Text)))
                    {
                        MessageBox.Show("Se ingreso el inventario correctamente");
                        this._Nuevo = false;
                        this.Limpiar();
                        this.MostrarGrid();
                        tabControl1.SelectedIndex = 0;
                    }else
                    {
                        MessageBox.Show("No se pudo ingresar");
                    }
                }
                if (this._Editar)
                {
                    if (inventarioMD.Update(GetIdSalon(), (int)GetIdModelo(), int.Parse(txt_cantidad.Text), (int)GetId()))
                    {
                        MessageBox.Show("Se actualizo el inventario correctamente");
                        this._Editar = false;
                        this.Limpiar();
                        this.MostrarGrid();
                        tabControl1.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar");
                    }

                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int id = (int)GetId();
            InventarioMD inventarioMD = new InventarioMD();
            var result = inventarioMD.Get().Find(p => p.Id_Inventario == id);

            ModeloMD modeloMD = new ModeloMD();
            
            this.txt_id.Text = id.ToString();
            this.txt_modelo.Text = result.Nombre_Modelo.ToString();
            this.txt_salon.Text = result.Nombre_Salon.ToString();
            this.txt_cantidad.Text = result.Cantidad.ToString();
            this.pictureBox1.ImageLocation = modeloMD.Get().Find(p => p.Nombre_Modelo == result.Nombre_Modelo).URL_Modelo;

            this._Nuevo = false;
            this._Editar = true;
            this.txt_cantidad.Enabled = true;
            this.txt_salon.Enabled = true;
            this.txt_modelo.Enabled = true;
            this.button1.Enabled = true;
            tabControl1.SelectedIndex = 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SalonMD salonMD = new SalonMD();
            var result = salonMD.Get().Find(p => p.Nombre_Salon == comboBox1.Text);

            InventarioMD inventarioMD = new InventarioMD();
            this.dataGridView1.DataSource = inventarioMD.Get(result.Id_Salon);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 1)
            {
                this.LlenarModelo();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            InventarioMD inventarioMD = new InventarioMD();
            var mensaje = MessageBox.Show("¿Desea eliminar el inventario?", "ELIMINAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (mensaje == DialogResult.OK)
            {
                if (inventarioMD.Delete((int)GetId()))
                {
                    MessageBox.Show("Se elimino correctamente");
                    this.MostrarGrid();
                }
                else MessageBox.Show("No se pudo eliminar");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
