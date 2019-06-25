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
    public partial class Roles : FormTemplate
    {
        private Dictionary<string, string> filtros = new Dictionary<string, string>();
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
            Roles_Load(sender, e);
        }

        private void Roles_Load(object sender, EventArgs e)
        {
            //cargar tabla roles al dgv
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Rol, ref dataGridViewRoles, null);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //llamo a modificarRol(id,nombre)
            MostrarResultado(new ModificarRol(Convert.ToInt32(dataGridViewRoles.SelectedCells[0].OwningRow.Cells["id"].Value), dataGridViewRoles.SelectedCells[0].OwningRow.Cells["nombre"].Value.ToString()).ShowDialog());
            Roles_Load(sender,e);
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            //habilitar rol seleccionado
            Conexion.getInstance().habilitar(Conexion.Tabla.Rol ,Convert.ToInt32(dataGridViewRoles.SelectedCells[0].OwningRow.Cells["id"].Value));
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Rol, ref dataGridViewRoles, null);
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            //deshabilitar rol seleccionado
            Conexion.getInstance().deshabilitar(Conexion.Tabla.Rol, Convert.ToInt32(dataGridViewRoles.SelectedCells[0].OwningRow.Cells["id"].Value));
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Rol, ref dataGridViewRoles, null);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
                filtros.Add("Nombre", Conexion.Filtro.Libre(txtNombre.Text));
            //lleno el dgv
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Rol, ref dataGridViewRoles, filtros);
            filtros.Clear();
        }
    }
}
