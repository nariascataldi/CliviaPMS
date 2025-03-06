using Clivia.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clivia.Infrastructure.Data.EntityConfigurations
{
	public class ReservaConfiguration:IEntityTypeConfiguration<Reserva>
	{
		public void Configure(EntityTypeBuilder<Reserva> builder)
		{
			builder
				.HasOne(r => r.Usuario)
				.WithMany(u => u.Reservas)
				.HasForeignKey(r => r.IdUsuario)
				.OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(r => r.Propiedad)
                   .WithMany(p => p.Reservas)
                   .HasForeignKey(r => r.IdPropiedad)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(r => r.IdUsuario);
        }
	}
}

