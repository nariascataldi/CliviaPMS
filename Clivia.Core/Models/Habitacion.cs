using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clivia.Core.Models
{
    public class Habitacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int IdPropiedad { get; set; }
        public virtual Propiedad Propiedad { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string NumeroHabitacion { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string TipoHabitacion { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public short? Capacidad { get; set; } // Usar short? para SMALLINT

        [MaxLength(100)]
        public string Detalle { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PrecioPorNoche { get; set; }

        public short? IdEstadoHabitacion { get; set; }
        public virtual EstadoHabitacion EstadoHabitacion { get; set; } = null!;

        public short? IdPiso { get; set; }
        public virtual Piso Piso { get; set; } = null!;

        public short? IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; } = null!;

        public bool Estado { get; set; } = false; // Valor por defecto

        public DateTime FechaCreacion { get; set; } = DateTime.Now; // Valor por defecto

        [MaxLength(50)]
        public string CreadoPor { get; set; } = string.Empty;

        public DateTime? FechaModificacion { get; set; }

        [MaxLength(50)]
        public string ModificadoPor { get; set; } = string.Empty;

        public virtual ICollection<HabitacionFecha> HabitacionesFechas { get; set; } = new List<HabitacionFecha>();

        public virtual ICollection<ResultadoChecklist> ResultadosChecklists { get; set; } = new List<ResultadoChecklist>();
    }
}