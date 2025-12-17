using System.ComponentModel.DataAnnotations;

namespace Ven.Shared.Entities;

public class Country
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Pais")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [MaxLength(200, ErrorMessage = "El campo {0} no puede ser mayor a {1}")]
    public string Name { get; set; } = null!;

    public bool Active { get; set; }
}
