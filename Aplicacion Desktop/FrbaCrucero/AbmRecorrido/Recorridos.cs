﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class Recorridos : FormTemplate
    {
        private Dictionary<string, string> filtros = new Dictionary<string, string>();
        private Dictionary<string, bool> datos = new Dictionary<string, bool>();

        public Recorridos()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtOrigen.Text = txtDestino.Text = string.Empty;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataGridViewRecorridos.DataSource = null;
            filtros.Clear();
            
            if (!string.IsNullOrEmpty(txtOrigen.Text))
                //ingresar nombre columna
                filtros.Add("[PUERTO_DESDE]", Conexion.Filtro.Libre(txtOrigen.Text));
            if (!string.IsNullOrEmpty(txtDestino.Text))
                //ingresar nombre columna
                filtros.Add("[PUERTO_HASTA]", Conexion.Filtro.Libre(txtDestino.Text));
            //lleno el dgv
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Recorrido, ref dataGridViewRecorridos, filtros);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            new CrearRecorrido().ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewRecorridos.Rows.Count.Equals(0))
            {
                MessageBox.Show("Debe seleccionar un recorrido");
            }
            else
                new ModificarRecorrido(Convert.ToInt32(dataGridViewRecorridos.SelectedCells[0].OwningRow.Cells["ID"].Value)).ShowDialog();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (dataGridViewRecorridos.Rows.Count.Equals(0) )
            {
                MessageBox.Show("Debe seleccionar un recorrido");
            }
            else
                Conexion.getInstance().deshabilitar(Conexion.Tabla.Recorrido,Convert.ToInt32(dataGridViewRecorridos.SelectedCells[0].OwningRow.Cells["ID"].Value));

            dataGridViewRecorridos.DataSource = null;
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Recorrido, ref dataGridViewRecorridos, filtros);

        }
    }
}
