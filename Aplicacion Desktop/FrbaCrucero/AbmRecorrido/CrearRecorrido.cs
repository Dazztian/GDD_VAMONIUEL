using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class CrearRecorrido : Form
    {
        List<Tramo> tramos;

        public CrearRecorrido()
        {
            InitializeComponent();
            tramos = new List<Tramo>();
        }

        private void btnAgregarTramo_Click(object sender, EventArgs e)
        {
            Tramo tramo = new Tramo();
            tramo.origen = Convert.ToInt32(comboBoxOrigen.SelectedValue);
            tramo.destino = Convert.ToInt32(comboBoxDestino.SelectedValue);
            tramo.precio = Convert.ToDecimal(txtPrecio.Text);

            if(tramos.Count()==0 || tramos.Last().destino.ToString() == tramo.origen.ToString())
                tramos.Add(tramo);
            else
                MessageBox.Show("El puerto de origen debe ser igual al ultimo puerto de destino");

            dataGridViewTramos.DataSource = null;
            dataGridViewTramos.DataSource = tramos;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tramos.Clear();
            dataGridViewTramos.DataSource = null;
        }

        private void CrearRecorrido_Load(object sender, EventArgs e)
        {
            DataTable puertosDesde = Conexion.getInstance().conseguirTabla(Conexion.Tabla.Puerto, null);
            comboBoxOrigen.DataSource = puertosDesde;
            comboBoxOrigen.ValueMember = "ID";
            comboBoxOrigen.DisplayMember = "Nombre";
            comboBoxOrigen.SelectedIndex = -1;
            DataTable puertosHasta = Conexion.getInstance().conseguirTabla(Conexion.Tabla.Puerto, null);
            comboBoxDestino.DataSource = puertosHasta;
            comboBoxDestino.ValueMember = "ID";
            comboBoxDestino.DisplayMember = "Nombre";
            comboBoxDestino.SelectedIndex = -1;
        }
    }
}
