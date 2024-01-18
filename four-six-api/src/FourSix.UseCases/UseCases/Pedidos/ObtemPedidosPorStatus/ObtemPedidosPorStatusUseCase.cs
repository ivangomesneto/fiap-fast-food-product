using FourSix.Domain.Entities.PedidoAggregate;
using FourSix.UseCases.Interfaces;
using System.Collections.Generic;

namespace FourSix.UseCases.UseCases.Pedidos.ObtemPedidosPorStatus
{
    public class ObtemPedidosPorStatusUseCase : IObtemPedidosPorStatusUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public ObtemPedidosPorStatusUseCase(FourSix.UseCases.Interfaces.IPedidoRepository pedidoRepository)
        {
            this._pedidoRepository = pedidoRepository;
        }

        public Task<ICollection<Pedido>> Execute(EnumStatusPedido statusId) => ListarPedidos(statusId);

        private async Task<ICollection<Pedido>> ListarPedidos(EnumStatusPedido statusId)
        {
            var pedidos = this._pedidoRepository.Listar(q => q.StatusId == statusId).ToList();

            return pedidos;
        }
    }
}