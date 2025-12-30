using System.ComponentModel.DataAnnotations;

namespace Ven.Shared.Entities;

public class City
{
    [Key]
    public int CityId { get; set; }

    public int StateId { get; set; }

    [Display(Name = "Ciudad")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [MaxLength(200, ErrorMessage = "El campo {0} no puede ser mayor a {1}")]
    public string Name { get; set; } = null!;

    // Relacion uno a uno
    public State? State { get; set; }
}
