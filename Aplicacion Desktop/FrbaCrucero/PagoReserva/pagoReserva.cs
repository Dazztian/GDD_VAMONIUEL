using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.PagoReserva
{
    public partial class pagoReserva : Form
    {
        public pagoReserva()
        {
            InitializeComponent();
        }
        private void ReloadForm()
        {
            dgv_cliente.DataSource = null; dgv_cliente.Refresh();
            dgv_crucero.DataSource = null; dgv_crucero.Refresh();
            dgv_pasaje.DataSource = null; dgv_pasaje.Refresh();
            dgv_reserva.DataSource = null; dgv_reserva.Refresh();
            dgv_viaje.DataSource = null; dgv_viaje.Refresh();
        }

        private void mostrar_datos_reserva(object sender, EventArgs e)
        {
            //Con esto cargo las reservas
            Dictionary<string, string> filtrosReserva = new Dictionary<string, string>();
            filtrosReserva.Add("RESERVA_CODIGO", Conexion.Filtro.Exacto(txt_codigo_reserva.Text));
            List<string> columnasReserva = new List<string>();
            columnasReserva.Add("ID");//Aca indicamos las columnas que queremos que nos traiga
            List<object> id_reservas = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.RESERVA, columnasReserva, filtrosReserva))["ID"]);
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.RESERVA, ref dgv_reserva, filtrosReserva);
            
            //SI NO EXISTE NINGUNA RESERVA ASOCIADA AL CODIGO
            if (!Conexion.getInstance().existeRegistro(Conexion.Tabla.RESERVA, columnasReserva, filtrosReserva))
            {
                MessageBox.Show("Codigo de reserva erroneo, vuelve a intentarlo con un codigo de reserva nuevo");
                this.ReloadForm();
                return;
            }   else { int id_reserva = (int)id_reservas[0]; }

            //PASAJES
            List<string> columnasPasaje = new List<string>();
            columnasPasaje.Add("ID_Pasaje");//Aca indicamos las columnas que queremos que nos traiga
            List<object> id_pasajes = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.RESERVA, columnasPasaje, filtrosReserva))["ID_Pasaje"]);
            int id_pasaje = (int)id_pasajes[0];//Obtengo el id_pasaje

            //A PARTIR DEL ID_PASAJE OBTENGO EL REGISTRO COMPLETO
            Dictionary<string, string> filtrosPasaje = new Dictionary<string, string>();
            filtrosPasaje.Add("ID", Conexion.Filtro.Exacto(id_pasaje.ToString()));
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.PASAJE, ref dgv_pasaje, filtrosPasaje);

/////////////////////////////////////////////////////////////////////////////CLIENTES/////////////////////////////////////////////////////////////////////////////
            List<string> columnasCliente = new List<string>();
            columnasCliente.Add("ID_Cliente");//Aca indicamos las columnas que queremos que nos traiga
            List<object> id_clientes = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.PASAJE, columnasCliente, filtrosPasaje))["ID_Cliente"]);
            int id_cliente = (int)id_clientes[0];//Obtengo el id_pasaje

            //A PARTIR DEL ID_PASAJE OBTENGO EL REGISTRO COMPLETO
            Dictionary<string, string> filtrosCliente = new Dictionary<string, string>();
            filtrosCliente.Add("ID", Conexion.Filtro.Exacto(id_cliente.ToString()));
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Cliente, ref dgv_cliente, filtrosCliente);

/////////////////////////////////////////////////////////////////////////////VIAJES/////////////////////////////////////////////////////////////////////////////
            List<string> columnasViaje = new List<string>();
            columnasViaje.Add("ID_Viaje");//Aca indicamos las columnas que queremos que nos traiga
            List<object> id_viajes = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.PASAJE, columnasViaje, filtrosPasaje))["ID_Viaje"]);
            int id_viaje = (int)id_viajes[0];//Obtengo el id_pasaje

            //A PARTIR DEL ID OBTENGO EL REGISTRO COMPLETO
            Dictionary<string, string> filtrosViaje = new Dictionary<string, string>();
            filtrosViaje.Add("ID", Conexion.Filtro.Exacto(id_viaje.ToString()));
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.VIAJE, ref dgv_viaje, filtrosViaje);

/////////////////////////////////////////////////////////////////////////////CRUCEROS/////////////////////////////////////////////////////////////////////////////
            List<string> columnasCrucero = new List<string>();
            columnasCrucero.Add("ID_Crucero");//Aca indicamos las columnas que queremos que nos traiga
            List<object> id_cruceros = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.VIAJE, columnasCrucero, filtrosViaje))["ID_Crucero"]);
            int id_crucero = (int)id_cruceros[0];//Obtengo el id_pasaje
            //MessageBox.Show(id_crucero.ToString());

            //A PARTIR DEL ID  OBTENGO EL REGISTRO COMPLETO
            Dictionary<string, string> filtrosCrucero = new Dictionary<string, string>();
            filtrosCrucero.Add("ID", Conexion.Filtro.Exacto(id_crucero.ToString()));
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.CRUCERO, ref dgv_crucero, filtrosCrucero);


        }
    }
}
