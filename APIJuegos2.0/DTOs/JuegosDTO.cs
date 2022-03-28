using System.ComponentModel.DataAnnotations;
using APIJuegos2._0.Validaciones;

namespace APIJuegos2._0.DTOs
{
    public class JuegosDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} solo puede tener hasta 100 caracteres.")]
        [PrimeraLetraMayusculaAttribute]
        public string Nombre { get; set; }
    }
}
