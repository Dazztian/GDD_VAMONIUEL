using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmCrucero
{
    public partial class CrearCrucero : Form
    {
        List<ConjuntoCabinas> conjuntoCabinas = new List<ConjuntoCabinas>();
        List<Cabina> cabinasIndividuales = new List<Cabina>();
        DataTable tablaCabinas = new DataTable();
        public CrearCrucero()
        {
            InitializeComponent();
        }

        private void CrearCrucero_Load(object sender, EventArgs e)
        {
            DataTable marca = Conexion.getInstance().conseguirTabla(Conexion.Tabla.Marca, null);
            comboBoxMarca.DataSource = marca;
            comboBoxMarca.ValueMember = "Marca";
            comboBoxMarca.DisplayMember = "Marca";
            comboBoxMarca.SelectedIndex = -1;
            DataTable tipoCabina = Conexion.getInstance().conseguirTabla(Conexion.Tabla.TipoCabina, null);
            comboBoxTipoCabina.DataSource = tipoCabina;
            comboBoxTipoCabina.ValueMember = "Tipo";
            comboBoxTipoCabina.DisplayMember = "Tipo";
            comboBoxTipoCabina.SelectedIndex = -1;

            DataColumn column = new DataColumn();
            column.ColumnName = "Tipo";
            tablaCabinas.Columns.Add(column);
            DataColumn column2 = new DataColumn();
            column2.ColumnName = "Cantidad";
            tablaCabinas.Columns.Add(column2);
            DataColumn column3 = new DataColumn();
            column3.ColumnName = "Piso";
            tablaCabinas.Columns.Add(column3);
            DataColumn column4 = new DataColumn();
            column4.ColumnName = "Recargo";
            tablaCabinas.Columns.Add(column4);
        }

        private void btnCabina_Click(object sender, EventArgs e)
        {
            if (groupBox1.Controls.OfType<ComboBox>().Any(t => string.IsNullOrEmpty(t.Text)) || groupBox1.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
            {
                MessageBox.Show("Se deben completar todos los campos");
            }
            else
            {
                if (conjuntoCabinas.Any(cabina => cabina.tipo == comboBoxTipoCabina.Text && cabina.piso == Convert.ToInt32(txtPisoCabina.Text)))
                {
                    MessageBox.Show("Ya cargo un conjunto de cabinas de ese tipo en ese piso");
                }
                else
                {
                    ConjuntoCabinas cabinas = new ConjuntoCabinas();
                    cabinas.tipo = comboBoxTipoCabina.Text;
                    cabinas.cantidad = Convert.ToInt32(txtCantidadCabinas.Text);
                    cabinas.piso = Convert.ToInt32(txtPisoCabina.Text);
                    cabinas.recargo = Convert.ToDecimal(txtRecargoCabina.Text);
                    conjuntoCabinas.Add(cabinas);
                    DataRow row = tablaCabinas.NewRow();
                    row[0] = cabinas.tipo;
                    row[1] = cabinas.cantidad;
                    row[2] = cabinas.piso;
                    row[3] = cabinas.recargo;

                    tablaCabinas.Rows.Add(row);
                    dataGridViewCabinas.DataSource = null;
                    dataGridViewCabinas.DataSource = tablaCabinas;
                    generarCabinasIndividuales(cabinas);
                }
            }
        }

        private void btnLimpiarCabinas_Click(object sender, EventArgs e)
        {
            conjuntoCabinas.Clear();
            tablaCabinas.Clear();
            dataGridViewCabinas.DataSource = null;
            cabinasIndividuales.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Dictionary<string,object> cruceroDatos = new Dictionary<string,object>();
            Dictionary<string,object> cabinaDatos = new Dictionary<string,object>();
            int idCrucero;
            if (comboBoxMarca.SelectedIndex == -1 || string.IsNullOrEmpty(txtModelo.Text) || conjuntoCabinas.Count.Equals(0))
            {
                MessageBox.Show("Se deben completar todos los campos");
            }
            else
            {
                cruceroDatos.Add("CRU_FABRICANTE",comboBoxMarca.Text.ToString());
                cruceroDatos.Add("CRUCERO_MODELO", txtModelo.Text.ToString());
                cruceroDatos.Add("Habilitado", true);
                idCrucero = Conexion.getInstance().Insertar(Conexion.Tabla.CRUCERO, cruceroDatos);
                foreach (Cabina cabina in cabinasIndividuales)
                {
                    cabinaDatos.Add("CABINA_NRO",cabina.numero);
                    cabinaDatos.Add("CABINA_PISO",cabina.piso);
                    cabinaDatos.Add("CABINA_TIPO",cabina.tipo);
                    cabinaDatos.Add("CABINA_TIPO_PORC_RECARGO", cabina.recargo);
                    cabinaDatos.Add("ID_CRUCERO", idCrucero);
                    Conexion.getInstance().Insertar(Conexion.Tabla.Cabina, cabinaDatos);
                    cabinaDatos.Clear();
                }
                MessageBox.Show("Se ha creado un nuevo crucero");
                cruceroDatos.Clear();
                conjuntoCabinas.Clear();
                tablaCabinas.Clear();
                dataGridViewCabinas.DataSource = null;
                cabinasIndividuales.Clear();
            }
        }

        private void generarCabinasIndividuales(ConjuntoCabinas cabinas)
        {
            int i;
            if(cabinasIndividuales.Any(cabina => cabina.piso == cabinas.piso))
            {
                i = cabinasIndividuales.FindAll(cabina => cabina.piso == cabinas.piso).Max(cabina => cabina.numero) + 1;
            }
            else
            {
                i=0;
            }
            for (int j = 0; j < cabinas.cantidad ; j++ )
            {
                Cabina nuevaCabina = new Cabina();
                nuevaCabina.tipo = cabinas.tipo;
                nuevaCabina.numero = i;
                nuevaCabina.piso = cabinas.piso;
                nuevaCabina.recargo = cabinas.recargo;
                cabinasIndividuales.Add(nuevaCabina);
                i++;
            }
        }

        private void txtCantidadCabinas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void txtPisoCabina_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void txtRecargoCabina_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;

            if (char.IsNumber(e.KeyChar) ||

                e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator

                )

                e.Handled = false;

            else

                e.Handled = true;
        }
    }
}
