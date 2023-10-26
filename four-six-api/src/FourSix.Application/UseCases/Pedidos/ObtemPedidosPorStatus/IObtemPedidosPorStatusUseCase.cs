using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.Application.UseCases.Pedidos.ObtemPedidosPorStatus
{
    public interface IObtemPedidosPorStatusUseCase
    {
        Task Execute(EnumStatusPedido statusId);
        void SetOutputPort(IOutputPort<ICollection<Pedido>> outputPort);
    }
}
