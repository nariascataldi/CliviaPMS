namespace Clivia.Core.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int HabitacionId { get; set; }
        public Habitacion Habitacion { get; set; } // Propiedad de navegación
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } // Propiedad de navegación
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public int NumeroAdultos { get; set; }
        public int NumeroNinios { get; set; }
        public string Estado { get; set; } // O enum EstadoReserva
    }
}