using FourSix.Controllers.Presenters;
using FourSix.Domain.Entities.PedidoAggregate;
using FourSix.UseCases.UseCases.Pedidos.AlteraStatusPedido;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.Controllers.Adapters.Pedidos.AlteraStatusPedido
{
    //[ApiController]
    //[Route("[controller]")]
    //[Produces("application/json")]
    //[SwaggerTag("Criar, Obter, Alterar e Cancelar Pedidos")]
    public class AlteraStatusPedidoAdapter : IAlteraStatusPedidoAdapter
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly IAlteraStatusPedidoUseCase _useCase;

        public AlteraStatusPedidoAdapter(Notification notification,
            IAlteraStatusPedidoUseCase useCase)
        {
            _useCase = useCase;
            _notification = notification;
        }

        ///// <summary>
        ///// Altera status do pedido
        ///// </summary>
        ///// <param name="pedidoId">ID do Pedido</param>
        ///// <param name="statusId">Status do Pedido</param>
        ///// <returns></returns>
        //[AllowAnonymous]
        //[HttpPut("{pedidoId:guid}/status/{statusId}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AlteraStatusPedidoResponse))]
        //[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AlteraStatusPedidoResponse))]
        //[ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Update))]
        public async Task Alterar(Guid pedidoId, EnumStatusPedido statusId)
        {
            try
            {
                await _useCase.Execute(pedidoId, statusId, DateTime.Now)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
            }

            //return _viewModel!;
        }
    }
}
