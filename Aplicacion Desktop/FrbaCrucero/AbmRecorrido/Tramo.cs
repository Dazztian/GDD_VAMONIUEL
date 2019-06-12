using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.AbmRecorrido
{
    class Tramo
    {
        public int id { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public decimal precio { get; set; }

        public Tramo(){}
    }
}
