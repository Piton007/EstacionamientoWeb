using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Localizacion
    {
        [DisplayName(" Nombre Local")]
        public int CodLocalizacion { get; set; }
        
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
    }
}
