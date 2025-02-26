using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clivia.Core.Models
{
    public class RolUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }

        public bool Estado { get; set; } = true;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string CreadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        [MaxLength(50)]
        public string ModificadoPor { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
