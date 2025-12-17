namespace Ven.Shared.Entities;

public class PaginationDTO
{
    public int Id { get; set; }
    public int Page { get; set; }
    public int RecordsNumber { get; set; } = 2; // Numero de Registros que se muestran por paginacion
    public string? Filter { get; set; }
    public string? Email { get; set; }
}
