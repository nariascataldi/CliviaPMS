using System.ComponentModel.DataAnnotations;

namespace Clivia.Core.Dtos
{
    public class CrearHabitacionDto
    {
        [Required]
        [MaxLength(20)]
        public required string NumeroHabitacion { get; set; }

        [Required]
        [MaxLength(50)]
        public required string TipoHabitacion { get; set; }

        public string Descripcion { get; set; } = string.Empty;
        public short Capacidad { get; set; }
        [MaxLength(100)] public string Detalle { get; set; } = string.Empty;

        [Required]
        [Range(0.01, double.MaxValue)]
        public required decimal PrecioPorNoche { get; set; }

        [Required]
        public required int IdPropiedad { get; set; }

        [Required]
        public required short IdEstadoHabitacion { get; set; }

        [Required]
        public required short IdPiso { get; set; }

        [Required]
        public required short IdCategoria { get; set; }
    }
}