using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clivia.Core.Models
{
    public class ResultadoChecklist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int IdChecklist { get; set; }
        public virtual Checklist Checklist { get; set; }

        public int? IdHabitacion { get; set; }
        public virtual Habitacion Habitacion { get; set; }

        [Required]
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }

        public DateTime FechaAplicacion { get; set; } = DateTime.Now;

        public virtual ICollection<ResultadoItemChecklist> ResultadosItemsChecklists { get; set; } = new List<ResultadoItemChecklist>();
    }
}