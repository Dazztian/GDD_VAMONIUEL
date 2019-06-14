using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero
{
    public partial class EnrutarFuncion : Form
    {
        private string rolSeleccionado;
        private string usuario;
        private int idCliente = -1;
        List<Funcion> funcion;
        private bool flag = false;

        public EnrutarFuncion(string rolSeleccionado, string usuario)
        {
            InitializeComponent();
            this.rolSeleccionado = rolSeleccionado;
            this.usuario = usuario;
        }

        private void enrutar(int index)
        {
            if (!flag)
                return;
            switch (funcion[index])
            {
                case Funcion.ABM_Crucero:
                new AbmCrucero.CrearCrucero().Show(); 
                break;
                case Funcion.ABM_Recorrido:
                new AbmRecorrido.CrearRecorrido().Show();
                break;
                case Funcion.ABM_ROL:
                new AbmRol.CrearRol().Show();
                break;
                case Funcion.Compra_Reserva_Pasaje://PENDIENTE DE HACER FEDE HAZAMA
                new CompraPasaje.Form1().Show();
                break;
                case Funcion.Generacion_Viaje:
                new GeneracionViaje.Form_generar_viaje().Show();
                break;
                case Funcion.Pago_Reserva:
                new PagoReserva.pagoReserva().Show();
                break;
                case Funcion.LISTADO_ESTADISTICO://PENDIENTE DE HACER FEDE HAZAMA
                new ListadoEstadistico.ListadoEstadistico().Show();
                break;

            }
            flag = false;
            Close();
        }

        private void EnrutarFuncion_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> filtros = new Dictionary<string, string>();
            filtros.Add("usuario", Conexion.Filtro.Exacto(usuario));
            filtros.Add("nombre_rol", Conexion.Filtro.Exacto(rolSeleccionado));
            Dictionary<string, List<object>> resul = Conexion.getInstance().ConsultaPlana(Conexion.Tabla.FuncionesUsuarios, new List<string>(new string[] { "nombre_funcion", "funcion_id" }), filtros);
            funcion = resul["funcion_id"].Cast<Funcion>().ToList();
            FormTemplate.Funciones = funcion;
            FormTemplate.usuario = usuario;

            if (usuario != "admin")
            {
                //me cazo el id del cliente con el usuario
                /*
                FormTemplate.isAdmin = false;

                List<string> columnas = new List<string>();
                columnas.Add("idCliente");
                columnas.Add("nombreUsr");

                Dictionary<string, string> filtrosUsr = new Dictionary<string, string>();
                filtrosUsr.Add("nombreUsr", Conexion.Filtro.Exacto(usuario));
                Dictionary<string, List<object>> resultadoConsulta = (Conexion.getInstance().ConsultaPlana(Conexion.Tabla.idDelCliente, columnas, filtrosUsr));
                if(resultadoConsulta["idCliente"].Count != 0)
                    idCliente = Convert.ToInt32(resultadoConsulta["idCliente"][0]);
                else
                {
                    columnas = new List<string>();
                    columnas.Add("id");
                    filtrosUsr = new Dictionary<string, string>();
                    filtrosUsr.Add("usuario", Conexion.Filtro.Exacto(usuario));
                    resultadoConsulta = (Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Usuario, columnas, filtrosUsr));
                    filtrosUsr = new Dictionary<string, string>();
                    filtrosUsr["id_usuario"] = Conexion.Filtro.Exacto(resultadoConsulta["id"][0].ToString());
                    //ESTO ESTA PARA CHECKEAR
                    //idCliente = Convert.ToInt32(Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Cliente, columnas, filtrosUsr)["id"][0]);
                }
                FormTemplate.idCliente = idCliente;             
                */
            }
            else//PARA ESTE SOLO NOS INTERESA TRABAJAR CON UN USUARIO ADMIN
            {
                FormTemplate.isAdmin = true;
            }


            if (resul["nombre_funcion"].Count > 1)
            {
                MessageBox.Show("Se detecto que tiene mas de una funcion asignada. Por favor, elija a la que desea ingresar");
                cbbSeleccion.DataSource = resul["nombre_funcion"];
                cbbSeleccion.SelectedIndex = -1;
            }
            else
            {
                enrutar(0);
            }
            flag = true;
        }

        private void cbbSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            enrutar(cbbSeleccion.SelectedIndex);
        }

        private void EnrutarFuncion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(flag)
                Program.FormInicial.Show();
        }
    }
}
