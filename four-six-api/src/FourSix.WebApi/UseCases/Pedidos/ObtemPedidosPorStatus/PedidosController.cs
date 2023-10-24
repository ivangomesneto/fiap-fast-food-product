using FourSix.Application.Services;
using FourSix.Application.UseCases;
using FourSix.Application.UseCases.Pedidos.ObtemPedidosPorStatus;
using FourSix.Domain.Entities.PedidoAggregate;
using FourSix.WebApi.Modules.Commons;
using FourSix.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Pedidos.ObtemPedido
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Criar, Obter, Alterar e Cancelar Pedidos")]
    public class PedidosController : Controller, IOutputPort<ICollection<Pedido>>
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly IObtemPedidosPorStatusUseCase _useCase;

        public PedidosController(Notification notification,
            IObtemPedidosPorStatusUseCase useCase)
        {
            _useCase = useCase;
            _notification = notification;
        }

        void IOutputPort<ICollection<Pedido>>.Invalid()
        {
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(_notification.ModelState);
            _viewModel = BadRequest(problemDetails);
        }

        void IOutputPort<ICollection<Pedido>>.NotFound() => _viewModel = NotFound();

        void IOutputPort<ICollection<Pedido>>.Ok(ICollection<Pedido> pedidos) =>
            _viewModel = Ok(new ObtemPedidosPorStatusResponse(new List<PedidoModel>(pedidos.Select(s => new PedidoModel(s)))));

        void IOutputPort<ICollection<Pedido>>.Exist() => _viewModel = BadRequest("Pedido já existe");

        /// <summary>
        /// Obtém lista de pedido por status
        /// </summary>
        /// <param name="statusId">Status dos pedidos</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtemPedidosPorStatusResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
        public async Task<IActionResult> Listar(EnumStatus statusId)
        {
            _useCase.SetOutputPort(this);

            await _useCase.Execute(statusId)
                .ConfigureAwait(false);

            return _viewModel!;
        }
    }
}
