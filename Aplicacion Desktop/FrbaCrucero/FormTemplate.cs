using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FrbaCrucero
{
    public partial class FormTemplate : Form
    {
        private bool flag = false;
        public static List<Funcion> Funciones { get; set; }
        public static string usuario { get; set; }
        public static int idCliente { get; set; }
        public static bool isAdmin { get; set; }
        public FormTemplate()
        {
            InitializeComponent();

            foreach (Funcion f in Funciones.Distinct().ToList())
            {
                ToolStripMenuItem item;
                switch (f)
                {
                    case Funcion.ABM_ROL:
                        item = new ToolStripMenuItem("ABM_ROL");
                        item.Click += ABM_ROL_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                    case Funcion.ABM_Recorrido:
                        item = new ToolStripMenuItem("ABM_Recorrido");
                        item.Click += ABM_Recorrido_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                    
                    case Funcion.ABM_Crucero:
                        item = new ToolStripMenuItem("ABM_Crucero");
                        item.Click += ABM_Crucero_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                    case Funcion.Compra_Reserva_Pasaje:
                        item = new ToolStripMenuItem("Compra_Reserva_Pasaje");
                        item.Click += Compra_Reserva_Pasaje_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                    case Funcion.Generacion_Viaje:
                        item = new ToolStripMenuItem("Generacion_Viaje");
                        item.Click += Generacion_Viaje_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                    case Funcion.Pago_Reserva:
                        item = new ToolStripMenuItem("Pago_Reserva");
                        item.Click += Pago_Reserva_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                    case Funcion.LISTADO_ESTADISTICO:
                        item = new ToolStripMenuItem("LISTADO_ESTADISTICO");
                        item.Click += LISTADO_ESTADISTICO_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                }
            }
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            Program.FormInicial.Show();
        }


        private void ABM_Crucero_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            new AbmCrucero.CrearCrucero().Show();
        }

        private void ABM_Recorrido_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            new AbmRecorrido.CrearRecorrido().Show();
        }
        private void ABM_ROL_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            new AbmRol.CrearRol().Show();
        }

        private void Compra_Reserva_Pasaje_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            new CompraPasaje.Form1().Show();
        }
        private void Generacion_Viaje_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            new GeneracionViaje.Form_generar_viaje().Show();
        }
        private void Pago_Reserva_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            new PagoReserva.pagoReserva().Show();
        }
         private void LISTADO_ESTADISTICO_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            new ListadoEstadistico.ListadoEstadistico().Show();
        }


        private void FormTemplate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!flag)
                Program.FormInicial.Show();
            flag = false;
        }
    }
}
