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

        private void mostrar_datos_reserva(object sender, EventArgs e)
        {
            Dictionary<string, string> filtrosReserva = new Dictionary<string, string>();
            filtrosReserva.Add("RESERVA_CODIGO", Conexion.Filtro.Exacto(txt_codigo_reserva.Text));
            List<string> columnasReserva = new List<string>();
            columnasReserva.Add("ID");//Aca indicamos las columnas que queremos que nos traiga
            List<object> id_reservas = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.RESERVA, columnasReserva, filtrosReserva))["ID"]);
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.RESERVA, ref dgv_reserva, filtrosReserva);
            int resultado = (int)id_reservas[0];//Aca catcheo el id que me devuelve la consulta

            Dictionary<string, string> filtrosReservaIDPasaje = new Dictionary<string, string>();
            List<string> columnasReservaIDPasaje = new List<string>();
            columnasReservaIDPasaje.Add("ID_Pasaje");//Aca indicamos las columnas que queremos que nos traiga
            List<object> id_pasajes = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.RESERVA, columnasReservaIDPasaje, filtrosReservaIDPasaje))["ID_Pasaje"]);
            int id_pasaje = (int)id_pasajes[0];

            //PROCEDIMIENTO PARA OBTENER 1 O MAS COLUMNAS EN PARTICULAR DE UNA TABLA
            List<string> columnasIDCliente = new List<string>();
            columnasIDCliente.Add("ID_Cliente");//Aca indicamos las columnas que queremos que nos traiga
            List<object> id_Clientes = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.PASAJE, columnasIDCliente, filtrosReservaIDPasaje))["ID_Cliente"]);
            int id_cliente = (int)id_Clientes[0];
            //PROCEDIMIENTO PARA LLENAR UN DATA GRID VIEW
            Dictionary<string, string> filtrosCliente = new Dictionary<string, string>();
            filtrosCliente.Add("ID", Conexion.Filtro.Exacto(id_cliente.ToString()));
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Cliente, ref dgv_cliente, filtrosCliente);

            //Con esto cargo los pasajes
            Dictionary<string, string> filtrosPasaje = new Dictionary<string, string>();
            filtrosPasaje.Add("ID", Conexion.Filtro.Exacto(id_pasaje.ToString()));
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.PASAJE, ref dgv_pasaje, filtrosPasaje);

            //ESTO NO FUNCIONA UN CHOTO
            MessageBox.Show(id_pasaje.ToString());
            Dictionary<string, string> filtrosViaje = new Dictionary<string, string>();
            filtrosViaje.Add("ID_PASAJE", Conexion.Filtro.Exacto(id_pasaje.ToString()));
            filtrosViaje.Add("ID_Crucero", Conexion.Filtro.NotNull());
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.VIAJE, ref dgv_viaje, filtrosViaje);



            //LO DE LOS CRUCEROS ME ESTA FALLANDOO 
            Dictionary<string, string> filtrosCrucero = new Dictionary<string, string>();
            List<string> columnasIDCrucero = new List<string>();
            columnasIDCrucero.Add("ID_Crucero");//Aca indicamos las columnas que queremos que nos traiga
            filtrosCrucero.Add("ID_Pasaje", Conexion.Filtro.Exacto(id_pasaje.ToString()));
            List<object> id_cruceros = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.VIAJE, columnasIDCrucero, filtrosCrucero))["ID_Crucero"]);
            //int id_crucero = (int)id_cruceros[0];
            //MessageBox.Show(id_crucero.ToString());
            







        }
    }
}
