using Clivia.Core.Models;
using Clivia.Core.Repositories;
using Clivia.Core.Services;

namespace Clivia.Application.Services
{
    public class HabitacionService : IHabitacionService
    {
        private readonly IHabitacionRepository _habitacionRepository;

        public HabitacionService(IHabitacionRepository habitacionRepository)
        {
            _habitacionRepository = habitacionRepository;
        }

        public async Task<IEnumerable<Habitacion>> ObtenerTodasLasHabitaciones()
        {
            return await _habitacionRepository.ObtenerTodasLasHabitaciones();
        }

        public async Task<Habitacion> ObtenerHabitacionPorId(int id)
        {
            return await _habitacionRepository.ObtenerHabitacionPorId(id);
        }

        public async Task<Habitacion> CrearHabitacion(Habitacion habitacion)
        {
            // Aquí puedes añadir lógica de negocio adicional, como validaciones, etc.
            return await _habitacionRepository.CrearHabitacion(habitacion);
        }

        public async Task<Habitacion> ActualizarHabitacion(Habitacion habitacion)
        {
            // Aquí puedes añadir lógica de negocio adicional
            return await _habitacionRepository.ActualizarHabitacion(habitacion);
        }

        public async Task<bool> EliminarHabitacion(int id)
        {
            // Aquí puedes añadir lógica de negocio adicional
            return await _habitacionRepository.EliminarHabitacion(id);
        }
    }
}