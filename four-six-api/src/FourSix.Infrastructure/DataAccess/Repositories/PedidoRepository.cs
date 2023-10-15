using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.Infrastructure.DataAccess.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(Context context) : base(context)
        {
        }
    }
}
