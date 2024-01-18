using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Pedidos.CancelaPedido;
using FourSix.WebApi.Modules.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Pedidos.CancelaPedido
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Criar, Obter, Alterar Status e Cancelar Pedidos")]
    public class PedidosController : Controller
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly ICancelaPedidoUseCase _useCase;

        public PedidosController(Notification notification,
            ICancelaPedidoUseCase useCase)
        {
            _useCase = useCase;
            _notification = notification;
        }

        /// <summary>
        /// Cancela pedido
        /// </summary>
        /// <param name="pedido">Dados do Pedido</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPut("cancelamentos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CancelaPedidoResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
        public async Task<IActionResult> Create([FromBody] CancelaPedidoRequest pedido)
        {
            await _useCase.Execute(pedido.PedidoId, pedido.DataCancelamento)
                .ConfigureAwait(false);

            return _viewModel!;
        }
    }
}
