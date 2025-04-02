using Clivia.Core.Models;
using Clivia.Infrastructure.Data;
using Clivia.Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Clivia.DataBase.Test
{
    // TODO: Probando la capa de acceso a datos con entidades. Realizar con las demás entidades.
    /// <summary>
    /// Probando la capa de acceso a datos con entidades
    /// </summary>
    public class HabitacionRepositoryTests : IDisposable
    {
        private readonly SqliteConnection _connection;
        private readonly CliviaDbContext _context;

        public HabitacionRepositoryTests()
        {
            #region Configuración SQLite en memoria
            // Crear una conexión SQLite en memoria
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            // Crear las opciones del DbContext
            var options = new DbContextOptionsBuilder<CliviaDbContext>()
                .UseSqlite(_connection)
                .LogTo(Console.WriteLine, LogLevel.Information) // Habilita el logging
                .Options;

            // Crear una instancia del DbContext
            _context = new CliviaDbContext(options);

            // Asegurarse de que la base de datos esté creada
            _context.Database.EnsureCreated();
            //_context.Database.Migrate();

            // Deshabilitar el tracking de cambios (temporalmente)
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            #endregion
            // Crear las entidades
            #region Entidades complementarias a Habitación
            var pais = new Pais { Nombre = "United State", CodigoIso = "US" };
            _context.Paises.Add(pais);
            _context.SaveChanges();

            var provinciaEstado = new ProvinciaEstado { Nombre = "SpringFieldState", Pais = pais };
            _context.ProvinciasEstados.Add(provinciaEstado);
            _context.SaveChanges();

            var codigoPostal = new CodigoPostal { 
                  Codigo = "12345"
                , Ciudad = "SpringField"
                , IdProvinciaEstado = provinciaEstado.Id
            };
            _context.CodigosPostales.Add(codigoPostal);
            _context.SaveChanges();
            
            var direccion = new Direccion
            {
                Calle = "SpringField",
                Ciudad = "SpringField",
                CodigosPostales = codigoPostal, // Usa la propiedad de navegación
                IdPais = pais.Id,
                IdProvinciaEstado = provinciaEstado.Id,
                NumeroUnidad = "123",
                Pais = pais, // Usa la propiedad de navegación
                ProvinciasEstados = provinciaEstado,  // Usa la propiedad de navegación
            };
            _context.Direcciones.Add(direccion);
            _context.SaveChanges();
            
            var propiedad = new Propiedad { NombrePropiedad = "Clivia Hotel", Direccion = direccion };
            _context.Propiedades.Add(propiedad);
            _context.SaveChanges();

            var estado = new EstadoHabitacion { Descripcion = "Disponible" };
            _context.EstadosHabitacion.Add(estado);
            _context.SaveChanges();

            var piso = new Piso { Descripcion = "Primer Piso" };
            _context.Pisos.Add(piso);
            _context.SaveChanges();

            var categoria = new Categoria { Descripcion = "Estándar" };
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            #endregion
            // Habilitar el tracking de cambios de nuevo
            _context.ChangeTracker.AutoDetectChangesEnabled = true;

            // Poblar la base de datos con datos de prueba
            _context.Habitaciones.Add(new Habitacion
            {
                NumeroHabitacion = "101",
                TipoHabitacion = "Individual",
                PrecioPorNoche = 100,
                EstadoHabitacion = estado,
                Piso = piso,
                Categorias = categoria,
                Propiedad = propiedad
            });
            _context.Habitaciones.Add(new Habitacion
            {
                NumeroHabitacion = "102",
                TipoHabitacion = "Doble",
                PrecioPorNoche = 150,
                EstadoHabitacion = estado,
                Piso = piso,
                Categorias = categoria,
                Propiedad = propiedad
            });

            _context.SaveChanges();
        }

        public void Dispose()
        {
            // Limpiar la base de datos en memoria después de cada prueba
            _connection.Close();
        }

        [Fact]
        public async Task ObtenerTodasLasHabitaciones_DeberiaRetornarTodasLasHabitaciones()
        {
            // Arrange
            var repository = new HabitacionRepository(_context);

            // Act
            var habitaciones = await repository.ObtenerTodasLasHabitaciones();

            // Assert
            Assert.Equal(2, ((ICollection<Habitacion>)habitaciones).Count);
        }

        [Fact]
        public async Task ObtenerHabitacionPorId_DeberiaRetornarLaHabitacionCorrecta()
        {
            // Arrange
            var repository = new HabitacionRepository(_context);

            // Act
            var habitacion = await repository.ObtenerHabitacionPorId(1);

            // Assert
            Assert.NotNull(habitacion);
            Assert.Equal("101", habitacion.NumeroHabitacion);
        }
        [Fact]
        public async Task ObtenerHabitacionPorIdSinRegistro_NoSeEncontroNingunaHabitacion()
        {
            var repository = new HabitacionRepository(_context);
            var idInexistente = 99;
         
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(
                async () => await repository.ObtenerHabitacionPorId(idInexistente)
            );
            
            Assert.Equal($"No se encontró ninguna Habitación con el ID {idInexistente}.", exception.Message);
        }

        [Fact]
        public async Task CrearHabitacion_DeberiaCrearUnaNuevaHabitacion()
        {
            // Arrange
            var repository = new HabitacionRepository(_context);

            // Obtener las entidades existentes desde la base de datos
            var estado = await _context.EstadosHabitacion.FirstOrDefaultAsync(e => e.Descripcion == "Disponible");
            var piso = await _context.Pisos.FirstOrDefaultAsync(p => p.Descripcion == "Primer Piso");
            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.Descripcion == "Estándar");
            var propiedad = await _context.Propiedades.FirstOrDefaultAsync(p => p.NombrePropiedad == "Clivia Hotel");

            var nuevaHabitacion = new Habitacion
            {
                NumeroHabitacion = "103",
                TipoHabitacion = "Suite",
                PrecioPorNoche = 200,
                EstadoHabitacion = estado ?? throw new Exception("No se encontró el estado de habitación"),
                Piso = piso ?? throw new Exception("No se encontró el piso"),
                Categorias = categoria ?? throw new Exception("No se encontró la categoría"),
                Propiedad = propiedad ?? throw new Exception("No se encontró la propiedad")
            };
            
            // Act
            await repository.CrearHabitacion(nuevaHabitacion);

            // Assert
            Assert.Equal(3, _context.Habitaciones.Count());
            Assert.Equal("103", _context.Habitaciones.OrderByDescending(h => h.Id).First().NumeroHabitacion);
        }

        //TODO: Escribe más pruebas para los otros métodos del repositorio EliminarHabitacion
        [Fact]
        public async Task ActualizarHabitacion_DeberiaActualizarLaHabitacionCorrectamente()
        {
            var repository = new HabitacionRepository(_context);
            Habitacion actualizarHabitacion = await repository.ObtenerHabitacionPorId(1);
            actualizarHabitacion.TipoHabitacion = "Simple";
            await repository.ActualizarHabitacion(actualizarHabitacion);
            Assert.Equal("Simple", actualizarHabitacion.TipoHabitacion);
        }
    }
}