using AutoMapper;
using Clivia.Application.Services;
using Clivia.Application.Mappings;
using Clivia.Core.Dtos;
using Clivia.Core.Models;
using Clivia.Core.Repositories;
using Moq;

namespace Clivia.Application.Test;

public class HabitacionServiceTests
{
    private readonly Mock<IHabitacionRepository> _mockRepo;
    private readonly IMapper _mapper; // Puedes mockear IMapper o usar el real
    private readonly HabitacionService _service;

    public HabitacionServiceTests()
    {
        _mockRepo = new Mock<IHabitacionRepository>();

        // Configuración para usar AutoMapper
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new HabitacionProfile()); // Tu perfil de mapeo
        });
        _mapper = mappingConfig.CreateMapper();

        _service = new HabitacionService(_mockRepo.Object, _mapper);
    }

    [Fact]
    public async Task ObtenerTodasLasHabitacionesAsync_DeberiaRetornarHabitacionDTOs()
    {
        // Arrange
        var habitacionesEntidad = new List<Habitacion>
        {
            new Habitacion
            {
                Id = 1, NumeroHabitacion = "101", TipoHabitacion = "Ind", PrecioPorNoche = 100,
                EstadoHabitacion = new EstadoHabitacion { Descripcion = "Disp" },
                Piso = new Piso { Descripcion = "P1" }, Categorias = new Categoria { Descripcion = "Std" },
                Propiedad = new Propiedad { NombrePropiedad = "Hotel" }
            },
            new Habitacion
            {
                Id = 2, NumeroHabitacion = "102", TipoHabitacion = "Dob", PrecioPorNoche = 150,
                EstadoHabitacion = new EstadoHabitacion { Descripcion = "Disp" },
                Piso = new Piso { Descripcion = "P1" }, Categorias = new Categoria { Descripcion = "Std" },
                Propiedad = new Propiedad { NombrePropiedad = "Hotel" }
            }
        };
        _mockRepo.Setup(repo => repo.ObtenerTodasLasHabitaciones())
            .ReturnsAsync(habitacionesEntidad);

        // Act
        var result = await _service.ObtenerTodasLasHabitacionesAsync();
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.IsAssignableFrom<IEnumerable<HabitacionDto>>(result); // Verifica el tipo DTO
        Assert.Equal("101", result.First().NumeroHabitacion);
        // Assert.Equal("Disp", result.First().EstadoHabitacion.Descripcion); // Verifica el mapeo
        _mockRepo.Verify(repo => repo.ObtenerTodasLasHabitaciones(), Times.Once); // Verifica que se llamó al repo
    }

    // TODO: Falta el método CrearHabitacionAsync
    [Fact(Skip = "Método CrearHabitacionDesdeDto aún no implementado o en revisión")]
    public async Task CrearHabitacionAsync_DeberiaMapearDtoAEntidad_LlamarRepo_Y_MapearResultadoADto()
    {
        // Arrange
        var createDto = new CrearHabitacionDto()
        {
            NumeroHabitacion = "103", TipoHabitacion = "Suite", PrecioPorNoche = 200,
            Capacidad = 2, Descripcion = "Matrimonial", Detalle = "camas amplias", IdCategoria = 1,
            IdEstadoHabitacion = 1, IdPiso = 0, IdPropiedad = 1
            // EstadoHabitacion = new EstadoHabitacion { Id = 1, Descripcion = "Disp" }
        };

        // Simula la entidad que el repo crearía y devolvería (con un ID)
        var entidadCreada = new Habitacion
        {
            Id = 3, // ID asignado por la BD/Repo
            NumeroHabitacion = "103", TipoHabitacion = "Suite", PrecioPorNoche = 200,
            Capacidad = 2, CreadoPor = "Nestor",
            // Incluir objetos relacionados si el mapeo de vuelta los necesita
            EstadoHabitacion = new EstadoHabitacion { Id = 1, Descripcion = "Disp" },
            Piso = new Piso { Id = 1, Descripcion = "P1" },
            Categorias = new Categoria { Id = 1, Descripcion = "Std" },
            Propiedad = new Propiedad { Id = 1, NombrePropiedad = "Hotel" }
        };

        // Configura el mock del repo para que cuando se le pase CUALQUIER Habitacion
        // (resultado del mapeo del DTO), devuelva la entidad simulada 'entidadCreada'.
        _mockRepo.Setup(repo => repo.CrearHabitacion(It.IsAny<Habitacion>()))
            .ReturnsAsync(entidadCreada); // Devuelve la entidad con ID y relaciones

        // Act
        var resultDto = await _service.CrearHabitacionDesdeDto(createDto);

        // Assert
        Assert.NotNull(resultDto);
        Assert.IsType<HabitacionDto>(resultDto);
        Assert.Equal(entidadCreada.Id, resultDto.Id); // Verifica que el ID se mapeó de vuelta
        Assert.Equal(createDto.NumeroHabitacion, resultDto.NumeroHabitacion);
        
        // Assert.Equal("Disp", resultDto.EstadoHabitacion.Descripcion); // Verifica mapeo de vuelta

        // Verifica que el método CrearHabitacion del repo fue llamado una vez con una entidad cuyas propiedades coinciden con las del DTO de entrada.
        _mockRepo.Verify(repo => repo.CrearHabitacion(It.Is<Habitacion>(h =>
            h.NumeroHabitacion == createDto.NumeroHabitacion &&
            h.TipoHabitacion == createDto.TipoHabitacion &&
            h.Capacidad == createDto.Capacidad
        )), Times.Once);
    }

    // ... más tests para ObtenerPorId, Actualizar, Eliminar ...
}