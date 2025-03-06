using Clivia.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clivia.Infrastructure.Data.EntityConfigurations
{
    public class HabitacionConfiguration : IEntityTypeConfiguration<Habitacion>
    {
        public void Configure(EntityTypeBuilder<Habitacion> builder)
        {
            builder.HasOne(h => h.Propiedad)
                   .WithMany(p => p.Habitaciones)
                   .HasForeignKey(h => h.IdPropiedad)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.EstadoHabitacion)
                   .WithMany(eh => eh.Habitaciones)
                   .HasForeignKey(h => h.IdEstadoHabitacion)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.Piso)
                   .WithMany(p => p.Habitaciones)
                   .HasForeignKey(h => h.IdPiso)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.Categoria)
                   .WithMany(c => c.Habitaciones)
                   .HasForeignKey(h => h.IdCategoria)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(h => h.IdPropiedad);
        }
    }
}