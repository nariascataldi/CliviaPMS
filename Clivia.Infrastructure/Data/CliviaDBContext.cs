using Clivia.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Clivia.Infrastructure.Data
{
    public class CliviaDBContext : DbContext
    {
        public CliviaDBContext(DbContextOptions<CliviaDBContext> options) : base(options) { }
//TODO: Revisar las tablas conté 23 y son 26
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<ItemsChecklist> ItemsChecklists { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }
        public DbSet<CodigoPostal> CodigosPostales { get; set; }
        public DbSet<Comodidad> Comodidades { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<EstadoHabitacion> EstadosHabitacion { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Piso> Pisos { get; set; }
        public DbSet<Propiedad> Propiedades { get; set; }
        public DbSet<ProvinciaEstado> ProvinciasEstados { get; set; }
        public DbSet<Resena> Resenas { get; set; }
        public DbSet<RolUsuario> RolesUsuarios { get; set; }
        public DbSet<ServicioReserva> ServiciosReservas { get; set; }
        public DbSet<HabitacionFecha> HabitacionesFechas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura las relaciones aquí usando la Fluent API
            modelBuilder.Entity<Habitacion>()
                .HasOne(h => h.Propiedad)
                .WithMany(p => p.Habitaciones)
                .HasForeignKey(h => h.IdPropiedad)
                .OnDelete(DeleteBehavior.Restrict); // Evita la eliminación en cascada por defecto

            modelBuilder.Entity<HabitacionFecha>()
                .HasKey(hf => new { hf.IdHabitacion, hf.Fecha }); //Configuración explícita de la clave primaria compuesta

            //Configuración explícita de relaciones con claves foráneas compuestas
            modelBuilder.Entity<PropiedadComodidad>()
                .HasKey(pc => new { pc.IdPropiedad, pc.IdComodidad });

            // Configura las relaciones HasMany
            modelBuilder.Entity<Propiedad>()
                .HasMany(p => p.Habitaciones)
                .WithOne(h => h.Propiedad)
                .HasForeignKey(h => h.IdPropiedad);

            base.OnModelCreating(modelBuilder);
        }
    }
}