using System.Collections.Generic;
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
        public string Calle { get; set; }

        [Required]
        [MaxLength(8)]
        public string NumeroUnidad { get; set; }

        [Required]
        [MaxLength(7)]
        public string CodigoPostal { get; set; }
        public virtual CodigoPostal CodigosPostales { get; set; }

        [MaxLength(50)]
        public string Ciudad { get; set; }

        public int? IdProvinciaEstado { get; set; }
        public virtual ProvinciaEstado ProvinciasEstados { get; set; }

        public int? IdPais { get; set; }
        public virtual Pais Pais { get; set; }

        public virtual ICollection<Propiedad> Propiedades { get; set; } = new List<Propiedad>();
    }
}