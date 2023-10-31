using FourSix.Application.Services;
using FourSix.Application.UseCases;
using FourSix.Application.UseCases.Pedidos.AlteraStatusPedido;
using FourSix.Domain.Entities.PedidoAggregate;
using FourSix.WebApi.Modules.Commons;
using FourSix.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Pedidos.AlteraStatusPedido
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Criar, Obter, Alterar e Cancelar Pedidos")]
    public class PedidosController : Controller, IOutputPort<Pedido>
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly IAlteraStatusPedidoUseCase _useCase;

        public PedidosController(Notification notification,
            IAlteraStatusPedidoUseCase useCase)
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
            _viewModel = Ok(new AlteraStatusPedidoResponse(new PedidoModel(pedido)));

        void IOutputPort<Pedido>.Exist() => _viewModel = BadRequest("Pedido já existe");

        /// <summary>
        /// Altera status do pedido
        /// </summary>
        /// <param name="pedidoId">ID do Pedido</param>
        /// <param name="statusId">Status do Pedido</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPut("{pedidoId:guid}/status/{statusId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AlteraStatusPedidoResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AlteraStatusPedidoResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Update))]
        public async Task<IActionResult> Alterar(Guid pedidoId, EnumStatusPedido statusId)
        {
            _useCase.SetOutputPort(this);

            try
            {
                await _useCase.Execute(pedidoId, statusId, DateTime.Now)
                    .ConfigureAwait(false);
            }
            catch(Exception ex) { }

            return _viewModel!;
        }
    }
}
