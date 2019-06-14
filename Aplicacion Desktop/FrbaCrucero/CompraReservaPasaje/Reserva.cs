﻿using System;
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
        string id_viaje;
        double preciobase;
        double preciomasrecargocabina;
        string id_cabinaxviaje;
        DateTime fechaCompra;
        public Reserva(int idC, string viaje, double precioB, double precioR, string idVxC)
        {
            InitializeComponent();
            idCliente = idC;
            id_viaje = viaje;
            preciobase = precioB;
            preciomasrecargocabina = precioR;
            id_cabinaxviaje = idVxC;
            fechaCompra = ConfigurationHelper.fechaActual;
        }

        private void Reserva_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> filtro = new Dictionary<string, string>();
            filtro.Add("ID", Conexion.Filtro.Exacto(idCliente.ToString()));
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Cliente, ref dataGridViewCliente, filtro);
            Dictionary<string, string> filtroViaje = new Dictionary<string, string>();
            filtro.Add("ID", Conexion.Filtro.Exacto(id_viaje.ToString()));
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.VIAJE, ref dataGridViewViaje, filtroViaje);
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> filtro = new Dictionary<string, string>();
            filtro.Add("ID", Conexion.Filtro.Exacto(id_viaje.ToString()));
            List<string> columnas = new List<string>();
            columnas.Add("ID");
            columnas.Add("FechaInicio");
            columnas.Add("FechaFin");
            Dictionary<string, List<object>> viaje = Conexion.getInstance().ConsultaPlana(Conexion.Tabla.VIAJE, columnas, filtro);
            
            Dictionary<string, object> datos = new Dictionary<string, object>();
            DateTime salida = Convert.ToDateTime(viaje["FechaInicio"][0].ToString());
            DateTime llegada = Convert.ToDateTime(viaje["FechaFin"][0].ToString());
            datos.Add("PASAJE_PRECIO", preciomasrecargocabina);
            datos.Add("PASAJE_FECHA_COMPRA", Convert.ToDateTime(fechaCompra.ToString("yyyy/MM/dd")));
            datos.Add("FECHA_SALIDA", Convert.ToDateTime(salida.ToString("yyyy/MM/dd")));
            datos.Add("FECHA_LLEGADA",Convert.ToDateTime(llegada.ToString("yyyy/MM/dd")));
            datos.Add("ID_Cliente", idCliente);
            datos.Add("ID_Viaje", id_viaje);
            datos.Add("ID_CabinaXViaje", id_cabinaxviaje);
            int idPasaje = Conexion.getInstance().Insertar(Conexion.Tabla.PASAJE, datos);

            Dictionary<string, object> datosReserva = new Dictionary<string, object>();
            datosReserva.Add("RESERVA_FECHA", fechaCompra);
            datosReserva.Add("Habilitado", true);
            datosReserva.Add("ID_Pasaje", idPasaje);
            int idReserva = Conexion.getInstance().Insertar(Conexion.Tabla.RESERVA, datosReserva);
            Dictionary<string, object> datosReservanuevo = new Dictionary<string, object>();
            datosReservanuevo.Add("RESERVA_CODIGO", idReserva);
            Conexion.getInstance().Modificar(idReserva, Conexion.Tabla.RESERVA, datosReservanuevo);
            MessageBox.Show("Reserva realizada. Su codigo es "+ idReserva.ToString());
        }
    }
}