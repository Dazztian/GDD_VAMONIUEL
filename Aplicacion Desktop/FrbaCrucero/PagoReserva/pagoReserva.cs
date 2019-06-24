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
    public partial class pagoReserva : FormTemplate
    {
        public pagoReserva()
        {
            InitializeComponent();

             cmb_medio_de_pago.Items.Add("Efectivo");
             cmb_medio_de_pago.Items.Add("Debito");
             cmb_medio_de_pago.Items.Add("Tarjeta de crédito 3 cuotas");
             cmb_medio_de_pago.Items.Add("Tarjeta de crédito 6 cuotas");
             cmb_medio_de_pago.Items.Add("Tarjeta de crédito 12 cuotas");
            
        }

        private Dictionary<string, object> datos = new Dictionary<string, object>();
     

        private void ReloadForm()
        {
            dgv_cliente.DataSource = null; dgv_cliente.Refresh();
            dgv_crucero.DataSource = null; dgv_crucero.Refresh();
            dgv_pasaje.DataSource = null; dgv_pasaje.Refresh();
            dgv_reserva.DataSource = null; dgv_reserva.Refresh();
            dgv_viaje.DataSource = null; dgv_viaje.Refresh();
        }
        //Lo voy a usar para crear el pago de reserva
        private void AgregarParaInsert(string nombreCol, object data)
        {
            datos[nombreCol] = data;
        }
            

        private void mostrar_datos_reserva(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(txt_codigo_reserva.Text))
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

            try//HAGO ESTO XQ CON LA MIGRA TENGO RESERVAS QUE NO TIENEN ASOCIADAS ID_PASAJE
            {
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
            catch { MessageBox.Show("ERROR, la reserva no tiene pasaje asociado. "); }
            }
            else { MessageBox.Show("NO PODES VISUALIZAR LOS DATOS ASOCIADOS A LA RESERVA PORQUE NO INGRESASTE CODIGO DE RESERVA "); }
        }

        private void btn_pago_de_reserva_Click(object sender, EventArgs e)
        {   //PORQUE YO PUEDO PAGAR LA RESERVA INDEPENDIENTEMENTE DE VISUALIZAR LOS DATOS ASOCIADAS A ESTA O NO
            if (!string.IsNullOrWhiteSpace(txt_codigo_reserva.Text))
            {
                if (!string.IsNullOrEmpty(cmb_medio_de_pago.Text))
                {

                    Dictionary<string, string> filtrosReserva = new Dictionary<string, string>();
                    filtrosReserva.Add("RESERVA_CODIGO", Conexion.Filtro.Exacto(txt_codigo_reserva.Text));
                    List<string> columnasReserva = new List<string>();
                    columnasReserva.Add("Habilitado");//Aca indicamos las columnas que queremos que nos traiga
                    List<object> habilitado = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.RESERVA, columnasReserva, filtrosReserva))["Habilitado"]);

                    //SI NO EXISTE NINGUNA RESERVA ASOCIADA AL CODIGO
                    if (!Conexion.getInstance().existeRegistro(Conexion.Tabla.RESERVA, columnasReserva, filtrosReserva))
                    {
                        MessageBox.Show("Codigo de reserva erroneo, vuelve a intentarlo con un codigo de reserva nuevo");
                        this.ReloadForm();
                        return;
                    }
                    else
                    {
                        //Si no es nula hago la ejecucion normal
                        //if (habilitado != null)
                        try 
                        {
                            bool bit_habilitado = (bool)habilitado[0];

                            if (bit_habilitado)//Si la reserva está habilitada...
                            {
                                //PASAJES
                                List<string> columnasPasaje = new List<string>();
                                columnasPasaje.Add("ID_Pasaje");//Aca indicamos las columnas que queremos que nos traiga
                                List<object> id_pasajes = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.RESERVA, columnasPasaje, filtrosReserva))["ID_Pasaje"]);
                                int id_pasaje = (int)id_pasajes[0];//Obtengo el id_pasaje

                                //ACA RESUELVO EL PAGO DE LA RESERVA
                                AgregarParaInsert("Fecha_Pago", DateTime.Now);
                                AgregarParaInsert("ID_Pasaje", id_pasaje);
                                AgregarParaInsert("medio_de_pago", this.cmb_medio_de_pago.GetItemText(this.cmb_medio_de_pago.SelectedItem));
                                int resultado = Conexion.getInstance().Insertar(Conexion.Tabla.Pago, datos);

                                //TENGO UN PROBLEMA SIEMPRE DEVUELVE -1, TENGO QUE ARREGLAR ESO
                                /* VER COMO RESOLVER ESTO
                                if (resultado == -1) { MessageBox.Show("NO PODES EFECTUAR EL PAGO PORQUE LA RESERVA ESTA FUERA DE FECHA"); }
                                else { MessageBox.Show("Pago realizado exitosamente"); }
                                */
                                this.Close();
                            }
                            else { MessageBox.Show("NO PODES EFECTUAR EL PAGO PORQUE LA RESERVA NO ESTA HABILITADA "); }
                        }//Este mensaje se da cuando recien se carga la BD
                        catch { MessageBox.Show("NO PODES EFECTUAR EL PAGO PORQUE LA RESERVA NO ESTA HABILITADA "); }
                    }
                } else { MessageBox.Show("NO PODES EFECTUAR EL PAGO PORQUE NO HAS SELECCIONADO UN METODO DE PAGO "); }

                }
            else { MessageBox.Show("NO PODES EFECTUAR EL PAGO PORQUE NO INGRESASTE CODIGO DE RESERVA "); }
        }

        private void txt_codigo_reserva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }
    }
}
