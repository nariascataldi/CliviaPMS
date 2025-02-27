using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clivia.Core.Models
{
    public class Comentario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; } = null!;

        public int? IdReserva { get; set; }
        public virtual Reserva Reserva { get; set; } = null!;

        public short? Calificacion { get; set; }

        public string ComentarioTexto { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}