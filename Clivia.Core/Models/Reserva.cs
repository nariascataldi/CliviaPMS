using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clivia.Core.Models
{
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }

        [Required]
        public int IdPropiedad { get; set; }
        public virtual Propiedad Propiedad { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaEntrada { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaSalida { get; set; }

        [Required]
        public short NumeroAdultos { get; set; }

        public short? NumeroNinios { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioTotal { get; set; }

        [MaxLength(50)]
        public string EstadoReserva { get; set; }

        //public string Comentarios { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string CreadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        [MaxLength(50)]
        public string ModificadoPor { get; set; }

        public virtual ICollection<ServicioReserva> ServiciosReservas { get; set; } = new List<ServiciosReservas>();
        public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
        public virtual ICollection<HabitacionFecha> HabitacionesFechas { get; set; } = new List<HabitacionesFecha>();


    }
}