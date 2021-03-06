﻿using System;
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
    public partial class CompraReservaPasaje : FormTemplate
    {
        string id_viaje;
        public CompraReservaPasaje()
        {
            InitializeComponent();
            dtpFechaviaje.MinDate = ConfigurationHelper.fechaActual;
            llenarcombo(Conexion.Tabla.Puerto, "Nombre", null, ref cmbOrigen);
            llenarcombo(Conexion.Tabla.Puerto, "Nombre", null, ref cmbDestino);
            cmbOrigen.Text = cmbDestino.Items[0].ToString();
            cmbDestino.Text = cmbDestino.Items[0].ToString();

        }

        private void btnBuscarviajes_Click(object sender, EventArgs e)
        {
            //cmbViaje.Items.Clear();
            Dictionary<string, string> filtros = this.ArmaFiltro(cmbOrigen.Text, cmbDestino.Text, dtpFechaviaje.Value.ToString("yyyy/MM/dd"));
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.viaje_oyd, ref dgv, filtros);
            //llenarcombo(Conexion.Tabla.viaje_oyd, "ID",filtros,ref cmbViaje);
           

        }
        private void llenarcombo(string tabla,string columna,Dictionary<string, string> filtros, ref ComboBox combito)
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
        private Dictionary<string, string> ArmaFiltro(string origen, string destino, string fecha)
        {
            Dictionary<string, string> filtros = new Dictionary<string, string>();
            filtros.Add("Origen", Conexion.Filtro.Exacto(origen));
            filtros.Add("Destino", Conexion.Filtro.Exacto(destino));
            filtros.Add("FechaInicio", Conexion.Filtro.Exacto(fecha));
        
            return filtros;
        }

        private void btnElegirviaje_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(id_viaje)){
                MessageBox.Show("Seleccione un viaje del despegable por favor.");
            }
            else
            {
                ElegirCabina elegirCabin = new ElegirCabina(id_viaje);
                elegirCabin.ShowDialog();
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;// get the Row Index
            DataGridViewRow selectedRow = dgv.Rows[index];
            id_viaje = selectedRow.Cells[0].Value.ToString();
            label5.Text = selectedRow.Cells[0].Value.ToString();
            Dictionary<string, string> filtros_reco = new Dictionary<string, string>();
            filtros_reco.Add("Viaje", Conexion.Filtro.Exacto(id_viaje));
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.reco_completo, ref dgvReco, filtros_reco);
        }
    }
}
