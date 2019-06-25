using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmCrucero
{
    public partial class FueraDeServicio : Form
    {
        public DateTime fechaBaja;
        public DateTime fechaAlta;
        public Boolean bajaCorrecta = false;
        public FueraDeServicio()
        {
            InitializeComponent();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(Convert.ToDateTime(dateTimePickerInicio.Value.ToString()), Convert.ToDateTime(dateTimePickerFin.Value.ToString())) < 0)
            {
                fechaBaja = Convert.ToDateTime(dateTimePickerInicio.Value.ToString());
                fechaAlta = Convert.ToDateTime(dateTimePickerFin.Value.ToString());
                bajaCorrecta = true;
            }
            else { MessageBox.Show("Error en las fechas, fecha inicial debe ser anterior a la fecha final"); }
        }

        private void FueraDeServicio_Load(object sender, EventArgs e)
        {
            dateTimePickerInicio.MinDate = ConfigurationHelper.fechaActual;
            dateTimePickerFin.MinDate = ConfigurationHelper.fechaActual;
        }
    }
}
