using FourSix.Application.Services;
using FourSix.Application.UseCases;
using FourSix.Application.UseCases.Pagamentos.BuscaPagamento;
using FourSix.Application.UseCases.Pagamentos.CancelaPagamento;
using FourSix.Domain.Entities.PagamentoAggregate;
using FourSix.WebApi.Modules.Commons;
using FourSix.WebApi.UseCases.Pagamentos.ConsultaPagamento;
using FourSix.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Pagamentos.CancelaPagamento
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Gerar, Efetuar, Buscar e Cancelar Pagamento")]
    public class BuscaPagamentoController : Controller, IOutputPort<Pagamento>
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly IBuscaPagamentoUseCase _useCase;

        public BuscaPagamentoController(Notification notification,
            IBuscaPagamentoUseCase useCase)
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
            _viewModel = Ok(new ConsultaPagamentoResponse(new PagamentoModel(pagamento)));

        void IOutputPort<Pagamento>.Exist() => null;

        /// <summary>
        /// Cancela pagamento
        /// </summary>
        /// <param name="request">Dados do pagamento</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("busca")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CancelaPagamentoResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ConsultaPagamentoResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Update))]
        public async Task<IActionResult> Buscar([FromBody] ConsultaPagamentoRequest request)
        {
            _useCase.SetOutputPort(this);

            await _useCase.Execute(request.PagamentoId)
                .ConfigureAwait(false);

            return _viewModel!;
        }
    }
}
