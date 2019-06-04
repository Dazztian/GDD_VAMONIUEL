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

            tramos.Add(tramo);

            dataGridViewTramos.DataSource = null;
            dataGridViewTramos.DataSource = tramos;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tramos.Clear();
            dataGridViewTramos.DataSource = null;
        }
    }
}
