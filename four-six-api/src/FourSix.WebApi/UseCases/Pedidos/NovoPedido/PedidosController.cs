using FourSix.Application.Services;
using FourSix.Application.UseCases;
using FourSix.Application.UseCases.Pedidos.NovoPedido;
using FourSix.Domain.Entities.PedidoAggregate;
using FourSix.WebApi.Modules.Commons;
using FourSix.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Pedidos.NovoPedido
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Criar, Obter, Alterar Status e Cancelar Pedidos")]
    public class PedidosController : Controller, IOutputPort<Pedido>
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly INovoPedidoUseCase _useCase;

        public PedidosController(Notification notification,
            INovoPedidoUseCase useCase)
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
            _viewModel = Ok(new NovoPedidoResponse(new PedidoModel(pedido)));

        void IOutputPort<Pedido>.Exist() => _viewModel = BadRequest("Pedido já existe");

        /// <summary>
        /// Cria novo pedido
        /// </summary>
        /// <param name="pedido">Dados do Pedido</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NovoPedidoResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NovoPedidoResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
        public async Task<IActionResult> Create([FromBody] NovoPedidoRequest pedido)
        {
            _useCase.SetOutputPort(this);

            try
            {
                await _useCase.Execute(pedido.DataPedido, pedido.ClienteId, pedido.Items.Select(i => new Tuple<Guid, decimal, int, string>(i.ItemPedidoId, i.ValorUnitario, i.Quantidade, i.Observacao)).ToList())
                    .ConfigureAwait(false);
            }
            catch (Exception ex) { }

            return _viewModel!;
        }
    }
}
