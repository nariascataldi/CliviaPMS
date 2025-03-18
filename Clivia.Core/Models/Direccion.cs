using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clivia.Core.Models
{
    public class Direccion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Calle { get; set; } = string.Empty;

        [Required]
        [MaxLength(8)]
        public string NumeroUnidad { get; set; } = string.Empty;

        [Required]
        [MaxLength(7)]
        public string CodigoPostal { get; set; } = string.Empty;
        public virtual CodigoPostal CodigosPostales { get; set; } = null!;

        [MaxLength(50)]
        public string Ciudad { get; set; } = string.Empty;

        public int? IdProvinciaEstado { get; set; }
        public virtual ProvinciaEstado ProvinciasEstados { get; set; } = null!;

        public int? IdPais { get; set; }
        public virtual Pais Pais { get; set; } = null!;

        public virtual ICollection<Propiedad> Propiedades { get; set; } = new List<Propiedad>();
    }
}