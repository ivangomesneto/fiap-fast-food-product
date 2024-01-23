using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Pagamentos.ObtemStatusPagamentoPedido;

namespace FourSix.Controllers.Adapters.Pagamentos.ObtemStatusPagamentoPedido
{
    public class ObtemStatusPagamentoPedidoAdapter : IObtemStatusPagamentoPedidoAdapter
    {
        private readonly Notification _notification;

        //private IActionResult _viewModel;
        private readonly IObtemStatusPagamentoPedidoUseCase _useCase;

        public ObtemStatusPagamentoPedidoAdapter(Notification notification,
            IObtemStatusPagamentoPedidoUseCase useCase)
        {
            _useCase = useCase;
            _notification = notification;
        }

        public async Task<ObtemStatusPagamentoPedidoPresenter> ObterStatusPagamento(Guid pedidoId)
        {
            var response = await _useCase.Execute(pedidoId).ConfigureAwait(false);

            return null;
            //return new ObtemStatusPagamentoPedidoResponse(response);
            //return _viewModel!;
        }
    }
}
