namespace Clivia.Core.Models
{
    public class Habitacion
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public TipoHabitacion Tipo { get; set; }
        public decimal PrecioPorNoche { get; set; }
        public bool Disponible { get; set; }
    }

    public enum TipoHabitacion
    {
        Individual,
        Doble,
        Suite
    }
}
