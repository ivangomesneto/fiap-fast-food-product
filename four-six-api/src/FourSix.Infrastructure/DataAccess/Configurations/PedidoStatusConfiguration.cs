using FourSix.Domain.Entities.PedidoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FourSix.Infrastructure.DataAccess.Configurations
{
    public class PedidoStatusConfiguration : IEntityTypeConfiguration<PedidoStatus>
    {

        public void Configure(EntityTypeBuilder<PedidoStatus> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("PedidoStatus");
            builder.HasKey(e => new { e.PedidoId, e.StatusId });

            builder.Property(b => b.PedidoId)
                .IsRequired()
                .ValueGeneratedNever()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.StatusId)
                .IsRequired()
                .HasConversion<int>()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.DataStatus)
                .IsRequired()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.HasOne(x => x.Status).WithMany().HasForeignKey(b => b.StatusId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
