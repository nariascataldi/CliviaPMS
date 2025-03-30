using Clivia.Core.Models;
using Clivia.Core.Repositories;
using Clivia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Clivia.Infrastructure.Repositories
{
    public class HabitacionRepository : IHabitacionRepository
    {
        private readonly CliviaDbContext _context;

        public HabitacionRepository(CliviaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Habitacion>> ObtenerTodasLasHabitaciones()
        {
            return await _context.Habitaciones.ToListAsync();
        }

        public async Task<Habitacion> ObtenerHabitacionPorId(int id)
        {
            var habitacion = await _context.Habitaciones.FindAsync(id);
            if (habitacion == null)
            {
                // Puedes elegir la excepción que mejor se adapte (e.g., NotFoundException personalizada)
                throw new KeyNotFoundException($"No se encontró ninguna Habitación con el ID {id}.");
            }
            return habitacion;
        }

        public async Task<Habitacion> CrearHabitacion(Habitacion habitacion)
        {
            _context.Habitaciones.Add(habitacion);
            await _context.SaveChangesAsync();
            return habitacion;
        }

        public async Task<Habitacion> ActualizarHabitacion(Habitacion habitacion)
        {
            _context.Entry(habitacion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return habitacion;
        }

        public async Task<bool> EliminarHabitacion(int id)
        {
            var habitacion = await _context.Habitaciones.FindAsync(id);
            if (habitacion == null)
            {
                return false;
            }

            _context.Habitaciones.Remove(habitacion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}