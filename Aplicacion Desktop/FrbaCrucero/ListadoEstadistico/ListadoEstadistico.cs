using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.ListadoEstadistico
{
    public partial class ListadoEstadistico : Form
    {
        public ListadoEstadistico()
        {
            InitializeComponent();
        }

        private void ListadoEstadistico_Load(object sender, EventArgs e)
        {

        }

        private void btnTop5Pasajes_Click(object sender, EventArgs e)
        {
          
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.top5Pasajes, ref dgv, null);
            lblPiola.Text = "Top 5 de los recorridos con más pasajes comprados.";
        }

        private void btnTop5CabinasLibres_Click(object sender, EventArgs e)
        {
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.top5CabinasLibres, ref dgv, null);
            lblPiola.Text = "Top 5 de los recorridos con más cabinas libres en cada uno de los viajes realizados.";
        }

        private void btnTop5CrucerosDeshabilitados_Click(object sender, EventArgs e)
        {
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.top5CrucerosDeshabilitados, ref dgv, null);
            lblPiola.Text = "Top 5 de los cruceros con mayor cantidad de días fuera de servicio.";
        }
    }
}
