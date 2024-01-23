using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Pedidos.CancelaPedido;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Pedidos.CancelaPedido
{
    //[ApiController]
    //[Route("[controller]")]
    //[Produces("application/json")]
    //[SwaggerTag("Criar, Obter, Alterar Status e Cancelar Pedidos")]
    public class CancelaPedidoAdapter: ICancelaPedidoAdapter
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly ICancelaPedidoUseCase _useCase;

        public CancelaPedidoAdapter(Notification notification,
            ICancelaPedidoUseCase useCase)
        {
            _useCase = useCase;
            _notification = notification;
        }

        ///// <summary>
        ///// Cancela pedido
        ///// </summary>
        ///// <param name="pedido">Dados do Pedido</param>
        ///// <returns></returns>
        //[AllowAnonymous]
        //[HttpPut("cancelamentos")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CancelaPedidoResponse))]
        //[ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
        public async Task Cancelar(CancelaPedidoRequest pedido)
        {
            await _useCase.Execute(pedido.PedidoId, pedido.DataCancelamento)
                .ConfigureAwait(false);

            //return _viewModel!;
        }
    }
}
