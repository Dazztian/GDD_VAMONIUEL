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
        public Cruceros()
        {
            InitializeComponent();
        }

        private void Cruceros_Load(object sender, EventArgs e)
        {
            DataTable marca = Conexion.getInstance().conseguirTabla(Conexion.Tabla.Marca, null);
            marca.Rows.Add("Todas");
            comboBoxMarca.DataSource = marca;
            comboBoxMarca.ValueMember = "Marca";
            comboBoxMarca.DisplayMember = "Marca";
            comboBoxMarca.SelectedValue = "Todas";
        }
    }
}
