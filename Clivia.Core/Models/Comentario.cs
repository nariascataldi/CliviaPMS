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
        public virtual Usuario Usuario { get; set; }

        public int? IdReserva { get; set; }
        public virtual Reserva Reserva { get; set; }

        public short? Calificacion { get; set; }

        public string ComentarioTexto { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}