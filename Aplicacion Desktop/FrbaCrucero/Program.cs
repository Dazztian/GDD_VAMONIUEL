using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero
{
    static class Program
    {
        public static Form FormInicial { get; set; }
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new AbmCrucero.Cruceros());
            //Application.Run(new GeneracionViaje.Form_generar_viaje());
           //Application.Run(new ListadoEstadistico.ListadoEstadistico());
            //FormInicial = new Login();
            //Application.Run(FormInicial);
            //Application.Run(new Login());
            //Application.Run(new Login());
            Application.Run(new PantallaInicial());

        }
    }
}
