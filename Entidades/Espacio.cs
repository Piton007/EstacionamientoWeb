using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Espacio
    {
        [DisplayName("Espacio ")]
        [Required(ErrorMessage = "Escoja un espacio")]
        public int Id { get; set; }
        public bool Disponible { get; set; }
        public Estacionamiento estacionamiento { get; set; }
    }
}
