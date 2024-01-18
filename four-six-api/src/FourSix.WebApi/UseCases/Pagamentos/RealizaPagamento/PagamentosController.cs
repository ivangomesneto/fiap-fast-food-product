using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Pagamentos.RealizaPagamento;
using FourSix.WebApi.Modules.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Pagamentos.RealizaPagamento
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Gerar, Efetuar e Cancelar Pagamento")]
    public class PagamentosController : Controller
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly IRealizaPagamentoUseCase _useCase;

        public PagamentosController(Notification notification,
            IRealizaPagamentoUseCase useCase)
        {
            _useCase = useCase;
            _notification = notification;
        }

        /// <summary>
        /// Efetiva pagamento pendente
        /// </summary>
        /// <param name="request">Dados do pagamento</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPut("efetivacoes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RealizaPagamentoResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RealizaPagamentoResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Update))]
        public async Task<IActionResult> Realizar([FromBody] RealizaPagamentoRequest request)
        {
            await _useCase.Execute(request.PagamentoId, request.ValorPago)
                .ConfigureAwait(false);

            return _viewModel!;
        }
    }
}
