using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.CompraPasaje
{
    public partial class CompraReservaPasaje : Form
    {
        public CompraReservaPasaje()
        {
            InitializeComponent();
            dtpFechaviaje.MinDate = ConfigurationHelper.fechaActual;
            List<string> columnas = new List<string>();
            columnas.Add("Nombre");
            List<object> resultadoConsulta = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Puerto, columnas, null))["Nombre"]);
            resultadoConsulta.Sort();

            for (int i=0; i<resultadoConsulta.Count() ; i++)
            {
                cmbOrigen.Items.Add(resultadoConsulta[i].ToString());
            }
            cmbOrigen.Text = resultadoConsulta[0].ToString();
 
            for (int i=0; i<resultadoConsulta.Count() ; i++)
            {
                cmbDestino.Items.Add(resultadoConsulta[i].ToString());
            }
            cmbDestino.Text = resultadoConsulta[0].ToString();

        }

        private void btnBuscarviajes_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> filtros = this.ArmaFiltro(cmbOrigen.Text, cmbDestino.Text, dtpFechaviaje.Value.ToString("yyyy/MM/dd"));
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.viaje_oyd, ref dgv, filtros);
        }

        private Dictionary<string, string> ArmaFiltro(string origen, string destino, string fecha)
        {
            Dictionary<string, string> filtros = new Dictionary<string, string>();
            filtros.Add("Origen", Conexion.Filtro.Exacto(origen));
            filtros.Add("Destino", Conexion.Filtro.Exacto(destino));
            filtros.Add("FechaInicio", Conexion.Filtro.Exacto(fecha));
        
            return filtros;
        }
    }
}
