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
    public partial class CambiarDestino : Form
    {
        public string destinoNuevo;
        public string destinoAnterior;
        public CambiarDestino(string destino)
        {
            InitializeComponent();
            destinoAnterior = destino;
        }

        private void CambiarDestino_Load(object sender, EventArgs e)
        {
            DataTable puertosHasta = Conexion.getInstance().conseguirTabla(Conexion.Tabla.Puerto, null);
            comboBoxDestino.DataSource = puertosHasta;
            comboBoxDestino.ValueMember = "Nombre";
            comboBoxDestino.DisplayMember = "Nombre";
            comboBoxDestino.SelectedValue = destinoAnterior;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            destinoNuevo = comboBoxDestino.Text;
        }
    }
}
