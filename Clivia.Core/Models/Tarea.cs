using System;
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
        public string Descripcion { get; set; }

        [Required]
        public int IdUsuarioAsignado { get; set; }
        public virtual Usuario UsuarioAsignado { get; set; }

        public DateTime FechaAsignacion { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime? FechaVencimiento { get; set; }

        [MaxLength(50)]
        public string EstadoTarea { get; set; }

        [MaxLength(50)]
        public string Prioridad { get; set; }

        public string Comentarios { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string CreadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        [MaxLength(50)]
        public string ModificadoPor { get; set; }
    }
}