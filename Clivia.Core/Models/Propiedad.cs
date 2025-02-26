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
        public string NombrePropiedad { get; set; }

        [MaxLength(15)]
        public string NumeroTelefono { get; set; }

        [Required]
        public int IdDireccion { get; set; }
        public virtual Direccion Direccion { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string CreadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        [MaxLength(50)]
        public string ModificadoPor { get; set; }
        public virtual ICollection<Habitacion> Habitaciones { get; set; } = new List<Habitacion>();
        public virtual ICollection<Resena> Resenas { get; set; } = new List<Resena>();

        public virtual ICollection<PropiedadesComodidades> PropiedadesComodidades { get; set; } = new List<PropiedadesComodidades>();

        public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    }
}