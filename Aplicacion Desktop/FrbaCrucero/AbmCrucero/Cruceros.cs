using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmCrucero
{
    public partial class Cruceros : Form
    {
        private Dictionary<string, string> filtros = new Dictionary<string, string>();
        public Cruceros()
        {
            InitializeComponent();
        }

        private void Cruceros_Load(object sender, EventArgs e)
        {
            DataTable marca = Conexion.getInstance().conseguirTabla(Conexion.Tabla.Marca, null);
            comboBoxMarca.DataSource = marca;
            comboBoxMarca.ValueMember = "Marca";
            comboBoxMarca.DisplayMember = "Marca";
            comboBoxMarca.SelectedIndex = -1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBoxMarca.Text))
                filtros.Add("CRU_FABRICANTE", Conexion.Filtro.Exacto(comboBoxMarca.Text));
            if (!string.IsNullOrEmpty(txtModelo.Text))
                filtros.Add("CRUCERO_MODELO", Conexion.Filtro.Libre(txtModelo.Text));
            //lleno el dgv
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.CRUCERO, ref dataGridViewCruceros , filtros);
            filtros.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new CrearCrucero().ShowDialog();
        }

        private void btnHabilitacion_Click(object sender, EventArgs e)
        {
            if (dataGridViewCruceros.Rows.Count.Equals(0))
            {
                MessageBox.Show("Debe seleccionar un crucero");
            }
            else
            {
                new Habilitacion(Convert.ToInt32(dataGridViewCruceros.SelectedCells[0].OwningRow.Cells["ID"].Value)).ShowDialog();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewCruceros.Rows.Count.Equals(0))
            {
                MessageBox.Show("Debe seleccionar un crucero");
            }
            else
            {
                new ModificarCrucero(Convert.ToInt32(dataGridViewCruceros.SelectedCells[0].OwningRow.Cells["ID"].Value)).ShowDialog();
            }
        }
    }
}
