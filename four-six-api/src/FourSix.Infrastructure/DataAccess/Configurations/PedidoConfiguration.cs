using FourSix.Domain.Entities.PedidoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FourSix.Infrastructure.DataAccess.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {

        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Pedido");
            builder.Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(b => b.ClientId).IsRequired();
            builder.Property(b => b.NumeroPedido).IsRequired();
            builder.Property(b => b.DataPedido).IsRequired();

            builder.HasOne(x => x.Cliente).WithMany().HasForeignKey(b => b.ClientId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.PedidoItens).WithOne().HasForeignKey(b => b.PedidoId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
