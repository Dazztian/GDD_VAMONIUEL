using FrbaCrucero.CompraReservaPasaje;
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
    public partial class ElegirCabina : Form
    {
        string id_viaje;
        double preciobase;
        double preciomasrecargocabina;
        string id_cabinaxviaje;

        public ElegirCabina(string idv)
        {
            InitializeComponent();
            id_viaje = idv;
            Dictionary<string, string> filtros = new Dictionary<string, string>();
            filtros.Add("Viaje", Conexion.Filtro.Exacto(id_viaje));
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.reco_completo, ref dgvReco, filtros);

            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.cabi_viaje, ref dgvCab, filtros);
            llenarcombo(Conexion.Tabla.cabi_viaje, "ID_Cabina", filtros, ref cmbIDCab);
        }

        private void ElegirCabina_Load(object sender, EventArgs e)
        {

        }

        private void btnElegir_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(cmbIDCab.Text.ToString()))
            {
                MessageBox.Show("Seleccione una cabina del listado despegable por favor.");
            }
            else
            {
                id_cabinaxviaje = cmbIDCab.Text.ToString();

                Dictionary<string, string> filtros = new Dictionary<string, string>();
                filtros.Add("viaje", Conexion.Filtro.Exacto(id_viaje));
                List<string> columnas = new List<string>();
                columnas.Add("precio_del_recorrido");
                List<object> resultadoConsulta = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.precio_base_recorrido, columnas, filtros)["precio_del_recorrido"]));
                preciobase=Convert.ToDouble(resultadoConsulta[0].ToString());

                Dictionary<string, string> filtros2 = new Dictionary<string, string>();
                filtros2.Add("cabina", Conexion.Filtro.Exacto(cmbIDCab.Text.ToString()));
                List<string> columnas2 = new List<string>();
                columnas2.Add("recargo");
                List<object> resultadoConsulta2 = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.recargo_cabina, columnas2, filtros2)["recargo"]));
                preciomasrecargocabina = preciobase * Convert.ToDouble(resultadoConsulta2[0]);

                new RegistrarCliente(id_viaje,preciobase,preciomasrecargocabina,id_cabinaxviaje).ShowDialog();
                this.Close();
                
            }
        }
        private void llenarcombo(string tabla, string columna, Dictionary<string, string> filtros, ref ComboBox combito)
        {
            List<string> columnas = new List<string>();
            columnas.Add(columna);
            List<object> resultadoConsulta = ((Conexion.getInstance().ConsultaPlana(tabla, columnas, filtros)[columna]));
            resultadoConsulta.Sort();
            for (int i = 0; i < resultadoConsulta.Count(); i++)
            {
                combito.Items.Add(resultadoConsulta[i].ToString());
            }
            //combito.Text = resultadoConsulta[0].ToString();
        }

    }
}
