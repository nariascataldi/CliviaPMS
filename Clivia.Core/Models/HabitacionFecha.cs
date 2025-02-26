using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clivia.Core.Models
{
    public class HabitacionFecha
    {
        [Key, Column(Order = 0)]
        public int IdHabitacion { get; set; }
        public virtual Habitacion Habitacion { get; set; }

        [Key, Column(Order = 1)]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Tarifa { get; set; }

        public int? IdReserva { get; set; }
        public virtual Reserva Reserva { get; set; }
    }
}