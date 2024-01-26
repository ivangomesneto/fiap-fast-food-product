using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Pagamentos.ObtemStatusPagamentoPedido;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Pagamentos.ObtemStatusPagamentoPedido
{
    public class ObtemStatusPagamentoPedidoAdapter : IObtemStatusPagamentoPedidoAdapter
    {
        private readonly Notification _notification;

        private readonly IObtemStatusPagamentoPedidoUseCase _useCase;

        public ObtemStatusPagamentoPedidoAdapter(Notification notification,
            IObtemStatusPagamentoPedidoUseCase useCase)
        {
            _useCase = useCase;
            _notification = notification;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtemStatusPagamentoPedidoResponse))]
        public async Task<ObtemStatusPagamentoPedidoResponse> ObterStatusPagamento(Guid pedidoId)
        {
            return new ObtemStatusPagamentoPedidoResponse(await _useCase.Execute(pedidoId));
        }
    }
}
