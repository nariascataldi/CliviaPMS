using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clivia.Core.Models
{
    public class CodigoPostal
    {
        [Key]
        [MaxLength(7)]
        public string Codigo { get; set; }

        [MaxLength(50)]
        public string Ciudad { get; set; }

        [Required]
        public int IdProvinciaEstado { get; set; }
        public virtual ProvinciaEstado ProvinciasEstados { get; set; }

        public virtual ICollection<Direccion> Direcciones { get; set; } = new List<Direccion>();
    }
}