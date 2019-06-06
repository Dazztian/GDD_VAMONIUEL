using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.GeneracionViaje
{
    public partial class Form_generar_viaje : Form
    {
        public Form_generar_viaje()
        {
            InitializeComponent();
        }

        int id_cliente;
        private List<TextBox> textos = new List<TextBox>();
        private Dictionary<string, object> datos = new Dictionary<string, object>();
        private Dictionary<string, object> datosPuntos = new Dictionary<string, object>();

        
        private void FormGenerarViajes(object sender, EventArgs e)
        {

                //Para el dgv de los recorridos
                this.cargar_dgv_recorridos();
                

                //Para los cruceros que son capaces de realizar cualquier recorrido
                this.cargar_dgv_cruceros_disponibles();


                //Obtengo todos los recorridos del sistema
                Dictionary<string, string> filtrosPremios = new Dictionary<string, string>();
                Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Recorrido, ref dgv_recorridos_disponibles, filtrosPremios);
                //cargaElComboDeIds();   
    
                //Obtengo todos los cruceros  del sistema, capaz de hacer algun recorrido
                Dictionary<string, string> filtrosCruceros = new Dictionary<string, string>();
                Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.CRUCERO, ref dgv_cruceros_disponibles, filtrosCruceros);
                //cargaElComboDeIds();
        }

        //CUANDO CAMBIO EL DTP ACTUALIZO LOS CRUCEROS DISPONIBLES
        private void dtp_actualizarCrucerosDisponibles(object sender, EventArgs e)
        {

        }
        //Los cruceros a mostrar dependeran a que esten disponibles para esa fecha y no asignados a otro recorrido
        private void cargar_dgv_cruceros_disponibles()
        {
            /*
            Dictionary<string, string> filtrosCruceros = new Dictionary<string, string>();
            filtrosCruceros.Add("ID_Cliente", Conexion.Filtro.Exacto(id_cliente.ToString()));
            filtrosCruceros.Add("year(FechaObtenIDos)", Conexion.Filtro.Exacto(ConfigurationHelper.fechaActual.Year.ToString()));//Tienen que ser de este año
            filtrosCruceros.Add("Utilizados", Conexion.Filtro.Between("0", "cant-1"));//Tienen que estar habilitados
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Puntos, ref dgv_Ptos_Cliente, filtrosCruceros);
            this.dgv_Ptos_Cliente.Sort(this.dgv_Ptos_Cliente.Columns["FechaObtenIDos"], ListSortDirection.Ascending);
            */
        }
        //Los recorridos no tienen ningun filtro
        private void cargar_dgv_recorridos() {}


    }
}
