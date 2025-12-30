using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Ven.Shared.Entities;

public class State
{
    [Key]
    public int StateId { get; set; }

    public int CountryId { get; set; }

    [Display(Name = "Estado")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [MaxLength(200, ErrorMessage = "El campo {0} no puede ser mayor a {1}")]
    public string Name { get; set; } = null!;

    // Relacion uno a uno
    public Country? Country { get; set; }

    // Relacion uno a muchos
    public ICollection<City>? Cities { get; set; }
}
