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
    public partial class CambiarOrigen : Form
    {
        public string origenNuevo;
        public string origenAnterior;
        public CambiarOrigen(string origen)
        {
            InitializeComponent();
            origenAnterior = origen;
        }

        private void CambiarOrigen_Load(object sender, EventArgs e)
        {
            DataTable puertosDesde = Conexion.getInstance().conseguirTabla(Conexion.Tabla.Puerto, null);
            comboBoxOrigen.DataSource = puertosDesde;
            comboBoxOrigen.ValueMember = "Nombre";
            comboBoxOrigen.DisplayMember = "Nombre";
            comboBoxOrigen.SelectedValue = origenAnterior;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            origenNuevo = comboBoxOrigen.Text;
        }
    }
}
