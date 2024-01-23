using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Pedidos.NovoPedido;

namespace FourSix.Controllers.Adapters.Pedidos.NovoPedido
{
    public class NovoPedidoAdapter : INovoPedidoAdapter
    {
        private readonly Notification _notification;

        //private IActionResult _viewModel;
        private readonly INovoPedidoUseCase _useCase;

        public NovoPedidoAdapter(Notification notification,
            INovoPedidoUseCase useCase)
        {
            _useCase = useCase;
            _notification = notification;
        }

        ///// <summary>
        ///// Cria novo pedido
        ///// </summary>
        ///// <param name="pedido">Dados do Pedido</param>
        ///// <returns></returns>
        //[AllowAnonymous]
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NovoPedidoResponse))]
        //[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NovoPedidoResponse))]
        //[ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
        public async Task Inserir(NovoPedidoRequest pedido)
        {
            try
            {
                await _useCase.Execute(pedido.DataPedido, pedido.ClienteId, pedido.Items.Select(i => new Tuple<Guid, decimal, int, string>(i.ItemPedidoId, i.ValorUnitario, i.Quantidade, i.Observacao)).ToList())
                    .ConfigureAwait(false);
            }
            catch (Exception ex) { }

            //return _viewModel!;
        }
    }
}
