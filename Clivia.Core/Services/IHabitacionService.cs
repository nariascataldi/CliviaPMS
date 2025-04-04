using Clivia.Core.Dtos;

namespace Clivia.Core.Services
{
    public interface IHabitacionService
    {
        Task<IEnumerable<HabitacionDto>> ObtenerTodasLasHabitacionesAsync(); // Devuelve DTO
        Task<HabitacionDto> ObtenerHabitacionPorIdAsync(int id); // Devuelve DTO
        Task<HabitacionDto> CrearHabitacionDesdeDtoAsync(CrearHabitacionDto dto); // Acepta y devuelve DTO
        Task<HabitacionDto> ActualizarHabitacionDesdeDtoAsync(int id, ActualizarHabitacionDto dto); // Acepta y devuelve DTO (o void/bool)
        Task<bool> EliminarHabitacionAsync(int id);
    }
}