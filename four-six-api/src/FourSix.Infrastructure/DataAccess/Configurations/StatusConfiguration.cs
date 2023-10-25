using FourSix.Domain.Entities.PedidoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FourSix.Infrastructure.DataAccess.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {

        public void Configure(EntityTypeBuilder<Status> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Status");
            builder.HasKey(e => e.Id);

            builder.Property(b => b.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasConversion<int>()
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(b => b.Descricao)
                .IsRequired()
                .HasMaxLength(20)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
        }
    }
}
