using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.Controllers.Adapters.Pedidos.AlteraStatusPedido
{
    public interface IAlteraStatusPedidoAdapter
    {
        Task Alterar(Guid pedidoId, EnumStatusPedido statusId);
    }
}
