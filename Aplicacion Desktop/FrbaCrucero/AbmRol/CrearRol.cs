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
            //TO DO
            List<string> columnas = new List<string>();
            columnas.Add("Nombre");
            Dictionary<string, string> filtrosNom = new Dictionary<string, string>();
            filtrosNom.Add("Nombre", Conexion.Filtro.Exacto(txtNombre.Text));
            
            //checkeo existencia del rol
            if (!Conexion.getInstance().existeRegistro(/*tabla rol*/"", columnas, filtrosNom))
            {   
                // List<int> funciones representa las ids de las funciones
                //Cambiar por List<Funcion> (funcion -> enum)
                List<int> funciones = new List<int>();
                for (int i = 0; i < checkedListBoxFuncionalidades.Items.Count; i++)
                {
                    if (checkedListBoxFuncionalidades.GetItemChecked(i))
                    {
                        funciones.Add((int)i + 1);
                    }
                }
                if (funciones.Count == 0)
                {
                    MessageBox.Show("Se debe seleccionar al menos una funcion");
                    return;
                }
                Dictionary<string, object> datos = new Dictionary<string, object>();
                datos["nombre"] = txtNombre.Text;
                //inserta nuevo rol
                //int idinsertada = Conexion.getInstance().Insertar(Conexion.Tabla.Rol, datos);
                foreach (int f in funciones)
                    //inserta nuevo rolXfuncion
                    //Conexion.getInstance().InsertarTablaIntermedia(Conexion.Tabla.RolXFuncion, "id_rol", "id_funcion", idinsertada, f);
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
        }
    }
}
