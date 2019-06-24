using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class CambiarPrecio : Form
    {
        public decimal precioNuevo;
        public decimal precioAnterior;
        public CambiarPrecio(decimal precio)
        {
            InitializeComponent();
            precioAnterior = precio;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            precioNuevo = Convert.ToDecimal(txtPrecio.Text);
        }

        private void CambiarPrecio_Load(object sender, EventArgs e)
        {
            txtPrecio.Text = precioAnterior.ToString();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;

            if (char.IsNumber(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) ||

                e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator

                )

                e.Handled = false;

            else

                e.Handled = true;
        }
    }
}
