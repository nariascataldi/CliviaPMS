using System.ComponentModel.DataAnnotations;

namespace Clivia.Core.Models
{
    public class CodigoPostal
    {
        [Key]
        [MaxLength(7)]
        public string Codigo { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Ciudad { get; set; } = string.Empty;

        [Required]
        public int IdProvinciaEstado { get; set; }
        public virtual ProvinciaEstado ProvinciasEstados { get; set; } = null!;

        public virtual ICollection<Direccion> Direcciones { get; set; } = new List<Direccion>();
    }
}