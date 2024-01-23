using FourSix.Controllers.Presenters;
using FourSix.Domain.Entities.PedidoAggregate;
using FourSix.UseCases.UseCases.Pedidos.ObtemPedidosPorStatus;
using FourSix.WebApi.UseCases.Pedidos.ObtemPedido;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Pedidos.ObtemPedidosPorStatus
{
    public class ObtemPedidosPorStatusAdapter : IObtemPedidosPorStatusAdapter
    {
        private readonly Notification _notification;

        private readonly IObtemPedidosPorStatusUseCase _useCase;

        public ObtemPedidosPorStatusAdapter(Notification notification,
            IObtemPedidosPorStatusUseCase useCase)
        {
            _useCase = useCase;
            _notification = notification;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtemPedidosPorStatusResponse))]
        public async Task<ICollection<Pedido>> Listar(EnumStatusPedido statusId)
        {
            //_useCase.SetOutputPort(this);

            var pedidos = _useCase.Execute(statusId).Result.ToList();
            //.ConfigureAwait(false);

            return pedidos;

            //return Ok(pedidos);
        }
    }
}
