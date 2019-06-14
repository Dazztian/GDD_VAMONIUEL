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
    public partial class ListadoEstadistico : FormTemplate
    {
        public ListadoEstadistico()
        {
            InitializeComponent();
            List<string> columnas = new List<string>();
            columnas.Add("anio");
            List<object> resultadoConsulta = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.AnioMinimo, columnas, null))["anio"]);
            //resultadoConsulta.Sort(); 
            //cmbAño.DataSource = resultadoConsulta;
            int añoactual = ConfigurationHelper.fechaActual.Year;

            for (int año = añoactual; año >= Convert.ToInt32(resultadoConsulta[0]); año--)
            {
                cmbAño.Items.Add(año);
            }
            cmbAño.Text = añoactual.ToString();
            cmbSemestre.Text = "1";
            cmbSemestre.Items.Add("1");
            cmbSemestre.Items.Add("2");
        }

        private void ListadoEstadistico_Load(object sender, EventArgs e)
        {

        }

        private void btnTop5Pasajes_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> filtros = this.ArmaFiltroDeAñoYSemestre(cmbSemestre.Text, cmbAño.Text, "FechaInicio");
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.top5Pasajes, ref dgv, filtros);
            lblPiola.Text = "Top 5 de los recorridos con más pasajes comprados.";
        }

        private void btnTop5CabinasLibres_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> filtros = this.ArmaFiltroDeAñoYSemestre(cmbSemestre.Text, cmbAño.Text, "FechaInicio");
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.top5CabinasLibres, ref dgv, filtros);
            lblPiola.Text = "Top 5 de los recorridos con más cabinas libres en cada uno de los viajes realizados.";
        }

        private void btnTop5CrucerosDeshabilitados_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> filtros = this.ArmaFiltroDeAñoYSemestre(cmbSemestre.Text, cmbAño.Text, "Fecha_fuera_de_servicio");
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.top5CrucerosDeshabilitados, ref dgv, filtros);
            lblPiola.Text = "Top 5 de los cruceros con mayor cantidad de días fuera de servicio.";
        }

        private Dictionary<string, string> ArmaFiltroDeAñoYSemestre(string semestre, string año, string campoFecha)
        {
            Dictionary<string, string> filtros = new Dictionary<string, string>();
            filtros.Add("YEAR(" + campoFecha + ")", Conexion.Filtro.Exacto(año));
            switch (semestre)
            {
                case "1":
                    filtros.Add("MONTH(" + campoFecha + ")", Conexion.Filtro.Between("1", "6"));
                    break;
                case "2":
                    filtros.Add("MONTH(" + campoFecha + ")", Conexion.Filtro.Between("6", "12"));
                    break;
            }
            return filtros;
        }
    }
}
