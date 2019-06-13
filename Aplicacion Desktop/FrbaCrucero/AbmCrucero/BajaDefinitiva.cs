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
    public partial class BajaDefinitiva : Form
    {
        public DateTime fechaBajaDefinitiva;
        public BajaDefinitiva()
        {
            InitializeComponent();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            fechaBajaDefinitiva = Convert.ToDateTime(dateTimePickerBaja.Value.ToString());
        }
    }
}
