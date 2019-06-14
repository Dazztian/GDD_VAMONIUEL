using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class Reserva : Form
    {
        int idCliente;
        int idViaje;
        int idCabinaXViaje;
        decimal precio;
        DateTime fechaCompra;
        public Reserva(int idC)
        {
            InitializeComponent();
            idCliente = idC;
        }

        private void Reserva_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> filtro = new Dictionary<string, string>();
            filtro.Add("ID", Conexion.Filtro.Exacto(idCliente.ToString()));
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Cliente, ref dataGridViewCliente, filtro);
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> filtro = new Dictionary<string, string>();
            filtro.Add("ID", Conexion.Filtro.Exacto(idViaje.ToString()));
            List<string> columnas = new List<string>();
            columnas.Add("ID");
            columnas.Add("FechaInicio");
            columnas.Add("FechaFin");
            Dictionary<string, List<object>> viaje = Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Cliente, columnas, filtro);
            
            Dictionary<string, object> datos = new Dictionary<string, object>();
            DateTime salida = Convert.ToDateTime(viaje["FechaInicio"][0].ToString());
            DateTime llegada = Convert.ToDateTime(viaje["FechaFin"][0].ToString());
            datos.Add("PASAJE_PRECIO", precio);
            datos.Add("PASAJE_FECHA_COMPRA", Convert.ToDateTime(fechaCompra.ToString("yyyy/MM/dd")));
            datos.Add("FECHA_SALIDA", Convert.ToDateTime(salida.ToString("yyyy/MM/dd")));
            datos.Add("FECHA_LLEGADA",Convert.ToDateTime(llegada.ToString("yyyy/MM/dd")));
            datos.Add("ID_Cliente", idCliente);
            datos.Add("ID_Viaje", idViaje);
            datos.Add("ID_CabinaXViaje", idCabinaXViaje);
            int idPasaje = Conexion.getInstance().Insertar(Conexion.Tabla.PASAJE, datos);
            Dictionary<string, object> datoNuevo = new Dictionary<string, object>();
            datoNuevo.Add("PASAJE_CODIGO", idPasaje);
            Conexion.getInstance().Modificar(idPasaje,Conexion.Tabla.PASAJE, datoNuevo);
        }
    }
}
