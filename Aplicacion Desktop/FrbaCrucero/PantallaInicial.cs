using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero
{
    public partial class PantallaInicial : Form
    {
        public PantallaInicial()
        {
            InitializeComponent();
        }

        private void btn_login_admin_Click(object sender, EventArgs e)
        {

            //AbmCrucero.CrearCrucero().Show(); 
            //Application.Run(new Login());
        }

        private void btn_pago_reserva_Click(object sender, EventArgs e)
        {
            new PagoReserva.pagoReserva().Show();
        }

        private void btn_compra_reserva_pasaje_Click(object sender, EventArgs e)
        {
            new CompraPasaje.Form1().Show();
        }
    }
}
