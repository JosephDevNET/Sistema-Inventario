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
	public partial class FmrMain : Form
	{
		public FmrMain()
		{
			InitializeComponent();
		}

		private void AbrirForm<MiForm>() where MiForm : Form, new()
		{
			Form formulario;
			formulario = panel_contenedor.Controls.OfType<MiForm>().FirstOrDefault();
	

			if(formulario == null)
			{
				formulario = new MiForm();
				formulario.TopLevel = false;
                panel_contenedor.Controls.Add(formulario);
                panel_contenedor.Tag = formulario;
				formulario.Show();
				formulario.BringToFront();
				formulario.FormBorderStyle = FormBorderStyle.None;
				formulario.Dock = DockStyle.Fill;
			}
			else formulario.BringToFront();
		}
        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirForm<FmrCategoria>();

        }

        private void equiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
			AbrirForm<FmrModelo>();
        }

        private void salonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
			FmrSalon fmrSalon = new FmrSalon();
			fmrSalon.Show();
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
			AbrirForm<FmrInventario>();
        }

        private void conToolStripMenuItem_Click(object sender, EventArgs e)
        {
			MessageBox.Show("Sistema desarrollado bajo el nombre de KokDev." +
				"Si presenta alguna dificultad a la hora de manejar el software o desea ingresar otra función" +
                "se puede contactar al correo: kokdevsoluciones06@@gmail.com", "INFORMACIÓN",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
