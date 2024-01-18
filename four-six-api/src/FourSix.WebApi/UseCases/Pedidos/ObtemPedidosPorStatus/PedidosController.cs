using FourSix.Controllers.Presenters;
using FourSix.Domain.Entities.PedidoAggregate;
using FourSix.WebApi.Modules.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Pedidos.ObtemPedido
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Criar, Obter, Alterar e Cancelar Pedidos")]
    public class PedidosController : Controller
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly FourSix.UseCases.UseCases.Pedidos.ObtemPedidosPorStatus.IObtemPedidosPorStatusUseCase _useCase;

        public PedidosController(Notification notification,
            FourSix.UseCases.UseCases.Pedidos.ObtemPedidosPorStatus.IObtemPedidosPorStatusUseCase useCase)
        {
            _useCase = useCase;
            _notification = notification;
        }

        /// <summary>
        /// Obtém lista de pedido por status
        /// </summary>
        /// <param name="statusId">Status dos pedidos</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtemPedidosPorStatusResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
        public async Task<IActionResult> Listar(EnumStatusPedido statusId)
        {
            //_useCase.SetOutputPort(this);

            List<Pedido> pedidos = _useCase.Execute(statusId).Result.ToList();
            //.ConfigureAwait(false);

            return Ok(pedidos);
        }
    }
}
