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

            //this.cargar_dgv_cruceros_disponibles();//Para los cruceros que son capaces de realizar cualquier recorrido


                //Obtengo todos los recorridos del sistema
                Dictionary<string, string> filtrosRecorridos = new Dictionary<string, string>();
                Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Recorrido, ref dgv_recorridos_disponibles, filtrosRecorridos);
                cargaElComboDeIdsDeRecorridos();
    
                //Obtengo todos los cruceros  del sistema, capaz de hacer algun recorrido
                Dictionary<string, string> filtrosCruceros = new Dictionary<string, string>();
                Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.CRUCERO, ref dgv_cruceros_disponibles, filtrosCruceros);
                cargaElComboDeIdsDeCruceros();
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

        private void cargaElComboDeIdsDeCruceros()
        {
            cmb_cruceros.Items.Clear();
            List<String> idCruceros = new List<String>();
            for (int rows = 0; rows < dgv_cruceros_disponibles.Rows.Count - 1; rows++)
            {
                idCruceros.Add(dgv_cruceros_disponibles.Rows[rows].Cells["ID"].Value.ToString());
            }
            List<int> listaIdCruceros = idCruceros.ConvertAll(int.Parse);
            listaIdCruceros.Sort();
            idCruceros = idCruceros.Distinct().ToList();
            for (int i = 0; i < idCruceros.Count(); i++)
            {
                cmb_cruceros.Items.Add(listaIdCruceros[i].ToString());
            }
        }

        private void  cargaElComboDeIdsDeRecorridos()
        {
            cmb_recorridos.Items.Clear();
            List<String> idRecorridos = new List<String>();
            for (int rows = 0; rows < dgv_recorridos_disponibles.Rows.Count - 1; rows++)
            {
                idRecorridos.Add(dgv_recorridos_disponibles.Rows[rows].Cells["ID"].Value.ToString());
            }
            List<int> listaidRecorridos = idRecorridos.ConvertAll(int.Parse);
            listaidRecorridos.Sort();
            idRecorridos = idRecorridos.Distinct().ToList();
            for (int i = 0; i < idRecorridos.Count(); i++)
            {
                cmb_recorridos.Items.Add(listaidRecorridos[i].ToString());
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


    }
}
