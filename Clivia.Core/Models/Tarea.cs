using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clivia.Core.Models
{
    public class Tarea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        public int IdUsuarioAsignado { get; set; }
        public virtual Usuario UsuarioAsignado { get; set; } = null!;

        public DateTime FechaAsignacion { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime? FechaVencimiento { get; set; }

        [MaxLength(50)]
        public string EstadoTarea { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Prioridad { get; set; } = string.Empty;

        public string Comentarios { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string CreadoPor { get; set; } = string.Empty;

        public DateTime? FechaModificacion { get; set; }

        [MaxLength(50)]
        public string ModificadoPor { get; set; } = string.Empty;
    }
}