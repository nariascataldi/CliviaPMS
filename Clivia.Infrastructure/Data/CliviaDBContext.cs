using Clivia.Core.Models;
using Clivia.Infrastructure.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Clivia.Infrastructure.Data
{
    public class CliviaDBContext : DbContext
    {
        public CliviaDBContext(DbContextOptions<CliviaDBContext> options) : base(options) { }

        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<ItemChecklist> ItemsChecklists { get; set; }
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
        public DbSet<ResultadoChecklist> ResultadosChecklists { get; set; }
        public DbSet<ResultadoItemChecklist> ResultadosItemsChecklists { get; set; }
        public DbSet<PropiedadComodidad> PropiedadesComodidades { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HabitacionConfiguracion());
            modelBuilder.ApplyConfiguration(new ReservaConfiguracion());
            
            // TODO: Continuar con las Configuraciones de las demás tablas

            // Relaciones 1:N
            //Usuarios -> Comentarios
            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Comentarios)
                .HasForeignKey(c => c.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            //Reservas -> Comentarios (Opcional)
            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Reserva)
                .WithMany(r => r.Comentarios)
                .HasForeignKey(c => c.IdReserva)
                .OnDelete(DeleteBehavior.Restrict);

            //Usuarios -> Asistencias
            modelBuilder.Entity<Asistencia>()
                .HasOne(a => a.Usuario)
                .WithMany(u => u.Asistencias)
                .HasForeignKey(a => a.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            //Usuarios -> Tareas
            modelBuilder.Entity<Tarea>()
                .HasOne(t => t.UsuarioAsignado)
                .WithMany(u => u.Tareas)
                .HasForeignKey(t => t.IdUsuarioAsignado)
                .OnDelete(DeleteBehavior.Restrict);

            //Propiedades -> Resenas
            modelBuilder.Entity<Resena>()
                .HasOne(r => r.Propiedad)
                .WithMany(p => p.Resenas)
                .HasForeignKey(r => r.IdPropiedad)
                .OnDelete(DeleteBehavior.Restrict);

            //Usuarios -> Resenas
            modelBuilder.Entity<Resena>()
                .HasOne(r => r.Usuario)
                .WithMany(u => u.Resenas)
                .HasForeignKey(r => r.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            //Checklists -> ItemsChecklist
            modelBuilder.Entity<ItemChecklist>()
                .HasOne(ic => ic.Checklist)
                .WithMany(c => c.ItemsChecklists)
                .HasForeignKey(ic => ic.IdChecklist)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete apropiado aquí

            //Checklists -> ResultadosChecklist
            modelBuilder.Entity<ResultadoChecklist>()
                .HasOne(rc => rc.Checklist)
                .WithMany(c => c.ResultadosChecklists)
                .HasForeignKey(rc => rc.IdChecklist)
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete apropiado aquí

            //Habitaciones -> ResultadosChecklist (Opcional)
            modelBuilder.Entity<ResultadoChecklist>()
                .HasOne(rc => rc.Habitacion)
                .WithMany(h => h.ResultadosChecklists)
                .HasForeignKey(rc => rc.IdHabitacion)
                .OnDelete(DeleteBehavior.Restrict);

            //Usuarios -> ResultadosChecklist
            modelBuilder.Entity<ResultadoChecklist>()
                .HasOne(rc => rc.Usuario)
                .WithMany(u => u.ResultadosChecklists)
                .HasForeignKey(rc => rc.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            //Paises -> ProvinciasEstados
            modelBuilder.Entity<ProvinciaEstado>()
                .HasOne(pe => pe.Pais)
                .WithMany(p => p.ProvinciasEstados)
                .HasForeignKey(pe => pe.IdPais)
                .OnDelete(DeleteBehavior.Restrict);

            //ProvinciasEstados -> CodigosPostales
            modelBuilder.Entity<CodigoPostal>()
                .HasOne(cp => cp.ProvinciasEstados)
                .WithMany(pe => pe.CodigosPostales)
                .HasForeignKey(cp => cp.IdProvinciaEstado)
                .OnDelete(DeleteBehavior.Restrict);

            //CodigosPostales -> Direcciones
            modelBuilder.Entity<Direccion>()
                .HasOne(d => d.CodigosPostales)
                .WithMany(cp => cp.Direcciones)
                .HasForeignKey(d => d.CodigoPostal)
                .OnDelete(DeleteBehavior.Restrict);

            //Direcciones -> Propiedades
            modelBuilder.Entity<Propiedad>()
                .HasOne(p => p.Direccion)
                .WithMany(d => d.Propiedades)
                .HasForeignKey(p => p.IdDireccion)
                .OnDelete(DeleteBehavior.Restrict);

            //RolesUsuarios -> Usuarios
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.RolesUsuarios)
                .WithMany(ru => ru.Usuarios)
                .HasForeignKey(u => u.IdRolUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            // Claves Compuestas
            modelBuilder.Entity<HabitacionFecha>()
                .HasKey(hf => new { hf.IdHabitacion, hf.Fecha });

            modelBuilder.Entity<PropiedadComodidad>()
                .HasKey(pc => new { pc.IdPropiedad, pc.IdComodidad });

            modelBuilder.Entity<ResultadoItemChecklist>()
                .HasKey(ric => new { ric.IdResultadosChecklist, ric.IdItemsChecklist });


            //Relaciones Muchos a Muchos (Tablas de Unión)

            //Reservas <-> Servicios
            modelBuilder.Entity<ServicioReserva>()
                .HasKey(sr => new { sr.IdReserva, sr.IdServicio });

            modelBuilder.Entity<ServicioReserva>()
                .HasOne(sr => sr.Reserva)
                .WithMany(r => r.ServiciosReservas)
                .HasForeignKey(sr => sr.IdReserva)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ServicioReserva>()
                .HasOne(sr => sr.Servicio)
                .WithMany(s => s.ServiciosReservas)
                .HasForeignKey(sr => sr.IdServicio)
                .OnDelete(DeleteBehavior.Restrict);

            //Propiedades <-> Comodidades
            modelBuilder.Entity<PropiedadComodidad>()
                .HasOne(pc => pc.Propiedad)
                .WithMany(p => p.PropiedadesComodidades)
                .HasForeignKey(pc => pc.IdPropiedad)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropiedadComodidad>()
                .HasOne(pc => pc.Comodidades)
                .WithMany(c => c.PropiedadesComodidades)
                .HasForeignKey(pc => pc.IdComodidad)
                .OnDelete(DeleteBehavior.Cascade);

            //ResultadosChecklist <-> ItemsChecklist
            modelBuilder.Entity<ResultadoItemChecklist>()
               .HasOne(ric => ric.ResultadosChecklist)
               .WithMany(rc => rc.ResultadosItemsChecklists)
               .HasForeignKey(ric => ric.IdResultadosChecklist)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ResultadoItemChecklist>()
                .HasOne(ric => ric.ItemsChecklist)
                .WithMany() // ItemChecklist no tiene navegación inversa
                .HasForeignKey(ric => ric.IdItemsChecklist)
                .OnDelete(DeleteBehavior.Restrict);

            //Habitaciones <-> Fechas
            modelBuilder.Entity<HabitacionFecha>()
                .HasOne(hf => hf.Habitacion)
                .WithMany(h => h.HabitacionesFechas)
                .HasForeignKey(hf => hf.IdHabitacion)
                .OnDelete(DeleteBehavior.Cascade); // si borras la habitación, borras sus fechas

            modelBuilder.Entity<HabitacionFecha>()
                .HasOne(hf => hf.Reserva)
                .WithMany(r => r.HabitacionesFechas)
                .HasForeignKey(hf => hf.IdReserva)
                .OnDelete(DeleteBehavior.SetNull); //Si borras reserva, queda la habitación disponible.

            //Indices
            //modelBuilder.Entity<Habitacion>()
            //    .HasIndex(h => h.IdPropiedad);

            //modelBuilder.Entity<Reserva>()
            //    .HasIndex(r => r.IdUsuario);

            modelBuilder.Entity<Comentario>()
                .HasIndex(c => c.IdReserva);

            modelBuilder.Entity<Resena>()
                .HasIndex(r => r.IdPropiedad);

            base.OnModelCreating(modelBuilder);
        }
    }
}