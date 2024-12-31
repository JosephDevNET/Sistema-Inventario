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
    public partial class FmrModelo : Form
    {
        bool _Nuevo = false;
        bool _Editar = false;
        public FmrModelo()
        {
            InitializeComponent();
            this.MostrarGrid();
            this.CategoriasLLenar();
            this.txt_marca.Enabled = false;
            this.txt_nombre.Enabled = false;
            this.txt_url.Enabled = false;
            this.txt_categorias.Enabled = false;
        }
        private void CategoriasLLenar()
        {
            CategoriaMD categoriaMD = new CategoriaMD();
            foreach(var item in categoriaMD.Get())
            {
                txt_categorias.Items.Add(item.Nombre_Categoria);
            }
        }
        private void Limpiar()
        {
            this.txt_nombre.Clear();
            this.txt_url.Clear();
            this.txt_marca.Clear();
            this.txt_id.Clear();
            txt_categorias.SelectedIndex = 1;
        }
        private bool Validation()
        {
            if (string.IsNullOrEmpty(txt_marca.Text.Trim()) || string.IsNullOrEmpty(txt_nombre.Text.Trim()) || string.IsNullOrEmpty(txt_url.Text.Trim())) return false;
            return true;
        }
        private void MostrarGrid()
        {
            ModeloMD modelo = new ModeloMD();
            this.dataGridView1.DataSource = modelo.Get();
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
        private int? GetIdCat()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString());
            }
            catch
            {
                return null;
            }

        }
        private int GetIdCategory()
        {
            CategoriaMD categoriaMD = new CategoriaMD();
            string nombre_cat = txt_categorias.Text.ToUpper();
            var result = categoriaMD.Get().Find(cat => cat.Nombre_Categoria == nombre_cat);
            return result.IdCategoria;
        }
        private void txt_categorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoriaMD categoria = new CategoriaMD();

            var result = categoria.Get(txt_categorias.Text.ToUpper());
            foreach(var item in result)
            {
                pictureBox2.ImageLocation = item.URL_Categoria;
            }
        }
        private void txt_url_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = txt_url.Text.Trim();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this._Nuevo = true;
            this.button1.Enabled = true;

            this.txt_marca.Enabled = true;
            this.txt_nombre.Enabled = true;
            this.txt_url.Enabled = true;
            this.txt_categorias.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ModeloMD modeloMD = new ModeloMD();
            if (Validation())
            {
                if (this._Nuevo)
                {
                    if (modeloMD.Add(txt_nombre.Text.ToUpper(), txt_marca.Text.ToUpper(), txt_url.Text.Trim(), GetIdCategory()))
                    {
                        MessageBox.Show("Se ingreso correctamente el modelo");
                        this._Nuevo = false;
                        this.button1.Enabled = false;
                        this.MostrarGrid();
                        this.Limpiar();
                        tabControl1.SelectedIndex = 0;
                    }
                    else MessageBox.Show("No se actualizo el modelo", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                }
                if (this._Editar)
                {
                    if (modeloMD.Update(txt_nombre.Text.ToUpper(), txt_marca.Text.ToUpper(), txt_url.Text.Trim(), GetIdCategory(), (int)GetId()))
                    {
                        MessageBox.Show("Se actualizo correctamente el modelo");
                        this._Nuevo = false;
                        this.button1.Enabled = false;
                        this.MostrarGrid();
                        this.Limpiar();
                        tabControl1.SelectedIndex = 0;
                    }
                    else MessageBox.Show("No se actualizo el modelo", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                }
            }
            else MessageBox.Show("Faltan campos!");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this._Editar = true;
            this._Nuevo = false;

            this.txt_marca.Enabled = true;
            this.txt_nombre.Enabled = true;
            this.txt_url.Enabled = true;
            this.txt_categorias.Enabled = true;

            int idCat = (int) GetIdCat();
            CategoriaMD categoriaMD = new CategoriaMD();
            var catencontrado = categoriaMD.Get(idCat);

            int id = (int)GetId();
            ModeloMD modeloMD = new ModeloMD();
            var result = modeloMD.Get(id);
            txt_id.Text = id.ToString();
            txt_nombre.Text = result.Nombre_Modelo;
            txt_marca.Text = result.Marca;
            txt_url.Text = result.URL_Modelo;
            txt_categorias.Text = catencontrado.Nombre_Categoria;
            tabControl1.SelectedIndex = 1;
            this.button1.Enabled = true;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            int id = (int)GetId();
            ModeloMD modeloMD = new ModeloMD();
            var mensaje = MessageBox.Show("Deseas eliminar el modelo","Eliminar",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if(mensaje == DialogResult.OK)
            {
                if (modeloMD.Delete(id))
                {
                    MessageBox.Show("Se elimino correctamente el modelo");
                    this.MostrarGrid();
                }
                else MessageBox.Show("No se pudo eliminar el modelo");
            }
        }

        private void txt_buscador_TextChanged(object sender, EventArgs e)
        {
            ModeloMD modeloMD = new ModeloMD();
            this.dataGridView1.DataSource = modeloMD.Get(txt_buscador.Text.ToUpper());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.MostrarGrid();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
