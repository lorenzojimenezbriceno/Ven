using System.ComponentModel.DataAnnotations;

namespace Ven.Shared.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = null!;
    }
}
