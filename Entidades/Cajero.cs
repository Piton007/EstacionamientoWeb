using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Cajero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Turno { get; set; }

        public Cajero() { }

        public Cajero(int id, string nombre, string turno)
        {
            Id = id;
            Nombre = nombre;
            Turno = turno;
        }

    }
}
