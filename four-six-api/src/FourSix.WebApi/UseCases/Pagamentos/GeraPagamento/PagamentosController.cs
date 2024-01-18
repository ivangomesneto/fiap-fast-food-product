using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Pagamentos.GeraPagamento;
using FourSix.WebApi.Modules.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Pagamentos.GeraPagamento
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Gerar, Efetuar e Cancelar Pagamento")]
    public class PagamentosController : Controller
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly IGeraPagamentoUseCase _useCase;

        public PagamentosController(Notification notification,
            IGeraPagamentoUseCase useCase)
        {
            _useCase = useCase;
            _notification = notification;
        }

        /// <summary>
        /// Gera novo pagamento
        /// </summary>
        /// <param name="request">Dados do pagamento</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GeraPagamentoResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GeraPagamentoResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
        public async Task<IActionResult> Gerar([FromBody] GeraPagamentoRequest request)
        {
            await _useCase.Execute(request.PedidoId, request.ValorPedido, request.Desconto)
                .ConfigureAwait(false);

            return _viewModel!;
        }
    }
}
