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
    public partial class FmrCategoria : Form
    {
        private  CategoriaMD _categoriaMD;
        public FmrCategoria()
        {
            InitializeComponent();
            _categoriaMD = new CategoriaMD();
            this.mostrar_Imagenes_Lateral();

        }

        private void mostrar_Imagenes_Lateral()
        {
            Panel_Lateral.Controls.Clear();
            var lista = _categoriaMD.Get();

            foreach(var item in lista)
            {
                var PictureImagen = new PictureBox();
                PictureImagen.ImageLocation = item.URL_Categoria;
                PictureImagen.Width = 119;
                PictureImagen.Height = 70;
                PictureImagen.SizeMode = PictureBoxSizeMode.Zoom;
                PictureImagen.Name = item.IdCategoria.ToString();
                PictureImagen.Click += CategoriaClick;
                PictureImagen.Cursor = Cursors.Hand;
                Panel_Lateral.Controls.Add(PictureImagen);
            }
        }

        private void CategoriaClick(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;
            if(clickedPictureBox != null)
            {
                this.MostrarEquipos(int.Parse(clickedPictureBox.Name));
            }
        }

        private void MostrarEquipos(int id)
        {
            ModeloMD modeloMD = new ModeloMD();
            dataGridView1.DataSource = modeloMD.GetinCat(id);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FmrCategoriaND fmrCategoriaND = new FmrCategoriaND();
            fmrCategoriaND.ShowDialog();
            this.mostrar_Imagenes_Lateral();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
