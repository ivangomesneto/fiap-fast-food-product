using FourSix.Application.Services;
using FourSix.Application.UseCases;
using FourSix.Application.UseCases.Pagamentos.CancelaPagamento;
using FourSix.Application.UseCases.Pagamentos.RealizaPagamento;
using FourSix.Domain.Entities.PagamentoAggregate;
using FourSix.WebApi.Modules.Commons;
using FourSix.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Pagamentos.RealizaPagamento
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Gerar, Efetuar e Cancelar Pagamento")]
    public class PagamentosController : Controller, IOutputPort<Pagamento>
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

        void IOutputPort<Pagamento>.Invalid()
        {
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(_notification.ModelState);
            _viewModel = BadRequest(problemDetails);
        }

        void IOutputPort<Pagamento>.NotFound() => _viewModel = NotFound();

        void IOutputPort<Pagamento>.Ok(Pagamento pagamento) =>
            _viewModel = Ok(new RealizaPagamentoResponse(new PagamentoModel(pagamento)));

        void IOutputPort<Pagamento>.Exist() => _viewModel = BadRequest("Pagamento já existe");

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
            _useCase.SetOutputPort(this);

            await _useCase.Execute(request.PagamentoId, request.ValorPago)
                .ConfigureAwait(false);

            return _viewModel!;
        }
    }
}
