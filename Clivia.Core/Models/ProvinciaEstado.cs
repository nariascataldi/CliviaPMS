using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clivia.Core.Models
{
    public class ProvinciaEstado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public int IdPais { get; set; }
        public virtual Pais Pais { get; set; } = null!;
        public virtual ICollection<CodigoPostal> CodigosPostales { get; set; } = new List<CodigoPostal>();
    }
}