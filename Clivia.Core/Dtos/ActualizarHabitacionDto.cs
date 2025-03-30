using System.ComponentModel.DataAnnotations;

namespace Clivia.Core.Dtos
{
    public class ActualizarHabitacionDto
    {
        // Podrías requerir solo algunos campos para la actualización
        [Required] [MaxLength(20)] public string NumeroHabitacion { get; set; } = string.Empty;
        // ... otros campos que se pueden actualizar
        [Required] public decimal PrecioPorNoche { get; set; }

        [Required] public short IdEstadoHabitacion { get; set; }
        // ... etc
    }
}