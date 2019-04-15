using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ingreso
    {
        public int CodIngreso { get; set; }
        public Tarifa Tarifa { get; set; }
        public string Placa { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Cajero Cajero { get; set; }
        public Espacio Espacio { get; set; }

    }
}
