using System.ComponentModel.DataAnnotations;
using APIJuegos2._0.Validaciones;
namespace APIJuegos2._0.Entidades
{
    public class Juegos
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength:100,ErrorMessage="El campo {0} solo puede tener hasta 100 caracteres.")]
        [PrimeraLetraMayusculaAttribute]
        public string Nombre { get; set; }

    }
}
