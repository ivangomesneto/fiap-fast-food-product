using FourSix.Domain.Entities.PedidoAggregate;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FourSix.Controllers.Gateways.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, UseCases.Interfaces.IPedidoRepository
    {
        public PedidoRepository(DbContext context) : base(context)
        {
        }

        public override IEnumerable<Pedido> Listar(Expression<Func<Pedido, bool>>? predicate = null)
        {
            var pedidos = _context.Set<Pedido>().Include(i => i.Itens).Include(i => i.HistoricoCheckout);

            if (predicate == null)
                return pedidos.AsNoTracking();
            else
                return pedidos.Where(predicate).AsNoTracking();
        }

        //public Task AlterarStatus(Guid pedidoId, EnumStatusPedido idStatus)
        //{
        //    var pedido = Obter(pedidoId);
        //    pedido
        //}
    }
}
