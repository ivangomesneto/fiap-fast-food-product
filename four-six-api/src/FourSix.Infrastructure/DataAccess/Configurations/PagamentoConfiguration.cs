using FourSix.Domain.Entities.PagamentoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FourSix.Infrastructure.DataAccess.Configurations
{
    public class PagamentoConfiguration : IEntityTypeConfiguration<Pagamento>
    {

        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Pagamento");
            builder.Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
        }
    }
}
