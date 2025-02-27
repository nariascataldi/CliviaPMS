using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clivia.Core.Models
{
    public class Propiedad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string NombrePropiedad { get; set; } = string.Empty;

        [MaxLength(15)]
        public string NumeroTelefono { get; set; } = string.Empty;

        [Required]
        public int IdDireccion { get; set; }
        public virtual Direccion Direccion { get; set; } = null!;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string CreadoPor { get; set; } = string.Empty;

        public DateTime? FechaModificacion { get; set; }

        [MaxLength(50)]
        public string ModificadoPor { get; set; } = string.Empty;

        public virtual ICollection<Habitacion> Habitaciones { get; set; } = new List<Habitacion>();
        public virtual ICollection<Resena> Resenas { get; set; } = new List<Resena>();
        public virtual ICollection<PropiedadComodidad> PropiedadesComodidades { get; set; } = new List<PropiedadComodidad>();
        public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}