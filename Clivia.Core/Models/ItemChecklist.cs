using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clivia.Core.Models
{
    public class ItemChecklist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int IdChecklist { get; set; }
        public virtual Checklist Checklist { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public short? Orden { get; set; }


    }
}