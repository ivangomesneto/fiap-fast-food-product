using FourSix.Domain.Entities.PedidoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FourSix.Infrastructure.DataAccess.Configurations
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {

        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("PedidoItem");
            builder.Property(b => b.PedidoId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(b => b.ItemPedidoId).IsRequired();
            builder.Property(b => b.ValorUnitario).IsRequired().HasPrecision(6, 2);
            builder.Property(b => b.Quantidade).IsRequired();
            builder.Property(b => b.Observacao).IsRequired();

            builder.HasOne(x => x.ItemPedido).WithMany().HasForeignKey(b => b.ItemPedidoId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
