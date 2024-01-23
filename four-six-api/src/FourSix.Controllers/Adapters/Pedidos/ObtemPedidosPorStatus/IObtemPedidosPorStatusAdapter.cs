using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.Controllers.Adapters.Pedidos.ObtemPedidosPorStatus
{
    public interface IObtemPedidosPorStatusAdapter
    {
        Task<ICollection<Pedido>> Listar(EnumStatusPedido statusId);
    }
}
