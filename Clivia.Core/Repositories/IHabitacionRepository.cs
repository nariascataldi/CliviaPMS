using Clivia.Core.Models;

namespace Clivia.Core.Repositories
{
    public interface IHabitacionRepository
    {
        Task<IEnumerable<Habitacion>> ObtenerTodasLasHabitaciones();
        Task<Habitacion> ObtenerHabitacionPorId(int id);
        Task<Habitacion> CrearHabitacion(Habitacion habitacion);
        Task<Habitacion> ActualizarHabitacion(Habitacion habitacion);
        Task<bool> EliminarHabitacion(int id);
    }
}