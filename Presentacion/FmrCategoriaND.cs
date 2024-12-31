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
    public partial class FmrCategoriaND : Form
    {
        bool Editar = false;
        bool Nuevo = false;
        public FmrCategoriaND()
        {
            InitializeComponent();
            this.MostrarGrid();
        }

        private string Validation()
        {
            CategoriaMD categoriaMD = new CategoriaMD();
            foreach(var item in categoriaMD.Get())
            {
                if (item.Nombre_Categoria.ToUpper() == txt_nombre.Text.ToUpper()) return "Ya existe una categoria con ese nombre";
            }
            if (string.IsNullOrEmpty(txt_nombre.Text) || string.IsNullOrEmpty(txt_url.Text)) return "no";
            return "si";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CategoriaMD categoriaMD = new CategoriaMD();
            if (Validation() == "si")
            {
                if (Nuevo)
                {
                    if (categoriaMD.Add(txt_nombre.Text.ToUpper(), txt_url.Text.Trim()))
                    {
                        MessageBox.Show("Se ingreso correctamente");
                        this.MostrarGrid();
                        tabControl1.SelectedIndex = 0;
                        txt_id.Clear();
                        txt_nombre.Clear();
                        txt_url.Clear();
                        this.Nuevo = false;
                        this.button1.Enabled = false;

                    }
                    else MessageBox.Show("No se pudo ingresar");
                }else if (Editar)
                {
                    if (categoriaMD.Update(txt_nombre.Text.ToUpper(), txt_url.Text.Trim(), int.Parse(txt_id.Text)))
                    {
                        MessageBox.Show("Se actualizo correctamente");
                        this.MostrarGrid();
                        tabControl1.SelectedIndex = 0;
                        txt_id.Clear();
                        txt_nombre.Clear();
                        txt_url.Clear();
                        this.Editar = false;
                        this.button1.Enabled = false;
                    }
                }
            }
            else MessageBox.Show(Validation());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txt_url_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = txt_url.Text;
        }
        private void MostrarGrid()
        {
            CategoriaMD categoriaMD = new CategoriaMD();
            this.dataGridView1.DataSource = categoriaMD.Get();
        }
        private void txt_buscador_TextChanged(object sender, EventArgs e)
        {
            CategoriaMD categoriaMD = new CategoriaMD();
            this.dataGridView1.DataSource = categoriaMD.Get(txt_buscador.Text.ToUpper());
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.MostrarGrid();
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
        private void button5_Click(object sender, EventArgs e)
        {
            this.Editar = true;
            CategoriaMD categoriaMD = new CategoriaMD();
            int? id = GetId();
            this.button1.Enabled = true;
            var Categoria = categoriaMD.Get((int)id);
            this.tabControl1.SelectedIndex = 1;
            txt_id.Text = id.ToString();
            txt_nombre.Text = Categoria.Nombre_Categoria;
            txt_url.Text = Categoria.URL_Categoria;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Nuevo = true;
            this.Editar = false;
            this.button1.Enabled = true;
            txt_id.Clear();
            txt_nombre.Clear();
            txt_url.Clear();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            var mensaje = MessageBox.Show("¿Desea eliminar la categoria?","ELIMINAR",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if(mensaje == DialogResult.OK)
            {
                CategoriaMD categoriaMD = new CategoriaMD();
                if (categoriaMD.Delete((int)GetId()))
                {
                    MessageBox.Show("Categoria eliminada");
                    this.MostrarGrid();
                }
                else MessageBox.Show("No se pudo eliminar");
            }
        }
    }
}
