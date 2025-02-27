using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clivia.Core.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string TipoDocumento { get; set; } = string.Empty;

        [Required]
        [MaxLength(15)]
        public string Documento { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string NombreCompleto { get; set; } = string.Empty;

        [MaxLength(50)]
        [EmailAddress]
        public string Correo { get; set; } = string.Empty;

        [MaxLength(15)]
        public string NumeroTelefono { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Direccion { get; set; } = string.Empty;

        public bool Estado { get; set; } = false;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string CreadoPor { get; set; } = string.Empty;

        public DateTime? FechaModificacion { get; set; }

        [MaxLength(50)]
        public string ModificadoPor { get; set; } = string.Empty;
    }
}