using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clivia.Core.Models
{
    public class ResultadoItemChecklist
    {
        [Key, Column(Order = 0)]
        public int IdResultadosChecklist { get; set; }
        public virtual ResultadoChecklist ResultadosChecklist { get; set; }

        [Key, Column(Order = 1)]
        public int IdItemsChecklist { get; set; }
        public virtual ItemChecklist ItemsChecklist { get; set; }

        [Required]
        public bool Completado { get; set; }

        public string Comentarios { get; set; }


    }
}
