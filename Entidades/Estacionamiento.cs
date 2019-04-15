using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estacionamiento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int NroEspacios { get; set; }
        public string Direccion { get; set; }
    }
}
