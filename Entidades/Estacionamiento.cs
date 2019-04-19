using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estacionamiento
    {
        public int Id { get; set; }
        [Required(ErrorMessage = " Ingrese Nombre Estacionamiento")]
        [DisplayName("Nombre Estacionamiento")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre no se debe superar los 50 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = " Ingrese numero de espacios")]
        [DisplayName(" Nro Espacios")]
        [Range(1, 50, ErrorMessage = "Solo puede alberga un maximo de 50 espacios")]
        public int espacios { get; set; }
        [DisplayName(" Direccion ")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "La direccion no se debe superar los 50 caracteres")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Please select a Local")]
        [DisplayName("Ingrese Nombre Local")]
        public Localizacion localizacion { get; set; }
    }
}
