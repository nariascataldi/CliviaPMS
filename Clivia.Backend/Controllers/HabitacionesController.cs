using AutoMapper; // Necesario para IMapper
using Clivia.Core.Dtos; // Namespace de tus DTOs
using Clivia.Core.Models;
using Clivia.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clivia.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HabitacionesController : ControllerBase
    {
        private readonly IHabitacionService _habitacionService;
        private readonly IMapper _mapper; // Inyecta AutoMapper

        public HabitacionesController(IHabitacionService habitacionService, IMapper mapper)
        {
            _habitacionService = habitacionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HabitacionDto>>> ObtenerTodasLasHabitaciones()
        {
            var habitaciones = await _habitacionService.ObtenerTodasLasHabitacionesAsync(); // El servicio podría devolver entidades o DTOs
            // Mapea a DTO si el servicio devuelve entidades
            var habitacionesDto = _mapper.Map<IEnumerable<HabitacionDto>>(habitaciones);
            return Ok(habitacionesDto);
        }

         [HttpGet("{id}")]
        public async Task<ActionResult<HabitacionDto>> ObtenerHabitacionPorId(int id)
        {
             var habitacion = await _habitacionService.ObtenerHabitacionPorIdAsync(id); // Servicio devuelve entidad
             if (habitacion == null)
             {
                 return NotFound();
             }
             var habitacionDto = _mapper.Map<HabitacionDto>(habitacion); // Mapea a DTO
             return Ok(habitacionDto);
        }


        // POST /api/habitaciones
        [HttpPost]
        // Ahora devuelve HabitacionDto y recibe CrearHabitacionDto
        public async Task<ActionResult<HabitacionDto>> CrearHabitacion([FromBody] CrearHabitacionDto crearDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Llama al nuevo método del servicio que acepta el DTO
            var nuevaHabitacionEntidad = await _habitacionService.CrearHabitacionDesdeDtoAsync(crearDto);

            // Verifica si el servicio devolvió null (indicando un error, ej: ID relacionado inválido)
            if (nuevaHabitacionEntidad == null)
            {
                // Devuelve un BadRequest con un mensaje más específico si es posible
                return BadRequest("No se pudo crear la habitación. Verifique que los IDs relacionados (Propiedad, Estado, Piso, Categoría) sean válidos.");
            }

            // Mapea la entidad creada a un DTO para la respuesta
            var habitacionDto = _mapper.Map<HabitacionDto>(nuevaHabitacionEntidad);

            // Devuelve 201 Created con la ubicación y el DTO
            return CreatedAtAction(nameof(ObtenerHabitacionPorId), new { id = habitacionDto.Id }, habitacionDto);
        }

        // ... refactorizar PUT y DELETE de manera similar ...
    }
}