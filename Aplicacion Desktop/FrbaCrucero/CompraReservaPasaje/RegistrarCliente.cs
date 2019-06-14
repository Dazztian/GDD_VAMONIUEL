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
    public partial class RegistrarCliente : Form
    {
        Boolean guardado = false;
        int idCliente;
        string id_viaje;
        double preciobase;
        double preciomasrecargocabina;
        string id_cabinaxviaje;
        public RegistrarCliente(string viaje,double precioB,double precioR,string idVxC)
        {
            InitializeComponent();
            id_viaje = viaje;
            preciobase = precioB;
            preciomasrecargocabina = precioR;
            id_cabinaxviaje = idVxC;
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDNI.Text))
            {
                Dictionary<string,string> filtro = new Dictionary<string,string>();
                filtro.Add("CLI_DNI",Conexion.Filtro.Exacto(txtDNI.Text));
                List<string> columnas = new List<string>();
                columnas.Add("CLI_DNI");
                if (Conexion.getInstance().existeRegistro(Conexion.Tabla.Cliente, columnas, filtro))
                {
                    columnas.Add("ID");
                    columnas.Add("CLI_NOMBRE");
                    columnas.Add("CLI_APELLIDO");
                    columnas.Add("CLI_DIRECCION");
                    columnas.Add("CLI_TELEFONO");
                    columnas.Add("CLI_MAIL");
                    columnas.Add("CLI_FECHA_NAC");
                    Dictionary<string,List<object>> datos = Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Cliente,columnas, filtro);
                    txtNombre.Text = datos["CLI_NOMBRE"][0].ToString();
                    txtApellido.Text = datos["CLI_APELLIDO"][0].ToString();
                    txtDireccion.Text = datos["CLI_DIRECCION"][0].ToString();
                    txtTelefono.Text = datos["CLI_TELEFONO"][0].ToString();
                    txtMail.Text = datos["CLI_MAIL"][0].ToString();
                    dateTimePickerNacimiento.Text = Convert.ToDateTime(datos["CLI_FECHA_NAC"][0].ToString()).ToString();
                }
                else
                {
                    MessageBox.Show("No se encontro ningun cliente con ese DNI");
                }

            }
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDNI.Text) || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtDireccion.Text) || string.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else
            {
                Dictionary<string, string> filtro = new Dictionary<string, string>();
                filtro.Add("CLI_DNI", Conexion.Filtro.Exacto(txtDNI.Text));
                List<string> columnas = new List<string>();
                columnas.Add("CLI_DNI");
                if (Conexion.getInstance().existeRegistro(Conexion.Tabla.Cliente, columnas, filtro))
                {
                    Dictionary<string, object> datos = new Dictionary<string, object>();
                    columnas.Add("ID");
                    Dictionary<string, List<object>> id = Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Cliente, columnas, filtro);
                    idCliente = Convert.ToInt32(id["ID"][0]);

                    datos.Add("CLI_NOMBRE", txtNombre.Text.ToString());
                    datos.Add("CLI_APELLIDO", txtApellido.Text.ToString());
                    datos.Add("CLI_DIRECCION", txtDireccion.Text.ToString());
                    datos.Add("CLI_TELEFONO", Convert.ToInt32(txtTelefono.Text.ToString()));
                    datos.Add("CLI_MAIL", txtMail.Text.ToString());
                    datos.Add("CLI_FECHA_NAC", Convert.ToDateTime(dateTimePickerNacimiento.Value.ToString("yyyy/MM/dd")));
                    Conexion.getInstance().Modificar(idCliente, Conexion.Tabla.Cliente, datos);
                    guardado = true;
                }
                else
                {

                    Dictionary<string, object> datos = new Dictionary<string, object>();                    
                    datos.Add("CLI_DNI", txtDNI.Text.ToString());
                    datos.Add("CLI_NOMBRE", txtNombre.Text.ToString());
                    datos.Add("CLI_APELLIDO", txtApellido.Text.ToString());
                    datos.Add("CLI_DIRECCION", txtDireccion.Text.ToString());
                    datos.Add("CLI_TELEFONO", Convert.ToInt32(txtTelefono.Text.ToString()));
                    datos.Add("CLI_MAIL", txtMail.Text.ToString());
                    datos.Add("CLI_FECHA_NAC", Convert.ToDateTime(dateTimePickerNacimiento.Value.ToString("yyyy/MM/dd")));
                    idCliente = Conexion.getInstance().Insertar(Conexion.Tabla.Cliente, datos);
                    guardado = true;
                }
            }
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            if (guardado)
            {
                new Reserva(idCliente, id_viaje, preciobase, preciomasrecargocabina, id_cabinaxviaje).Show();
            }
            else
            {
                MessageBox.Show("Debe guardar sus datos antes");
            }
            
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (guardado)
            {
                new Compra().Show();
            }
            else
            {
                MessageBox.Show("Debe guardar sus datos antes");
            }
        }
    }
}
