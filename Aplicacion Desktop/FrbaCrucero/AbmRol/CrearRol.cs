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
    public partial class CrearRol : Form
    {
        public CrearRol()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Se debe ingresar un nombre");
                return;
            }


            List<string> columnas = new List<string>();
            columnas.Add("Nombre");
            Dictionary<string, string> filtrosNom = new Dictionary<string, string>();
            filtrosNom.Add("Nombre", Conexion.Filtro.Exacto(txtNombre.Text));

            if (!Conexion.getInstance().existeRegistro(Conexion.Tabla.Rol, columnas, filtrosNom))
            {
                List<Funcion> funciones = new List<Funcion>();
                for (int i = 0; i < checkedListBoxFuncionalidades.Items.Count; i++)
                {
                    if (checkedListBoxFuncionalidades.GetItemChecked(i))
                    {
                        funciones.Add((Funcion)i + 1);
                    }
                }
                if (funciones.Count == 0)
                {
                    MessageBox.Show("Se debe seleccionar al menos una funcion");
                    return;
                }
                Dictionary<string, object> datos = new Dictionary<string, object>();
                datos["nombre"] = txtNombre.Text;
                int idinsertada = Conexion.getInstance().Insertar(Conexion.Tabla.Rol, datos);
                foreach (int f in funciones)
                    Conexion.getInstance().InsertarTablaIntermedia(Conexion.Tabla.Rol_X_Funcion, "id_rol", "id_funcion", idinsertada, f);
                MessageBox.Show("Rol creado exitosamente");
                foreach (int i in checkedListBoxFuncionalidades.CheckedIndices)
                {
                    checkedListBoxFuncionalidades.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
            else
            {
                MessageBox.Show("Ese rol ya existe.");
                txtNombre.Text = string.Empty;
            }
        }

        private void CrearRol_Load(object sender, EventArgs e)
        {
            //obtener funciones de la tabla funcion
            //cargarlas en el listBox
            Dictionary<string, List<object>> resul = Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Funcion, new List<string>(new string[] { "nombre" }), null);
            resul["nombre"].ForEach(o => checkedListBoxFuncionalidades.Items.Add(o.ToString(), false));
        }
    }
}
