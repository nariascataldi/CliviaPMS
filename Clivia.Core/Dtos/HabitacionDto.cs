namespace Clivia.Core.Dtos;

public class HabitacionDto
{
    public int Id { get; set; }
    public string? NumeroHabitacion { get; set; }
    public string? TipoHabitacion { get; set; }
    public string? Descripcion { get; set; }
    public short? Capacidad { get; set; }
    public string? Detalle { get; set; }
    public decimal PrecioPorNoche { get; set; }
    // Puedes incluir nombres/descripciones de las entidades relacionadas si es útil para el cliente
    public string? NombreEstadoHabitacion { get; set; }
    public string? DescripcionPiso { get; set; }
    public string? DescripcionCategoria { get; set; }
    public string? NombrePropiedad { get; set; }
    // O solo los IDs si prefieres que el cliente los busque por separado
    // public int IdEstadoHabitacion { get; set; }
    // public int IdPiso { get; set; }
    // public int IdCategoria { get; set; }
    // public int IdPropiedad { get; set; }
}