using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clivia.Core.Models
{
    public class ProvinciasEstados
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        public int IdPais { get; set; }
        public virtual Pais Pais { get; set; }
        public virtual ICollection<CodigosPostales> CodigosPostales { get; set; } = new List<CodigosPostales>();
    }
}using System;
namespace Clivia.Core.Models
{
	public class ProvinciasEstados
	{
		public ProvinciasEstados()
		{
		}
	}
}

