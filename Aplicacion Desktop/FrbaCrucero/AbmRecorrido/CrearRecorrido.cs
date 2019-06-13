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

namespace FrbaCrucero.AbmRecorrido
{
    public partial class CrearRecorrido : Form
    {
        List<Tramo> tramos;
        Dictionary<string,object> tramoAInsertar = new Dictionary<string,object>();
        int idTramoAInsertar;
        Dictionary<string, object> recorrido = new Dictionary<string, object>();
        int idRecorrido;
        string origen;
        string destino;
        Dictionary<string, object> tramoXRecorrido = new Dictionary<string, object>();
        public CrearRecorrido()
        {
            InitializeComponent();
            tramos = new List<Tramo>();
        }

        private void btnAgregarTramo_Click(object sender, EventArgs e)
        {
            Tramo tramo = new Tramo();
            tramo.origen = comboBoxOrigen.SelectedValue.ToString();
            tramo.destino = comboBoxDestino.SelectedValue.ToString();
            tramo.precio = Convert.ToDecimal(txtPrecio.Text);
            if (tramos.Count() == 0 || tramos.Last().destino.ToString() == tramo.origen.ToString())
            {
                tramos.Add(tramo);
            }
            else
                MessageBox.Show("El puerto de origen debe ser igual al ultimo puerto de destino");

            dataGridViewTramos.DataSource = null;
            dataGridViewTramos.DataSource = tramos;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tramos.Clear();
            dataGridViewTramos.DataSource = null;
        }

        private void CrearRecorrido_Load(object sender, EventArgs e)
        {
            DataTable puertosDesde = Conexion.getInstance().conseguirTabla(Conexion.Tabla.Puerto, null);
            comboBoxOrigen.DataSource = puertosDesde;
            comboBoxOrigen.ValueMember = "Nombre";
            comboBoxOrigen.DisplayMember = "Nombre";
            //comboBoxOrigen.SelectedIndex = -1;
            DataTable puertosHasta = Conexion.getInstance().conseguirTabla(Conexion.Tabla.Puerto, null);
            comboBoxDestino.DataSource = puertosHasta;
            comboBoxDestino.ValueMember = "Nombre";
            comboBoxDestino.DisplayMember = "Nombre";
            //comboBoxDestino.SelectedIndex = -1;
        }

        //revisar insert tramoXrecorrido
        private void btnCrearRecorrido_Click(object sender, EventArgs e)
        {
            if (tramos.Count.Equals(0))
            {
                MessageBox.Show("Debe ingresar al menos un tramo");
            }
            else
            {
                origen = tramos.First().origen;
                destino = tramos.Last().destino;
                recorrido.Add("PUERTO_DESDE",origen);
                recorrido.Add("PUERTO_HASTA",destino);
                idRecorrido = Conexion.getInstance().Insertar(Conexion.Tabla.Recorrido,recorrido);
                foreach (Tramo tramo in tramos)
                {
                    tramoAInsertar.Add("PUERTO_DESDE", tramo.origen);
                    tramoAInsertar.Add("PUERTO_HASTA", tramo.destino);
                    tramoAInsertar.Add("RECORRIDO_PRECIO_BASE", tramo.precio);
                    idTramoAInsertar= Conexion.getInstance().Insertar(Conexion.Tabla.tramo, tramoAInsertar);
                    tramoXRecorrido.Add("id_recorrido", idRecorrido);
                    tramoXRecorrido.Add("id_tramo", idTramoAInsertar);
                    Conexion.getInstance().Insertar(Conexion.Tabla.TramoXRecorrido, tramoXRecorrido);
                    tramoAInsertar.Clear();
                    tramoXRecorrido.Clear();
                }
            }

            
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
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
