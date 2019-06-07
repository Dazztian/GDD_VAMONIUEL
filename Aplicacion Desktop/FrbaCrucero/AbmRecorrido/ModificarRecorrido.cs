using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class ModificarRecorrido : Form
    {
        int idRecorrido;
        private Dictionary<string, string> filtros = new Dictionary<string, string>();

        public ModificarRecorrido(int id)
        {
            InitializeComponent();
            idRecorrido = id;
        }

        private void ModificarRecorrido_Load(object sender, EventArgs e)
        {
            filtros.Add("idRecorrido", Conexion.Filtro.Exacto(idRecorrido.ToString()));
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Tramos_asociados_a_recorridos, ref dataGridViewTramos, filtros);
        }
    }
}
