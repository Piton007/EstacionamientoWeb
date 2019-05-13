using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ingreso
    {
        [DisplayName("Codigo Ingreso: ")]
        public int CodIngreso { get; set; }
        [DisplayName("Tarifa: ")]
        [Required(ErrorMessage = "Ingrese Tarifa")]
        public Tarifa Tarifa { get; set; }
        [DisplayName("Placa: ")]
        [Required(ErrorMessage = "Ingrese Placa")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "La placa solo tiene 7 caracteres")]
        public string Placa { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Cajero Cajero { get; set; }
        public Espacio Espacio { get; set; }

    }
}
