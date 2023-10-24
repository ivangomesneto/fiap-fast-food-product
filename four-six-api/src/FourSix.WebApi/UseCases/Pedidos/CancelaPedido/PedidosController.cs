using FourSix.Application.Services;
using FourSix.Application.UseCases;
using FourSix.Application.UseCases.Pedidos.CancelaPedido;
using FourSix.Application.UseCases.Pedidos.NovoPedido;
using FourSix.Domain.Entities.PedidoAggregate;
using FourSix.WebApi.Modules.Commons;
using FourSix.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Pedidos.CancelaPedido
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Criar, Obter, Alterar Status e Cancelar Pedidos")]
    public class PedidosController : Controller, IOutputPort<Pedido>
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

        void IOutputPort<Pedido>.Invalid()
        {
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(_notification.ModelState);
            _viewModel = BadRequest(problemDetails);
        }

        void IOutputPort<Pedido>.NotFound() => _viewModel = NotFound();

        void IOutputPort<Pedido>.Ok(Pedido pedido) =>
            _viewModel = Ok(new CancelaPedidoResponse(new PedidoModel(pedido)));

        void IOutputPort<Pedido>.Exist() => _viewModel = BadRequest("Pedido já existe");

        /// <summary>
        /// Cancela pedido
        /// </summary>
        /// <param name="pedido">Dados do Pedido</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CancelaPedidoResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
        public async Task<IActionResult> Create([FromBody] CancelaPedidoRequest pedido)
        {
            _useCase.SetOutputPort(this);

            await _useCase.Execute(pedido.PedidoId, pedido.DataCancelamento)
                .ConfigureAwait(false);

            return _viewModel!;
        }
    }
}
