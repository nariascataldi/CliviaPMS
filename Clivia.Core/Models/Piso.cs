using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clivia.Core.Models
{
    public class Piso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short Id { get; set; }

        [MaxLength(50)]
        public string Descripcion { get; set; } = string.Empty;

        public bool Estado { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string CreadoPor { get; set; } = string.Empty;

        public DateTime? FechaModificacion { get; set; }

        [MaxLength(50)]
        public string ModificadoPor { get; set; } = string.Empty;
        public virtual ICollection<Habitacion> Habitaciones { get; set; } = new List<Habitacion>();
    }
}