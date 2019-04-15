using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comprobante
    {

        public int Id { get; set; }
        [DisplayName("Fecha")]
        [Required(ErrorMessage="Please enter Fecha")]
        public DateTime FechaInicio { get; set; }
        [DisplayName("Monto")]
        public double Monto { get; set; }
    }
}
