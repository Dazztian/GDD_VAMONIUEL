using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmRol
{
    public partial class ModificarRol : Form
    {
        int idRol;
        string nombreOriginal;
        //lista de ids funciones
        private List<int> funcionesOriginales = new List<int>();

        public ModificarRol(int id, string nombre)
        {
            idRol = id;
            InitializeComponent();
            nombreOriginal = nombre;
            txtNombre.Text = nombre;

        }

        private void ModificarRol_Load(object sender, EventArgs e)
        {
            //TO DO
            //obtengo funciones
            Dictionary<string, List<object>> resul = Conexion.getInstance().ConsultaPlana(/*Conexion.Tabla.Funcion*/"", new List<string>(new string[] { "id", "nombre" }), null);
            Dictionary<string, string> filtros = new Dictionary<string, string>();
            //cargo todas las funciones
            for (int i = 1; i <= resul["nombre"].Count; i++)
            {
                filtros["id_rol"] = Conexion.Filtro.Exacto(idRol.ToString());
                filtros["id_funcion"] = Conexion.Filtro.Exacto(i.ToString());
                checkedListBoxFuncionalidades.Items.Add(resul["nombre"][i - 1], (Conexion.getInstance().existeRegistro(/*Conexion.Tabla.RolXFuncion*/"", new List<string>(new string[] { "id_rol", "id_funcion" }), filtros)));
            }
            //marco funciones existentes al ListBox
            for (int i = 1; i <= checkedListBoxFuncionalidades.Items.Count; i++)
            {
                if (checkedListBoxFuncionalidades.GetItemChecked(i - 1))
                {
                    funcionesOriginales.Add((int)i);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Se debe ingresar un nombre");
                return;
            }
            //TO DO
            //ids funciones
            List<int> aBorrar = new List<int>();
            List<int> aInsertar = new List<int>();
            Dictionary<string, string> filtrosFunc = new Dictionary<string, string>();

            for (int i = 0; i < checkedListBoxFuncionalidades.Items.Count; i++)
            {

                if (checkedListBoxFuncionalidades.GetItemChecked(i) && !funcionesOriginales.Contains((int)i + 1))
                    aInsertar.Add((int)i + 1);
                if (!checkedListBoxFuncionalidades.GetItemChecked(i) && funcionesOriginales.Contains((int)i + 1))
                    aBorrar.Add((int)i + 1);
            }

            Dictionary<string, object> datos = new Dictionary<string, object>();
            datos["id_rol"] = idRol;

            foreach (int v in aInsertar)
            {
                datos["id_funcion"] = v;
                if (!Conexion.getInstance().InsertarTablaIntermedia(/*Conexion.Tabla.RolXFuncion*/"", "id_rol", "id_funcion", idRol, v))
                {
                    DialogResult = DialogResult.Abort;
                    return;
                }

            }
            foreach (int v in aBorrar)
            {
                datos["id_funcion"] = v;
                if (!Conexion.getInstance().eliminarTablaIntermedia(/*Conexion.Tabla.RolXFuncion*/"", "id_rol", "id_funcion", idRol, v))
                {
                    DialogResult = DialogResult.Abort;
                    return;
                }
            }
            DialogResult = DialogResult.OK;
        }
    }
}
