using AutoMapper; // Necesario para IMapper
using Clivia.Core.Dtos;
using Clivia.Core.Models;
using Clivia.Core.Repositories;
using Clivia.Core.Services;
using Microsoft.EntityFrameworkCore;

// Considera añadir usings para otros repositorios si haces validación de IDs aquí
// using Clivia.Core.Repositories; // Por ejemplo, para IPropiedadRepository

namespace Clivia.Application.Services
{
    public class HabitacionService : IHabitacionService
    {
        private readonly IHabitacionRepository _habitacionRepository;
        private readonly IMapper _mapper;
        // Opcional: Inyectar otros repositorios para validar IDs
        // private readonly IPropiedadRepository _propiedadRepository;
        // private readonly IEstadoHabitacionRepository _estadoHabitacionRepository;
        // ... etc

        public HabitacionService(
            IHabitacionRepository habitacionRepository,
            IMapper mapper
            // ,IPropiedadRepository propiedadRepository // Inyectar si validas
            // ... etc
            )
        {
            _habitacionRepository = habitacionRepository;
            _mapper = mapper;
            // _propiedadRepository = propiedadRepository; // Asignar si validas
            // ... etc
        }

        public Task<HabitacionDto> CrearHabitacionDesdeDto(CrearHabitacionDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<HabitacionDto>> ObtenerTodasLasHabitacionesAsync()
        {
            // 1. Obtener las entidades desde el repositorio
            var habitacionesEntidad = await _habitacionRepository.ObtenerTodasLasHabitaciones();

            // 2. Mapear las entidades a DTOs usando AutoMapper
            var habitacionesDto = _mapper.Map<IEnumerable<HabitacionDto>>(habitacionesEntidad);

            // 3. Devolver los DTOs mapeados
            return habitacionesDto;
        }

        public Task<IEnumerable<Habitacion>> ObtenerTodasLasHabitaciones()
        {
            throw new NotImplementedException();
        }

        public async Task<Habitacion> ObtenerHabitacionPorId(int id)
        {
             // Considera devolver HabitacionDto aquí también
            return await _habitacionRepository.ObtenerHabitacionPorId(id);
        }

        public Task<Habitacion> CrearHabitacion(Habitacion habitacion)
        {
            throw new NotImplementedException();
        }

        public async Task<HabitacionDto> ObtenerHabitacionPorIdAsync(int id)
        {
            var habitacion = await _habitacionRepository.ObtenerHabitacionPorId(id);
            // Manejar caso no encontrado si el repo devuelve null
            if (habitacion == null)
            {
                // Puedes lanzar una excepción específica o devolver null según tu diseño
                throw new KeyNotFoundException($"No se encontró Habitación con ID {id}");
                // return null;
            }
            return _mapper.Map<HabitacionDto>(habitacion);
        }

        public Task<HabitacionDto> ActualizarHabitacionDesdeDto(Habitacion habitacion)
        {
            throw new NotImplementedException();
        }


        // Puedes mantener este método si lo necesitas internamente,
        // pero la creación desde la API debería usar el método con DTO.
        // public async Task<Habitacion> CrearHabitacion(Habitacion habitacion)
        // {
        //     return await _habitacionRepository.CrearHabitacion(habitacion);
        // }

        public async Task<Habitacion> ActualizarHabitacion(Habitacion habitacion)
        {
            // Idealmente, tendrías un método ActualizarHabitacionDesdeDto similar
            return await _habitacionRepository.ActualizarHabitacion(habitacion);
        }
// TODO: ActualizarHabitacionDesdeDto
        // public async Task<HabitacionDto> ActualizarHabitacionDesdeDto(HabitacionDto habitacion)
        // {
        //     var habitacionExistente = await _habitacionRepository.ObtenerHabitacionPorId(habitacion.Id);
        //     if (habitacionExistente == null)
        //     {
        //         throw new KeyNotFoundException($"No se encontró Habitación con ID {habitacion.Id} para actualizar.");
        //     }
        //
        //     // Mapear los cambios del DTO sobre la entidad existente
        //     _mapper.Map(habitacion, habitacionExistente);
        //
        //     return await _habitacionRepository.ActualizarHabitacion(habitacionExistente);
        // }

        public async Task<bool> EliminarHabitacion(int id)
        {
            return await _habitacionRepository.EliminarHabitacion(id);
        }

        // --- Implementación del nuevo método ---
        // TODO: Actualizar el HabitacionRepositorio para que sea compatible con automapper
        // public async Task<HabitacionDto> CrearHabitacionDesdeDto(CrearHabitacionDto dto)
        // {
        //     // 1. Validación (Opcional pero Recomendado):
        //     //    Verificar que los IDs (IdPropiedad, IdEstadoHabitacion, etc.) existen.
        //     //    Si no existen, podrías retornar null o lanzar una excepción específica.
        //     //    Ejemplo (requiere inyectar los repositorios correspondientes):
        //     //    var propiedadExiste = await _propiedadRepository.ObtenerPropiedadPorId(dto.IdPropiedad) != null;
        //     //    if (!propiedadExiste) return null; // O lanzar excepción
        //
        //     // 2. Mapear el DTO a la Entidad Habitacion
        //     var nuevaHabitacion = _mapper.Map<Habitacion>(dto);
        //
        //     // 3. Establecer valores predeterminados o calculados si es necesario
        //     //    (AutoMapper puede haber manejado los campos básicos)
        //     //    Ej: nuevaHabitacion.FechaCreacion = DateTime.UtcNow;
        //     //    Ej: nuevaHabitacion.CreadoPor = "UsuarioActual"; // Necesitarías obtener el usuario actual
        //
        //     // 4. Llamar al Repositorio para crear la entidad
        //     try
        //     {
        //         var habitacionCreada = await _habitacionRepository.CrearHabitacion(nuevaHabitacion);
        //         return habitacionCreada;
        //     }
        //     catch (DbUpdateException ex) // Captura errores de BD (ej: FK constraint)
        //     {
        //          // Loguear el error (ex)
        //          // Podrías analizar ex.InnerException para ver si es una violación de FK
        //          // y devolver null o lanzar una excepción más específica si un ID era inválido.
        //         Console.WriteLine($"Error al guardar la habitación: {ex.Message}"); // Logging simple
        //         return null; // Indica que hubo un problema al guardar
        //     }
        // }
    }
}