using Clivia.Core.Models;
using Clivia.Core.Dtos; // Asegúrate de tener el using para los DTOs

namespace Clivia.Core.Services
{
    public interface IHabitacionService
    {
        Task<IEnumerable<Habitacion>> ObtenerTodasLasHabitaciones();
        Task<Habitacion> ObtenerHabitacionPorId(int id);
        // Task<Habitacion> CrearHabitacion(Habitacion habitacion); // Puedes comentar o eliminar esta si ya no la usas directamente
        Task<Habitacion> ActualizarHabitacion(Habitacion habitacion); // Probablemente también querrás un DTO para actualizar
        Task<bool> EliminarHabitacion(int id);

        // --- Nuevo método para crear desde DTO ---
        Task<Habitacion> CrearHabitacionDesdeDto(CrearHabitacionDto dto);
    }
}