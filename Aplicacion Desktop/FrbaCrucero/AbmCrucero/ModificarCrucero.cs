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
    public partial class ModificarCrucero : Form
    {
        int idCrucero;
        DataTable datosCrucero;
        public ModificarCrucero(int id)
        {
            InitializeComponent();
            idCrucero = id;
        }

        private void ModificarCrucero_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> filtroCrucero = new Dictionary<string, string>();
            filtroCrucero.Add("ID", Conexion.Filtro.Exacto(idCrucero.ToString()));
            datosCrucero = Conexion.getInstance().conseguirTabla(Conexion.Tabla.CRUCERO, filtroCrucero);
            txtId.Text = idCrucero.ToString();
            DataTable marca = Conexion.getInstance().conseguirTabla(Conexion.Tabla.Marca, null);
            comboBoxMarca.DataSource = marca;
            comboBoxMarca.ValueMember = "Marca";
            comboBoxMarca.DisplayMember = "Marca";
            comboBoxMarca.SelectedValue = datosCrucero.Rows[0].ItemArray[1].ToString();
            txtModelo.Text = datosCrucero.Rows[0].ItemArray[2].ToString();
            if (Convert.ToBoolean(datosCrucero.Rows[0].ItemArray[4]))
            {
                txtEstado.Text = "Habilitado";
            }
            else
            {
                txtEstado.Text = "Fuera de servicio";
            }
            txtId.ReadOnly = true;
            txtEstado.ReadOnly = true;
            Dictionary<string, string> filtroCabina = new Dictionary<string, string>();
            filtroCabina.Add("ID_Crucero", Conexion.Filtro.Exacto(idCrucero.ToString()));
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Cabina, ref dataGridViewCabinas, filtroCabina);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> modificacion = new Dictionary<string, object>();
            if (!comboBoxMarca.ToString().Equals(datosCrucero.Rows[0].ItemArray[1].ToString()))
            {
                modificacion.Add("CRU_FABRICANTE", comboBoxMarca.SelectedValue.ToString());
            }
            if (!txtModelo.Text.ToString().Equals(datosCrucero.Rows[0].ItemArray[2].ToString()))
            {
                modificacion.Add("CRUCERO_MODELO", txtModelo.Text.ToString());
                
            }
            Conexion.getInstance().Modificar(idCrucero, Conexion.Tabla.CRUCERO, modificacion);
            modificacion.Clear();
            MessageBox.Show("Cambios realizados con exito");
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            ModificarCrucero_Load(sender,e);
        }
    }
}
