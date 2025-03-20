using Clivia.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clivia.Core.Services
{
    public interface IHabitacionService
    {
        Task<IEnumerable<Habitacion>> ObtenerTodasLasHabitaciones();
        Task<Habitacion> ObtenerHabitacionPorId(int id);
        Task<Habitacion> CrearHabitacion(Habitacion habitacion);
        Task<Habitacion> ActualizarHabitacion(Habitacion habitacion);
        Task<bool> EliminarHabitacion(int id);
    }
}