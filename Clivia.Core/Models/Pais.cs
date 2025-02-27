using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clivia.Core.Models
{
    public class Pais
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(2)]
        public string CodigoISO { get; set; } = string.Empty;

        public virtual ICollection<ProvinciaEstado> ProvinciasEstados { get; set; } = new List<ProvinciaEstado>();

    }
}
