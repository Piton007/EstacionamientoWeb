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
        [DisplayName("Cod_Boleta")]

        public int Id { get; set; }
        [DisplayName("Monto")]
        [Required(ErrorMessage ="Please enter Monto")]
        public double Monto { get; set; }
        [DisplayName("Registro")]
        public Ingreso cod_ingreso { get; set; }
        [DisplayName("Fecha Fin")]
        [Required(ErrorMessage ="Please enter Fecha Fin")]
        public DateTime FechaFinal { get; set; }


    }
}
