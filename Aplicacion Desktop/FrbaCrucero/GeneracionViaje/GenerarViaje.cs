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
        
        //Lo voy a usar para crear el nuevo viaje
        private void AgregarParaInsert(string nombreCol, object data)
        {
            datos[nombreCol] = data;
        }
             
        private void FormGenerarViajes(object sender, EventArgs e)
        {
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
        private void cargar_dgv_cruceros_disponibles(){}

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
        private void cargaElComboDeIdsDeCrucerosPRUEBA(List<object> lista_id_cruceros)
        {
            cmb_cruceros.Items.Clear();
            List<string> idCruceros = lista_id_cruceros.Select(s => s.ToString()).ToList(); //lista_id_cruceros.Select(s => (string)s).ToList();
            //var idCruceros = lista_id_cruceros.OfType<string>();
            /* for (int rows = 0; rows < dgv_cruceros_disponibles.Rows.Count - 1; rows++) { idCruceros.Add(dgv_cruceros_disponibles.Rows[rows].Cells["ID"].Value.ToString());}*/
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

        //Logica del modulo
        private void btn_generar_viaje(object sender, EventArgs e)
        { 
            DateTime fecha_inicial = Convert.ToDateTime(dtp_fecha_inicio.Value.ToString());
            DateTime fecha_final = Convert.ToDateTime(dtp_fecha_fin.Value.ToString());
            //Checkeo las fechas
            if ( DateTime.Compare(fecha_inicial, fecha_final) < 0)
            {   //Exijo que seleccione un recorrido y un crucero
                if (!string.IsNullOrWhiteSpace(cmb_recorridos.Text) && !string.IsNullOrWhiteSpace(cmb_cruceros.Text))
                { int id_recorrido = Convert.ToInt32(cmb_recorridos.Text.ToString());
                  int id_crucero = Convert.ToInt32(cmb_cruceros.Text.ToString());


                  //Aca resuelvo la creacion del nuevo viaje
                  //OBS: Podria agregarle los demas campos pero no lo veo necesario
                  AgregarParaInsert("FechaInicio", Convert.ToDateTime(dtp_fecha_inicio.Value.ToString("yyyy/MM/dd")));
                  AgregarParaInsert("FechaFin", Convert.ToDateTime(dtp_fecha_fin.Value.ToString("yyyy/MM/dd")));
                  AgregarParaInsert("ID_Crucero",id_crucero);
                  AgregarParaInsert("ID_Recorrido", id_recorrido);
                  int resultado =Conexion.getInstance().Insertar(Conexion.Tabla.VIAJE, datos);//Finalmente aca le adjudico el premio
                  if (resultado != -1) { MessageBox.Show("Insertaste reeey"); }
                  else { MessageBox.Show("ERROR DE INSERCION  reeey"); } 
                    
                }
                else { MessageBox.Show("Te falta seleccionar 1 recorrido y 1 crucero"); }
            }
            else { MessageBox.Show("Te equivocaste de fecha monster"); }
            
        }

        //Voy a hacer que se actualize el dgv cada vez que modifico, o el recorrido, o alguna de las 2 fechas
        private void cmb_seleccionar_recorrido(object sender, EventArgs e)
        {
        //Aca obtengo el id del recorrido que quiero laburar
        Dictionary<string, string> filtrosRecorrido = new Dictionary<string, string>();
        filtrosRecorrido.Add("ID", Conexion.Filtro.Exacto(cmb_recorridos.Text.ToString()));
        //Filtro los cruceros que cumplen dicho criterio DE LA VISTA cruceros_ocupados_por_fecha
        Dictionary<string, string> filtrosCrucero = new Dictionary<string, string>();
        filtrosCrucero.Add("habilitado", Conexion.Filtro.Exacto("1"));

        String formatoFechaInicio = Conexion.getInstance().darFormatoFechaYYYYMMDD(dtp_fecha_inicio);
        String formatoFechaFin = Conexion.getInstance().darFormatoFechaYYYYMMDD(dtp_fecha_fin);

        filtrosCrucero.Add("FechaInicio", Conexion.Filtro.NotBetween(formatoFechaInicio, formatoFechaFin));
        filtrosCrucero.Add("FechaFin", Conexion.Filtro.NotBetween(formatoFechaInicio, formatoFechaFin));
        List<string> columnasCrucero = new List<string>();
        columnasCrucero.Add("distinct ID");
        //columnasCrucero.Add("CRU_FABRICANTE"); Solo quiero que me traiga el ID para luego cargarlo en el combo
        List<object> id_cruceros_disponibles = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Cruceros_ocupados_por_fecha, columnasCrucero, filtrosCrucero))["ID"]);
        cargaElComboDeIdsDeCrucerosPRUEBA(id_cruceros_disponibles);

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }




    }
}
