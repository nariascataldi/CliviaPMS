using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clivia.Core.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string CorreoElectronico { get; set; }

        [Required]
        [MaxLength(255)] // Adjust based on hashing algorithm
        public string Contrasena { get; set; }

        [Required]
        [MaxLength(25)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(25)]
        public string Apellido { get; set; }

        [MaxLength(15)]
        public string NumeroTelefono { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaNacimiento { get; set; }

        public bool EsUsuario { get; set; } = true;

        public short? IdRolUsuario { get; set; }
        public virtual RolUsuario RolesUsuarios { get; set; }

        public bool Estado { get; set; } = true;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string CreadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        [MaxLength(50)]
        public string ModificadoPor { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
        public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
        public virtual ICollection<Asistencia> Asistencias { get; set; } = new List<Asistencia>();
        public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
        public virtual ICollection<ResultadoChecklist> ResultadosChecklists { get; set; } = new List<ResultadosChecklist>();

    }
}