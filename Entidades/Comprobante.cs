using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Comprobante
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public double Monto { get; set; }
    }
}
