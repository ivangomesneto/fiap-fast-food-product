using FourSix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FourSix.Infrastructure.DataAccess.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {

        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Produto");
            builder.Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(b => b.Nome).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Descricao).HasMaxLength(200);
            builder.Property(b => b.Categoria).IsRequired();
            builder.Property(b => b.Preco).IsRequired().HasPrecision(6, 2);
        }
    }
}
