using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tarifa
    {
        public int Id { get; set; }
        public double MontoTarifa { get; set; }
        [DisplayName("Tipo Vehiculo")]
        [Required(ErrorMessage = "Ingrese Tipo Vehiculo")]
        public string TipoVehiculo { get; set; }
    }
}
