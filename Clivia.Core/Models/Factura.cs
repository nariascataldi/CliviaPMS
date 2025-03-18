using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clivia.Core.Models
{
    public class Factura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int IdReserva { get; set; }
        public virtual Reserva Reserva { get; set; } = null!;

        public DateTime FechaEmision { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoTotal { get; set; }

        [MaxLength(50)]
        public string MetodoPago { get; set; } = string.Empty;

        [MaxLength(50)]
        public string EstadoFactura { get; set; } = string.Empty;

        public string Detalles { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string CreadoPor { get; set; } = string.Empty;

        public DateTime? FechaModificacion { get; set; }

        [MaxLength(50)]
        public string ModificadoPor { get; set; } = string.Empty;
    }
}