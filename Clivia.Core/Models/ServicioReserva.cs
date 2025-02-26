using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clivia.Core.Models
{
    public class ServicioReserva
    {
        [Key, Column(Order = 0)]
        public int IdReserva { get; set; }
        public virtual Reserva Reserva { get; set; }

        [Key, Column(Order = 1)]
        public int IdServicio { get; set; }
        public virtual Servicio Servicio { get; set; }

        [Required]
        public short Cantidad { get; set; }

        public string Comentarios { get; set; }
    }
}