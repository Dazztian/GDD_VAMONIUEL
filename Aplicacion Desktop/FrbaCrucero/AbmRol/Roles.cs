using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmRol
{
    public partial class Roles : Form//Template
    {
        public Roles()
        {
            InitializeComponent();
        }

        private void MostrarResultado(DialogResult dr)
        {
            if (dr == DialogResult.OK)
                MessageBox.Show("Se actualizó correctamente");
            if (dr == DialogResult.Abort)
                MessageBox.Show("Se encontró un error fatal y se abortó la actualización");
            if (dr == DialogResult.Cancel)
                MessageBox.Show("Se canceló la solicitud");
        }

        private void btnAgregarRol_Click(object sender, EventArgs e)
        {
            MostrarResultado(new CrearRol().ShowDialog());
        }

        private void Roles_Load(object sender, EventArgs e)
        {
            //cargar tabla roles al dgv
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //llamo a modificarRol(id,nombre)
            MostrarResultado(new ModificarRol(Convert.ToInt32(dataGridViewRoles.SelectedCells[0].OwningRow.Cells["id"].Value), dataGridViewRoles.SelectedCells[0].OwningRow.Cells["nombre"].Value.ToString()).ShowDialog());
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            //habilitar rol seleccionado
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            //deshabilitar rol seleccionado
        }
    }
}
