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
        public virtual Propiedad Propiedad { get; set; }

        [Required]
        [MaxLength(20)]
        public string NumeroHabitacion { get; set; }

        [Required]
        [MaxLength(50)]
        public string TipoHabitacion { get; set; }

        public string Descripcion { get; set; }

        public short? Capacidad { get; set; } // Usar short? para SMALLINT

        [MaxLength(100)]
        public string Detalle { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioPorNoche { get; set; }

        public short? IdEstadoHabitacion { get; set; }
        public virtual EstadoHabitacion EstadoHabitacion { get; set; }

        public short? IdPiso { get; set; }
        public virtual Piso Piso { get; set; }

        public short? IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }

        public bool Estado { get; set; } = true; // Valor por defecto

        public DateTime FechaCreacion { get; set; } = DateTime.Now; // Valor por defecto

        [MaxLength(50)]
        public string CreadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        [MaxLength(50)]
        public string ModificadoPor { get; set; }

        public virtual ICollection<HabitacionesFecha> HabitacionesFechas { get; set; } = new List<HabitacionesFecha>();

        public virtual ICollection<ResultadosChecklist> ResultadosChecklists { get; set; } = new List<ResultadosChecklist>();
    }
}