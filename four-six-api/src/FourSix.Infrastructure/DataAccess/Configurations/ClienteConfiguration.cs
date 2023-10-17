using FourSix.Domain.Entities;
using FourSix.Domain.Entities.ClienteAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FourSix.Infrastructure.DataAccess.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {

        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Cliente");
            builder.Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(b => b.Cpf).IsRequired().HasMaxLength(11);
            builder.Property(b => b.Nome).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Email).IsRequired().HasMaxLength(100);
        }
    }
}
