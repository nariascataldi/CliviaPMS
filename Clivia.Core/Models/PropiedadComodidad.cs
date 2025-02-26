using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clivia.Core.Models
{
    public class PropiedadComodidad
    {
        [Key, Column(Order = 0)]
        public int IdPropiedad { get; set; }
        public virtual Propiedad Propiedad { get; set; }

        [Key, Column(Order = 1)]
        public short IdComodidad { get; set; }
        public virtual Comodidad Comodidades { get; set; }
    }
}
