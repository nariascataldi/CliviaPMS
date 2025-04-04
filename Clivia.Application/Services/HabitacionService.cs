using AutoMapper;
using Clivia.Core.Dtos;
using Clivia.Core.Models;
using Clivia.Core.Repositories;
using Clivia.Core.Services;
using Microsoft.EntityFrameworkCore; // Para DbUpdateException

namespace Clivia.Application.Services
{
    public class HabitacionService : IHabitacionService
    {
        private readonly IHabitacionRepository _habitacionRepository;
        private readonly IMapper _mapper;
        // Inyectar otros repos si validas IDs:
        // private readonly IPropiedadRepository _propiedadRepository;

        public HabitacionService(IHabitacionRepository habitacionRepository, IMapper mapper /*, IPropiedadRepository propiedadRepository*/)
        {
            _habitacionRepository = habitacionRepository ?? throw new ArgumentNullException(nameof(habitacionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            // _propiedadRepository = propiedadRepository;
        }

        public async Task<IEnumerable<HabitacionDto>> ObtenerTodasLasHabitacionesAsync()
        {
            var entidades = await _habitacionRepository.ObtenerTodasLasHabitaciones();
            return _mapper.Map<IEnumerable<HabitacionDto>>(entidades); // Mapea a DTO
        }

        public async Task<HabitacionDto> ObtenerHabitacionPorIdAsync(int id)
        {
            var entidad = await _habitacionRepository.ObtenerHabitacionPorId(id);
            if (entidad == null)
            {
                // Considera lanzar una excepción específica o devolver null
                // dependiendo de cómo quieras manejarlo en el controlador.
                // Lanzar es a menudo más explícito para "no encontrado".
                throw new KeyNotFoundException($"No se encontró Habitación con ID {id}");
                // return null;
            }
            return _mapper.Map<HabitacionDto>(entidad); // Mapea a DTO
        }

        public async Task<HabitacionDto> CrearHabitacionDesdeDtoAsync(CrearHabitacionDto dto)
        {
            // --- Validación Opcional de IDs relacionados ---
            // Ejemplo: var prop = await _propiedadRepository.GetByIdAsync(dto.IdPropiedad); if (prop == null) throw new ArgumentException(...);
            // --- Fin Validación ---

            var entidad = _mapper.Map<Habitacion>(dto); // Mapea DTO a Entidad

            // Aquí puedes establecer valores que no vienen del DTO si es necesario
            // entidad.FechaCreacion = DateTime.UtcNow;
            // entidad.CreadoPor = "Sistema"; // O obtener usuario actual

            try
            {
                var entidadCreada = await _habitacionRepository.CrearHabitacion(entidad);
                return _mapper.Map<HabitacionDto>(entidadCreada); // Mapea la entidad creada de vuelta a DTO
            }
            catch (DbUpdateException ex) // Captura errores específicos de EF Core
            {
                // Loguear el error (ex)
                // Podrías devolver una excepción personalizada o null
                Console.WriteLine($"Error de base de datos al crear habitación: {ex.InnerException?.Message ?? ex.Message}");
                throw new Exception("Error al guardar la habitación en la base de datos.", ex); // Relanza o maneja
            }
        }

        public async Task<HabitacionDto> ActualizarHabitacionDesdeDtoAsync(int id, ActualizarHabitacionDto dto)
        {
            var entidadExistente = await _habitacionRepository.ObtenerHabitacionPorId(id);
            if (entidadExistente == null)
            {
                throw new KeyNotFoundException($"No se encontró Habitación con ID {id} para actualizar.");
            }

            // --- Validación Opcional de IDs relacionados en el DTO de actualización ---

            // Mapea los cambios del DTO sobre la entidad existente que recuperaste
            _mapper.Map(dto, entidadExistente);

            // Aquí puedes establecer valores de auditoría si es necesario
            // entidadExistente.FechaModificacion = DateTime.UtcNow;
            // entidadExistente.ModificadoPor = "Sistema";

            try
            {
                var entidadActualizada = await _habitacionRepository.ActualizarHabitacion(entidadExistente);
                 return _mapper.Map<HabitacionDto>(entidadActualizada); // Devuelve el DTO actualizado
            }
             catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error de base de datos al actualizar habitación: {ex.InnerException?.Message ?? ex.Message}");
                throw new Exception("Error al guardar los cambios de la habitación en la base de datos.", ex);
            }
            // Si el método de la interfaz devolviera void o bool, no necesitarías mapear de vuelta.
            // await _habitacionRepository.ActualizarHabitacion(entidadExistente);
            // return true; // o simplemente no devolver nada (void)
        }

        public async Task<bool> EliminarHabitacionAsync(int id)
        {
             // Podrías querer verificar si existe antes de intentar eliminar
             var entidad = await _habitacionRepository.ObtenerHabitacionPorId(id);
             if (entidad == null)
             {
                  return false; // O lanzar KeyNotFoundException si prefieres
             }
            return await _habitacionRepository.EliminarHabitacion(id);
        }
    }
}