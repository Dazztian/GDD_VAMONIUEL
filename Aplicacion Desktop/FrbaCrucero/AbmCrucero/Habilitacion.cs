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
    public partial class Habilitacion : Form
    {
        int idCrucero;
        DataTable datosCrucero;
        DataTable habilitacion;
        public Habilitacion(int id)
        {
            InitializeComponent();
            idCrucero = id;
        }

        private void Habilitacion_Load(object sender, EventArgs e)
        {
            Dictionary<string,string> filtroCrucero = new Dictionary<string,string>();
            filtroCrucero.Add("ID",Conexion.Filtro.Exacto(idCrucero.ToString()));
            Dictionary<string,string> filtroHabilitacion = new Dictionary<string,string>();
            filtroHabilitacion.Add("ID_Crucero", Conexion.Filtro.Exacto(idCrucero.ToString()));
            datosCrucero = Conexion.getInstance().conseguirTabla(Conexion.Tabla.CRUCERO, filtroCrucero);
            habilitacion = Conexion.getInstance().conseguirTabla(Conexion.Tabla.Estado_del_crucero, filtroHabilitacion);
            dataGridViewEstados.DataSource = habilitacion;
            txtId.Text = datosCrucero.Rows[0].ItemArray[3].ToString();
            txtMarca.Text = datosCrucero.Rows[0].ItemArray[1].ToString();
            txtModelo.Text = datosCrucero.Rows[0].ItemArray[2].ToString();
            txtId.ReadOnly = true;
            txtMarca.ReadOnly = true;
            txtModelo.ReadOnly = true;
        }

        private void btnFueraDeServicio_Click(object sender, EventArgs e)
        {
            FueraDeServicio fueraDeServicio = new FueraDeServicio();
            DialogResult res = fueraDeServicio.ShowDialog();
            Dictionary<string, object> baja = new Dictionary<string, object>();
            if (res == DialogResult.OK)
            {
                DateTime fechaBaja = fueraDeServicio.fechaBaja;
                DateTime fechaAlta = fueraDeServicio.fechaAlta;
                baja.Add("Fecha_fuera_de_servicio", Convert.ToDateTime(fechaBaja.ToString("yyyy/MM/dd")));
                baja.Add("Fecha_reinicio_de_servicio", Convert.ToDateTime(fechaAlta.ToString("yyyy/MM/dd")));
                baja.Add("ID_Crucero",idCrucero);
                Conexion.getInstance().Insertar(Conexion.Tabla.Estado_del_crucero, baja);
                MessageBox.Show("Operacion realizada");
            }
            Habilitacion_Load(sender, e);
        }

        private void btnBajaDefinitiva_Click(object sender, EventArgs e)
        {
            BajaDefinitiva bajaDefinitiva = new BajaDefinitiva();
            DialogResult res = bajaDefinitiva.ShowDialog();
            Dictionary<string, object> baja = new Dictionary<string, object>();
            if (res == DialogResult.OK)
            {
                DateTime fechaBajaDefinitiva = bajaDefinitiva.fechaBajaDefinitiva;
                baja.Add("Fecha_baja_definitiva", Convert.ToDateTime(fechaBajaDefinitiva.ToString("yyyy/MM/dd")));
                baja.Add("ID_Crucero", idCrucero);
                Conexion.getInstance().Insertar(Conexion.Tabla.Estado_del_crucero, baja);
                MessageBox.Show("Operacion realizada");
            }
            Habilitacion_Load(sender, e);
        }
    }
}
