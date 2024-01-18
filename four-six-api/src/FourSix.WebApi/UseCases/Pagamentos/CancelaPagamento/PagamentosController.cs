using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Pagamentos.CancelaPagamento;
using FourSix.WebApi.Modules.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Pagamentos.CancelaPagamento
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Gerar, Efetuar e Cancelar Pagamento")]
    public class PagamentosController : Controller
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly ICancelaPagamentoUseCase _useCase;

        public PagamentosController(Notification notification,
            ICancelaPagamentoUseCase useCase)
        {
            _useCase = useCase;
            _notification = notification;
        }

        /// <summary>
        /// Cancela pagamento
        /// </summary>
        /// <param name="request">Dados do pagamento</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPut("cancelamentos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CancelaPagamentoResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CancelaPagamentoResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Update))]
        public async Task<IActionResult> Cancelar([FromBody] CancelaPagamentoRequest request)
        {
            await _useCase.Execute(request.PagamentoId)
                .ConfigureAwait(false);

            return _viewModel!;
        }
    }
}
