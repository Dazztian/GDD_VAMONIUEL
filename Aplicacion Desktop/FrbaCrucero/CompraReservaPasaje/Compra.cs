using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class Compra : Form
    {
        public Compra()
        {
            InitializeComponent();
        }

        private void Compra_Load(object sender, EventArgs e)
        {
            comboBoxPago.Items.Add("Efectivo");
            comboBoxPago.Items.Add("Debito");
            comboBoxPago.Items.Add("Tarjeta de crédito 3 cuotas");
            comboBoxPago.Items.Add("Tarjeta de crédito 6 cuotas");
            comboBoxPago.Items.Add("Tarjeta de crédito 12 cuotas");
        }
    }
}
