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
    public partial class pagoReserva : Form
    {
        public pagoReserva()
        {
            InitializeComponent();
        }

        private void mostrar_datos_reserva(object sender, EventArgs e)
        {
            Dictionary<string, string> filtrosCrucero = new Dictionary<string, string>();
            filtrosCrucero.Add("habilitado", Conexion.Filtro.Exacto("1"));
            List<string> columnasCrucero = new List<string>();
            columnasCrucero.Add("distinct ID");
            List<object> id_cruceros_disponibles = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Cruceros_ocupados_por_fecha, columnasCrucero, filtrosCrucero))["ID"]);
        }
    }
}
