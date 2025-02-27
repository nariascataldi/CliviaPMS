using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clivia.Core.Models
{
    public class Resena
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; } = null!;

        [Required]
        public int IdPropiedad { get; set; }
        public virtual Propiedad Propiedad { get; set; } = null!;

        [Required]
        [Range(1, 5)]
        public short Calificacion { get; set; }

        public string Comentario { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string CreadoPor { get; set; } = string.Empty;

        public DateTime? FechaModificacion { get; set; }

        [MaxLength(50)]
        public string ModificadoPor { get; set; } = string.Empty;
    }
}