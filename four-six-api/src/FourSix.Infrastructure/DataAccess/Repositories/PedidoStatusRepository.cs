using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.Infrastructure.DataAccess.Repositories
{
    public class PedidoStatusRepository : BaseRepository<PedidoStatus, EnumStatus>, IPedidoStatusRepository
    {
        public PedidoStatusRepository(Context context) : base(context)
        {
        }
    }
}
